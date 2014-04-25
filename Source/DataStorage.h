#ifndef _DATASTORAGE_H_
#define _DATASTORAGE_H_

#include <vector>
#include "Product.h"
#include <iostream>
#include <iomanip>
#include <sstream>
#include <fstream>
#include <stack>
#include <queue>

using namespace std;

class DataStorage
{
	private:
		vector<Product> _productList;
		struct Search
		{
			Product data;
			int index;
		};
		
		string _name,_cat,_man,temp,transID,job;
		int _unitsold,_curunit,_barcode,_qty,numT,numJobs;
		double _price;
		vector<Search> _searchList;
		queue<queue<string>> storeTrans;
		stack<queue<string>> batchPro;
		queue<string> errorLog;
		void stringtoothers(string str,double& result);
		void stringtoothers(string str,int&);

	public:
		DataStorage(){}
		void addProduct(int index,Product& p);
		bool delProduct(int);
		int  getSize();
		void getDetails(int index,Product& p);
		bool specifySales(int, int); 
		bool restock(int, int); 
		void swap(Product &back,Product &front);
		int changePrice(int,double);
		int readFile(string fname,char type,int &time);
		int writeFile(string sname,string type);
		int searchName(int type,string search);
		int searchCat(string search);
		int searchBarcode(int type,int search);
		void getSearchPro(int &index,int i,int &barcode,double &price,int &curunit,int &unitsold);
		void delSearchPro(int i);
		void addSearchPro(int index,string name, string cat, string manu, int code, int unitCur, int unitSold, double price);
		void ClearSearch();
		string getsearchName(int i);
		string getsearchCat(int i);
		string getsearchManu(int i);
		void getBestSellingManufacturer(vector<string> &topManuName, vector<int> &topManuSold);
		int readTransaction(string fname);
		void writeTransaction();
		bool storeExistingBatch(int);
		int processBatch();
		void writeErrorLog();
		vector<Product> merge_sort(vector<Product>& vec);
		vector<Product> merge(vector<Product>& left, vector<Product>& right);
		int topNselling(int n);
};

#endif