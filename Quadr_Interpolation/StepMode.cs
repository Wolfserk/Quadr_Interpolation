using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quadr_Interpolation
{
    class StepMode
    { 
        public static int c = 0;
        public static ArrayList al = new ArrayList();

        static void ChoosePoint(double x1, double x2, double x3, double xx, double xmin, double eps1, double eps2)
        {
            if (xx < xmin)
            {
                if (xx >= x1 && xx <= x2)
                {
                    Min(x1, xx, x2, eps1, eps2);
                }
                else
                {
                    Min(x2, xx, x3, eps1, eps2);
                }
            }
            else
            {
                if (xmin >= x1 && xmin <= x2)
                {
                    Min(x1, xmin, x2, eps1, eps1);
                }
                else
                {
                    Min(x2, xmin, x3, eps1, eps2);
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
        public void Res(ArrayList res)
        {

            ((StartForm)Application.OpenForms["StartForm"]).tB5.Text = res[res.Count-1].ToString();
            ((StartForm)Application.OpenForms["StartForm"]).drawStep(double.Parse(res[res.Count - 1].ToString()));
           // ((StartForm)Application.OpenForms["StartForm"]).OutTB.Text += "Итерация № 1" + Environment.NewLine + "X=" + res[res.Count-res.Count].ToString() + Environment.NewLine;

        }

        public static void Points(double x1, double dx, double eps1, double eps2)
        {
            double x2, x3;
            x2 = x1 + dx;

            if (StaticMode.Y(x1) > StaticMode.Y(x2))
            {
                x3 = x1 + 2 * dx;
            }
            else
            {
                x3 = x1 - dx;
            }
            Min(x1, x2, x3, eps1, eps2);

        }
        static void Min(double x1, double x2, double x3, double eps1, double eps2)
        {
            try
            {
                int ymin;
                double xmin = 0;
                double xx, a1, a2, min, c1, c2;
                double[] arr = new double[3];
                arr[0] = StaticMode.Y(x1);
                arr[1] = StaticMode.Y(x2);
                arr[2] = StaticMode.Y(x3);
                min = arr.Min();
                ymin = Array.IndexOf(arr, min);
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
                a1 = (x2 * x2 - x3 * x3) * StaticMode.Y(x1) + (x3 * x3 - x1 * x1) * StaticMode.Y(x2) + (x1 * x1 - x2 * x2) * StaticMode.Y(x3);
                a2 = (x2 - x3) * StaticMode.Y(x1) + (x3 - x1) * StaticMode.Y(x2) + (x1 - x2) * StaticMode.Y(x3);
                if (a2 == 0)
                {
                    Points(xmin, double.Parse(((StartForm)Application.OpenForms["StartForm"]).tB2.Text), eps1, eps2);
                }
                else
                {
                    xx = 0.5 * (a1 / a2);
                    al.Add(xx);
                    c1 = Math.Abs((min - StaticMode.Y(xx)) / StaticMode.Y(xx));
                    c2 = Math.Abs((xmin - xx) / xx);
                    if (c1 < eps1 && c2 < eps2)
                    {
                        StepMode sm = new StepMode();
                        sm.Res(al);
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
                                Points(xx, double.Parse(((StartForm)Application.OpenForms["StartForm"]).tB2.Text), eps1, eps2);
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
