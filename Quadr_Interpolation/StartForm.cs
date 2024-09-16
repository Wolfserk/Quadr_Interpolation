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
using ZedGraph;

namespace Quadr_Interpolation
{
    public partial class StartForm : Form
    {
        public static int sch = 0;
        public static int ix = -1;
        public int ii = 0;
        double x;
        double xx;
        int ax = 0;
        int dd = 0;
        int it = 1;
        double d;
        LineItem Dyn;
        double start=0, end=0, cur = 0;
        int StepD=1;

        LineItem point;
        LineItem minx;
        LineItem CurveG;
        PointPairList list_f = new PointPairList();
        PointPairList list_g = new PointPairList();
        PointPairList list_p = new PointPairList();
        PointPairList list_m = new PointPairList();


        PointPairList x_list = new PointPairList();
        PointPairList g_list = new PointPairList();
        PointPairList p_list = new PointPairList();
        
        public double mx()
        {
         double x1x = double.Parse(tB1.Text);
         double x2x = x1x + double.Parse(tB2.Text);
         double x3x = count_x2(x1x, x2x);
         return x3x+3;
        }
        public StartForm()
        {
            InitializeComponent();
            GraphPane pane = zedGraph.GraphPane;
            SetColors(pane);           
            zedGraph.ContextMenuBuilder +=
           new ZedGraphControl.ContextMenuBuilderEventHandler(zedGraph_ContextMenuBuilder);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DynamGraph();
        }
        public void Err()
        {
            MessageBox.Show("Ошибка");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraph.GraphPane;
            zedGraph.RestoreScale(zedGraph.GraphPane);
            sch = 0;
            ix = -1;
            ii = 0;
            ax = 0;
            it = 1;
            dd = 0;
            start = 0; end = 0; cur = 0;
            StepD = 1;
            tB.Value = 3;
            stop.Enabled = false;
            pr.Enabled = false;
            tB.Enabled = false;
            StaticMode.al.Clear();
            StaticMode.abort = 0; 
            tB5.Clear();
            OutTB.Clear();
            StaticMode.sch = 1;
            OutTB.Clear();
            if (comboBox.SelectedItem==null && comboBox.Text=="")
            {
                MessageBox.Show("Выберите или введите функцию!");
            }
            else
            {
               if(tB1.Text == null || !Double.TryParse(tB1.Text,out d) || Convert.ToDouble(tB1.Text)<=0)
                {
                    MessageBox.Show("Введите корректное начальное значение!");
                }
                else
                {
                    if (tB2.Text == null || !Double.TryParse(tB2.Text, out d) || double.Parse(tB2.Text)<=0)
                    {
                        MessageBox.Show("Введите корректную величину шага! (Положительное число больше 0)");
                    }
                    else
                    {
                        if (tB3.Text == null || !Double.TryParse(tB3.Text, out d)  || double.Parse(tB3.Text)<=0 || double.Parse(tB3.Text)>1)
                        {
                            MessageBox.Show("Введите точность функции (Положительное число от 0 до 1)");
                        }
                        else
                        {
                            if (tB4.Text == null || !Double.TryParse(tB4.Text, out d) || double.Parse(tB4.Text) <= 0 || double.Parse(tB4.Text) > 1)
                            {
                                MessageBox.Show("Введите точность координаты (Положительное число от 0 до 1)");
                            }
                            else
                            {
                                try
                                {
                                    if (rB1.Checked || rB2.Checked || rB3.Checked)
                                    {
                                        pane.CurveList.Clear();
                                        list_f.Clear();
                                        list_g.Clear();
                                        list_p.Clear();
                                        list_m.Clear();
                                        button2.Enabled = true;
                                        button3.Enabled = true;
                                        button4.Enabled = true;
                                        sch = 0;
                                        ix = -1;
                                        ii = 0;
                                        dd = 0;

                                        double x1 = 0, x2 = 0, x3 = 0;
                                        x1 = double.Parse(tB1.Text);
                                        x2 = x1 + double.Parse(tB2.Text);
                                        x3 = count_x2(x1, x2);

                                        // pane.CurveList.Clear();

                                        PointPairList listt = new PointPairList();
                                        double xmax = x3 + 3;
                                        double xmin = -xmax;

                                        for (double x = xmin; x <= xmax; x += double.Parse(tB2.Text) / 4)
                                        {
                                            listt.Add(x, StaticMode.Y(x));
                                        }
                                        
                                        LineItem tt = pane.AddCurve("", listt, Color.Green, SymbolType.None);
                                        tt.Line.IsVisible = false;
                                        zedGraph.RestoreScale(zedGraph.GraphPane);
                                        if (rB1.Checked)
                                        {
                                            Dyn = pane.AddCurve("", list_f, Color.Green, SymbolType.None);
                                            Dyn.Line.Width = 2;
                                            Dyn = pane.AddCurve("", list_g, Color.Red, SymbolType.None);
                                            Dyn.Line.Width = 4;
                                            Dyn = pane.AddCurve("", list_m, Color.Yellow, SymbolType.Circle);
                                            Dyn.Symbol.Size = 5;
                                            Dyn.Symbol.Fill.Type = FillType.Solid;
                                            Dyn = pane.AddCurve("", list_p, Color.BlueViolet, SymbolType.Diamond);
                                            Dyn.Line.IsVisible = false;
                                            Dyn.Symbol.Fill.Type = FillType.Solid;
                                            Dyn.Symbol.Size = 10;
                                            end = -(cur = start = -5);
                                            button3.Enabled = false;
                                            button4.Enabled = false;
                                            pr.Text = "Пауза";
                                            pr.Width = 80;
                                            stop.Enabled = true;
                                            tB.Enabled = true;
                                            pr.Enabled = true;
                                          
                                            PointPairList list = new PointPairList();
                                            LineItem f = pane.AddCurve("f(x) - График функции", list, Color.Green, SymbolType.None);
                                            LineItem g = pane.AddCurve("g(x) - График интерполяционной функции", list, Color.Red, SymbolType.None);
                                            LineItem y = pane.AddCurve("Узловые точки", list, Color.BlueViolet, SymbolType.Diamond);
                                            LineItem m = pane.AddCurve("Найденный минимум", list, Color.Yellow, SymbolType.Circle);
                                            y.Line.IsVisible = false;
                                            y.Symbol.Fill.Color = Color.LightGreen;
                                            y.Symbol.Fill.Type = FillType.Solid;
                                            y.Symbol.Size = 10;
                                            x = -mx();
                                            xx = x;
                                            StaticMode.Points(double.Parse(tB1.Text), double.Parse(tB2.Text), double.Parse(tB3.Text), double.Parse(tB4.Text));
                                        }
                                        else
                                        {
                                            if (rB2.Checked)
                                            {
                                                back.Enabled = false;
                                                forward.Enabled = true;
                                                StaticMode.Points(double.Parse(tB1.Text), double.Parse(tB2.Text), double.Parse(tB3.Text), double.Parse(tB4.Text));
                                            }
                                            else
                                            {
                                                back.Enabled = false;
                                                forward.Enabled = false;
                                                StaticMode.Points(double.Parse(tB1.Text), double.Parse(tB2.Text), double.Parse(tB3.Text), double.Parse(tB4.Text));

                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Выберите режим работы!");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Exception вылетел " + ex);
                                }
                            }
                        }
                    }
                }
            }
        }
        public double count_x2(double x0,double x1)
        {
            double x2;
            if (StaticMode.Y(x0) > StaticMode.Y(x1))
            {
               return x2 = x0 + 2 * double.Parse(tB2.Text);
            }
            else
            {
              return  x2 = x0 - double.Parse(tB2.Text);
            }
        }
        public double Interpolation_Graph(double x, double x0, double x1, double x2)
        {
            double e1 = ((x - x1) * (x - x2)) / ((x0 - x1) * (x0 - x2));
            double e2 = ((x - x0) * (x - x2)) / ((x1 - x0) * (x1 - x2));
            double e3 = ((x - x0) * (x - x1)) / ((x2 - x0) * (x2 - x1));
          //  if (double.IsInfinity(e1) || double.IsInfinity(e2) || double.IsInfinity(e3) || double.IsNaN(e1) || double.IsNaN(e2) || double.IsNaN(e3)) return x;
            double y = StaticMode.Y(x0) * e1 + StaticMode.Y(x1) * e2 + StaticMode.Y(x2) * e3;
            return y;
        }
        public void drawGraph(double res)
        {

            zedGraph.RestoreScale(zedGraph.GraphPane);
            GraphPane pane = zedGraph.GraphPane;
            double x1 = 0, x2 = 0, x3 = 0;
            x1 = double.Parse(tB1.Text);
            x2 = x1 + double.Parse(tB2.Text);
            x3 = count_x2(x1, x2);
          
            pane.CurveList.Clear();

            PointPairList f1_list = new PointPairList();

            PointPairList f2_list = new PointPairList();

            PointPairList p_list = new PointPairList();

            PointPairList x_list = new PointPairList();

            double xmax = x3+3;
            double xmin = -xmax;

            for (double x = xmin; x <= xmax; x += double.Parse(tB2.Text)/4)
            {
                f1_list.Add(x, StaticMode.Y(x));   
            }

            for (double x = xmin; x <= xmax; x += double.Parse(tB2.Text)/4)
            {
                if (double.IsInfinity(Interpolation_Graph(x, StaticMode.ax1[StaticMode.ax1.Count - 1], StaticMode.ax2[StaticMode.ax2.Count - 1], StaticMode.ax3[StaticMode.ax3.Count - 1])) || double.IsNaN(Interpolation_Graph(x, StaticMode.ax1[StaticMode.ax1.Count - 1], StaticMode.ax2[StaticMode.ax2.Count - 1], StaticMode.ax3[StaticMode.ax3.Count - 1])))
                {
                    x += double.Parse(tB2.Text) / 4;
                }
                {
                    f2_list.Add(x, Interpolation_Graph(x, StaticMode.ax1[StaticMode.ax1.Count - 1], StaticMode.ax2[StaticMode.ax2.Count - 1], StaticMode.ax3[StaticMode.ax3.Count - 1]));
                }
            }
            StaticMode sm = new StaticMode();
            p_list.Add(StaticMode.ax1[StaticMode.ax1.Count - 1], StaticMode.Y(StaticMode.ax1[StaticMode.ax1.Count - 1]));
            p_list.Add(StaticMode.ax2[StaticMode.ax2.Count - 1], StaticMode.Y(StaticMode.ax2[StaticMode.ax2.Count - 1]));
            p_list.Add(StaticMode.ax3[StaticMode.ax3.Count - 1], StaticMode.Y(StaticMode.ax3[StaticMode.ax3.Count - 1]));
            x_list.Add(res, StaticMode.Y(res));

            LineItem minx = pane.AddCurve("Найденный минимум", x_list, Color.Yellow, SymbolType.Circle);

            LineItem myCurve = pane.AddCurve("Узловые точки", p_list, Color.BlueViolet, SymbolType.Diamond);  

            LineItem f1_curve = pane.AddCurve("f(x) - График функции", f1_list, Color.Yellow, SymbolType.None);

            LineItem f2_curve = pane.AddCurve("g(x) - График интерполяционной функции", f2_list, Color.Red, SymbolType.None);

            myCurve.Line.IsVisible = false;

            myCurve.Symbol.Fill.Color = Color.BlueViolet;

            myCurve.Symbol.Fill.Type = FillType.Solid;

            myCurve.Symbol.Size = 13;

            minx.Line.IsVisible = false;

            minx.Symbol.Fill.Color = Color.Yellow;

            minx.Symbol.Fill.Type = FillType.Solid;

            minx.Symbol.Size = 8;

            f1_curve.Line.Width = 2;
            f2_curve.Line.Width = 4;

            f1_curve.Line.IsSmooth = true;
            f2_curve.Line.IsSmooth = true;
            zedGraph.AxisChange();

            zedGraph.Invalidate();
        }

        public void drawStepX(double res,int x)
        {
            double xmax = StaticMode.ax3[0]+3;
            double xmin = -xmax;
            GraphPane pane = zedGraph.GraphPane;

            if (x == 0) pane.CurveList.RemoveRange(1, 3);
            if (ix >= 0)
            {
                if (pane.CurveList.Count>=4)
                {
                    pane.CurveList.RemoveRange(1,3);
                    x_list.Clear();
                    p_list.Clear();
                    g_list.Clear();
                    x_list.Add(res, StaticMode.Y(res));
                    p_list.Add(StaticMode.ax1[ix], StaticMode.Y(StaticMode.ax1[ix]));
                    p_list.Add(StaticMode.ax2[ix], StaticMode.Y(StaticMode.ax2[ix]));
                    p_list.Add(StaticMode.ax3[ix], StaticMode.Y(StaticMode.ax3[ix]));
                    for (double xc = xmin; xc <= xmax; xc += double.Parse(tB2.Text) / 4)
                    {
                        g_list.Add(xc, Interpolation_Graph(xc, StaticMode.ax1[ix], StaticMode.ax2[ix], StaticMode.ax3[ix]));
                    }
                    point = pane.AddCurve("Узловые точки", p_list, Color.BlueViolet, SymbolType.Diamond);
                    minx = pane.AddCurve("Найденный минимум", x_list, Color.Yellow, SymbolType.Circle);
                    CurveG = pane.AddCurve("g(x) - График интерполяционной функции", g_list, Color.Red, SymbolType.None);
                    point.Line.IsVisible = false;
                    point.Symbol.Fill.Color = Color.BlueViolet;
                    point.Symbol.Fill.Type = FillType.Solid;
                    point.Symbol.Size = 8;
                    minx.Line.IsVisible = false;
                    minx.Symbol.Fill.Color = Color.Yellow;
                    minx.Symbol.Fill.Type = FillType.Solid;
                    minx.Symbol.Size = 10;
                    CurveG.Line.Width = 4;
                   
                }
                else
                {
                    x_list.Clear();
                    p_list.Clear();
                    g_list.Clear();
                    x_list.Add(res, StaticMode.Y(res));
                    p_list.Add(StaticMode.ax1[ix], StaticMode.Y(StaticMode.ax1[ix]));
                    p_list.Add(StaticMode.ax2[ix], StaticMode.Y(StaticMode.ax2[ix]));
                    p_list.Add(StaticMode.ax3[ix], StaticMode.Y(StaticMode.ax3[ix]));
                    for (double xc = xmin; xc <= xmax; xc += double.Parse(tB2.Text) / 4)
                    {
                        g_list.Add(xc, Interpolation_Graph(xc, StaticMode.ax1[ix], StaticMode.ax2[ix], StaticMode.ax3[ix]));
                    }
                    point = pane.AddCurve("Узловые точки", p_list, Color.BlueViolet, SymbolType.Diamond);
                    minx = pane.AddCurve("Найденный минимум", x_list, Color.Yellow, SymbolType.Circle);
                    CurveG = pane.AddCurve("g(x) - График интерполяционной функции", g_list, Color.Red, SymbolType.None);
                    point.Line.IsVisible = false;
                    point.Symbol.Fill.Color = Color.BlueViolet;
                    point.Symbol.Fill.Type = FillType.Solid;
                    point.Symbol.Size = 8;
                    minx.Line.IsVisible = false;
                    minx.Symbol.Fill.Color = Color.Yellow;
                    minx.Symbol.Fill.Type = FillType.Solid;
                    minx.Symbol.Size = 10;
                    CurveG.Line.Width = 4;
                }
                zedGraph.AxisChange();
                zedGraph.Invalidate();
            }
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
        public void drawStep(double res)
        {
            zedGraph.RestoreScale(zedGraph.GraphPane);

            GraphPane pane = zedGraph.GraphPane;
            double x1 = 0, x2 = 0, x3 = 0;
            x1 = double.Parse(tB1.Text);
            x2 = x1 + double.Parse(tB2.Text);
            x3 = count_x2(x1, x2);


            pane.CurveList.Clear();


            PointPairList f1_list = new PointPairList();


   

            double xmax = x3 + 3;
            double xmin = -xmax;


            for (double x = xmin; x <= xmax; x += double.Parse(tB2.Text) / 4)
            {
                f1_list.Add(x, StaticMode.Y(x));
            }



            LineItem f1_curve = pane.AddCurve("f(x) - График функции", f1_list, Color.Yellow, SymbolType.None);

            f1_curve.Line.Width = 2;
          

            f1_curve.Line.Width = 2;

            f1_curve.Line.IsSmooth = true;
           // f2_curve.Line.IsSmooth = true;
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        private static void SetColors(GraphPane pane)
        {
            // !!!
            // Установим цвет рамки для всего компонента
            pane.Border.Color = Color.Black;

            // Установим цвет рамки вокруг графика
            pane.Chart.Border.Color = Color.Green;

            // Закрасим фон всего компонента ZedGraph
            // Заливка будет сплошная
            pane.Fill.Type = FillType.Solid;
            pane.Fill.Color = Color.WhiteSmoke;

            // Закрасим область графика (его фон) в черный цвет
            pane.Chart.Fill.Type = FillType.Solid;
            pane.Chart.Fill.Color = Color.Black;

            // Включим показ оси на уровне X = 0 и Y = 0, чтобы видеть цвет осей
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;
            // Установим цвет осей
            pane.XAxis.Color = Color.Gray;
            pane.YAxis.Color = Color.Gray;


            // Установим цвет для подписей рядом с осями
            pane.XAxis.Title.FontSpec.FontColor = Color.Black;
            pane.YAxis.Title.FontSpec.FontColor = Color.Black;

            // Установим цвет подписей под метками
            pane.XAxis.Scale.FontSpec.FontColor = Color.Black;
            pane.YAxis.Scale.FontSpec.FontColor = Color.Black;

            // Установим цвет заголовка над графиком
            pane.Title.FontSpec.FontColor = Color.Black;

            pane.XAxis.Title.Text = "Ось X";


            // Изменим текст по оси Y
            pane.YAxis.Title.Text = "Ось Y";

            // Изменим текст заголовка графика
            pane.Title.Text = "График оптимизации:";
        }
        void zedGraph_ContextMenuBuilder(ZedGraphControl sender,
       ContextMenuStrip menuStrip,
       Point mousePt,
       ZedGraphControl.ContextMenuObjectState objState)
        {
            // !!! 
            // Переименуем (переведем на русский язык) некоторые пункты контекстного меню
            menuStrip.Items[0].Text = "Копировать";
            menuStrip.Items[1].Text = "Сохранить как картинку…";
            menuStrip.Items[2].Text = "Параметры страницы…";
            menuStrip.Items[3].Text = "Печать…";
            menuStrip.Items[4].Text = "Показывать значения в точках…";
            menuStrip.Items[7].Text = "Установить масштаб по умолчанию…";

            // Некоторые пункты удалим
            menuStrip.Items.RemoveAt(5);
            menuStrip.Items.RemoveAt(5);

            // Добавим свой пункт меню
            // ToolStripItem newMenuItem = new ToolStripMenuItem("Этот пункт меню ничего не делает");
            // menuStrip.Items.Add(newMenuItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zedGraph.RestoreScale(zedGraph.GraphPane);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraph.GraphPane;
            if (pane.CurveList.Count!=0)
            {
               // PointPairList p_list = new PointPairList();
                double x1 = double.Parse(tB1.Text);
                double x2 = x1 + double.Parse(tB2.Text);
                double x3 = count_x2(x1, x2);
             
                double dx = double.Parse(tB2.Text);

                double[] arrx = new double[3];
                // arrx[0] = (x1);
                // arrx[1] = (x2);
                // arrx[2] = (x3);

                   arrx[0] = (StaticMode.ax1[StaticMode.ax1.Count-1]);
                   arrx[1] = (StaticMode.ax2[StaticMode.ax2.Count - 1]);
                   arrx[2] = (StaticMode.ax3[StaticMode.ax3.Count - 1]);


                double[] arry = new double[3];
                //  arry[0] = StaticMode.Y(x1);
                //  arry[1] = StaticMode.Y(x2);
                //  arry[2] = StaticMode.Y(x3);

                  arry[0] = StaticMode.Y(arrx[0]);
                  arry[1] = StaticMode.Y(arrx[1]);
                  arry[2] = StaticMode.Y(arrx[2]);

                // p_list.Add(x1, arry[0]);
                //  p_list.Add(x2, arry[1]);
                //  p_list.Add(x3, arry[2]);

                //  LineItem myCurve = pane.AddCurve("", p_list, Color.BlueViolet, SymbolType.Diamond);

                //  myCurve.Line.IsVisible = false;
                // myCurve.Symbol.Fill.Color = Color.BlueViolet;
                // myCurve.Symbol.Fill.Type = FillType.Solid;
                // myCurve.Symbol.Size = 10;

                double xmax = arrx.Max();
                double xmin = arrx.Min();

                double ymax = arry.Max();
                double ymin = arry.Min();

               // double xmin_limit = xmin - 2.3;
               // double xmax_limit = xmax + 2.3;

              //  double ymin_limit = ymin - 2.3;
               // double ymax_limit = ymax + 2.3;

                double xmin_limit = xmin - dx;
                double xmax_limit = xmax + dx;

                double ymin_limit = ymin - dx;
                double ymax_limit = ymax + dx;

                pane.XAxis.Scale.Min = xmin_limit;
                pane.XAxis.Scale.Max = xmax_limit;

                pane.YAxis.Scale.Min = ymin_limit;
                pane.YAxis.Scale.Max = ymax_limit;

                zedGraph.AxisChange();

                zedGraph.Invalidate();
            }
            else
            {
                MessageBox.Show("График отсутствует!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraph.GraphPane;
            if (pane.CurveList.Count>=4 && OutTB.Text!="")
            {
                var lines = OutTB.Lines.ToList();
                
                double dx = double.Parse(tB2.Text);
                double xmin = double.Parse(lines[lines.Count-2]);

                double xmin_limit = xmin - 2*dx;
                double xmax_limit = xmin + 2*dx;

                double ymin_limit = StaticMode.Y(xmin) - 2*dx;
                double ymax_limit = StaticMode.Y(xmin) + 2*dx;
                
                pane.XAxis.Scale.Min = xmin_limit;
                pane.XAxis.Scale.Max = xmax_limit;

                pane.YAxis.Scale.Min = ymin_limit;
                pane.YAxis.Scale.Max = ymax_limit;

                zedGraph.AxisChange();

                zedGraph.Invalidate();
            }


            else
            {
                MessageBox.Show("Точка отсутствует на графике!");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            sch--; //Счетчик итераций (0)
            ix--; //Счетчик индекса списка точек (-1)
            ii--;  //Счетчик номера точки (для отрисовки точки) (0)
            var lines = OutTB.Lines.ToList(); //Построчное преобразование данных из textBox в список
            lines.RemoveRange(lines.Count - 3, 3); // Удаление последних трех записей
            OutTB.Lines = lines.ToArray(); // Добавление получившегося списка в textBox
            if (ix >= 0) { forward.Enabled = true; drawStepX(double.Parse(StaticMode.al[ix].ToString()),ii);} // Вызов отрисовки точки
            else
            { back.Enabled = false;
                drawStepX(0, ii); // Если "Назад" до первой итерации, то удаляем точку на графике
            }
        }

        private void forward_Click(object sender, EventArgs e)
        {
            ix++;
            sch++;
            ii++;
            OutTB.Text += Environment.NewLine + "Итерация №" + sch + Environment.NewLine + StaticMode.al[ix].ToString() + Environment.NewLine;
            drawStepX(double.Parse(StaticMode.al[ix].ToString()),ii);
            if (ix!= StaticMode.al.Count-1)back.Enabled = true;
            else
            forward.Enabled = false;
       }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            timer.Stop();
            pr.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            tB.Enabled = false;
            stop.Enabled = false;
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        public void StartDynam()
        {
            timer.Start();
        }
        private void pr_Click(object sender, EventArgs e)
        {
            if(pr.Text.Equals("Пауза"))
            {
                timer.Stop();
                pr.Width = 100;
                pr.Text = "Продолжить";
            }
            else
            {
                timer.Start();
                pr.Width = 80;
                pr.Text = "Пауза";
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (tB.Value)
            {
                case 1:
                    timer.Interval = 700;
                    break;
                case 2:
                    timer.Interval = 500;
                    break;
                case 3:
                    timer.Interval = 200;
                    break;
                case 4:
                    timer.Interval = 100;
                    break;
                case 5:
                    timer.Interval = 50;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
      public void  DynamGraph()
        {
            if (StepD == 1 && cur < end) DrawF();
            else if (StepD == 1) StepD = 2;
            if (StepD == 2) 
            {
                list_p.Clear();
                list_p.Add(StaticMode.ax1[ax], StaticMode.Y(StaticMode.ax1[ax]));
                list_p.Add(StaticMode.ax2[ax], StaticMode.Y(StaticMode.ax2[ax]));
                list_p.Add(StaticMode.ax3[ax], StaticMode.Y(StaticMode.ax3[ax]));
                OutTB.Text += "Итерация №" + it + Environment.NewLine + StaticMode.al[ax] + Environment.NewLine;
                it++;
                cur = start;
                StepD = 3;
                button3.Enabled = true;
            }
            if (StepD == 3 && cur < end) DrawG();
            else if (StepD == 3) StepD = 4;
            if (StepD == 4 && ax < StaticMode.al.Count-1)
            {
                list_m.Clear();
                
                list_m.Add(double.Parse(StaticMode.al[ax].ToString()), StaticMode.Y(double.Parse(StaticMode.al[ax].ToString())));
                if (ax < StaticMode.ax1.Count-1)
                {
                    list_g.Clear();
                    StepD = 2;  
                    ax++;
                    button4.Enabled=true;
                }
            }
            else if(StepD == 4)
            {
                timer.Stop();
            }
               
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            back.Enabled = false;
            forward.Enabled = false;
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            back.Enabled = false;
            forward.Enabled = false;
            pr.Enabled = false;
            tB.Enabled = false;
            stop.Enabled = false;
        }

        private void rB3_CheckedChanged(object sender, EventArgs e)
        {
            back.Enabled = false;
            forward.Enabled = false;
            pr.Enabled = false;
            tB.Enabled = false;
            stop.Enabled = false;
        }

        private void help_Click(object sender, EventArgs e)
        {
             Help.ShowHelp(this, "Help.chm", HelpNavigator.TableOfContents);
        }

        public void DrawF()
        {
            list_f.Add(cur,StaticMode.Y(cur));
            cur +=0.125;
        }

        public void DrawG()
        {
            list_g.Add(cur, Interpolation_Graph(cur,StaticMode.ax1[ax], StaticMode.ax2[ax], StaticMode.ax3[ax]));
            cur += 0.125;
        }
    }  
}
