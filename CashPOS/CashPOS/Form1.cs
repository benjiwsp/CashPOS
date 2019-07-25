using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashPOS
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        InfoSettings infoSetting;
        CashSales cashSales;
        PriceSetting priceSetting;
        HomeScreen homeScreen;
        Inventory inventory;
        ProdMgm prodMgm;
        CustMgm custMgm;
        InvoiceMgm invoiceMgm;
        public Form1()
        {
            InitializeComponent();
            infoSetting = new InfoSettings();
            cashSales = new CashSales();
            priceSetting = new PriceSetting();
            homeScreen = new HomeScreen();
            inventory = new Inventory();
            prodMgm = new ProdMgm();
            custMgm = new CustMgm();
            invoiceMgm = new InvoiceMgm();
            mainPanel.Controls.Add(homeScreen);

        }


        protected void ButtonClicked(object sender, EventArgs e)
        {
            buttonHandler(sender);
        }

        public void buttonHandler(object sender)
        {
            Button button = sender as Button;
            mainPanel.Controls.Clear();

            if (button != null)
            {
                switch (button.Name)
                {
                    case "HomeBtn":
                        homeScreen.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(homeScreen);
                        break;

                    case "cashSalesBtn":
                        cashSales.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(cashSales);
                        break;

                    case "settingBtn":
                        infoSetting.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(infoSetting);
                        break;

                    case "priceSettingBtn":
                        priceSetting.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(priceSetting);
                        break;

                    case "invBtn":
                        inventory.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(inventory);
                        break;

                    case "prodMgmBtn":
                        prodMgm.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(prodMgm);
                        break;

                    case "custMgmBtn":
                        custMgm.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(custMgm);
                        break;
                    case "InvoiceCheckBtn":
                        invoiceMgm.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(invoiceMgm);
                        break;
                    default:
                        mainPanel.Controls.Clear();
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /*
                // the biggest font that will fit.
                private Font SizeLabelFont(Button btn)
                {
                    int best_size = 100;
                    // Only bother if there's text.
                    string txt = btn.Text;
                    if (txt.Length > 0)
                    {
                       // int best_size = 100;
                        // See how much room we have, allowing a bit
                        // for the Label's internal margin.
                        int wid = btn.DisplayRectangle.Width - 1;
                        int hgt = btn.DisplayRectangle.Height - 1;

                        // Make a Graphics object to measure the text.
                        using (Graphics gr = btn.CreateGraphics())
                        {
                            for (int i = 1; i <= 100; i++)
                            {
                                using (Font test_font =
                                    new Font(btn.Font.FontFamily, i))
                                {
                                    // See how much space the text would
                                    // need, specifying a maximum width.
                                    SizeF text_size =
                                        gr.MeasureString(txt, test_font);
                                    if ((text_size.Width > wid) ||
                                        (text_size.Height > hgt))
                                    {
                                        best_size = i ;
                                        break;
                                    }
                                }
                            }
                        }
                        // Use that font size.
                      //  newFont = 

                    }
                    return new Font(btn.Font.FontFamily, best_size);
                }

                */
    }
}
