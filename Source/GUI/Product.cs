using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ProjectFinalGui
{

    public partial class Product : Form
    {
        aboutBox about = new aboutBox();
        IntPtr logicobj;
        int arrsize = 0, searchsize=0;
        System.DateTime start, end;
        List<int> indexList = new List<int>();
        List<int> searchlist = new List<int>();
        List<ListViewItem> lvItems = new List<ListViewItem>();
        AutoCompleteStringCollection catList = new AutoCompleteStringCollection();
        AutoCompleteStringCollection nameList = new AutoCompleteStringCollection();
        int check = 0,temp = 0;
     
        public Product()
        {
            InitializeComponent();
            logicobj = Logicdll.init();   
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

        }
        string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else
                            operatingSystem = "8";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        public void autoComplete()
        {
            catList.Clear();
            nameList.Clear();
            Logicdll.clearSearchC(logicobj);
            arrsize = Logicdll.getSizeC(logicobj);
            String name, cat, manu;
            double price = 0;
            int unitcur = 0, unitsold = 0, barcode = 0;
           for (int i = 0; i < arrsize; i++)
            {
                Logicdll.addSearchProC(logicobj, i);
                Logicdll.getSearchProC(logicobj, 1, ref temp, i, ref barcode, ref price, ref unitcur, ref unitsold);
                name = Logicdll.getSearchNameC(logicobj, i);
                cat = Logicdll.getSearchCatC(logicobj, i);
                manu = Logicdll.getSearchManuC(logicobj, i);
                catList.Add(cat);
                nameList.Add(name);
            }
        }
        public void loadAll()
        {
            indexList.Clear();
            searchlist.Clear();
            lvItems.Clear();
            lblMsg.Visible = true;
            String name, cat, manu;
            double price = 0;
            int unitcur = 0, unitsold = 0, barcode = 0;
            Logicdll.clearSearchC(logicobj);
            arrsize = Logicdll.getSizeC(logicobj);
            searchsize = arrsize;
            for (int i = 0; i < arrsize; i++)
            {
                ListViewItem item = new ListViewItem();
                Logicdll.addSearchProC(logicobj, i);
                Logicdll.getSearchProC(logicobj, 1, ref temp, i, ref barcode, ref price, ref unitcur, ref unitsold);
                indexList.Add(temp);
                searchlist.Add(temp);
                name = Logicdll.getSearchNameC(logicobj, i);
                cat = Logicdll.getSearchCatC(logicobj, i);
                manu = Logicdll.getSearchManuC(logicobj, i);
                item.Text = name;
                item.SubItems.Add(cat);
                item.SubItems.Add(manu);
                item.SubItems.Add(barcode.ToString());
                item.SubItems.Add(unitcur.ToString());
                item.SubItems.Add(unitsold.ToString());
                item.SubItems.Add(price.ToString());
                lvItems.Add(item);
            }
            lblSystemInfo0.Text = getOSInfo();
            lblSystemInfo1.Text = System.Environment.OSVersion.Version.ToString();
        }

        public void listViewUpdate(int first)
        {
            result_listbox.Items.Clear();
            start = DateTime.Now;
            result_listbox.BeginUpdate();
            result_listbox.Items.AddRange(lvItems.ToArray());
            result_listbox.EndUpdate();
            int percent;
            progressBar1.Value = 0;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            if (first == 0)             // if it is loaded for first time no need to copy 
            {
                indexList.Clear();
                for (int i = 0; i < searchsize; i++)
                {
                    indexList.Add(searchlist.ElementAt(i));         // this is for show all
                    
                }
            }
            progressBar1.Value = 100;
            percent = Convert.ToInt32(Convert.ToDouble(progressBar1.Value) / Convert.ToDouble(progressBar1.Maximum) * 100);
            progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Times New Roman", 8, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
            checkLow();
            altRow();
            end = DateTime.Now;
            lblMsg.ForeColor = Color.Black;
            lblMsg.Text = "Please select a product.";
            lblStatus.Text = (end - start).ToString() + "s.";
            lblStatus.Visible = true;
            btnAdd.Enabled = true;
           
        }
        public void checkLow()   // this function is to check whether Unitcur is less than 20 or not. If it is less than 20, it will be highlighted with red color
        {
            string stocks = "";
            for (int i = 0; i < result_listbox.Items.Count; i++)
            {
                stocks = result_listbox.Items[i].SubItems[4].Text;
                if ((int.Parse(stocks)) < 20)
                {
                    result_listbox.Items[i].UseItemStyleForSubItems = false;
                    result_listbox.Items[i].SubItems[4].ForeColor = Color.Red;
                }
                else
                {
                    result_listbox.Items[i].UseItemStyleForSubItems = false;
                    result_listbox.Items[i].SubItems[4].ForeColor = Color.Black;
                }
            }


        }

        //for stats list view alt row color settings
        public void altStatRow()
        {
            for (int i = 0; i < lvStats.Items.Count; i++)
            {
                lvStats.Items[i].UseItemStyleForSubItems = false;

                if (i % 2 == 0)
                {
                    lvStats.Items[i].SubItems[0].BackColor = Color.PowderBlue;
                    lvStats.Items[i].SubItems[1].BackColor = Color.PowderBlue;

                }
                else
                {
                    lvStats.Items[i].SubItems[0].BackColor = Color.White;
                    lvStats.Items[i].SubItems[1].BackColor = Color.White;

                }
            }
        }

        //for main list view alt row color settings
        public void altRow()
        {
            for (int i = 0; i < result_listbox.Items.Count; i++)
            {
                result_listbox.Items[i].UseItemStyleForSubItems = false;

                if (i % 2 == 0)
                {
                    result_listbox.Items[i].SubItems[0].BackColor = Color.PowderBlue;
                    result_listbox.Items[i].SubItems[1].BackColor = Color.PowderBlue;
                    result_listbox.Items[i].SubItems[2].BackColor = Color.PowderBlue;
                    result_listbox.Items[i].SubItems[3].BackColor = Color.PowderBlue;
                    result_listbox.Items[i].SubItems[4].BackColor = Color.PowderBlue;
                    result_listbox.Items[i].SubItems[5].BackColor = Color.PowderBlue;
                    result_listbox.Items[i].SubItems[6].BackColor = Color.PowderBlue;
                }
                else
                {
                    result_listbox.Items[i].SubItems[0].BackColor = Color.White;
                    result_listbox.Items[i].SubItems[1].BackColor = Color.White;
                    result_listbox.Items[i].SubItems[2].BackColor = Color.White;
                    result_listbox.Items[i].SubItems[3].BackColor = Color.White;
                    result_listbox.Items[i].SubItems[4].BackColor = Color.White;
                    result_listbox.Items[i].SubItems[5].BackColor = Color.White;
                    result_listbox.Items[i].SubItems[6].BackColor = Color.White;

                }

            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(price_txt.Text, out check) && int.TryParse(currentunit_txt.Text, out check) && int.TryParse(barcode_txt.Text, out check))
            {
                Search_btn.Enabled = true;
                result_listbox.Enabled = true;
                unitsold_txt.Text = "0";
                int result;
                start = DateTime.Now;
                result = Logicdll.addProdC(logicobj, name_txt.Text, cat_txt.Text, manu_txt.Text, int.Parse(barcode_txt.Text) , int.Parse(currentunit_txt.Text), double.Parse(price_txt.Text));  // to update the datastorage of C++
                end = DateTime.Now;
                ListViewItem item = new ListViewItem();
                if (result == 1)
                {
                    lblStatus.ForeColor = Color.Green;
                    lblMsg.Text = "Product Added in " + (end - start).ToString() + "s.";
                    indexList.Add(arrsize);
                    searchlist.Add(arrsize);
                    arrsize++;
                    searchsize++;
                    Logicdll.addSearchProC(logicobj, arrsize - 1);
                    item.Text = name_txt.Text;
                    item.SubItems.Add(cat_txt.Text);
                    item.SubItems.Add(manu_txt.Text);
                    item.SubItems.Add(barcode_txt.Text);
                    item.SubItems.Add(currentunit_txt.Text);
                    item.SubItems.Add(unitsold_txt.Text);
                    item.SubItems.Add(price_txt.Text);
                    result_listbox.Items.Add(item);
                    lvItems.Add(item);
                    catList.Add(cat_txt.Text);
                    nameList.Add(name_txt.Text);
                    name_txt.Clear();
                    cat_txt.Clear();
                    manu_txt.Clear();
                    barcode_txt.Clear();
                    unitsold_txt.Clear();
                    currentunit_txt.Clear();
                    price_txt.Clear();
                    groupBox2.Enabled = false;
                    altRow();
                    btnAdd.Enabled = true;
                    
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Adding product failed, duplicate barcode found.";
                }
               
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                if (!int.TryParse(price_txt.Text, out check))
                {
                    lblStatus.Text = "Adding product failed. Invalid price entered.";
                    price_txt.Focus();
                }
                else if (!int.TryParse(barcode_txt.Text, out check))
                {
                    lblStatus.Text = "Adding product failed. Invalid barcode entered.";
                    barcode_txt.Focus();
                }
                else
                {
                    lblStatus.Text = "Adding product failed. Invalid current units entered.";
                    currentunit_txt.Focus();
                }
            }
            lblStatus.Visible = true;
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            indexList.Clear();
            name_txt.Clear();
            cat_txt.Clear();
            barcode_txt.Clear();
            manu_txt.Clear();
            price_txt.Clear();
            unitsold_txt.Clear();
            currentunit_txt.Clear();
            lblStatus.Visible = false;
            int percent,result,unitcur = 0, unitsold = 0, barcode = 0;
            progressBar1.Value = 0;
            String name, cat, manu;
            double price = 0;
            Logicdll.clearSearchC(logicobj);    // clear the search list in C++ 
            start = DateTime.Now;
            if (Search_txt.Text == "")
            {
                lblStatus.Text = "Please enter a search term.";
                lblStatus.ForeColor = Color.Red;
                lblStatus.Visible = true;
            }
            else
            {
                result_listbox.Items.Clear();
                if (NameS_rbtn.Checked == true)
                    result = Logicdll.searchC(logicobj, 1, Search_txt.Text);

                else if (CatS_rbtn.Checked == true)
                    result = Logicdll.searchC(logicobj, 2, Search_txt.Text);

                else
                    result = Logicdll.searchC(logicobj, 3, Search_txt.Text);
                end = DateTime.Now;

                arrsize = result;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = arrsize;
                for (int i = 0; i < result; i++)
                {
                    progressBar1.Value++;
                    lblMsg.ForeColor = Color.Red;
                    ListViewItem item = new ListViewItem();
                    Logicdll.getSearchProC(logicobj, 1, ref temp, i, ref barcode, ref price, ref unitcur, ref unitsold);    // to get the properties of each product from C++ 
                    name = Logicdll.getSearchNameC(logicobj, i);
                    cat = Logicdll.getSearchCatC(logicobj, i);
                    manu = Logicdll.getSearchManuC(logicobj, i);
                    indexList.Add(temp);
                    item.Text = name;
                    item.SubItems.Add(cat);
                    item.SubItems.Add(manu);
                    item.SubItems.Add(barcode.ToString());
                    item.SubItems.Add(unitcur.ToString());
                    item.SubItems.Add(unitsold.ToString());
                    item.SubItems.Add(price.ToString());
                    result_listbox.Items.Add(item);
                    percent = Convert.ToInt32(Convert.ToDouble(progressBar1.Value) / Convert.ToDouble(progressBar1.Maximum) * 100);
                    progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Times New Roman", 8, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                }
                if (result_listbox.Items.Count == 0)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "No results found.";
                    Delete_btn.Enabled = false;
                    Restock_btn.Enabled = false;
                    Specify_btn.Enabled = false;
                    lblMsg.Visible = true;
                }
                else
                {
                    lblMsg.Text = result_listbox.Items.Count + " product(s) found in " + (end - start).ToString() + "s.";
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "You have searched for '" + Search_txt.Text + "'.";
                    lblStatus.Visible = true;
                }
                Search_txt.Clear();
                checkLow();
                altRow();
                ShowAll_btn.Enabled = true;
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int index = -1,percent =0;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            lblMsg.Visible = true;
            index = result_listbox.FocusedItem.Index;
            start = DateTime.Now;
            int dindex = indexList.ElementAt(index);
            int result = Logicdll.delProdC(logicobj, indexList.ElementAt(index), index);
            lvItems.RemoveAt(dindex);
            indexList.RemoveAt(index);
            searchlist.RemoveAt(index);
            
            end = DateTime.Now;
            result_listbox.Items[index].Remove();
            int count = indexList.Count;   
            
            arrsize--;
            searchsize--;
            for (int i = index; i < count; i++)
            {
                indexList[i]--;
            }
            Delete_btn.Enabled = false;
            Restock_btn.Enabled = false;
            Specify_btn.Enabled = false;
            if (!listEmpty())
            {
                result_listbox.Enabled = true;
                lblMsg.ForeColor = Color.Black;
                lblMsg.Text = "Please select a product.";
            }
            else
            {
                result_listbox.Enabled = true;
                Search_btn.Enabled = true;
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No products loaded.";

            }
            lblStatus.Visible = true;
            lblStatus.ForeColor = Color.Green;
            progressBar1.Value += 100;
            lblStatus.Text = "Product deleted successfully in " + (end - start).ToString() + "s.";
            altRow();
            checkLow();
            percent = Convert.ToInt32(Convert.ToDouble(progressBar1.Value) / Convert.ToDouble(progressBar1.Maximum) * 100);
            progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Times New Roman", 8, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

        }

        private void ShowAll_btn_Click(object sender, EventArgs e)
        {
            listViewUpdate(0);
            lblMsg.Visible = false;
        }


        private void Restock_btn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tFieldValue.Text, out check))
            {
                lblStatus.Text = "Please enter a valid value.";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                int percent, result;
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                int index = result_listbox.FocusedItem.Index;
                ListViewItem item = new ListViewItem();
                item = result_listbox.FocusedItem;
                int change_data = indexList.ElementAt(index);
                start = DateTime.Now;
                result = Logicdll.restockProductC(logicobj, int.Parse(tFieldValue.Text), indexList.ElementAt(index)); // restock inside the datastrage of C++
                end = DateTime.Now;
                lblStatus.Text = (end - start).ToString() + "s.";
                lblStatus.Visible = true;
                progressBar1.Value += 50;
                if (result == -1)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Restock Failed.";
                    item = null;
                }

                else
                {
                    editPanel.Hide();
                    progressBar1.Value += 50;
                    result_listbox.BeginUpdate();
                    item.SubItems[4].Text = (int.Parse(result_listbox.SelectedItems[0].SubItems[4].Text) + int.Parse(tFieldValue.Text)).ToString();  //update the selected data at the list view for user friendly
                    lvItems[change_data].SubItems[4].Text = (int.Parse(result_listbox.SelectedItems[0].SubItems[4].Text)).ToString();
                    result_listbox.EndUpdate();
                    result_listbox.Refresh();
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Restock Successful in " + (end - start).ToString() + "s.";
                    result_listbox.Items[index].EnsureVisible();
                    tFieldValue.Clear();
                    groupBox2.Enabled = true;
                }

                percent = Convert.ToInt32(Convert.ToDouble(progressBar1.Value) / Convert.ToDouble(progressBar1.Maximum) * 100);
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Times New Roman", 8, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                altRow();
                checkLow();
                groupBox5.Enabled = true;
            }
        }

        private void Specify_btn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tFieldValue.Text, out check))
            {
                lblStatus.Text = "Please enter a valid value.";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                int percent, result;
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                int index = result_listbox.FocusedItem.Index;
                ListViewItem item = new ListViewItem();
                item = result_listbox.FocusedItem;
                start = DateTime.Now;
                result = Logicdll.specifySalesOfProductsC(logicobj, int.Parse(tFieldValue.Text), indexList.ElementAt(index));
                int change_data = indexList.ElementAt(index);
                end = DateTime.Now;
                progressBar1.Value += 50;

                if (result == -1)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Updating of sales failed.";
                    item = null;

                }
                else
                {
                    editPanel.Hide();
                    result_listbox.BeginUpdate();
                    progressBar1.Value += 50;
                    item.SubItems[5].Text = (int.Parse(result_listbox.SelectedItems[0].SubItems[5].Text) + int.Parse(tFieldValue.Text)).ToString();
                    item.SubItems[4].Text = (int.Parse(result_listbox.SelectedItems[0].SubItems[4].Text) - int.Parse(tFieldValue.Text)).ToString();
                    lvItems[change_data].SubItems[4].Text = (int.Parse(result_listbox.SelectedItems[0].SubItems[4].Text)).ToString();
                    lvItems[change_data].SubItems[5].Text = (int.Parse(result_listbox.SelectedItems[0].SubItems[5].Text)).ToString();
                    result_listbox.EndUpdate();
                    result_listbox.Refresh();
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Updating of sales is successful in " + (end - start).ToString() + "s.";
                    percent = Convert.ToInt32(Convert.ToDouble(progressBar1.Value) / Convert.ToDouble(progressBar1.Maximum) * 100);
                    progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Times New Roman", 8, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    groupBox2.Enabled = true;
                    tFieldValue.Clear();
                }
                checkLow();
                loadAll();
                listViewUpdate(0);
                altRow();
                groupBox5.Enabled = true;
            }
        }
        public bool listEmpty()
        {
            bool empty = false;
            if (result_listbox.Items.Count == 0)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No Product.";
                empty = true;
                Search_btn.Enabled = false;
            }
            return empty;
        }

        private void result_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            Add_btn.Enabled = false;
            unitsold_txt.Enabled = true;
            result_listbox.HideSelection = false;
            lblStatus.Visible = false;
            lblMsg.ForeColor = Color.Black;
            lblMsg.Text = "Select your desired action.";
            Delete_btn.Enabled = true;
            btnRe.Enabled = true;
            btnSpec.Enabled = true;
            btnPr.Enabled = true;
            name_txt.Enabled = false;
            cat_txt.Enabled = false;
            barcode_txt.Enabled = false;
            manu_txt.Enabled = false;
            price_txt.Enabled = false;
            unitsold_txt.Enabled = false;
            currentunit_txt.Enabled = false;
            btnAddCancel.Enabled = false;

            if (result_listbox.SelectedItems.Count > 0)
            {
                ListViewItem itemInfo = result_listbox.SelectedItems[0];
                name_txt.Text = itemInfo.SubItems[0].Text;
                cat_txt.Text = itemInfo.SubItems[1].Text;
                barcode_txt.Text = itemInfo.SubItems[3].Text;
                manu_txt.Text = itemInfo.SubItems[2].Text;
                price_txt.Text = itemInfo.SubItems[6].Text;
                unitsold_txt.Text = itemInfo.SubItems[5].Text;
                currentunit_txt.Text = itemInfo.SubItems[4].Text;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadAll();
            ShowAll_btn.Enabled = true;
        }

        void topSell(int n)
        {
            groupBox6.Text = "Top " + n + " selling product(s) as of " + DateTime.Now.ToShortTimeString();
            lvStats.Items.Clear();
            colStatName.Text = "Name";
            colStatSold.Text = "Units Sold";
            String name;
            double price = 0;
            int unitcur = 0, unitsold = 0, barcode = 0;
            lvStats.Items.Clear();
            int arrsize = Logicdll.topNsellingC(logicobj, n);
            List<int> statsList = new List<int>();
            for (int i = 0; i < arrsize; i++)
            {

                ListViewItem item = new ListViewItem();
                Logicdll.getSearchProC(logicobj, 1, ref temp, i, ref barcode, ref price, ref unitcur, ref unitsold);
                statsList.Add(temp);
                name = Logicdll.getSearchNameC(logicobj, i);
                item.Text = name;
                item.SubItems.Add(unitsold.ToString());
                lvStats.Items.Add(item);
            }
            altStatRow();
        }

        void topManu()
        {
            groupBox6.Text += " as of " + DateTime.Now.ToShortTimeString();
            lvStats.Items.Clear();
            colStatName.Text = "Manufacturer";
            colStatSold.Text = "Units Sold";
            Logicdll.callbestSellingC(logicobj);
            int count = Logicdll.getBSWsizeC(logicobj);
            int sale = 0;
            ListViewItem statItem = new ListViewItem();
            for (int i = 0; i < count; i++)
            {
                statItem.Text = Logicdll.bestSellingManC(logicobj, i, ref sale);
                statItem.SubItems.Add(sale.ToString());
                lvStats.Items.Add(statItem);
            }
            altStatRow();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            result_listbox.Enabled = true;
            groupBox2.Enabled = true;
            Add_btn.Enabled = true;
            unitsold_txt.Enabled = false;
            name_txt.Enabled = true;
            cat_txt.Enabled = true;
            barcode_txt.Enabled = true;
            manu_txt.Enabled = true;
            price_txt.Enabled = true;
            currentunit_txt.Enabled = true;
            name_txt.Clear();
            cat_txt.Clear();
            barcode_txt.Clear();
            manu_txt.Clear();
            price_txt.Clear();
            unitsold_txt.Clear();
            currentunit_txt.Clear();
        }

        public void splashScreenLoad(string filename, int type)
        {
            this.Show();
            this.Visible = false;
            Splash frmSplash = new Splash();
            frmSplash.Show();
            frmSplash.Update();
            while (loadFile(filename, type) == false) Thread.Sleep(1000);
            frmSplash.Close();
            loadAll();
            autoComplete();
            listViewUpdate(1);
            this.Visible = true;

        }

        public bool loadFile(string filename, int type)
        {
            int result, time = 0;
            result = Logicdll.loadFileC(logicobj, filename, type, ref time); // 1 for csv 2 for txt
            if (result == 1) return true;
            else return false;

        }

        private void topSellingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox6.Text = "Statistics";
            topSell(1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the file?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Save save = new Save();
                save.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void bestManufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox6.Text = "Statistics";
            topManu();
        }

        private void btnSpec_Click(object sender, EventArgs e)
        {
            groupBox5.Enabled = false;
            editPanel.Show();
            Restock_btn.Hide();
            Specify_btn.Show();
            btnPriceChange.Hide();
            lblPopSign.Hide();
            Specify_btn.Enabled = true;

        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            groupBox5.Enabled = false;
            editPanel.Show();
            Restock_btn.Show();
            Specify_btn.Hide();
            btnPriceChange.Hide();
            lblPopSign.Hide();
            Restock_btn.Enabled = true;
        }

        private void btnPr_Click(object sender, EventArgs e)
        {
            groupBox5.Enabled = false;
            editPanel.Show();
            lblPopSign.Show();
            Restock_btn.Hide();
            Specify_btn.Hide();
            btnPriceChange.Show();
            btnPriceChange.Enabled = true;
        }


        private void btnPriceChange_Click(object sender, EventArgs e)
        {
            passwordForm password = new passwordForm();
            password.ShowDialog();
            if (password.lblPassError.Text == "ok")
            {
                if (!int.TryParse(tFieldValue.Text, out check))
                {
                    lblStatus.Text = "Please enter a valid value.";
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = Color.Red;
                }
                else
                {
                    int percent, result;
                    progressBar1.Value = 0;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 100;
                    int index = result_listbox.SelectedIndices[0];
                    ListViewItem item = new ListViewItem();
                    item = result_listbox.FocusedItem;
                    start = DateTime.Now;
                    result = Logicdll.changepriceC(logicobj, double.Parse(tFieldValue.Text), indexList.ElementAt(index));
                    end = DateTime.Now;
                    progressBar1.Value += 50;

                    if (result == 0)
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = "Updating of price failed.";
                        item = null;

                    }
                    else
                    {
                        editPanel.Hide();
                        result_listbox.BeginUpdate();
                        progressBar1.Value += 50;
                        item.SubItems[6].Text = tFieldValue.Text;
                        result_listbox.EndUpdate();
                        result_listbox.Refresh();

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Updating of price is successful in " + (end - start).ToString() + "s.";
                        percent = Convert.ToInt32(Convert.ToDouble(progressBar1.Value) / Convert.ToDouble(progressBar1.Maximum) * 100);
                        progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Times New Roman", 8, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                        groupBox2.Enabled = true;
                        tFieldValue.Clear();
                        lblStatus.Text = "";

                    }
                    loadAll();
                    altRow();
                    checkLow();
                    groupBox5.Enabled = true;
                }
            }
            else lblStatus.Text = "Not enough rights to update price.";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            editPanel.Hide();
            groupBox5.Enabled = true;
            lblStatus.Text = "";
        }

        private void addNewTransactionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            transDialog.ShowDialog();
        }

        private void transDialog_FileOk(object sender, CancelEventArgs e)
        {
            //use openfile dialog
            int a = Logicdll.readTransC(logicobj, Path.GetFileName(transDialog.FileName));
            if (a == 1)
            {
                lblMsg.Text = "Transaction added successfully!";
                lblMsg.ForeColor = Color.Green;
                batchProcessingToolStripMenuItem.Enabled = true;
            }
            else
            {
                lblMsg.Text = "Failed.";
                lblMsg.ForeColor = Color.Red;
            }

        }

        private void batchProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // will return 3 kinds of values
            int result = Logicdll.processBatchC(logicobj);
            if (result == 1)
            {
                lblMsg.Text = "Some errors occured, please check log.txt file!";
                loadAll();
                //   listViewUpdate();
            }
            else if (result == 2)
            {
                lblMsg.Text = "Batch processed successfully!";
                lblMsg.ForeColor = Color.Green;
                loadAll();
            }
            else
            {
                lblMsg.Text = "Please add some transactions!";
                lblMsg.ForeColor = Color.Red;
            }
        }

        private void datetime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblDateTime.Text = dt.ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save save = new Save();
            save.Show();
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {

            Search_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            if (CatS_rbtn.Checked)
                Search_txt.AutoCompleteCustomSource = catList;
            else if (NameS_rbtn.Checked)
                Search_txt.AutoCompleteCustomSource = nameList;
            else
                Search_txt.AutoCompleteMode = AutoCompleteMode.None;
            Search_txt.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            name_txt.Clear();
            cat_txt.Clear();
            barcode_txt.Clear();
            manu_txt.Clear();
            price_txt.Clear();
            unitsold_txt.Clear();
            currentunit_txt.Clear();
            groupBox2.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void topNSellingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpBoxTopN.Visible = true;
        }

        private void btnTopN_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTopN.Text, out check) && int.Parse(txtTopN.Text) <= Logicdll.getSizeC(logicobj) && int.Parse(txtTopN.Text) > 0)
            {
                topSell(int.Parse(txtTopN.Text));
                grpBoxTopN.Visible = false;
            }
            else
            {
                lblStatsError.Visible = true;
                txtTopN.Clear();
            }
        }

    }
}
