#include "DataStorage.h"

void DataStorage::addProduct(int index,Product& p)	//add new product
{
	_productList.insert(_productList.begin()+index,p);
}
bool DataStorage::delProduct(int index)		// delete a product
{
	if(index<0||index>=(int)_productList.size())
		return false;
	_productList.erase(_productList.begin()+index);
	return true;
}
bool DataStorage::specifySales(int index, int qty)		// specify sales
{
		if(index<0||index>=(int)_productList.size())
			return false;
		if(qty <=0 || (qty > _productList.at(index).getUnitCur()))
			return false;
		
		_productList.at(index).setUnitCur(_productList.at(index).getUnitCur() - qty);
		_productList.at(index).setUnitSold(_productList.at(index).getUnitSold() + qty);

		for(int i=0;i<index;i++)
		{
			if(_productList.at(index-i).getUnitSold()>_productList.at(index-i-1).getUnitSold())
				swap(_productList.at(index-i),_productList.at(index-i-1));
		}
		return true;
}
int DataStorage::changePrice(int index, double Cprice)	// change price
{
	if(index<0||index>=(int)_productList.size())
		return 0;
	
	_productList.at(index).setPrice(Cprice);	
	return 1;
}

bool DataStorage::restock(int index, int qty)		// restock the product
{
		if(index<0||index>=(int)_productList.size() || qty <= 0)
			return false;
		
		_productList.at(index).setUnitCur(_productList.at(index).getUnitCur() + qty);
		return true;
}
int DataStorage::getSize()
{
	return _productList.size();
}
// Retrieving the information of product[i] by passing by reference
//void DataStorage::getDetails(string& name, string& cat, string& manu, string& exp, int& code, int& unitCur,int& unitSold, double& price, double& disc, int index)
void DataStorage::getDetails(int index,Product& p)
{
	p=_productList.at(index);	
}
int DataStorage::readFile(string fname,char type, int &time)	// to read from .csv or .txt file
{
	ifstream readfile(fname);
	string temp;
	int num;
	if(readfile.good())
	{
		getline(readfile,temp);
		stringtoothers(temp,num);
		if(type == ',')
		{
			getline(readfile,temp,'\n');
			getline(readfile,temp,'\n');
		}
		int start, end;
			start = clock(); // record starting time

		while(num>0)
		{
			num--;
			if(type!=',')
			getline(readfile,temp,'\n');
			getline(readfile,_name,type);
			getline(readfile,_cat,type);
			getline(readfile,temp,type);
			stringtoothers(temp,_barcode);
			getline(readfile,temp,type);
			stringtoothers(temp,_price);
			getline(readfile,_man,type);
			getline(readfile,temp,type);
			stringtoothers(temp,_curunit);

			getline(readfile,temp,'\n');
			stringtoothers(temp,_unitsold);
			if(type == ',')
			{
				_cat = _cat.substr(0,_cat.length()-1);
				_cat = _cat.substr(1,_cat.length());
				_name = _name.substr(0,_name.length()-1);
				_name = _name.substr(1,_name.length());
				_man  = _man.substr(0,_man.length()-1);
				_man = _man.substr(1,_man.length());
			}
			if(!searchBarcode(1,_barcode))		// for checking duplicated barcode
			{
				Product p(_name,_cat,_man,_barcode,_unitsold,_curunit,_price);
				addProduct(getSize(),p);
			}
		}

		readfile.close();
		_productList=merge_sort(_productList);		// sort the product according to unit sold
		end = clock(); // record ending time
		time = end - start;
		return 1;
	}
	else
	{
		readfile.close();
		return -1;
	}
}
int DataStorage::writeFile(string sname,string type)	// save the file either in .csv or .txt file
{
	ofstream writefile(sname);
	writefile<<getSize()<<endl<<endl;
	if(type == ",")
	writefile<<"Name"<<type<<"Cat"<<type<<"barcode"<<type<<"price"<<type<<"manufacture"<<type<<"unitcur"<<type<<"unitsold"<<endl;
	string tmpcat,tmpname,tmpman;
	char d = '"';
	for(int i=0; i<getSize(); i++)
	{
		if(type == ",")
		{
			tmpcat = d + _productList.at(i).getCat() +d;
			tmpname =d+ _productList.at(i).getName()+d;
			tmpman = d+_productList.at(i).getManu()+d;
		}
		else
		{
			tmpcat =  _productList.at(i).getCat() ;
			tmpname =_productList.at(i).getName();
			tmpman = _productList.at(i).getManu();
		}
	
		writefile<<tmpname<<type;
		writefile<<tmpcat<<type;
		writefile<<_productList.at(i).getBarcode()<<type;
		writefile<<_productList.at(i).getPrice()<<type;
		writefile<<tmpman<<type;
		writefile<<_productList.at(i).getUnitCur()<<type;
		writefile<<_productList.at(i).getUnitSold()<<type;

		writefile<<'\n';
	}
	writefile.close();
	return 1;
}
void DataStorage::swap(Product &back,Product &front)
{
	Product p = back;
	back=front;
	front=p;
}
vector<Product> DataStorage::merge_sort(vector<Product>& vec)
{
    // Termination condition: List is completely sorted if it
    // only contains a single element.
    if(vec.size() == 1)
    {
        return vec;
    }
 
    // Determine the location of the middle element in the vector
    std::vector<Product>::iterator middle = vec.begin() + (vec.size() / 2);
 
    vector<Product> left(vec.begin(), middle);
    vector<Product> right(middle, vec.end());
 
    // Perform a merge sort on the two smaller vectors
    left = merge_sort(left);
    right = merge_sort(right);
 
    return merge(left, right);
}

vector<Product> DataStorage::merge(vector<Product>& left, vector<Product>& right)
{
    // Fill the resultant vector with sorted results from both vectors
    vector<Product> result;
    unsigned left_it = 0, right_it = 0;
 
    while(left_it < left.size() && right_it < right.size())
    {
		if(left[left_it].getUnitSold() > right[right_it].getUnitSold())
        {
            result.push_back(left[left_it]);
            left_it++;
        }
        else
        {
            result.push_back(right[right_it]);
            right_it++;
        }
    }
 
    // Push the remaining data from both vectors onto the resultant
    while(left_it < left.size())
    {
        result.push_back(left[left_it]);
        left_it++;
    }
 
    while(right_it < right.size())
    {
        result.push_back(right[right_it]);
        right_it++;
    }
 
    return result;
}
void DataStorage::stringtoothers(string str,double& result)
{
	stringstream ss(str);
	ss>>result ? result: 0;
}
void DataStorage::stringtoothers(string str,int& result)
{
	stringstream ss(str);
	ss>>result ? result: 0;
}
int DataStorage::searchName(int type,string search)			// search the product by name
{
	int count= 0;
	for (int i = 0; i < (int)search.size(); i++)
	{
		search[i] = (char)tolower(search[i]);
	}
	if(type == 1)
	{
		for(int i = 0; i < getSize(); i++)
		{
			string	temp = _productList.at(i).getName(); 
			for (int j = 0; j < (int)temp.size(); j++)
			{
				temp[j] = (char)tolower(temp[j]);
			}
			if(temp == search)
			{
				return -1;
			}
		}
		return 2;
	}
	for(int i=0; i<getSize(); i++)
	{
		string	temp = _productList.at(i).getName();
			for (int j = 0; j < (int)temp.size(); j++)
			{
				temp[j] = (char)tolower(temp[j]);
			}
			if(temp == search || temp.find(search)!=-1)
			{
				count++;
				addSearchPro(i,_productList.at(i).getName(),_productList.at(i).getCat(),_productList.at(i).getManu(),_productList.at(i).getBarcode(),_productList.at(i).getUnitCur(),_productList.at(i).getUnitSold(),_productList.at(i).getPrice());		// to store searched product from GUI 
			}
	}
	return count;
}
int DataStorage::searchCat(string search)	// search the product by category
{
	int count=0;
	for (int i = 0; i < (int)search.size(); i++)
	{
		search[i] = (char)tolower(search[i]);
	}
	for(int i=0; i<getSize(); i++)
	{
		string	temp = _productList.at(i).getCat();
			for (int j = 0; j < (int)temp.size(); j++)
			{
				temp[j] = (char)tolower(temp[j]);
			}
			if(temp == search || temp.find(search)!=-1)
			{
				count++;
				addSearchPro(i,_productList.at(i).getName(),_productList.at(i).getCat(),_productList.at(i).getManu(),_productList.at(i).getBarcode(),_productList.at(i).getUnitCur(),_productList.at(i).getUnitSold(),_productList.at(i).getPrice());	 // to store resulted search product from GUI 
			}
	}
	return count;
}
int DataStorage::searchBarcode(int type,int search)  // search by barcode
{
	int count=0;
	if(type == 1)
	{
		for(int i=0;i<getSize();i++)
		{
				if(_productList.at(i).getBarcode() == search)
				{
					return -1;
				}
		}
		return 0;
	}
	for(int i=0; i<getSize(); i++)
	{
			if(_productList.at(i).getBarcode() == search)
			{
				count++;
				addSearchPro(i,_productList.at(i).getName(),_productList.at(i).getCat(),_productList.at(i).getManu(),_productList.at(i).getBarcode(),_productList.at(i).getUnitCur(),_productList.at(i).getUnitSold(),_productList.at(i).getPrice());	
			}
	}
	return count;
}

void DataStorage::getSearchPro(int &index,int i,int &barcode,double &price,int &curunit,int &unitsold) //for gui to get properties of resulted search product
{
	index = _searchList.at(i).index;
	barcode = _searchList.at(i).data.getBarcode();
	price = _searchList.at(i).data.getPrice();
	curunit = _searchList.at(i).data.getUnitCur();
	unitsold = _searchList.at(i).data.getUnitSold();
}
void DataStorage::delSearchPro(int i)
{
	_searchList.erase(_searchList.begin()+i);
}
void DataStorage::addSearchPro(int index,string name, string cat, string manu, int code, int unitCur, int unitSold, double price)	// add resulted search product
{
	Search temp;
	temp.data.setName(name);
	temp.data.setCat(cat);
	temp.data.setManu(manu);
	temp.data.setBarcode(code);
	temp.data.setUnitCur(unitCur);
	temp.data.setUnitSold(unitSold);
	temp.data.setPrice(price);
	temp.index = index;
	_searchList.push_back(temp);
}
void DataStorage::ClearSearch()
{
	while(!_searchList.empty())
	{
		_searchList.pop_back();
	}
}
string DataStorage::getsearchName(int index)	
{
	return _searchList.at(index).data.getName();
}
string DataStorage::getsearchCat(int index)
{
	return _searchList.at(index).data.getCat();
}
string DataStorage::getsearchManu(int index)
{
	return _searchList.at(index).data.getManu();
}
void DataStorage::getBestSellingManufacturer(vector<string> &topManuName, vector<int> &topManuSold) //return first occurrence of Manufacturer found.
{
	vector<string> manuList;
	vector<int> saleList;
	int max,found;
	while(!topManuName.empty())
		topManuName.pop_back();

	while(!topManuSold.empty())
		topManuSold.pop_back();
	for(int j=0;j<(int)_productList.size();j++)
	{
		if(manuList.size()==0&&saleList.size()==0)
		{
			manuList.push_back(_productList.at(0).getManu());
			saleList.push_back(_productList.at(0).getUnitSold());
		}
		else
		{
			found=0;
			for(int i=0;i<(int)manuList.size();i++)
				if(manuList.at(i)==_productList.at(j).getManu())
				{
					saleList.at(i)+=_productList.at(j).getUnitSold();
					found=1;
				}
			if(found==0)
			{
				manuList.push_back(_productList.at(j).getManu());
				saleList.push_back(_productList.at(j).getUnitSold());
			}
		}
	}
	max=saleList.at(0);
	for (int i=1;i<(int)saleList.size();i++)
		if(max<saleList.at(i))
			max=saleList.at(i);
	for (int i=0;i<(int)saleList.size();i++)
		if(saleList.at(i)==max)
		{
			cout<<"adding into top "<<manuList.at(i)<<" "<<saleList.at(i)<<endl;
			topManuName.push_back(manuList.at(i));
			topManuSold.push_back(saleList.at(i));
		}
}

int DataStorage::readTransaction(string fname)
{
	ifstream readTransaction(fname);
	if(readTransaction.good())
	{
		queue<string> trans;
		getline(readTransaction,temp); //transaction ID
		trans.push(temp);
		getline(readTransaction,temp); //num jobs
		trans.push(temp);
		stringtoothers(temp,numJobs);
		getline(readTransaction,temp);
		while(numJobs>0)
		{
			numJobs--;
			getline(readTransaction,job); //what job it is
			trans.push(job);
			getline(readTransaction,temp); //since all jobs have at least one line, take in one line first.
			trans.push(temp);
			if(!job.compare("SALE")||!job.compare("RESTOCK"))
			{
				getline(readTransaction,temp);
				trans.push(temp);
			}
			else if(!job.compare("ADD"))
			{
				for(int i=0;i<5;i++)
				{
					getline(readTransaction,temp);
					trans.push(temp);
				}
			}
			getline(readTransaction,temp);
		}
		storeTrans.push(trans);
	
	readTransaction.close();
	storeExistingBatch(0); //need to copy out from existing file
	numT++;
	writeTransaction();
	return 1;
	}
	else
	{
		readTransaction.close();
		return 0;
	}
}
bool DataStorage::storeExistingBatch(int type)
{
	ifstream storeExistingBatch("batchjobs.txt");
	if(storeExistingBatch.good())
	{
		getline(storeExistingBatch,temp); //num Transactions
		stringtoothers(temp,numT);
		int countT=numT;
		getline(storeExistingBatch,temp);
		while(countT>0)
		{
			queue<string> trans;
			countT--;

			getline(storeExistingBatch,temp); //transaction ID
			trans.push(temp);
			getline(storeExistingBatch,temp); //num jobs
			trans.push(temp);
			stringtoothers(temp,numJobs);
			getline(storeExistingBatch,temp);
			while(numJobs>0)
			{
				numJobs--;
				getline(storeExistingBatch,job); //what job it is
				trans.push(job);
				getline(storeExistingBatch,temp); //since all jobs have at least one line, take in one line first.
				trans.push(temp);
				if(!job.compare("SALE")||!job.compare("RESTOCK"))
				{
					getline(storeExistingBatch,temp);
					trans.push(temp);
				}
				else if(!job.compare("ADD"))
				{
					for(int i=0;i<5;i++)
					{
						getline(storeExistingBatch,temp);
						trans.push(temp);
					}
				}
				getline(storeExistingBatch,temp);
			}
			if(!type)
				storeTrans.push(trans);
			else
				batchPro.push(trans);
		}
		return true;
	}
	return false;
}
void DataStorage::writeTransaction()
{
	ofstream writeTransaction("batchjobs.txt");

	writeTransaction<<numT<<endl<<endl;
	int countT=numT;
	while(countT>0)
	{
		countT--;
		writeTransaction<<storeTrans.front().front()<<endl; //transaction ID
		storeTrans.front().pop();
		stringtoothers(storeTrans.front().front(),numJobs);
		writeTransaction<<storeTrans.front().front()<<endl<<endl; //num jobs
		storeTrans.front().pop();
		while(numJobs>0)
		{
			numJobs--;
			job=storeTrans.front().front();
			writeTransaction<<storeTrans.front().front()<<endl;//what job it is
			storeTrans.front().pop();
			writeTransaction<<storeTrans.front().front()<<endl; //since all jobs have at least one line, write out one line first.
			storeTrans.front().pop();
			if(!job.compare("SALE")||!job.compare("RESTOCK"))
			{
				writeTransaction<<storeTrans.front().front()<<endl;
				storeTrans.front().pop();
			}
			else if(!job.compare("ADD"))
			{
				for(int i=0;i<5;i++)
				{
					writeTransaction<<storeTrans.front().front()<<endl;
					storeTrans.front().pop();
				}
			}
			writeTransaction<<endl;
		}
		storeTrans.pop();
	}
	writeTransaction.close();
}
void DataStorage::writeErrorLog()
{
	ofstream writeErrorLog("log.txt");

	while(!errorLog.empty())
	{
		for(int i=0;i<3;i++)
		{
			writeErrorLog<<errorLog.front()<<" ";
			errorLog.pop();
		}
		writeErrorLog<<endl;
	}
	writeErrorLog.close();
}
int DataStorage::processBatch()
{
	if(storeExistingBatch(1))
	{
		string job;
		int error=0;
		int countT=(int)batchPro.size();
		for(int i=0;i<countT;i++)
		{
			transID=batchPro.top().front();
			batchPro.top().pop();
			stringtoothers(batchPro.top().front(),numJobs);
			batchPro.top().pop();
			for(int j=0;j<numJobs;j++)
			{
				job=batchPro.top().front(); //what job it is
				batchPro.top().pop();
				if(!job.compare("DELETE")||!job.compare("SALE")||!job.compare("RESTOCK"))
				{
					temp=batchPro.top().front();
					stringtoothers(temp,_barcode);
					batchPro.top().pop();
					if(!job.compare("DELETE"))
					{
						int ind=searchBarcode(1,_barcode);
						if(ind)
							delProduct(ind);
						else
							error=1;
					}
					else if(!job.compare("SALE"))
					{
						stringtoothers(batchPro.top().front(),_qty);
						batchPro.top().pop();
						int ind=searchBarcode(1,_barcode);
						if(ind)
							if(!specifySales(ind,_qty))
								error=1;
					}
					else if(!job.compare("RESTOCK"))
					{
						stringtoothers(batchPro.top().front(),_qty);
						batchPro.top().pop();
						int ind=searchBarcode(1,_barcode);
						if(ind)
							restock(ind,_qty);
						else
							error=1;
					}
				}
				else if(!job.compare("ADD"))
				{
					_name=batchPro.top().front();
					batchPro.top().pop();
					_cat=batchPro.top().front();
					batchPro.top().pop();
					temp=batchPro.top().front();
					stringtoothers(temp,_barcode);

					if(!searchBarcode(1,_barcode))
					{
						batchPro.top().pop();
						stringtoothers(batchPro.top().front(),_price);
						batchPro.top().pop();
						_man=batchPro.top().front();
						batchPro.top().pop();
						stringtoothers(batchPro.top().front(),_curunit);
						batchPro.top().pop();

						Product p(_name,_cat,_man,_barcode,0,_curunit,_price);
						addProduct(_productList.size(),p);
					}
					else
						error=1;
				}
				if(error)
				{
					errorLog.push(transID);
					errorLog.push(job);
					errorLog.push(temp);
					error=0;
				}
			}
			batchPro.pop();
		}
		if(!errorLog.empty())
		{
			writeErrorLog();//cout<<"Some errors occured, please check log.txt file!"<<endl;	 // 
			return 1;
		}
		return 2;//cout<<"Batch Processed!"<<endl;
	}
	else
		return 3; // cout<<"Please add some transactions!"<<endl;
}

int DataStorage::topNselling(int n)
{
	int count =0,rcount=0;
	while(!_searchList.empty())
	{
		_searchList.pop_back();
	}
	addSearchPro(0,_productList.at(0).getName(),_productList.at(0).getCat(),_productList.at(0).getManu(),_productList.at(0).getBarcode(),_productList.at(0).getUnitCur(),_productList.at(0).getUnitSold(),_productList.at(0).getPrice());	
	for(int i=1; i<_productList.size(); i++)
	{
		if(_productList.at(i-1).getUnitSold() != _productList.at(i).getUnitSold())
			count++;
		
		if(count == n)
			return i;
		addSearchPro(i,_productList.at(i).getName(),_productList.at(i).getCat(),_productList.at(i).getManu(),_productList.at(i).getBarcode(),_productList.at(i).getUnitCur(),_productList.at(i).getUnitSold(),_productList.at(i).getPrice());	
	}
	return rcount;
}
