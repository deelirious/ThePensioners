namespace Someren
{
    partial class Someren_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Someren_Form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAfsluiten = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.docentenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toonDocentenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoekKamersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bardienstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drankvoorraadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kassaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omzetrapportageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activiteitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activiteitenlijstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.begeleidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overSomerenAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.boxId = new System.Windows.Forms.TextBox();
            this.LblInstructions = new System.Windows.Forms.Label();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.drinkAddBtn = new System.Windows.Forms.Button();
            this.drinkPriceBox = new System.Windows.Forms.TextBox();
            this.drinkDeleteBtn = new System.Windows.Forms.Button();
            this.drinkNameBox = new System.Windows.Forms.TextBox();
            this.drinkUpdateBtn = new System.Windows.Forms.Button();
            this.drinkAmountBox = new System.Windows.Forms.TextBox();
            this.drinkAmountLbl = new System.Windows.Forms.Label();
            this.drinkNameLbl = new System.Windows.Forms.Label();
            this.drinkPriceLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.toolStripMenuItem5,
            this.docentenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.bardienstToolStripMenuItem,
            this.activiteitenToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1258, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuAfsluiten});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.bestandToolStripMenuItem.Text = "File";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // menuAfsluiten
            // 
            this.menuAfsluiten.Name = "menuAfsluiten";
            this.menuAfsluiten.Size = new System.Drawing.Size(184, 30);
            this.menuAfsluiten.Text = "Exit";
            this.menuAfsluiten.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(93, 29);
            this.toolStripMenuItem5.Text = "Students";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(214, 30);
            this.toolStripMenuItem6.Text = "Show Students";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // docentenToolStripMenuItem
            // 
            this.docentenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toonDocentenToolStripMenuItem});
            this.docentenToolStripMenuItem.Name = "docentenToolStripMenuItem";
            this.docentenToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.docentenToolStripMenuItem.Text = "Teachers";
            // 
            // toonDocentenToolStripMenuItem
            // 
            this.toonDocentenToolStripMenuItem.Name = "toonDocentenToolStripMenuItem";
            this.toonDocentenToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.toonDocentenToolStripMenuItem.Text = "Show Teachers";
            this.toonDocentenToolStripMenuItem.Click += new System.EventHandler(this.toonDocentenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.zoekKamersToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 29);
            this.toolStripMenuItem1.Text = "Rooms";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 30);
            this.toolStripMenuItem2.Text = "Show Rooms";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(209, 30);
            this.toolStripMenuItem3.Text = "Kamerindeling";
            // 
            // zoekKamersToolStripMenuItem
            // 
            this.zoekKamersToolStripMenuItem.Name = "zoekKamersToolStripMenuItem";
            this.zoekKamersToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
            this.zoekKamersToolStripMenuItem.Text = "Zoek Kamers";
            // 
            // bardienstToolStripMenuItem
            // 
            this.bardienstToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drankvoorraadToolStripMenuItem,
            this.kassaToolStripMenuItem,
            this.omzetrapportageToolStripMenuItem});
            this.bardienstToolStripMenuItem.Name = "bardienstToolStripMenuItem";
            this.bardienstToolStripMenuItem.Size = new System.Drawing.Size(115, 29);
            this.bardienstToolStripMenuItem.Text = "Bar services";
            this.bardienstToolStripMenuItem.Click += new System.EventHandler(this.bardienstToolStripMenuItem_Click);
            // 
            // drankvoorraadToolStripMenuItem
            // 
            this.drankvoorraadToolStripMenuItem.Name = "drankvoorraadToolStripMenuItem";
            this.drankvoorraadToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.drankvoorraadToolStripMenuItem.Text = "Drinking supply";
            this.drankvoorraadToolStripMenuItem.Click += new System.EventHandler(this.drankvoorraadToolStripMenuItem_Click);
            // 
            // kassaToolStripMenuItem
            // 
            this.kassaToolStripMenuItem.Name = "kassaToolStripMenuItem";
            this.kassaToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.kassaToolStripMenuItem.Text = "Cashier";
            // 
            // omzetrapportageToolStripMenuItem
            // 
            this.omzetrapportageToolStripMenuItem.Name = "omzetrapportageToolStripMenuItem";
            this.omzetrapportageToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.omzetrapportageToolStripMenuItem.Text = "Reports";
            // 
            // activiteitenToolStripMenuItem
            // 
            this.activiteitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activiteitenlijstToolStripMenuItem,
            this.begeleidersToolStripMenuItem,
            this.roosterToolStripMenuItem});
            this.activiteitenToolStripMenuItem.Name = "activiteitenToolStripMenuItem";
            this.activiteitenToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.activiteitenToolStripMenuItem.Text = "Activities";
            // 
            // activiteitenlijstToolStripMenuItem
            // 
            this.activiteitenlijstToolStripMenuItem.Name = "activiteitenlijstToolStripMenuItem";
            this.activiteitenlijstToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.activiteitenlijstToolStripMenuItem.Text = "Activity List";
            // 
            // begeleidersToolStripMenuItem
            // 
            this.begeleidersToolStripMenuItem.Name = "begeleidersToolStripMenuItem";
            this.begeleidersToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.begeleidersToolStripMenuItem.Text = "Coaches";
            // 
            // roosterToolStripMenuItem
            // 
            this.roosterToolStripMenuItem.Name = "roosterToolStripMenuItem";
            this.roosterToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.roosterToolStripMenuItem.Text = "Timetable";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overSomerenAppToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // overSomerenAppToolStripMenuItem
            // 
            this.overSomerenAppToolStripMenuItem.Name = "overSomerenAppToolStripMenuItem";
            this.overSomerenAppToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.overSomerenAppToolStripMenuItem.Text = "About SomerenApp";
            this.overSomerenAppToolStripMenuItem.Click += new System.EventHandler(this.overSomerenAppToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(18, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(871, 631);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TODO list for Someren";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblId);
            this.panel1.Controls.Add(this.boxId);
            this.panel1.Controls.Add(this.LblInstructions);
            this.panel1.Controls.Add(this.refreshBtn);
            this.panel1.Controls.Add(this.drinkAddBtn);
            this.panel1.Controls.Add(this.drinkPriceBox);
            this.panel1.Controls.Add(this.drinkDeleteBtn);
            this.panel1.Controls.Add(this.drinkNameBox);
            this.panel1.Controls.Add(this.drinkUpdateBtn);
            this.panel1.Controls.Add(this.drinkAmountBox);
            this.panel1.Controls.Add(this.drinkAmountLbl);
            this.panel1.Controls.Add(this.drinkNameLbl);
            this.panel1.Controls.Add(this.drinkPriceLbl);
            this.panel1.Location = new System.Drawing.Point(10, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 582);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(583, 37);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 20);
            this.lblId.TabIndex = 12;
            this.lblId.Text = "ID";
            // 
            // boxId
            // 
            this.boxId.Location = new System.Drawing.Point(658, 37);
            this.boxId.Name = "boxId";
            this.boxId.Size = new System.Drawing.Size(176, 26);
            this.boxId.TabIndex = 11;
            // 
            // LblInstructions
            // 
            this.LblInstructions.AutoSize = true;
            this.LblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInstructions.Location = new System.Drawing.Point(583, 532);
            this.LblInstructions.Name = "LblInstructions";
            this.LblInstructions.Size = new System.Drawing.Size(237, 40);
            this.LblInstructions.TabIndex = 10;
            this.LblInstructions.Text = "*Hover over Labels and Buttons \r\n  to see the instructions.";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(658, 390);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(176, 33);
            this.refreshBtn.TabIndex = 9;
            this.refreshBtn.Text = "Refresh the List";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // drinkAddBtn
            // 
            this.drinkAddBtn.Location = new System.Drawing.Point(658, 235);
            this.drinkAddBtn.Name = "drinkAddBtn";
            this.drinkAddBtn.Size = new System.Drawing.Size(176, 33);
            this.drinkAddBtn.TabIndex = 0;
            this.drinkAddBtn.Text = "Add";
            this.drinkAddBtn.UseVisualStyleBackColor = true;
            this.drinkAddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // drinkPriceBox
            // 
            this.drinkPriceBox.Location = new System.Drawing.Point(658, 127);
            this.drinkPriceBox.Name = "drinkPriceBox";
            this.drinkPriceBox.Size = new System.Drawing.Size(176, 26);
            this.drinkPriceBox.TabIndex = 3;
            this.drinkPriceBox.TextChanged += new System.EventHandler(this.drinkPriceBox_TextChanged);
            // 
            // drinkDeleteBtn
            // 
            this.drinkDeleteBtn.Location = new System.Drawing.Point(658, 336);
            this.drinkDeleteBtn.Name = "drinkDeleteBtn";
            this.drinkDeleteBtn.Size = new System.Drawing.Size(176, 33);
            this.drinkDeleteBtn.TabIndex = 8;
            this.drinkDeleteBtn.Text = "Delete";
            this.drinkDeleteBtn.UseVisualStyleBackColor = true;
            this.drinkDeleteBtn.Click += new System.EventHandler(this.drinkDeleteBtn_Click);
            // 
            // drinkNameBox
            // 
            this.drinkNameBox.Location = new System.Drawing.Point(658, 81);
            this.drinkNameBox.Name = "drinkNameBox";
            this.drinkNameBox.Size = new System.Drawing.Size(176, 26);
            this.drinkNameBox.TabIndex = 1;
            this.drinkNameBox.TextChanged += new System.EventHandler(this.drinkNameBox_TextChanged);
            // 
            // drinkUpdateBtn
            // 
            this.drinkUpdateBtn.Location = new System.Drawing.Point(658, 286);
            this.drinkUpdateBtn.Name = "drinkUpdateBtn";
            this.drinkUpdateBtn.Size = new System.Drawing.Size(176, 33);
            this.drinkUpdateBtn.TabIndex = 7;
            this.drinkUpdateBtn.Text = "Update";
            this.drinkUpdateBtn.UseVisualStyleBackColor = true;
            this.drinkUpdateBtn.Click += new System.EventHandler(this.drinkUpdateBtn_Click);
            // 
            // drinkAmountBox
            // 
            this.drinkAmountBox.Location = new System.Drawing.Point(658, 175);
            this.drinkAmountBox.Name = "drinkAmountBox";
            this.drinkAmountBox.Size = new System.Drawing.Size(176, 26);
            this.drinkAmountBox.TabIndex = 2;
            this.drinkAmountBox.TextChanged += new System.EventHandler(this.drinkAmountBox_TextChanged);
            // 
            // drinkAmountLbl
            // 
            this.drinkAmountLbl.AutoSize = true;
            this.drinkAmountLbl.Location = new System.Drawing.Point(583, 181);
            this.drinkAmountLbl.Name = "drinkAmountLbl";
            this.drinkAmountLbl.Size = new System.Drawing.Size(65, 20);
            this.drinkAmountLbl.TabIndex = 6;
            this.drinkAmountLbl.Text = "Amount";
            this.drinkAmountLbl.Click += new System.EventHandler(this.drinkAmountLbl_Click);
            // 
            // drinkNameLbl
            // 
            this.drinkNameLbl.AutoSize = true;
            this.drinkNameLbl.Location = new System.Drawing.Point(583, 87);
            this.drinkNameLbl.Name = "drinkNameLbl";
            this.drinkNameLbl.Size = new System.Drawing.Size(51, 20);
            this.drinkNameLbl.TabIndex = 4;
            this.drinkNameLbl.Text = "Name";
            this.drinkNameLbl.Click += new System.EventHandler(this.drinkNameLbl_Click);
            // 
            // drinkPriceLbl
            // 
            this.drinkPriceLbl.AutoSize = true;
            this.drinkPriceLbl.Location = new System.Drawing.Point(583, 133);
            this.drinkPriceLbl.Name = "drinkPriceLbl";
            this.drinkPriceLbl.Size = new System.Drawing.Size(44, 20);
            this.drinkPriceLbl.TabIndex = 5;
            this.drinkPriceLbl.Text = "Price";
            this.drinkPriceLbl.Click += new System.EventHandler(this.drinkPriceLbl_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(897, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 274);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "SomerenAdministratie is gestart.";
            this.notifyIcon1.BalloonTipTitle = "SomerenAdministratie";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SomerenAdministratie";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 661);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1258, 30);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 25);
            this.toolStripStatusLabel1.Text = " ";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 25);
            this.toolStripStatusLabel2.Text = " ";
            // 
            // Someren_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 691);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Someren_Form";
            this.Text = "SomerenAdministration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAfsluiten;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem activiteitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overSomerenAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bardienstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drankvoorraadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kassaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omzetrapportageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activiteitenlijstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem begeleidersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roosterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem zoekKamersToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem docentenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toonDocentenToolStripMenuItem;
        private System.Windows.Forms.Button drinkAddBtn;
        private System.Windows.Forms.TextBox drinkPriceBox;
        private System.Windows.Forms.TextBox drinkAmountBox;
        private System.Windows.Forms.TextBox drinkNameBox;
        private System.Windows.Forms.Button drinkDeleteBtn;
        private System.Windows.Forms.Button drinkUpdateBtn;
        private System.Windows.Forms.Label drinkAmountLbl;
        private System.Windows.Forms.Label drinkPriceLbl;
        private System.Windows.Forms.Label drinkNameLbl;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label LblInstructions;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox boxId;
    }
}

