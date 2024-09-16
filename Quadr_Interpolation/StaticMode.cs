using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELW.Library.Math;
using ELW.Library.Math.Exceptions;
using ELW.Library.Math.Expressions;
using ELW.Library.Math.Tools;


namespace Quadr_Interpolation
{
    class StaticMode
    {
        public static int sch=1;
        public static int control = 0;
        public static int abort = 0;
        public static Random ch = new Random();

        public static ArrayList al = new ArrayList();

        public static List<Double> ax1 = new List<double>();
        public static List<Double> ax2 = new List<double>();
        public static List<Double> ax3 = new List<double>();

        public static double Y(double x)
        {
            double y = 0;
            try {
                switch (((StartForm)Application.OpenForms["StartForm"]).comboBox.SelectedIndex)
                {
                    case 0:
                        y = 2 * Math.Pow(x, 2) + 16 / x;
                       // y = 10*x*Math.Log(x)-Math.Pow(x,2)/2;
                        break;
                    case 1:
                        y = 127 / 4 * Math.Pow(x, 2) - 61 / 4 * x + 2;
                        break;
                    case 2:
                        y = 2 * Math.Pow(x, 2) - Math.Pow(Math.E, x);
                        break;
                    default:
                        y = YY(x);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Неверно введена функция (Вид входной функции: x^2-x-1).");
                throw;
            }
            return y;
        }

        public static double YY(double x)
        {
                double res = 0;

                PreparedExpression preparedExpression = ToolsHelper.Parser.Parse(((StartForm)Application.OpenForms["StartForm"]).comboBox.Text);
                CompiledExpression compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
                List<VariableValue> variables = new List<VariableValue>();
                variables.Add(new VariableValue(x, "x"));
                res = ToolsHelper.Calculator.Calculate(compiledExpression, variables);  

                return res;
        }

        static void ChoosePoint(double x1, double x2, double x3, double xx, double xmin,double eps1,double eps2)
        {
            if (xx < xmin)
            {
                if (xx >= x1 && xx <= x2)
                {
                    Min(x1, xx, x2,eps1,eps2);
                }
                else
                {
                    Min(x2, xx, x3,eps1,eps2);
                }
            }
            else
            {
                if (xmin >= x1 && xmin <= x2)
                {
                    Min(x1, xmin, x2,eps1,eps1);
                }
                else
                {
                    Min(x2, xmin, x3,eps1,eps2);
                }
            }
        }
        static bool CheckInterval(double x1, double x3, double xx)
        {
            if (xx >= x1 && xx <= x3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Res(ArrayList res)
        {
            if (((StartForm)Application.OpenForms["StartForm"]).rB3.Checked)
            {
                ((StartForm)Application.OpenForms["StartForm"]).tB5.Text = res[res.Count - 1].ToString();
                ((StartForm)Application.OpenForms["StartForm"]).drawGraph(double.Parse(res[res.Count - 1].ToString()));
            }
            else
            {
                if (((StartForm)Application.OpenForms["StartForm"]).rB2.Checked)
                {
                    ((StartForm)Application.OpenForms["StartForm"]).tB5.Text = res[res.Count - 1].ToString();
                    ((StartForm)Application.OpenForms["StartForm"]).drawStep(double.Parse(res[res.Count - 1].ToString()));
                }
                else
                {
                    ((StartForm)Application.OpenForms["StartForm"]).tB5.Text = res[res.Count - 1].ToString();
                    ((StartForm)Application.OpenForms["StartForm"]).StartDynam();
                }
            }
        }

        public static void Points(double x1, double dx, double eps1, double eps2)
        {
            if (abort <=15 + ch.Next(1, 10))
            { 
            double x2, x3;
            x2 = x1 + dx;
            if (Y(x1) > Y(x2))
            {
                x3 = x1 + 2 * dx;
                    ax3.Add(x3);
            }
            else
            {
                x3 = x1 - dx;
            }
            Min(x1, x2, x3, eps1, eps2);
            }
            else
            {
                Res(al);
            }
           
          
            
        }

        static void Min(double x1, double x2, double x3,double eps1,double eps2)
        {
            try
            {
                int ymin;
                double xmin = 0;
                double xx, a1, a2, min, c1, c2;
                double[] arr = new double[3];
                arr[0] = Y(x1);
                arr[1] = Y(x2);
                arr[2] = Y(x3);
                min = arr.Min();
                ymin = Array.IndexOf(arr, min);
                ax1.Add(x1);
                ax2.Add(x2);
                ax3.Add(x3);
                switch (ymin)
                {
                    case 0:
                        xmin = x1;
                        break;
                    case 1:
                        xmin = x2;
                        break;
                    case 2:
                        xmin = x3;
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                a1 = (x2 * x2 - x3 * x3) * Y(x1) + (x3 * x3 - x1 * x1) * Y(x2) + (x1 * x1 - x2 * x2) * Y(x3);
                a2 = (x2 - x3) * Y(x1) + (x3 - x1) * Y(x2) + (x1 - x2) * Y(x3);

                if (a2 == 0)
                {
                    Points(xmin, double.Parse(((StartForm)Application.OpenForms["StartForm"]).tB2.Text), eps1, eps2);
                }
                else
                {

                    xx = 0.5 * (a1 / a2);
                    if (((StartForm)Application.OpenForms["StartForm"]).rB2.Checked || ((StartForm)Application.OpenForms["StartForm"]).rB1.Checked)
                    {
                        al.Add(xx);
                        abort++;
                    }
                    else
                    {
                         al.Add(xx);
                         abort++;
                        ((StartForm)Application.OpenForms["StartForm"]).OutTB.Text += "Итерация №" + sch++ + Environment.NewLine + xx.ToString() + Environment.NewLine;
                    }
                    c1 = Math.Abs((min - Y(xx)) / Y(xx));
                    c2 = Math.Abs((xmin - xx) / xx);
                    if (double.IsNaN(c1) || double.IsNaN(c2)) Res(al);
                    if (c1 < eps1 && c2 < eps2)
                    {
                        Res(al);
                    }
                    else
                    {
                        if (c1 >= eps1 || c2 >= eps2 && CheckInterval(x1, x3, xx))
                        {
                            ChoosePoint(x1, x2, x3, xx, xmin, eps1, eps2);
                        }
                        else
                        {
                            if (c1 >= eps1 || c2 >= eps2 && !CheckInterval(x1, x3, xx))
                            {
                                Points(xx, double.Parse(((StartForm)Application.OpenForms["StartForm"]).tB2.Text), eps1, eps2);
                            }
                        }
                    }

                }
            }
            catch (StackOverflowException ex)
            {
                MessageBox.Show("Exception вылетел " + ex);
            }


        }
    }
}