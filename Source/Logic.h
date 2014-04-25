#ifndef _LOGIC_H
#define _LOGIC_H

#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include "DataStorage.h"
#include "SList.h"

using namespace std;


extern  "C"
{
	__declspec(dllexport)
	int addProdC(void* those, char* name, char* cat, char* man, int barcode, int qty, double price);
	__declspec(dllexport)
	int delProdC(void* those ,int i,int Si);
	__declspec(dllexport)
	int specifySalesOfProductsC(void* those,int type,int i);
	__declspec(dllexport)
	int restockProductC(void* those,int type,int i);
	__declspec(dllexport)
	int loadFileC(void* those,char* name,int type,int &time);
	__declspec(dllexport)
	int saveFileC(void* those,char* name,int type);
	__declspec(dllexport)
	void* init();
	__declspec(dllexport)
	int searchC(void* those,int type,char* search);
	__declspec(dllexport)
    void getSearchProC(void* those,int type,int &index,int i,int &barcode,double &price,int &curunit,int &unitsold);
	__declspec(dllexport)
	int getSizeC(void* those);
	__declspec(dllexport)
	void addSearchProC(void* those, int i);
	__declspec(dllexport)
	void clearSearchC(void* those);
	__declspec(dllexport)
	char* getSearchNameC(void* those,int i);
	__declspec(dllexport)
	char* getSearchCatC(void* those,int i);
	__declspec(dllexport)
	char* getSearchManuC(void* those,int i);
	__declspec(dllexport)
	char* bestSellingManC(void* those, int i, int& sale);
	__declspec(dllexport)
	int getBSWsizeC(void* those);
	__declspec(dllexport)
	void callbestSellingC(void* those);
	__declspec(dllexport)
	int readTransC(void* those,char* name);
	__declspec(dllexport)
	int processBatchC(void* those);
	__declspec(dllexport)
	int topNsellingC(void* those,int n);
	__declspec(dllexport)
	int changepriceC(void* those,double Cprice,int i);
}

class Logic
{
private:
	string _name,_cat,_man;
	int _unitsold,_curunit,_barcode,_qty;
	double _price,_dis;
	int _totalnum;

	/*to switch between vector and Slit*/
	//DataStorage list;
	SList list;

	
	string NumberToString (int Number);
	string NumberToString(double Number);

	vector<string> manu;
	vector<int> sales;

public:
	Logic(){}

	int addProd(string name,string cat,string man,int barcode,int qty,double price);
    int delProd(int,int);
	int specifySalesOfProducts(int,int); 
	int restockProduct(int,int);
	int changePrice(int,double); 
	void loadFile();
	int writeFile(string sname,string type);
	int saveFile(string name,int type);
	int readFile(string,char,int&);
	string stringtoword(string str);
	void stringtoothers(string str,int&);
	int getSize();
	int searchName(int type,string search);
	int searchCat(string search);
	int searchBarcode(int type,int search);
	void clearSearch();
	void addSearchpro(int i);
	void getSearchPro(int& index,int i,int &barcode,double &price,int &curunit,int &unitsold);
	string getSearchName(int i);
	string getSearchCat(int i);
	string getSearchManu(int i);
	string bestsellingMan(int i,int &totalunitSold);
	int getBSMnum();
	void callbestselling();
	int readTrans(string fname);
	int processBatch();
	int topNselling(int n);
};


#endif
