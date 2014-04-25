#include "DList.h"

DList::DList()
{
	head=NULL;
	tail=NULL;
	size=0;
}
DList::~DList()
{
	while(size!=0)
	{
		ListNode *rm=head;
		head=head->next;
		delete rm;
		size--;
	}
}
void DList::at(int index,ListNode* &cur)
{
	if(size==index)
		cur=NULL;
	else if(index<=size/2)
	{
		cur=head;
		for(int i=0;i<index;i++)
			cur=cur->next;
	}
	else
	{
		cur=tail;
		for(int i=1;i<(size-index);i++)
			cur=cur->prev;
	}
}
void DList::addProduct(int index,Product &p)
{
	ListNode *ptr=new ListNode;
	ptr->pro=p;
	ptr->next=NULL;
	ptr->prev=NULL;
	if(size==0)
	{
		head=ptr;
		tail=ptr;
		ptr->prev=NULL;
		ptr->next=NULL;
	}
	else
	{
		if(size>1&&p.getBarcode()==1)
			ptr->pro.setBarcode(tail->pro.getBarcode()+1);
		if(index==0)
		{
			head->prev=ptr;
			ptr->next=head;
			head=head->prev;
			return;
		}
		ListNode *cur=NULL;
		at(index,cur);

		if(cur==NULL)
		{
			cur=tail;
			ptr->prev=cur;
			cur->next=ptr;
			tail=tail->next;
		}
		else
		{
			ptr->next=cur;
			ptr->prev=cur->prev;

			cur->prev->next=ptr;
			cur->prev=ptr;
		}		
	}
	size++;
}
int DList::getSize()
{
	return size;
}
void DList::print()
{
	if(size==0)
	{
		cout<<"No products! Please add or load some products."<<endl;
		return;
	}
	ListNode *cur=head;
	cout<<setfill('-')<<setw(140)<<"-"<<endl<<setfill(' ');
	cout<<left<<setw(50)<<"|Name"<<setw(6)<<"  |Barcode"<<setw(20)<<"|Category"<<setw(22)<<" |Manufacturer"<<setw(7)<<"|Price"<<setw(7)<<"|Stock"<<setw(10)<<"|Sold  |"<<endl;
	while(cur!=NULL)
	{
		cout<<setfill(' ')<<fixed<<setprecision(2)<<"|"<<left<<setw(50)<<cur->pro.getName()<<" |"<<right<<setfill('0')<<setw(6)<<cur->pro.getBarcode()<<" |"<<left<<setfill(' ')<<left<<setw(20)<<cur->pro.getCat()<<"|"<<left<<setw(20)<<cur->pro.getManu()<<"|$"<<left<<setw(5)<<cur->pro.getPrice()<<left<<"|"<<setw(6)<<cur->pro.getUnitCur()<<"|"<<setw(6)<<cur->pro.getUnitSold()<<"|"<<endl;
		cur=cur->next;
	}
	cout<<setfill('-')<<setw(140)<<"-"<<endl;
}
void DList::printLast()
{
	cout<<setfill('-')<<setw(140)<<"-"<<endl<<setfill(' ');
	cout<<left<<setw(50)<<"|Name"<<setw(6)<<"  |Barcode"<<setw(20)<<"|Category"<<setw(22)<<" |Manufacturer"<<setw(7)<<"|Price"<<setw(6)<<"|Discount"<<setw(6)<<"|Expiry"<<setw(7)<<"|Stock"<<setw(10)<<"|Sold  |"<<endl;
	cout<<setfill(' ')<<fixed<<setprecision(2)<<"|"<<left<<setw(50)<<tail->pro.getName()<<" |"<<right<<setfill('0')<<setw(6)<<tail->pro.getBarcode()<<" |"<<left<<setfill(' ')<<left<<setw(20)<<tail->pro.getCat()<<"|"<<left<<setw(20)<<tail->pro.getManu()<<"|$"<<left<<setw(5)<<tail->pro.getPrice()<<"|"<<left<<setw(6)<<tail->pro.getUnitCur()<<"|"<<setw(6)<<tail->pro.getUnitSold()<<"|"<<endl;
	cout<<setfill('-')<<setw(140)<<"-"<<endl;
}
bool DList::delProduct(int index)
{
	if(index<0||index>=size)
		return false;
	ListNode *cur=NULL;
	at(index,cur);

	if(cur==tail)
		cur->prev->next=NULL;
	else if(cur==head)
		cur->next->prev=NULL;
	else
	{
		cur->prev->next=cur->next;
		cur->next->prev=cur->prev;
	}
	tail=tail->prev;
	delete cur;
	size--;
	return true;
}

bool DList::specifySales(int index, int qty)
{
	if(index<0||index>=size)
		return false;
	ListNode *cur=NULL;
	at(index,cur);
	if(qty <=0 || (qty > cur->pro.getUnitCur()))
		return false;

	cur->pro.setUnitCur(cur->pro.getUnitCur() - qty);
	cur->pro.setUnitSold(cur->pro.getUnitSold() + qty);

	for(int i=0;(i<index)&&(cur->prev!=NULL);i++)
	{
		if(cur->pro.getUnitSold()>cur->prev->pro.getUnitSold())
			swap(cur->pro,cur->prev->pro);
		cur=cur->prev;
	}
	return true;
}
void DList::swap(Product &back,Product &front)
{
	Product p = back;
	back=front;
	front=p;
}
bool DList::restock(int index,int qty)
{
	if(index<0||index>=size)
		return false;
	ListNode *cur=NULL;
	at(index,cur);

	cur->pro.setUnitCur(cur->pro.getUnitCur() + qty);
	return true;
}

void DList::getDetails(int index,Product& p)
{
	ListNode *cur=NULL;
	at(index,cur);
	p=cur->pro;
}
string DList::getName(int index)
{
	ListNode *cur=NULL;
	at(index,cur);
	return cur->pro.getName();
}
string DList::getCat(int index)
{
	ListNode *cur=NULL;
	at(index,cur);
	return cur->pro.getCat();
}
int DList::getBarcode(int index)
{
	ListNode *cur=NULL;
	at(index,cur);
	return cur->pro.getBarcode();
}
int DList::getUnitSold(int index)
{
	ListNode *cur=NULL;
	at(index,cur);
	return cur->pro.getUnitSold();
}
