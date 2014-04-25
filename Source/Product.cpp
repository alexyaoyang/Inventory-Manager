#include "Product.h"

Product::Product(string name, string cat, string manu,  int barcode, int unitSold, int unitCur, double price)
{
	_name = name;
	_category = cat;
	_manufacturer = manu;
	_barcode = barcode;
	_unitSold = unitSold;
	_unitCur = unitCur;
	_price = price;	
}

//accessors and mutators
string Product::getName()
{
	return _name;
}

void Product::setName(string name)
{
	_name = name;
}

string Product::getCat()
{
	return _category;
}

void Product::setCat(string cat)
{
	_category = cat;
}

string Product::getManu()
{
	return _manufacturer;
}

void Product::setManu(string manu)
{
	_manufacturer = manu;
}

int Product::getBarcode()
{
	return _barcode;
}

void Product::setBarcode(int barcode)
{
	_barcode = barcode;
}

int Product::getUnitSold()
{
	return _unitSold;
}

void Product::setUnitSold(int unitSold)
{
	_unitSold = unitSold;
}

int Product::getUnitCur()
{
	return _unitCur;
}

void Product::setUnitCur(int unitCur)
{
	_unitCur = unitCur;
}

double Product::getPrice()
{
	return _price;
}

void Product::setPrice(double price)
{
	_price = price;
}


