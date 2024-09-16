namespace Quadr_Interpolation
{
    partial class StartForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tB1 = new System.Windows.Forms.TextBox();
            this.tB2 = new System.Windows.Forms.TextBox();
            this.tB3 = new System.Windows.Forms.TextBox();
            this.tB4 = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.help = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rB3 = new System.Windows.Forms.RadioButton();
            this.rB2 = new System.Windows.Forms.RadioButton();
            this.rB1 = new System.Windows.Forms.RadioButton();
            this.tB5 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.forward = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.OutTB = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.stop = new System.Windows.Forms.Button();
            this.pr = new System.Windows.Forms.Button();
            this.tB = new System.Windows.Forms.TrackBar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tB)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tB1
            // 
            this.tB1.Location = new System.Drawing.Point(167, 66);
            this.tB1.Name = "tB1";
            this.tB1.Size = new System.Drawing.Size(129, 20);
            this.tB1.TabIndex = 1;
            // 
            // tB2
            // 
            this.tB2.Location = new System.Drawing.Point(167, 92);
            this.tB2.Name = "tB2";
            this.tB2.Size = new System.Drawing.Size(129, 20);
            this.tB2.TabIndex = 2;
            // 
            // tB3
            // 
            this.tB3.Location = new System.Drawing.Point(167, 118);
            this.tB3.Name = "tB3";
            this.tB3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tB3.Size = new System.Drawing.Size(129, 20);
            this.tB3.TabIndex = 3;
            // 
            // tB4
            // 
            this.tB4.Location = new System.Drawing.Point(167, 144);
            this.tB4.Name = "tB4";
            this.tB4.Size = new System.Drawing.Size(129, 20);
            this.tB4.TabIndex = 4;
            // 
            // comboBox
            // 
            this.comboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "16",
            "127",
            "E"});
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "2*x^2+16/x",
            "127/4*x^2-61/4*x+2",
            "x^2-e^x"});
            this.comboBox.Location = new System.Drawing.Point(167, 39);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(129, 21);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "Оптимизировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Функция:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Начальное значение:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Величина шага:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(3, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Точность координаты:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(3, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Точность функции:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.help);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tB5);
            this.panel1.Controls.Add(this.comboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tB2);
            this.panel1.Controls.Add(this.tB1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tB3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tB4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 278);
            this.panel1.TabIndex = 13;
            // 
            // help
            // 
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.help.Location = new System.Drawing.Point(6, 4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(110, 27);
            this.help.TabIndex = 18;
            this.help.Text = "Справка";
            this.help.UseVisualStyleBackColor = true;
            this.help.Visible = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(3, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Результат оптимизации:Xmin=";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rB3);
            this.panel2.Controls.Add(this.rB2);
            this.panel2.Controls.Add(this.rB1);
            this.panel2.Location = new System.Drawing.Point(6, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 62);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(120, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Режим работы:";
            // 
            // rB3
            // 
            this.rB3.AutoSize = true;
            this.rB3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rB3.Location = new System.Drawing.Point(224, 21);
            this.rB3.Name = "rB3";
            this.rB3.Size = new System.Drawing.Size(111, 21);
            this.rB3.TabIndex = 2;
            this.rB3.TabStop = true;
            this.rB3.Text = "Статический";
            this.rB3.UseVisualStyleBackColor = true;
            this.rB3.CheckedChanged += new System.EventHandler(this.rB3_CheckedChanged);
            // 
            // rB2
            // 
            this.rB2.AutoSize = true;
            this.rB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rB2.Location = new System.Drawing.Point(127, 21);
            this.rB2.Name = "rB2";
            this.rB2.Size = new System.Drawing.Size(101, 21);
            this.rB2.TabIndex = 1;
            this.rB2.TabStop = true;
            this.rB2.Text = "Пошаговый";
            this.rB2.UseVisualStyleBackColor = true;
            this.rB2.CheckedChanged += new System.EventHandler(this.rB2_CheckedChanged);
            // 
            // rB1
            // 
            this.rB1.AutoSize = true;
            this.rB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rB1.Location = new System.Drawing.Point(9, 21);
            this.rB1.Name = "rB1";
            this.rB1.Size = new System.Drawing.Size(124, 21);
            this.rB1.TabIndex = 0;
            this.rB1.TabStop = true;
            this.rB1.Text = "Динамический";
            this.rB1.UseVisualStyleBackColor = true;
            this.rB1.CheckedChanged += new System.EventHandler(this.rB1_CheckedChanged);
            // 
            // tB5
            // 
            this.tB5.Location = new System.Drawing.Point(219, 243);
            this.tB5.Name = "tB5";
            this.tB5.ReadOnly = true;
            this.tB5.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tB5.Size = new System.Drawing.Size(122, 20);
            this.tB5.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(135, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 45);
            this.button2.TabIndex = 18;
            this.button2.Text = "Стандартный масштаб графика";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(365, 12);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(687, 407);
            this.zedGraph.TabIndex = 14;
            this.zedGraph.UseExtendedPrintDialog = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.forward);
            this.panel3.Controls.Add(this.back);
            this.panel3.Location = new System.Drawing.Point(365, 476);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 79);
            this.panel3.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(30, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Пошаговый режим!";
            // 
            // forward
            // 
            this.forward.Enabled = false;
            this.forward.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.forward.Location = new System.Drawing.Point(99, 31);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(80, 40);
            this.forward.TabIndex = 1;
            this.forward.Text = "Вперед";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // back
            // 
            this.back.Enabled = false;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.back.Location = new System.Drawing.Point(3, 31);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(80, 40);
            this.back.TabIndex = 0;
            this.back.TabStop = false;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // OutTB
            // 
            this.OutTB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OutTB.Location = new System.Drawing.Point(12, 296);
            this.OutTB.Multiline = true;
            this.OutTB.Name = "OutTB";
            this.OutTB.ReadOnly = true;
            this.OutTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutTB.Size = new System.Drawing.Size(347, 269);
            this.OutTB.TabIndex = 19;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.Location = new System.Drawing.Point(369, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 45);
            this.button3.TabIndex = 20;
            this.button3.Text = "Показать узловые точки";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button4.Location = new System.Drawing.Point(561, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 45);
            this.button4.TabIndex = 21;
            this.button4.Text = "Показать точку минимума";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Location = new System.Drawing.Point(365, 418);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 52);
            this.panel4.TabIndex = 22;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // stop
            // 
            this.stop.Enabled = false;
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stop.Location = new System.Drawing.Point(113, 48);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(80, 40);
            this.stop.TabIndex = 23;
            this.stop.Text = "Стоп";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // pr
            // 
            this.pr.Enabled = false;
            this.pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pr.Location = new System.Drawing.Point(3, 48);
            this.pr.Name = "pr";
            this.pr.Size = new System.Drawing.Size(80, 40);
            this.pr.TabIndex = 24;
            this.pr.Text = "Пауза";
            this.pr.UseVisualStyleBackColor = true;
            this.pr.Click += new System.EventHandler(this.pr_Click);
            // 
            // tB
            // 
            this.tB.Enabled = false;
            this.tB.LargeChange = 1;
            this.tB.Location = new System.Drawing.Point(210, 43);
            this.tB.Maximum = 5;
            this.tB.Minimum = 1;
            this.tB.Name = "tB";
            this.tB.Size = new System.Drawing.Size(138, 45);
            this.tB.TabIndex = 25;
            this.tB.Value = 3;
            this.tB.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.pr);
            this.panel5.Controls.Add(this.tB);
            this.panel5.Controls.Add(this.stop);
            this.panel5.Location = new System.Drawing.Point(632, 476);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(402, 91);
            this.panel5.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(207, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Скорость построения графика.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(110, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Динамический режим!";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1062, 577);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.OutTB);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.zedGraph);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1078, 616);
            this.MinimumSize = new System.Drawing.Size(1078, 616);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Одномерная оптимизация методом квадратичной интерполяции";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tB)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBox;
        public System.Windows.Forms.TextBox tB1;
        public System.Windows.Forms.TextBox tB2;
        public System.Windows.Forms.TextBox tB3;
        public System.Windows.Forms.TextBox tB4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zedGraph;
        public System.Windows.Forms.TextBox tB5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox OutTB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.RadioButton rB3;
        public System.Windows.Forms.RadioButton rB2;
        public System.Windows.Forms.RadioButton rB1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button pr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tB;
        private System.Windows.Forms.Button help;
    }
}

