#include "SList.h"

SList::SList()
{
	head=NULL;
	tail=NULL;
	size=0;
}
SList::~SList()
{
	while(size!=0)
	{
		ListNode *rm=head;
		head=head->next;
		delete rm;
		size--;
	}
}
void SList::at(int index,ListNode* &cur,ListNode* &prev)
{
	if(size==index)
		prev=cur=NULL;
	else if(index==size-1)
	{
		at(index-1,cur,prev);
		cur=tail;
	}
	else
	{
		cur=head;
		for(int i=0;i<index;i++)
		{
			prev=cur;
			cur=cur->next;
		}
	}
}
void SList::addProduct(int index,Product &p)
{
	ListNode *ptr=new ListNode;
	ptr->pro=p;
	ptr->next=NULL;
	if(size==0)
	{
		head=ptr;
		tail=ptr;
	}
	else
	{
		if(index==0)
		{
			ptr->next=head;
			head=ptr;
			size++;
			return;
		}
		if(index==size)
		{
			tail->next=ptr;
			tail=ptr;
			size++;
			return;
		}
		cur=NULL;
		at(index-1,cur,prev);

		ptr->next=cur->next;
		cur->next=ptr;
			
	}
	size++;
}
int SList::getSize()
{
	return size;
}
bool SList::delProduct(int index)
{
	if(index<0||index>=size||size==0)
		return false;
	cur=NULL;
	prev=NULL;

	if(head==tail)
	{
		cur=head;
		head=NULL;
	}
	else
	{
		at(index,cur,prev);

		if(cur==tail)
		{
			prev->next->next=NULL;
			tail=prev->next;
		}
		else if(cur==head)
		{
			head=head->next;
		}
		else
		{
			prev->next->next=cur->next;
		}
	}
	delete cur;
	size--;
	return true;
}

bool SList::specifySales(int index, int qty)
{
	if(index<0||index>=size)
		return false;
	ListNode *iterator = head;
	at(index,cur,prev);
	if(qty <=0 || (qty > cur->pro.getUnitCur()))
		return false;

	cur->pro.setUnitCur(cur->pro.getUnitCur() - qty);
	cur->pro.setUnitSold(cur->pro.getUnitSold() + qty);
	while(iterator!=cur)
	{
		if(iterator->pro.getUnitSold()<cur->pro.getUnitSold())
			swap(iterator->pro,cur->pro);
		iterator=iterator->next;
	}
	return true;
}
int SList::changePrice(int index,double Cprice)
{
	if(index<0||index>=size)
		return 0;
	cur=NULL;
	prev=NULL;
	at(index,cur,prev);
	
	cur->pro.setPrice(Cprice);
	return 1;
}
void SList::swap(Product &back,Product &front)
{
	Product p = back;
	back=front;
	front=p;
}
bool SList::restock(int index,int qty)
{
	if(index<0||index>=size)
		return false;
	cur=NULL;
	at(index,cur,prev);

	cur->pro.setUnitCur(cur->pro.getUnitCur() + qty);
	return true;
}
void SList::getDetails(int index,Product& p)
{
	ListNode *cur=NULL,*prev= NULL;
	at(index,cur,prev);
	p=cur->pro;
}
void SList::getBestSellingManufacturer(vector<string> &topManuName, vector<int> &topManuSold) //return top selling manufacturer
{
	vector<string> manuList;
	vector<int> saleList;
	int max,i,found;
	while(!topManuName.empty())
		topManuName.pop_back();
	while(!topManuSold.empty())
		topManuSold.pop_back();
	cur=head;
	while(cur!=NULL)
	{
		if(manuList.size()==0&&saleList.size()==0)
		{
			manuList.push_back(cur->pro.getManu());
			saleList.push_back(cur->pro.getUnitSold());
		}
		else
		{
			found=0;
			for(i=0;i<(int)manuList.size();i++)
				if(manuList.at(i)==cur->pro.getManu())
				{
					saleList.at(i)+=cur->pro.getUnitSold();
					found=1;
				}
			if(found==0)
			{
				manuList.push_back(cur->pro.getManu());
				saleList.push_back(cur->pro.getUnitSold());
			}
		}
		cur=cur->next;
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
int SList::readFile(string fname,char type,int &time)   //read from .csv or .txt file // return 1 when read successfully and -1 if not
{
	ListNode *cur=head;
	ifstream readfile(fname);
	string temp;
	int index = size,num,start,end;
	if(readfile.good())
	{
		start = clock();
		getline(readfile,temp);
		stringtoothers(temp,num);
		if(type == ',')
		{
			getline(readfile,temp,'\n');
			getline(readfile,temp,'\n');
		}
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
			if(!searchBarcode(1,_barcode))
			{
				Product p(_name,_cat,_man,_barcode,_unitsold,_curunit,_price);
				addProduct(index,p);
			}
		}
		head=MergeSort(head);
		while(tail->next!=NULL)
			tail=tail->next;
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
SList::ListNode* SList::MergeSort(ListNode *head)
{
	ListNode* head_one;
    ListNode* head_two;
     
 
    if((head == NULL) || (head->next == NULL)) 
     return head;
 
    head_one = head;
    head_two = head->next;
 
    while ((head_two != NULL) && (head_two->next != NULL))
    {
        head = head->next;
        head_two = head_two->next->next;
    }
    head_two = head->next;
    head->next=NULL;
     
    return Merge(MergeSort(head_one), MergeSort(head_two));
}

SList::ListNode* SList::Merge(ListNode* head_one, ListNode* head_two)
{
    if (head_one == NULL)
        return head_two;
 
    if (head_two == NULL)
        return head_one;
 
	if (head_two->pro.getUnitSold() > head_one->pro.getUnitSold())
    {
        head_two->next = Merge(head_one, head_two->next);
        return head_two;
    }
    else
    {
        head_one->next = Merge(head_one->next, head_two);
        return head_one;
    }
}
int SList::writeFile(string sname,string type)
{
	ListNode *cur=head;
	ofstream writefile(sname);
	writefile<<size<<endl<<endl;
	if(type == ",")
	writefile<<"Name"<<type<<"Cat"<<type<<"barcode"<<type<<"price"<<type<<"manufacture"<<type<<"unitcur"<<type<<"unitsold"<<endl;
	string tmpcat,tmpname,tmpman;
	char d = '"';
	for(int i=0; i<size; i++)
	{
		if(type == ",")
		{
			tmpcat = d + cur->pro.getCat() +d;
			tmpname =d+cur->pro.getName()+d;
			tmpman = d+cur->pro.getManu()+d;
		}
		else
		{
			tmpcat =  cur->pro.getCat() ;
			tmpname =cur->pro.getName();
			tmpman = cur->pro.getManu();
		}
		writefile<<tmpname<<type;
		writefile<<tmpcat<<type;
		writefile<<cur->pro.getBarcode()<<type;
		writefile<<cur->pro.getPrice()<<type;
		writefile<<tmpman<<type;
		writefile<<cur->pro.getUnitCur()<<type;
		writefile<<cur->pro.getUnitSold()<<type;

		writefile<<'\n';
		cur=cur->next;
	}
	writefile.close();
	return 1;

}
int SList::searchName(int type,string search)
{
	ListNode *cur=head;
	int count= 0;
	for (int i = 0; i < (int)search.size(); i++)
	{
		search[i] = (char)tolower(search[i]);
	}
	if(type == 1)
	{
		for(int i = 0; i < size; i++)
		{
			string	temp = cur->pro.getName();
			for (int j = 0; j < (int)temp.size(); j++)
			{
				temp[j] = (char)tolower(temp[j]);
			}
			if(temp == search)
			{
				return -1;
			}
			cur=cur->next;
		}
		return 2;
	}
	cur= head;
	for(int i=0; i<size; i++)
	{
		string	temp = cur->pro.getName();
			for (int j = 0; j < (int)temp.size(); j++)
			{
				temp[j] = (char)tolower(temp[j]);
			}
			if(temp == search || temp.find(search)!=-1)
			{
				count++;
				addSearchPro(i,cur->pro.getName(),cur->pro.getCat(),cur->pro.getManu(),cur->pro.getBarcode(),cur->pro.getUnitCur(),cur->pro.getUnitSold(),cur->pro.getPrice());	
			}
			cur=cur->next;
	}
	return count;
}
int SList::searchCat(string search)
{
	ListNode *cur=head;
	int count=0;
	for (int i = 0; i < (int)search.size(); i++)
	{
		search[i] = (char)tolower(search[i]);
	}
	for(int i=0; i<size; i++)
	{
		string	temp = cur->pro.getCat();
			for (int j = 0; j < (int)temp.size(); j++)
			{
				temp[j] = (char)tolower(temp[j]);
			}
			if(temp == search || temp.find(search)!=-1)
			{
				count++;
				addSearchPro(i,cur->pro.getName(),cur->pro.getCat(),cur->pro.getManu(),cur->pro.getBarcode(),cur->pro.getUnitCur(),cur->pro.getUnitSold(),cur->pro.getPrice());	
			}
			cur = cur->next;
	}
	return count;
}
int SList::searchBarcode(int type,int search)
{
	ListNode *cur = head;
	int count=0;
	if(type == 1)
	{
		for(int i=0;i<size;i++)
		{
			if(cur->pro.getBarcode() == search)
			{
				return -1;
			}
			cur=cur->next;
		}
		return 0;
	}
	cur = head;
	for(int i=0; i<size; i++)
	{
			if(cur->pro.getBarcode() == search)
			{
				count++;
				addSearchPro(i,cur->pro.getName(),cur->pro.getCat(),cur->pro.getManu(),cur->pro.getBarcode(),cur->pro.getUnitCur(),cur->pro.getUnitSold(),cur->pro.getPrice());	
			}
			cur = cur->next;
	}
	return count;
}
void SList::stringtoothers(string str,double& result)
{
	stringstream ss(str);
	ss>>result ? result: 0;
}
void SList::stringtoothers(string str,int& result)
{
	stringstream ss(str);
	ss>>result ? result: 0;
}

void SList::addSearchPro(int index,string name, string cat, string manu, int code, int unitCur, int unitSold, double price)
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

void SList::ClearSearch()
{
	while(!_searchList.empty())
	{
		_searchList.pop_back();
	}
}
string SList::getsearchName(int i)
{
	return _searchList.at(i).data.getName();
}
string SList::getsearchCat(int i)
{
	return _searchList.at(i).data.getCat();
}
string SList::getsearchManu(int i)
{
	return _searchList.at(i).data.getManu();
}
void SList::delSearchPro(int i)
{
	_searchList.erase(_searchList.begin()+i);
}
void SList::getSearchPro(int &index,int i,int &barcode,double &price,int &curunit,int &unitsold)
{
	index = _searchList.at(i).index;
	barcode = _searchList.at(i).data.getBarcode();
	price = _searchList.at(i).data.getPrice();
	curunit = _searchList.at(i).data.getUnitCur();
	unitsold = _searchList.at(i).data.getUnitSold();
}	
int SList::readTransaction(string fname)
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
bool SList::storeExistingBatch(int type)
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
void SList::writeTransaction()
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
void SList::writeErrorLog()
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
int SList::processBatch()
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
						addProduct(size,p);
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
			writeErrorLog();
			return 1;   //cout<<"Some errors occured, please check log.txt file!"<<endl;	 // 
		}
		return 2;//cout<<"Batch Processed!"<<endl;
	}
	else
		return 3; // cout<<"Please add some transactions!"<<endl;
}

int SList::topNselling(int n)
{
	ListNode *cur =head->next;
	ListNode *prev = head;
	int count =0,rcount=0;
	while(!_searchList.empty())
	{
		_searchList.pop_back();
	}
	addSearchPro(0,prev->pro.getName(),prev->pro.getCat(),prev->pro.getManu(),prev->pro.getBarcode(),prev->pro.getUnitCur(),prev->pro.getUnitSold(),prev->pro.getPrice());	
	while(cur!=NULL)
	{
		rcount++;
		if(prev->pro.getUnitSold() != cur->pro.getUnitSold())
			count++;
		
		if(count == n)
			return rcount;
		addSearchPro(rcount,cur->pro.getName(),cur->pro.getCat(),cur->pro.getManu(),cur->pro.getBarcode(),cur->pro.getUnitCur(),cur->pro.getUnitSold(),cur->pro.getPrice());	

		prev = cur;
		cur = cur->next;
	}
	return rcount;
}