#include <iostream>
#include "Logic.h"
using namespace std;

int main()
{
	Logic logic;
	int choice=0;
	while(choice!=11)
	{
		cout<<endl<<"1. Add new product"<<endl;
		cout<<"2. Delete a product"<<endl;
		cout<<"3. Specify sale of product"<<endl;
		cout<<"4. Restock product"<<endl;
		cout<<"5. Search products by name"<<endl;
		cout<<"6. Search products by barcode"<<endl;
		cout<<"7. Search products by category"<<endl;
		cout<<"8. Load products from file"<<endl;
		cout<<"9. Save products to file"<<endl;
		cout<<"10. Print all current products"<<endl;
		cout<<"11. Quit"<<endl;
		cout<<"Enter choice: ";
		cin>>choice;
		cout<<endl;

		switch (choice)
		{
		case 1:
		//	logic.addProd();
			break;
		case 2:
			logic.listOrSearch(choice);
			break;
		case 3:
			logic.listOrSearch(choice);
			break;
		case 4:
			logic.listOrSearch(choice);
			break;
		case 5:
			logic.searchName(0,"");
			break;
		case 6:
			logic.searchBarcode(0,-1);
			break;
		case 7:
			logic.searchCat(0);
			break;
		case 8:
			logic.loadFile();
			break;
		case 9:
			logic.saveFile();
			break;
		case 10:
			logic.printAll();
			break;
		}
	}
	system("pause");
	return 0;
}