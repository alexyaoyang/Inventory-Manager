#ifndef _PRODUCT_H_
#define _PRODUCT_H_

#include <string>
using namespace std;

class Product
{
private:
	string _name, _category, _manufacturer;
	int _barcode, _unitSold, _unitCur;
	double _price;

public:
	Product(){};
	//parametrised constructor
	Product(string name, string cat, string manu,  int barcode, int unitSold, int unitCur, double price);
	string getName();
	void setName(string);
	string getCat();
	void setCat(string);
	string getManu();
	void setManu(string);
	int getBarcode();
	void setBarcode(int);
	int getUnitSold();
	void setUnitSold(int);
	int getUnitCur();
	void setUnitCur(int);
	double getPrice();
	void setPrice(double);

};

#endif