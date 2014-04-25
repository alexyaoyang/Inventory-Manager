#include "Product.h"

#ifndef DLIST_H
#define DLIST_H

#include <iostream>
using namespace std;
#include <iostream>//delete after GUI implemented
#include <iomanip>//delete after GUI implemented

class DList
{
private:
	struct ListNode
	{
		Product pro;
		ListNode *prev;
		ListNode *next;
	};
	int size;
	ListNode *head;
	ListNode *tail;
public:
	DList();
	~DList();
	void at(int,ListNode*&);
	void addProduct(int index, Product& p);
	bool delProduct(int);
	int getSize();
	void print();
	void printLast();
	bool specifySales(int, int); 
	void swap(Product&,Product&);
	bool restock(int, int); 
	
	//void getDetails(string& name, string& cat, string& manu, string& exp, int& code,  int& unitCur, int& unitSold, double& price, double& disc, int index);
	void getDetails(int index,Product& p);
	string getName(int);
	string getCat(int);
	int getBarcode(int);
	int getUnitSold(int i);
	
};

#endif
