#include "Logic.h"
#include <iostream>
#include <iomanip>
using namespace std;

#include <ctime> // to use C library function clock()

int Logic::addProd(string name,string cat,string man,int barcode,int qty,double price)	//return 1 if succesful in writing!, -1 if found
{
	if(list.getSize()!=0 && searchBarcode(1,barcode)==-1)
	{
		cout<<"Product Exists!"<<endl;
		return -1;
	}
	else
	{
		Product p(name, cat, man, barcode, 0, qty, price);
		list.addProduct(list.getSize(),p);
		return 1;
	}
}

int Logic::delProd(int index,int Sindex)
{
	if(!list.delProduct(index))
		return -1;
	else
	{
		list.delSearchPro(Sindex);			// GUI
		return 1;
	}
}

int Logic::specifySalesOfProducts(int qty,int index)
{
	if(!list.specifySales(index,qty))
		return -1;
	else
		return 1;
}
int Logic::changePrice(int index, double Cprice)
{
	return list.changePrice(index,Cprice);
}

int Logic::restockProduct(int qty,int index)
{
	if(!list.restock(index,qty))
		return -1;
	else
		return 1;
}
int Logic::readTrans(string fname)
{
	return list.readTransaction(fname);
}
int Logic::processBatch()
{
	return list.processBatch();
}

int Logic::saveFile(string name,int type)
{
	if(type==1)
		return writeFile(name+".csv",",");
	else 
		return writeFile(name+".txt","\n");
}

int Logic::readFile(string fname,char type,int& time)   
{
	return list.readFile(fname,type,time);
}
// this function is to write to the file according to parameter type
// if type == ';' , this function will write to excel file
// it type == ' ' , this function will write to text file
int Logic::writeFile(string sname,string type)
{
	 return list.writeFile(sname,type);
}
int Logic::searchName(int type,string search)
{
	return list.searchName(type,search);
}
int Logic::searchCat(string search)
{
	return list.searchCat(search);
}
int Logic::searchBarcode(int type,int search)
{
	return list.searchBarcode(type,search);
}
void Logic::getSearchPro(int& index,int i,int &barcode,double &price,int &curunit,int &unitsold)  //GUI search products
{
	 list.getSearchPro(index,i,barcode,price,curunit,unitsold);
}  
string Logic::getSearchName(int i)	//GUI to return name
{
	return list.getsearchName(i);
}
string Logic::getSearchCat(int i)	//GUI to return Category
{
	return list.getsearchCat(i);
}
string Logic::getSearchManu(int i)	//GUI to return Manufacturer
{
	return list.getsearchManu(i);
}
int Logic::getSize()				//GUI 
{
	return list.getSize();
}
void Logic::addSearchpro(int i)		//link C++ product with GUI search product
{
	Product p;
	list.getDetails(i,p);
	list.addSearchPro(i,p.getName(),p.getCat(),p.getManu(),p.getBarcode(),p.getUnitCur(),p.getUnitSold(),p.getPrice());	
}
string Logic::NumberToString(int Number)
{
	ostringstream ss;
	ss << Number;
	return ss.str();
 }
string Logic::NumberToString(double Number)
{
	ostringstream ss;
	ss << Number;
	return ss.str();
 }
string Logic::stringtoword(string str)
{
	string word;
	istringstream ss(str);
	ss>>word;
	return word;
}
void Logic::stringtoothers(string str,int& result)
{
	stringstream ss(str);
	ss>>result ? result: 0;
} 
/*best selling manufacturer*/
void Logic::callbestselling()
{
	list.getBestSellingManufacturer(manu,sales);
}
string Logic::bestsellingMan(int i,int &totalunitSold)
{
	totalunitSold = sales.at(i);
	return manu.at(i);
}
int Logic::getBSMnum()   // will pass the number of Best manufacturer to GUI
{
	return manu.size();
}
void Logic::clearSearch()
{
	list.ClearSearch();
}
int Logic::topNselling(int n)
{
	return list.topNselling(n);
}

/*to interact with C#*/
void* init()
{
	static Logic logdll;
	return (void*)&logdll;
}
int addProdC(void* those, char* name, char* cat, char* man, int barcode, int qty, double price)
{
	return(((Logic*)those)->addProd(name, cat, man,barcode, qty, price));
}
int delProdC(void* those ,int i,int Si)
{
	return ((Logic*)those)->delProd(i,Si);
}
int specifySalesOfProductsC(void* those,int type,int i)
{
	return ((Logic*)those)->specifySalesOfProducts(type,i);
}
int changepriceC(void* those,double Cprice,int i)
{
	return ((Logic*)those)->changePrice(i,Cprice);
}
int restockProductC(void* those,int type,int i)
{
	return ((Logic*)those)->restockProduct(type,i);
}
int loadFileC(void* those,char* name,int type,int &time)
{
	if(type == 1)
		return((Logic*)those)->readFile(name,',',time);
	else if(type==2)
		return((Logic*)those)->readFile(name,'\n',time);
	else
		return 0;
}
int saveFileC(void* those,char* name,int type)
{
	return ((Logic*)those)->saveFile(name,type);
}
int searchC(void* those,int type,char* search)
{
	
	if(type == 1)
		return ((Logic*)those)->searchName(2,search);
	else if(type == 2)
		return ((Logic*)those)->searchCat(search);
	else
	{
		int bar;
		((Logic*)those)->stringtoothers(search,bar);
		return ((Logic*)those)->searchBarcode(0,bar);
	}
}

void addSearchProC(void* those, int i)
{
	((Logic*)those)->addSearchpro(i);
}
void getSearchProC(void* those,int type,int &index,int i,int &barcode,double &price,int &curunit,int &unitsold)
{
	((Logic*)those)->getSearchPro(index,i,barcode,price,curunit,unitsold);
}
char* getSearchNameC(void* those,int i)
{
	string temp;
	temp = ((Logic*)those)->getSearchName(i);
	char *cstr = new char[temp.length()+1];
	strcpy(cstr,temp.c_str());
	return cstr;
}
char* getSearchCatC(void* those,int i)
{
	string temp;
	temp = ((Logic*)those)->getSearchCat(i);
	char *cstr = new char[temp.length()+1];
	strcpy(cstr,temp.c_str());
	return cstr;
}
char* getSearchManuC(void* those,int i)
{
	string temp;
	temp = ((Logic*)those)->getSearchManu(i);
	char *cstr = new char[temp.length()+1];
	strcpy(cstr,temp.c_str());
	return cstr;
}
int getSizeC(void* those)
{
	return ((Logic*)those)->getSize();
}
void clearSearchC(void* those)
{
	((Logic*)those)->clearSearch();
}
char* bestSellingManC(void* those, int i, int& sale)
{
	string temp;
	temp = ((Logic*)those)->bestsellingMan(i,sale);
	char *cstr=  new char[temp.length()+1];
	strcpy(cstr,temp.c_str());
	return cstr;
}
int getBSWsizeC(void* those)
{
	return ((Logic*)those)->getBSMnum();
}
void callbestSellingC(void* those)
{
	((Logic*)those)->callbestselling();
}
int readTransC(void* those,char* name)
{
	return ((Logic*)those)->readTrans(name);
}
int processBatchC(void* those)
{
	return ((Logic*)those)->processBatch();
}
int topNsellingC(void* those,int n)
{
	return ((Logic*)those)->topNselling(n);
}