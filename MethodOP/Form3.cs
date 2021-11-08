using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MethodOP
{
    public partial class Form3 : Form
    {
        public static int CountPoints = 10000;

        public static double [] pointsX = new double[CountPoints];

        public static double [] pointsY  = new double [CountPoints];

        public static double A = 1;

        public static double B = 3;

        public static int I = 0;

        public static double EPS = 0.0001;



        public static double interval = (B - A) / CountPoints;

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }
       
       
       public static void GetFunction()
        {

            double x = A;
            for (int i = 0; i < CountPoints; i += 1){
                pointsX[i]=x;
                double y = Program.f(x);
                pointsY[i]=y;
                x += interval;
                chart1_.Series[0].Points.AddXY(x,y);
               // chart1_.
            }
        }
        public Form3()
        {
            InitializeComponent();

            GetFunction();
        }
            // double eps = 0.1, x = 10;
           
        

       /* double f(double x)
        {
            //return 3*x*x*x*x/4+12*x*x*x+66*x*x+144*x+3;
            return 4.3300 * Math.Sin(4.0080 * x) - 3.50 * x;
        }*/

        double GetLipschitzConst(double a, double b)
        {
            double tmpL, L = 0;
            double h = Math.Abs(b - a) / 10000;
            for (double cur = a ; cur <= b; cur += h)
            {
                tmpL = Math.Abs(Program.f(cur) - Program.f(cur - h)) / h;
                if (tmpL > L) { L = tmpL; }
            }

            return L;
        }
        double GetPointIntersection(double Lx, double Rx, double L)
        {
            return (Program.f(Lx) - Program.f(Rx)) / (2 * L) + (Lx + Rx) / 2;
        }
        public static  double g(double u,double v)
        {
            return Program.f(v) + Program.fd(v) * (u - v);
        }
        public static double newton(
               double start, int nr_iteratii)
        {
            double  min_p;
            I = 0;
            string path = Path.GetTempFileName();
            FileInfo fi1 = new FileInfo(path);
            if (!fi1.Exists)
            {
                //Create a file to write to.
                using (StreamWriter sw = fi1.CreateText())
                {
                    sw.WriteLine(" ");
                }
            }
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                /*double u0 = A;
                double[] p1 = new double[CountPoints];
                for (int i = 0; i < CountPoints; i++)
                {
                    p1[i] = g(i, u0);
                }
                 min_p = p1.Min();
                I = 0;
                while (Math.Abs(min_p - u0) > EPS)
                {
                    double[] p2 = new double[CountPoints];
                    for (int i = 0; i < CountPoints; i++)
                    {
                        p2[i] = g(i, min_p);
                    }
                    
                    for (int i = 0; i < CountPoints; i++)
                    {
                        
                        u0 = min_p;
                        min_p = p2.Min();
                        p1 = p2;
                    }
                    I += 1;
                }*/
                double x_next = 1;
                double tmp;
                double x_curr = B;
                double x_prev = A;
                do
                {
                    tmp = x_next;
                    x_next = x_curr - Program.f(x_curr) * (x_prev - x_curr) / (Program.f(x_prev) - Program.f(x_curr));
                    x_prev = x_curr;
                    x_curr = tmp;
                    I += 1;
                } while (Math.Abs(x_next - x_curr) > EPS);
                min_p = x_next;


                sw.WriteLine("u* = {" + x_next + "}\tJ* = {" + Program.f(x_next) + "}\tJ'(u*) = {" + Program.fd(x_next) + "}\t");
                sw.WriteLine("итераций:=" + I);
                sw.Close();
               
            }
            Process.Start("notepad.exe", path);
            return min_p;








            /* double x = start;
             double Eps = 1e-7;
             double pas = 1 / Math.Abs(Program.fdd(x));

             // fprintf(logfile2, "x, f(x)\n");
             for (int i = 0; i < nr_iteratii; i++)
             {
                 x = x - Program.fd(x) / Math.Abs(Program.fdd(x));
                 if (pas < Eps)
                     break;

                 // "x=%f, f(x)=%f \n"+ x+" , "+  f(x);
                 // fprintf(logfile2, "%f, %f\n", x, f(x));
             }
            // Form3.richTextBox1.Text = "Метод второй производной : F(x):=" + Program.f(x) + " , x:=" + x;
             return x;*/
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioHord_CheckedChanged_1(object sender, EventArgs e)
        {
           

           if (radioHord.Checked)
    {
                string path = Path.GetTempFileName();
                FileInfo fi1 = new FileInfo(path);
                if (!fi1.Exists)
                {
                    //Create a file to write to.
                    using (StreamWriter sw = fi1.CreateText())
                    {
                        sw.WriteLine(" ");
                    }
                }
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    // Метод Ломаных

                    double eps = 0.000001;
                    double Lx = A;
                    double Rx = B;
                    chart1_.Series[1].Points.AddXY(Lx, Program.f(Lx));
                    double L = GetLipschitzConst(A, B);
                    double PIx = GetPointIntersection(Lx, Rx, L),
                        PILx = GetPointIntersection(Lx, PIx, L),
                        PIRx = GetPointIntersection(PIx, Rx, L);

                    sw.Write("PIx:= " + PIx + " , ");
                    sw.Write("PILx:= " + PILx + " , ");
                    sw.Write("PIRx:= " + PIRx + " \n ");
                    I += 1;
                    sw.WriteLine("функция удовлетворяет условию Липшица:=" + L);

                    chart1_.Series[1].Points.AddXY(PILx, Program.f(PILx));
                    while (Math.Abs(Rx) - Math.Abs(Lx) <= eps)
                    {
                        PIx = GetPointIntersection(Lx, Rx, L);
                        sw.Write("PIx:= " + PIx + " , ");
                        PILx = GetPointIntersection(Lx, PIx, L);
                        sw.Write("PILx:= " + PILx + " , ");
                        PIRx = GetPointIntersection(PIx, Rx, L);
                        sw.Write("PIRx:= " + PIRx + " \n ");
                        if (Program.f(PILx) <= Program.f(PIRx))
                        {
                            Rx = PIx;
                            chart1_.Series[1].Points.AddXY(Lx, Program.f(Lx));
                        }
                        else
                        {
                            Lx = PIx;
                            chart1_.Series[1].Points.AddXY(Lx, Program.f(Lx));
                        }
                        I += 1;

                    }
                    //min of Метод Ломаных
                    var answer = GetPointIntersection(Lx, Rx, L);
                    chart1_.Series[1].Points.AddXY(Lx, Program.f(Lx));
                    sw.WriteLine("Метод Ломаных:" + answer + " , F(x):=" + Program.f(answer) + ". Итераций :=" + I);
                    /* double a = -0.3879  double b = 0;  */
                   
                   
                    sw.Close();
                    //a=-3.5 b=8.1
                    // Console.WriteLine("x= " + Newton(x, eps));
                    //Console.ReadLine();
                }
                Process.Start("notepad.exe", path);
            }
              //  draw.DrawHord(pointhord, width, height, grap);
          //  string result = "F(x) = 0 в точке " + Math.Round(lim.Y, 3).ToString();
            // richTextBox1.Text = result;
        }

        private void radioCas_CheckedChanged_1(object sender, EventArgs e)
        {
            
           if (radioCas.Checked)
            {
                string path = Path.GetTempFileName();
                FileInfo fi1 = new FileInfo(path);
                if (!fi1.Exists)
                {
                    //Create a file to write to.
                    using (StreamWriter sw = fi1.CreateText())
                    {
                        sw.WriteLine(" ");
                    }
                }
                var answer2 = newton(1, CountPoints);
               /* using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    
                    //sw.WriteLine("Метод Ньютона:" + answer2 + " f(x):=" + Program.f(answer2));
                  //  sw.Close();
                }*/
                Process.Start("notepad.exe", path);
            }
              //  draw.DrawSec(pointcas, width, height, grap);
           // string result = "F(x) = 0 в точке " + Math.Round(lim.Y, 3).ToString();
            //  richTextBox1.Text = result;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
