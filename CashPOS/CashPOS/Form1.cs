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
        ArrayList itemList = new ArrayList();


        public Form1()
        {

            InitializeComponent();

            itemList.Add("redBrickaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            itemList.Add("紅磚");
            itemList.Add("redBrick2");
            itemList.Add("redBrick3");
            itemList.Add("redBrick4");
            itemList.Add("redBrick5");
            itemList.Add("redBrick6");
            itemList.Add("redBrick7");
            itemList.Add("redBrick8");
            itemList.Add("redBrick9");
            itemList.Add("redBrick10");
           // createButton(50, 3, 1, itemList);
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            selectedPanel.Top = HomeBtn.Top;
            selectedPanel.Height = HomeBtn.Height;
        }

        private void CashBtn_Click(object sender, EventArgs e)
        {
            selectedPanel.Top = cashBtn.Top;
            selectedPanel.Height = cashBtn.Height;
        }

/*
        //create buttons based on the given starting row and col
        private void createButton(int numOfBtn, int startRow, int startCol, ArrayList itemList)
        {

            int toRow = startRow;
            int toCol = startCol;
            for (int i = 0; i < itemList.Count; i++)
            {
                Button btn = new Button();
                btn.Name = "button";
                btn.Text = itemList[i].ToString();
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Green;
                btn.Font = SizeLabelFont(btn);
                btn.Width = 170;
                btn.Height = 80;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Margin = new Padding(5);
                tableLayoutPanel1.Controls.Add(btn, toRow, toCol);

                //  if the current row has reached the end, jump to the next col at the same starting row
                if (toRow < tableLayoutPanel1.RowCount - 1)
                {
                    toRow += 1;
                }
                else
                {
                    toCol += 1;
                    toRow = startRow;
                }
            }
        }

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
