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
        List<Tuple<int, int>> vertex; //https://stackoverflow.com/questions/19231460/define-a-list-like-listint-string

        public GraphForm(int[,] _adjMatrix)
        {
            InitializeComponent();
            adjMatrix = _adjMatrix;
            vertex = new List<Tuple<int, int>>();
        }




        private void CheckForVertices()
        {
            for (int col = 1; col < 10; col++) //look through (col,row) up down, left right
            {
                for (int row = 1; row < 10; row++)
                {
                    int current = adjMatrix[col, row];

                    if (current == 1)
                    {
                        vertex.Add(new Tuple<int, int>(row, col));
                    }
                }
            }
            vertex.Sort();
        }


        private void DrawPoints(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            Pen LinePen = new Pen(Color.Blue, 2);

            List<Point> pointLocation = new List<Point>();

            foreach (var v in vertex)
            {
                pointLocation.Add(new Point(v.Item1, v.Item2));
            }

            Point point = new Point(0, 0);
            Point current = new Point(0, 0);
            Point next = new Point(0, 0);
            Point checkPoint;


            if (pointLocation.Count > 1)
            {
                checkPoint = new Point(pointLocation[1].X, pointLocation[1].Y);
            }
            else
            {
                checkPoint = new Point(0, 0);
            }

            List<Point> GetPoints = new List<Point>();
            for (int i = 0; i < vertex.Count; i++)
            {
                point = new Point(pointLocation[i].X, pointLocation[i].Y);

                if (point.X != checkPoint.X || point.Y != checkPoint.Y)
                {
                    e.Graphics.DrawEllipse(pen, new Rectangle(point.X * 30, point.Y * 30, 4, 4)); //Help from Dez

                    //GetPoints.Add(new Point(point.X * 30, point.Y * 30));
                }
            }

            for (int i = 0; i < vertex.Count; i++)
            {
                point = new Point(pointLocation[i].X, pointLocation[i].Y);
                GetPoints.Add(new Point(point.X * 30, point.Y * 30));
            }

            //Draw the lines            
            for (int i = 0; i < GetPoints.Count - 1; i++)
            {
                if (GetPoints[i].X != GetPoints[i + 1].X || GetPoints[i].Y != GetPoints[i + 1].Y)
                {
                    current = GetPoints[i];
                    next = GetPoints[i + 1];
                }
                else
                {
                    current = GetPoints[i];
                    next = GetPoints[i + 1];
                }

                e.Graphics.DrawLine(LinePen, current, next);
            }

            //e.Graphics.DrawLine(LinePen, next, GetPoints[0]); //end the line
        }

        private void GraphForm_Paint(object sender, PaintEventArgs e) //Help from https://www.makeuseof.com/c-sharp-windows-form-graphics/
        {
            CheckForVertices();
            DrawPoints(sender, e);
        }

    }
}
