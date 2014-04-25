#include "Product.h"

#ifndef SLIST_H
#define SLIST_H

using namespace std;
#include <fstream>
#include <sstream>
#include <vector>
#include <ctime> 
#include <iostream>
#include <stack>
#include <queue>

class SList
{
private:
	struct ListNode
	{
		Product pro;
		ListNode *next;
	};
	struct Search
	{
		Product data;
		int index;
	};
	int size;
	ListNode *head;
	ListNode *tail;
	string _name,_cat,_man,temp,transID,job;
	int _unitsold,_curunit,_barcode,_qty,numT,numJobs;
	double _price;
	void at(int,ListNode*&,ListNode*&);
	ListNode *cur;
	ListNode *prev;
	
	vector<Search> _searchList;
	queue<queue<string>> storeTrans;
	stack<queue<string>> batchPro;
	queue<string> errorLog;
	
	void stringtoothers(string str,double& result);
	void stringtoothers(string str,int&);


public:
	SList();
	~SList();
	void addProduct(int index, Product& p);
	bool delProduct(int);
	int getSize();
	bool specifySales(int, int); 
	void swap(Product&,Product&);
	bool restock(int, int); 
	int changePrice(int,double);
	void getDetails(int index,Product& p);
	int readFile(string fname,char type,int& time);
	int writeFile(string sname,string type);
	int searchName(int type,string search);
	int searchCat(string search);
	int searchBarcode(int type,int search);
	void addSearchPro(int index,string name, string cat, string manu, int code, int unitCur, int unitSold, double price);
	void getSearchPro(int &index,int i,int &barcode,double &price,int &curunit,int &unitsold);
	void delSearchPro(int i);
	void ClearSearch();

	string getsearchName(int i);
	string getsearchCat(int i);
	string getsearchManu(int i);

	void getBestSellingManufacturer(vector<string> &topManuName, vector<int> &topManuSold); 
	ListNode* MergeSort(ListNode *my_node);
	ListNode* Merge(ListNode* firstNode, ListNode* secondNode);
	int readTransaction(string fname);
	void writeTransaction();
	bool storeExistingBatch(int);
	int processBatch();
	void writeErrorLog();

	int topNselling(int n);

};

#endif
