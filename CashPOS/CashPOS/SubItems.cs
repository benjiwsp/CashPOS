﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashPOS
{
    public partial class SubItems : UserControl
    {
        List<Button> btnList = new List<Button>();
        List<String> itemList = new List<String>();
        CashSales myParent = null;

        public SubItems(string typeSelected, CashSales myParent)
        {
            InitializeComponent();
            this.myParent = myParent; 
            addSubItems();
            createItemBtn(itemList, subItemPanel, itemBtnClicked);
        }

        private void addSubItems()
        {
            itemList.Add("red1");
            itemList.Add("磚red1");
            itemList.Add("泥red1");
            itemList.Add("膠red1水");
            itemList.Add("其red1他");
            itemList.Add("Emred1ix");
            itemList.Add("Tyred1p7");
            itemList.Add("Typred18");
        }

        //create number of itemBtn based on the amount of item from the itemList
        public void createItemBtn(List<String> itemList, Control panel, EventHandler handler)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                Button newButton = new Button();
                newButton.Width = 203;
                newButton.Height = 132;
                newButton.AutoSize = false;
                newButton.Name = "newBtn" + i;
                newButton.Text = itemList[i].ToString();
                btnList.Add(newButton);
                panel.Controls.Add(newButton);
            }
            //add event handler to ecah button 
            foreach (Button btn in btnList)
            {
                btn.Click += new EventHandler(handler);
            }
        }

        
        protected void itemBtnClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string itemSelected = btn.Text;
            //TO-DO: read price from database and update it to the unitPriceBox
            myParent.selectLblValue = itemSelected;
            myParent.unitPriceValue = "abc";
        //       unitPriceTxt.Text = unitPrice.ToString("#.##");
        }
    }
}