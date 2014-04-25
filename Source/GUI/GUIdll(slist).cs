﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ProjectFinalGui
{

    class Logicdll
    {

        [DllImport("ProjectFinal(slist).dll", EntryPoint = "addProdC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int addProdC(IntPtr those, string name, string cat, string man, int barcode, int qty, double price);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "delProdC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int delProdC(IntPtr those, int i, int Si);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "specifySalesOfProductsC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int specifySalesOfProductsC(IntPtr those, int type, int i);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "restockProductC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int restockProductC(IntPtr those, int type, int i);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "loadFileC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int loadFileC(IntPtr those, string name, int type, ref int time);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "searchC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchC(IntPtr those, int type, string search);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "init", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr init();
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "getSearchProC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getSearchProC(IntPtr those, int type, ref int index, int i, ref int barcode, ref double price, ref int curunit, ref int unitsold);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "saveFileC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int saveFileC(IntPtr those, string name, int type);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "getSizeC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSizeC(IntPtr those);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "addSearchProC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void addSearchProC(IntPtr those, int i);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "clearSearchC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void clearSearchC(IntPtr those);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "getSearchNameC", CallingConvention = CallingConvention.Cdecl)]
        public static extern string getSearchNameC(IntPtr those, int i);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "getSearchCatC", CallingConvention = CallingConvention.Cdecl)]
        public static extern string getSearchCatC(IntPtr those, int i);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "getSearchManuC", CallingConvention = CallingConvention.Cdecl)]
        public static extern string getSearchManuC(IntPtr those, int i);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "bestSellingManC", CallingConvention = CallingConvention.Cdecl)]
        public static extern string bestSellingManC(IntPtr those, int i, ref int sale);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "getBSWsizeC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getBSWsizeC(IntPtr those);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "callbestSellingC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void callbestSellingC(IntPtr those);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "readTransC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int readTransC(IntPtr those, string name);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "processBatchC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int processBatchC(IntPtr those);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "topNsellingC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int topNsellingC(IntPtr those, int n);
        [DllImport("ProjectFinal(slist).dll", EntryPoint = "changepriceC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int changepriceC(IntPtr those, double Cprice, int i);
    };
}
