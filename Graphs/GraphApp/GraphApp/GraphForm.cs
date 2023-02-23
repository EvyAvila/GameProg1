using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GraphApp
{
    public partial class GraphForm : Form
    {
        int[,] adjMatrix;
        List<Tuple<int,int>> vertex; //https://stackoverflow.com/questions/19231460/define-a-list-like-listint-string

        double radius;

        public GraphForm( int[,] _adjMatrix)
        {
            InitializeComponent();
            adjMatrix = _adjMatrix;
            vertex=  new List<Tuple<int, int>>();
        }

        private void DrawVertices(object sender, PaintEventArgs e)
        {
            Brush brush= new SolidBrush(Color.Red); 

            foreach (var v in vertex)
            {
                CreateGraph(v.Item1, v.Item2);
                e.Graphics.FillRectangle(brush, v.Item1, v.Item2, 1, 1); //from https://stackoverflow.com/questions/761003/draw-a-single-pixel-on-windows-forms
                e.Graphics.RotateTransform((float)radius);
            }
        }
        
        //Might not be right
        private void CreateGraph(int col, int row)
        {
            double Degrees = 2 * int.Parse(adjMatrix.GetValue(col, row).ToString()); 
            double Edges = Degrees / 2;
            int origin = col + row;
            radius = Edges / 2; //?
            double theta = Math.Atan(Math.PI / 180); //https://www.oreilly.com/library/view/c-cookbook/0596003390/ch01s15.html
            double EndPoint = Math.Cos(col) / Math.Sin(row) * radius; 

        }

        private void GraphForm_Paint(object sender, PaintEventArgs e) //Help from https://www.makeuseof.com/c-sharp-windows-form-graphics/
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (int.Parse(adjMatrix.GetValue(i, j).ToString()) != 0 && i != j)
                    {
                        vertex.Add( new Tuple<int, int>(i, j));
                        //CreateGraph(i, j);
                    }
                }
            }
            
            DrawVertices(sender, e);
        }
    }
}
