using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace GraphApp
{
    public partial class Form1 : Form
    {
        TextBox[,] textBoxes = new TextBox[0, 0]; //Help from Duncan Mcdonald
        public Form1()
        {
            InitializeComponent();

            TBLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single; //Help from https://stackoverflow.com/questions/19609490/tablelayoutpanel-does-not-show-up-c-sharp

            SetMatrixTextBox();
            SetMatrix();
        }

        private void SetMatrix()
        {
            for (int i = 0; i < TBLayout.ColumnCount; i++) //Vertical
            {
                TBLayout.Controls.Add(new TextBox() { Text = "V" + i, ReadOnly = true }, 0, i);
            }
            for (int i = 1; i < TBLayout.RowCount; i++) //Horizontal 
            {
                TBLayout.Controls.Add(new TextBox() { Text = "V" + i, ReadOnly = true }, i, 0);
            }
        }

        private void SetMatrixTextBox()
        {
            textBoxes = new TextBox[TBLayout.ColumnCount, TBLayout.RowCount];
            for (int i = 1; i < TBLayout.ColumnCount; i++)
            {
                for (int j = 1; j < TBLayout.RowCount; j++)
                {
                    if (i == j)
                    {
                        //Help from Duncan Mcdonald
                        TextBox temp = new TextBox() { Text = "0", ReadOnly = true };
                        TBLayout.Controls.Add(temp, i, j); //Help from Leo Hazou
                        textBoxes[i, j] = temp;
                    }
                    else
                    {
                        TextBox temp = new TextBox();
                        TBLayout.Controls.Add(temp, i, j);
                        textBoxes[i, j] = temp;
                    }
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //Help from Duncan Mcdonald
            int[,] adjMatrix = new int[TBLayout.ColumnCount, TBLayout.RowCount];

            for (int i = 1; i < TBLayout.ColumnCount; i++)
            {
                for (int j = 1; j < TBLayout.RowCount; j++)
                {
                    if(textBoxes[i, j].Text != "0" && textBoxes[i, j].Text.Length != 0)
                    {
                        adjMatrix[i, j] = textBoxes[i, j].Text.Length;
                    } 
                }
            }

            GraphForm graph = new GraphForm(adjMatrix);
            graph.ShowDialog();
        }
    }
}
