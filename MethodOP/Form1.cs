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

    public partial class Form1 : Form
    {
		
		static double f(double x)
		{
			return x * x + 8 * Math.Pow(2.7, 0.55 * x);
		}
		/*static  double  D(double a, double b, double E)
		{
			string path = Path.GetTempFileName();
			FileInfo fi1 = new FileInfo(path);
			double x1, x2, f1, f2;
			double d = 0.1 * E, n = 0;
			if (!fi1.Exists)
			{
				//Create a file to write to.
				using (StreamWriter sw = fi1.CreateText())
				{
					sw.WriteLine(" ");
				}
			}
            *//*using (StreamReader sr = fi1.OpenText())
			{
				string s = "";
				while ((s = sr.ReadLine()) != null)
				{
					Console.WriteLine(s);
				}
			}*//*
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("n\t a\t b\t x1\t x2\t f(x1)\t f(x2)\n\n");
            }
			//std::cout << "n\t a\t b\t x1\t x2\t f(x1)\t f(x2)\n\n";
			using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
			{
				while (b - a > E)
			{
				
					x2 = x1 = (a + b) / 2;
					x1 -= d;
					x2 += d;
					f1 = f(x1);
					f2 = f(x2);
                    

					//sw.WriteLine("n\t a\t b\t x1\t x2\t f(x1)\t f(x2)\n\n");
					sw.WriteLine(n + "\t" + a + "\t" + b + "\t" + x1 + "\t" + x2 + "\t" + f1 + "\t" + f2 + "\n");


					// Вывод промежуточных результатов
					*//*std::cout << std::setprecision(5) << n << "\t";
					std::cout << a << "\t" << b << "\t";
					std::cout << x1 << "\t" << x2 << "\t";
					std::cout << f1 << "\t" << f2 << "\n";*//*

					n++;

					//Если f1 меньше f2 то b = x2 иначе a = x1
					//f1 < f2 ? b = x2 : a = x1;
					if (f1 < f2)
					{
						b = x2;
					}
					else
					{
						a = x1;
					}

				}
			}
			Process.Start("notepad.exe", path);
			return ((a + b) / 2);
		}*/
		public Form1()
        {
			Stopwatch stopWatch = new Stopwatch();
			InitializeComponent();
			double x;
			double y;
			double a = -100, b = 100, E = 0.001;
			string path = Path.GetTempFileName();
			FileInfo fi1 = new FileInfo(path);
			double x1, x2, f1, f2;
			double d = 0.1 * E, n = 0;
			if (!fi1.Exists)
			{
				//Create a file to write to.
				using (StreamWriter sw = fi1.CreateText())
				{
					sw.WriteLine(" ");
				}
			}
			/*using (StreamReader sr = fi1.OpenText())
			{
				string s = "";
				while ((s = sr.ReadLine()) != null)
				{
					Console.WriteLine(s);
				}
			}*/
			
				
			
		
			for (int i = -10; i <= 5; i++)
            {
				chart1.Series[0].Points.AddXY(i, f(i));
			}
			//std::cout << "n\t a\t b\t x1\t x2\t f(x1)\t f(x2)\n\n";
			using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
			{
				sw.WriteLine("МЕТОД ДИХОТОМИИ");
				sw.WriteLine("n\t a\t b\t x1\t x2\t f(x1)\t f(x2)\n\n");
				stopWatch.Start();
				while (b - a > E)
				{

					x2 = x1 = (a + b) / 2;
					x1 -= d;
					x2 += d;
					f1 = f(x1);
					f2 = f(x2);
					

					//sw.WriteLine("n\t a\t b\t x1\t x2\t f(x1)\t f(x2)\n\n");
					sw.WriteLine(n + "\t" + a + "\t" + b + "\t" + x1 + "\t" + x2 + "\t" + f1 + "\t" + f2 + "\n");


					// Вывод промежуточных результатов
					/*std::cout << std::setprecision(5) << n << "\t";
					std::cout << a << "\t" << b << "\t";
					std::cout << x1 << "\t" << x2 << "\t";
					std::cout << f1 << "\t" << f2 << "\n";*/

					n++;

					//Если f1 меньше f2 то b = x2 иначе a = x1
					//f1 < f2 ? b = x2 : a = x1;
					if (f1 < f2)
					{
						b = x2;
					}
					else
					{
						a = x1;
					}
					
				}
				stopWatch.Stop();
				x = ((a + b) / 2);
				y = f(x);
				sw.WriteLine("X:= " + x + " " + "Y:= " + y);
				TimeSpan ts = stopWatch.Elapsed;

				// Format and display the TimeSpan value.
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					ts.Hours, ts.Minutes, ts.Seconds,
					ts.Milliseconds / 10);
				sw.WriteLine("Время работы алгоритма:=  "+ts);
				sw.WriteLine("------------------------------------------------------------------------");
				sw.WriteLine("МЕТОД ЗОЛОТОГО СЕЧЕНИЯ ");
				//
				Stopwatch stopWatch2 = new Stopwatch();
				double a2 = -100, b2 = 100,  z = (3 - Math.Sqrt(5)) / 2;
				double x3 = a2 + z * (b2 - a2), x4 = b2 - z * (b2 - a2);
				stopWatch2.Start();
				for (int i = 0; b2 - a2 > E; i++)
				{
					sw.WriteLine(i + "\t" + a2 + "\t" + b2 + "\t" + x3 + "\t" + x4 + "\t" + f(x3) + "\t" + f(x4) + "\n");
					if (f(x3) <= f(x4))
					{
						b2 = x4;
						x4 = x3;
						x3 = a2 + b2 - x4;
					}
					else
					{
						a2 = x3;
						x3 = x4;
						x4 = a2 + b2 - x3;
					}
				}
				stopWatch2.Stop();
				TimeSpan ts2 = stopWatch2.Elapsed;
				string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					ts.Hours, ts.Minutes, ts.Seconds,
					ts.Milliseconds / 10);
				double x5 = (a2 + b2) / 2;
				sw.WriteLine("X:= " + x5 + " " + "Y:= " + f(x5));
				sw.WriteLine("Время работы алгоритма:=  " + ts2);

				//

			}
			Process.Start("notepad.exe", path);
			//return ((a + b) / 2);
			 x = ((a + b) / 2);
			 y = f(x);

			label3.Text = x.ToString();
			label4.Text = y.ToString();
			chart1.Series[1].Points.AddXY(x, y);
			//chart1->Series[0]->Points->AddXY(j, FUNC(j));


		}

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
