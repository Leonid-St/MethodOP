using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodOP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
        public static double f(double x)
        {
            // return (x - log(x));
            //  return (float)(x * x + 8 * Math.Pow(2.7, 0.55 * x));
            // return (float)(x * x + 8 * Math.Pow(2.7, 0.55 * x));
            var arg = Math.Log(6.0976 * x);
            double res = Math.Log(6.0976 * x) - 6.8720 * x + 1;
            return res;
        }
        public static double fd(double x)
        {
            // return (x - 1) / x;
            //return (float)(4.3300 * 4.0080 * Math.Cos(4.0080 * x) - 3.50);
            return (1 / x) - 6.8720;
        }
        public static double fdd(double x)
        {
            // return (float)(4.3300 * 4.0080 * 4.0080 * (-Math.Sin(4.0080 * x)));
            //return (float)(2+((121*Math.Pow(2.71,((11/20)*x)))/50));
            return (-(1 / x * x));
        }
    }
}
