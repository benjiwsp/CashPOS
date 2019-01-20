using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashPOS
{
    public partial class ProdMgm : UserControl
    {
        public ProdMgm()
        {
            InitializeComponent();
            setupGrid();
        }


        private void setupGrid(){
            addGridCol(newProdGrid,"nameCol", "貨品");
            addGridCol(newProdGrid,"codeCol", "貨品ID");
            addGridCol(newProdGrid, "unitCol", "單位");
            addGridCol(newProdGrid, "unitPrePackCol", "件數/包裝");
            addGridCol(newProdGrid,"unitPriceCol", "單價");
            addGridCol(newProdGrid, "packPriceCol", "包裝價錢");
            addGridCol(newProdGrid,"insertTimeCol", "加入時間");
            newProdGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            addGridCol(allProdGrid, "nameCol", "貨品");
            addGridCol(allProdGrid, "codeCol", "貨品ID");
            addGridCol(allProdGrid, "unitCol", "單位");
            addGridCol(allProdGrid, "unitPrePackCol", "件數/包裝");
            addGridCol(allProdGrid, "unitPriceCol", "單價");
            addGridCol(allProdGrid, "packPriceCol", "包裝價錢");
            addGridCol(allProdGrid, "insertTimeCol", "加入時間");
            allProdGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void addGridCol(DataGridView grid, string colName, string header)
        {
            grid.Columns.Add(colName, header);
        }

    }
}
