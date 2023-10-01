namespace AdhanyDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lbl_settingInfo = new Label();
            groupBox1 = new GroupBox();
            panel4 = new Panel();
            ddl_method = new ComboBox();
            label4 = new Label();
            btn_save = new Button();
            panel3 = new Panel();
            ddl_city = new ComboBox();
            label3 = new Label();
            panel2 = new Panel();
            ddl_country = new ComboBox();
            label2 = new Label();
            table_fetchedData = new TableLayoutPanel();
            res_isha = new Label();
            res_maghrib = new Label();
            res_asir = new Label();
            res_dhuhr = new Label();
            res_sunrise = new Label();
            res_fajr = new Label();
            res_hijri = new Label();
            res_date = new Label();
            lbl_location = new Label();
            lbl_date = new Label();
            lbl_hijri = new Label();
            lbl_fajr = new Label();
            lbl_sunrise = new Label();
            lbl_dhuhr = new Label();
            lbl_asir = new Label();
            lbl_mahgrib = new Label();
            lbl_isha = new Label();
            label8 = new Label();
            res_location = new Label();
            statusStrip1 = new StatusStrip();
            statusProgressBar = new ToolStripProgressBar();
            statusLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            resetSettingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            table_fetchedData.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_settingInfo);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(12, 38);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15, 0, 15, 15);
            panel1.Size = new Size(256, 303);
            panel1.TabIndex = 0;
            // 
            // lbl_settingInfo
            // 
            lbl_settingInfo.AutoSize = true;
            lbl_settingInfo.Location = new Point(0, 12);
            lbl_settingInfo.MaximumSize = new Size(256, 0);
            lbl_settingInfo.Name = "lbl_settingInfo";
            lbl_settingInfo.Size = new Size(239, 30);
            lbl_settingInfo.TabIndex = 1;
            lbl_settingInfo.Text = "Please select your location. You can change these settings at any time.";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel4);
            groupBox1.Controls.Add(btn_save);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel2);
            groupBox1.Location = new Point(0, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(256, 258);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(ddl_method);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(19, 133);
            panel4.Margin = new Padding(5, 0, 5, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(0, 0, 10, 10);
            panel4.Size = new Size(219, 57);
            panel4.TabIndex = 4;
            // 
            // ddl_method
            // 
            ddl_method.Dock = DockStyle.Bottom;
            ddl_method.FormattingEnabled = true;
            ddl_method.Location = new Point(0, 24);
            ddl_method.Name = "ddl_method";
            ddl_method.Size = new Size(209, 23);
            ddl_method.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(124, 15);
            label4.TabIndex = 0;
            label4.Text = "Method of calculation";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(19, 208);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(79, 28);
            btn_save.TabIndex = 5;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(ddl_city);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(19, 76);
            panel3.Margin = new Padding(5, 0, 5, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 0, 10, 10);
            panel3.Size = new Size(219, 57);
            panel3.TabIndex = 4;
            // 
            // ddl_city
            // 
            ddl_city.AutoCompleteMode = AutoCompleteMode.Append;
            ddl_city.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddl_city.Dock = DockStyle.Bottom;
            ddl_city.FormattingEnabled = true;
            ddl_city.Items.AddRange(new object[] { "Ottawa", "Riyadh" });
            ddl_city.Location = new Point(0, 24);
            ddl_city.Name = "ddl_city";
            ddl_city.Size = new Size(209, 23);
            ddl_city.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 0;
            label3.Text = "City";
            // 
            // panel2
            // 
            panel2.Controls.Add(ddl_country);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(19, 19);
            panel2.Margin = new Padding(5, 0, 5, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 10, 10);
            panel2.Size = new Size(219, 57);
            panel2.TabIndex = 3;
            // 
            // ddl_country
            // 
            ddl_country.AutoCompleteMode = AutoCompleteMode.Append;
            ddl_country.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddl_country.Dock = DockStyle.Bottom;
            ddl_country.FormattingEnabled = true;
            ddl_country.Items.AddRange(new object[] { "Canada", "Saudi Arabia" });
            ddl_country.Location = new Point(0, 24);
            ddl_country.Name = "ddl_country";
            ddl_country.Size = new Size(209, 23);
            ddl_country.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 0;
            label2.Text = "Country";
            // 
            // table_fetchedData
            // 
            table_fetchedData.AutoSize = true;
            table_fetchedData.BackColor = SystemColors.Control;
            table_fetchedData.ColumnCount = 2;
            table_fetchedData.ColumnStyles.Add(new ColumnStyle());
            table_fetchedData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table_fetchedData.Controls.Add(res_isha, 1, 9);
            table_fetchedData.Controls.Add(res_maghrib, 1, 8);
            table_fetchedData.Controls.Add(res_asir, 1, 7);
            table_fetchedData.Controls.Add(res_dhuhr, 1, 6);
            table_fetchedData.Controls.Add(res_sunrise, 1, 5);
            table_fetchedData.Controls.Add(res_fajr, 1, 4);
            table_fetchedData.Controls.Add(res_hijri, 1, 2);
            table_fetchedData.Controls.Add(res_date, 1, 1);
            table_fetchedData.Controls.Add(lbl_location, 0, 0);
            table_fetchedData.Controls.Add(lbl_date, 0, 1);
            table_fetchedData.Controls.Add(lbl_hijri, 0, 2);
            table_fetchedData.Controls.Add(lbl_fajr, 0, 4);
            table_fetchedData.Controls.Add(lbl_sunrise, 0, 5);
            table_fetchedData.Controls.Add(lbl_dhuhr, 0, 6);
            table_fetchedData.Controls.Add(lbl_asir, 0, 7);
            table_fetchedData.Controls.Add(lbl_mahgrib, 0, 8);
            table_fetchedData.Controls.Add(lbl_isha, 0, 9);
            table_fetchedData.Controls.Add(label8, 0, 3);
            table_fetchedData.Controls.Add(res_location, 1, 0);
            table_fetchedData.Location = new Point(305, 38);
            table_fetchedData.Name = "table_fetchedData";
            table_fetchedData.Padding = new Padding(10);
            table_fetchedData.RowCount = 10;
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table_fetchedData.Size = new Size(217, 303);
            table_fetchedData.TabIndex = 1;
            table_fetchedData.Visible = false;
            // 
            // res_isha
            // 
            res_isha.AutoSize = true;
            res_isha.Dock = DockStyle.Fill;
            res_isha.Location = new Point(75, 262);
            res_isha.Name = "res_isha";
            res_isha.Size = new Size(129, 31);
            res_isha.TabIndex = 19;
            res_isha.Text = "label13";
            // 
            // res_maghrib
            // 
            res_maghrib.AutoSize = true;
            res_maghrib.Dock = DockStyle.Fill;
            res_maghrib.Location = new Point(75, 234);
            res_maghrib.Name = "res_maghrib";
            res_maghrib.Size = new Size(129, 28);
            res_maghrib.TabIndex = 18;
            res_maghrib.Text = "label12";
            // 
            // res_asir
            // 
            res_asir.AutoSize = true;
            res_asir.Dock = DockStyle.Fill;
            res_asir.Location = new Point(75, 206);
            res_asir.Name = "res_asir";
            res_asir.Size = new Size(129, 28);
            res_asir.TabIndex = 17;
            res_asir.Text = "label11";
            // 
            // res_dhuhr
            // 
            res_dhuhr.AutoSize = true;
            res_dhuhr.Dock = DockStyle.Fill;
            res_dhuhr.Location = new Point(75, 178);
            res_dhuhr.Name = "res_dhuhr";
            res_dhuhr.Size = new Size(129, 28);
            res_dhuhr.TabIndex = 16;
            res_dhuhr.Text = "label10";
            // 
            // res_sunrise
            // 
            res_sunrise.AutoSize = true;
            res_sunrise.Dock = DockStyle.Fill;
            res_sunrise.Location = new Point(75, 150);
            res_sunrise.Name = "res_sunrise";
            res_sunrise.Size = new Size(129, 28);
            res_sunrise.TabIndex = 15;
            res_sunrise.Text = "label9";
            // 
            // res_fajr
            // 
            res_fajr.AutoSize = true;
            res_fajr.Dock = DockStyle.Fill;
            res_fajr.Location = new Point(75, 122);
            res_fajr.Name = "res_fajr";
            res_fajr.Size = new Size(129, 28);
            res_fajr.TabIndex = 14;
            res_fajr.Text = "label7";
            // 
            // res_hijri
            // 
            res_hijri.AutoSize = true;
            res_hijri.Dock = DockStyle.Fill;
            res_hijri.Location = new Point(75, 66);
            res_hijri.Name = "res_hijri";
            res_hijri.Size = new Size(129, 28);
            res_hijri.TabIndex = 13;
            res_hijri.Text = "label6";
            // 
            // res_date
            // 
            res_date.AutoSize = true;
            res_date.Dock = DockStyle.Fill;
            res_date.Location = new Point(75, 38);
            res_date.Name = "res_date";
            res_date.Size = new Size(129, 28);
            res_date.TabIndex = 12;
            res_date.Text = "label5";
            // 
            // lbl_location
            // 
            lbl_location.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_location.AutoSize = true;
            lbl_location.Location = new Point(13, 10);
            lbl_location.Name = "lbl_location";
            lbl_location.Size = new Size(56, 28);
            lbl_location.TabIndex = 0;
            lbl_location.Text = "Location:";
            // 
            // lbl_date
            // 
            lbl_date.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_date.AutoSize = true;
            lbl_date.Location = new Point(13, 38);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(56, 28);
            lbl_date.TabIndex = 1;
            lbl_date.Text = "Date:";
            // 
            // lbl_hijri
            // 
            lbl_hijri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_hijri.AutoSize = true;
            lbl_hijri.FlatStyle = FlatStyle.System;
            lbl_hijri.Location = new Point(13, 66);
            lbl_hijri.Name = "lbl_hijri";
            lbl_hijri.Size = new Size(56, 28);
            lbl_hijri.TabIndex = 2;
            lbl_hijri.Text = "Hijri:";
            // 
            // lbl_fajr
            // 
            lbl_fajr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_fajr.AutoSize = true;
            lbl_fajr.Location = new Point(13, 122);
            lbl_fajr.Name = "lbl_fajr";
            lbl_fajr.Size = new Size(56, 28);
            lbl_fajr.TabIndex = 4;
            lbl_fajr.Text = "Fajr:";
            // 
            // lbl_sunrise
            // 
            lbl_sunrise.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_sunrise.AutoSize = true;
            lbl_sunrise.Location = new Point(13, 150);
            lbl_sunrise.Name = "lbl_sunrise";
            lbl_sunrise.Size = new Size(56, 28);
            lbl_sunrise.TabIndex = 5;
            lbl_sunrise.Text = "Sunrise:";
            // 
            // lbl_dhuhr
            // 
            lbl_dhuhr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_dhuhr.AutoSize = true;
            lbl_dhuhr.Location = new Point(13, 178);
            lbl_dhuhr.Name = "lbl_dhuhr";
            lbl_dhuhr.Size = new Size(56, 28);
            lbl_dhuhr.TabIndex = 6;
            lbl_dhuhr.Text = "Dhuhr:";
            // 
            // lbl_asir
            // 
            lbl_asir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_asir.AutoSize = true;
            lbl_asir.Location = new Point(13, 206);
            lbl_asir.Name = "lbl_asir";
            lbl_asir.Size = new Size(56, 28);
            lbl_asir.TabIndex = 7;
            lbl_asir.Text = "Asir:";
            // 
            // lbl_mahgrib
            // 
            lbl_mahgrib.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_mahgrib.AutoSize = true;
            lbl_mahgrib.Location = new Point(13, 234);
            lbl_mahgrib.Name = "lbl_mahgrib";
            lbl_mahgrib.Size = new Size(56, 28);
            lbl_mahgrib.TabIndex = 8;
            lbl_mahgrib.Text = "Maghrib:";
            // 
            // lbl_isha
            // 
            lbl_isha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_isha.AutoSize = true;
            lbl_isha.Location = new Point(13, 262);
            lbl_isha.Name = "lbl_isha";
            lbl_isha.Size = new Size(56, 31);
            lbl_isha.TabIndex = 9;
            lbl_isha.Text = "Isha:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.LightGray;
            table_fetchedData.SetColumnSpan(label8, 2);
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(13, 94);
            label8.Name = "label8";
            label8.Size = new Size(191, 28);
            label8.TabIndex = 10;
            label8.Text = "Prayer Times";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // res_location
            // 
            res_location.AutoSize = true;
            res_location.Dock = DockStyle.Fill;
            res_location.Location = new Point(75, 10);
            res_location.Name = "res_location";
            res_location.Size = new Size(129, 28);
            res_location.TabIndex = 11;
            res_location.Text = "label1";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusProgressBar, statusLabel });
            statusStrip1.Location = new Point(0, 348);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(534, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusProgressBar
            // 
            statusProgressBar.Name = "statusProgressBar";
            statusProgressBar.Size = new Size(100, 16);
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 17);
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { resetSettingsToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(534, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // resetSettingsToolStripMenuItem
            // 
            resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            resetSettingsToolStripMenuItem.Size = new Size(92, 20);
            resetSettingsToolStripMenuItem.Text = "&Reset Settings";
            resetSettingsToolStripMenuItem.Click += resetSettingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(38, 20);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 370);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(table_fetchedData);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            table_fetchedData.ResumeLayout(false);
            table_fetchedData.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_settingInfo;
        private Panel panel2;
        private ComboBox ddl_country;
        private Label label2;
        private Button btn_save;
        private Panel panel4;
        private ComboBox ddl_method;
        private Label label4;
        private Panel panel3;
        private ComboBox ddl_city;
        private Label label3;
        private GroupBox groupBox1;
        private TableLayoutPanel table_fetchedData;
        private Label lbl_location;
        private Label lbl_date;
        private Label lbl_hijri;
        private Label lbl_fajr;
        private Label lbl_sunrise;
        private Label lbl_dhuhr;
        private Label lbl_asir;
        private Label lbl_mahgrib;
        private Label lbl_isha;
        private Label label8;
        private Label res_location;
        private Label res_maghrib;
        private Label res_asir;
        private Label res_dhuhr;
        private Label res_sunrise;
        private Label res_fajr;
        private Label res_hijri;
        private Label res_date;
        private Label res_isha;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar statusProgressBar;
        private ToolStripStatusLabel statusLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem resetSettingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}