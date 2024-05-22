using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {

        int max = 300; // iterations to determine whether point is in set
        double zoom = 1;
        double xc = 0; // coords of centre
        double yc = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            DrawMandelbrotSet();
            DrawJuliaSet(pictureBox1.Width/2, pictureBox1.Height/2);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Left)
            //{
            //    double xAdd = ((double)e.X / (double)pictureBox1.Width) * 4 - 2;
            //    double yAdd = ((double)e.Y / (double)pictureBox1.Height) * 4 - 2;
            //    xc += xAdd;
            //    yc += yAdd;
            //    max = 200;
            //    zoom += 3;
            //    DrawMandelbrotSet();
            //}
            //else if (e.Button == MouseButtons.Right)
            //{
            //    xc = 0; 
            //    yc = 0;
            //    max = 100;
            //    zoom = 1;
            //    DrawMandelbrotSet();
            //}

            DrawJuliaSet(e.X, e.Y);
        }

        private void DrawMandelbrotSet()
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = ((double)(x - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4) - xc) / zoom;
                    double b = ((double)(y - (pictureBox1.Height / 2)) / (double)(pictureBox1.Width / 4) + yc) / zoom;
                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    int i = 0;
                    while (i < max) {
                        i++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break;
                    }
                    int col = Color.Black.ToArgb();
                    //col /= Convert.ToInt32(Math.Log(i * 10)); // idk I just get cool colours by doing this
                    //col *= Convert.ToInt32(Math.Log(1 / Math.Pow(i,100))); // I like this one
                    col *= i * Convert.ToInt32(Math.Log(i));
                    //col += i;

                    bm.SetPixel(x, y, Color.FromArgb(col));
                    //bm.SetPixel(x, y, it < MAX ? Color.Black : Color.White);
                }
            }
            pictureBox1.Image = bm;
        }

        private void DrawJuliaSet(int x_seed, int y_seed)
        {
            Bitmap bm = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            for (int x = 0; x < pictureBox2.Width; x++)
            {
                for (int y = 0; y < pictureBox2.Height; y++)
                {
                    //double a = ((double)(x - (pictureBox2.Width / 2)) / (double)(pictureBox2.Width / 4) - xc) / zoom;
                    //double b = ((double)(y - (pictureBox2.Height / 2)) / (double)(pictureBox2.Width / 4) + yc) / zoom;

                    double a = -2 + ((double)(4 * x) / (double)pictureBox2.Width);
                    double b = -2 + ((double)(4 * y) / (double)pictureBox2.Height);

                    //double x_normal = ((double)(x_seed - (pictureBox2.Width / 2)) / (double)(pictureBox2.Width / 4) - xc) / zoom;
                    //double y_normal = ((double)(x_seed - (pictureBox2.Height / 2)) / (double)(pictureBox2.Height / 4) - xc) / zoom;

                    double x_normal = -2 + ((double)(4*x_seed) / (double)pictureBox2.Width);
                    double y_normal = -2 + ((double)(4*y_seed) / (double)pictureBox2.Height);


                    Complex c = new Complex(x_normal, y_normal);
                    Complex z = new Complex(a, b);
                    int i = 0;
                    while (i < max)
                    {
                        i++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break;
                    }
                    int col = Color.Black.ToArgb();
                    //col /= Convert.ToInt32(Math.Log(i * 10)); // idk I just get cool colours by doing this
                    //col *= Convert.ToInt32(Math.Log(1 / Math.Pow(i, 100))); // I like this one
                    col *= i * Convert.ToInt32(Math.Log(i));
                    //col += i * 1;



                    bm.SetPixel(x, y, Color.FromArgb(col));
                    //bm.SetPixel(x, y, it < MAX ? Color.Black : Color.White);
                }
            }
            pictureBox2.Image = bm;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            DrawJuliaSet(e.X, e.Y);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            DrawJuliaSet(e.X, e.Y);
        }

        /*private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Space:
                    zoom += 3;
                    xc -= (zoom * 0.09);
                    yc -= (zoom * 0.09);
                    break;
                case Keys.Up:
                    yc -= (zoom * 0.05);
                    break;
                case Keys.Down:
                    yc += (zoom * 0.05);
                    break;
                case Keys.Right:
                    xc -= (zoom * 0.05);
                    break;
                case Keys.Left:
                    xc += (zoom * 0.05);
                    break;
                default:
                    break;
            }

            DrawMandelbrotSet();
        }*/
    }
}
