﻿
namespace WinTool_json
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonUlozit = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bindingNavigatorProcesy = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewProcesy = new System.Windows.Forms.DataGridView();
            this.dataGridViewPodmienky = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorPodmienky = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelProcesy = new System.Windows.Forms.Label();
            this.labelPodmienky = new System.Windows.Forms.Label();
            this.buttonUmiestnitPDF = new System.Windows.Forms.Button();
            this.buttonZdrojovyPriecinok = new System.Windows.Forms.Button();
            this.buttonSpracovanyPriecinok = new System.Windows.Forms.Button();
            this.labelSpracovavam = new System.Windows.Forms.Label();
            this.labelPerioda = new System.Windows.Forms.Label();
            this.textBoxPerioda = new System.Windows.Forms.TextBox();
            this.checkBoxSpustene = new System.Windows.Forms.CheckBox();
            this.labelCopyright = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorProcesy)).BeginInit();
            this.bindingNavigatorProcesy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPodmienky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPodmienky)).BeginInit();
            this.bindingNavigatorPodmienky.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUlozit
            // 
            this.buttonUlozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUlozit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUlozit.Location = new System.Drawing.Point(837, 437);
            this.buttonUlozit.Name = "buttonUlozit";
            this.buttonUlozit.Size = new System.Drawing.Size(120, 54);
            this.buttonUlozit.TabIndex = 0;
            this.buttonUlozit.Text = "&Uložiť";
            this.buttonUlozit.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Program pre triedenie fotoalbumov";
            this.notifyIcon.BalloonTipTitle = "WinTool-JSON";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WinTool-JSON";
            this.notifyIcon.Visible = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 557);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(945, 23);
            this.progressBar.TabIndex = 1;
            // 
            // bindingNavigatorProcesy
            // 
            this.bindingNavigatorProcesy.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorProcesy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bindingNavigatorProcesy.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorProcesy.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorProcesy.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigatorProcesy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorProcesy.Location = new System.Drawing.Point(12, 494);
            this.bindingNavigatorProcesy.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorProcesy.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorProcesy.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorProcesy.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorProcesy.Name = "bindingNavigatorProcesy";
            this.bindingNavigatorProcesy.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorProcesy.Size = new System.Drawing.Size(249, 25);
            this.bindingNavigatorProcesy.TabIndex = 3;
            this.bindingNavigatorProcesy.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Přidat nový";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Celkový počet položek";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Odstranit";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Přesunout na první";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Přesunout na předchozí";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Umístění";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuální pozice";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Přesunout na další";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Přesunout na poslední";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewProcesy
            // 
            this.dataGridViewProcesy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewProcesy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcesy.Location = new System.Drawing.Point(12, 43);
            this.dataGridViewProcesy.Name = "dataGridViewProcesy";
            this.dataGridViewProcesy.Size = new System.Drawing.Size(281, 448);
            this.dataGridViewProcesy.TabIndex = 6;
            // 
            // dataGridViewPodmienky
            // 
            this.dataGridViewPodmienky.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPodmienky.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPodmienky.Location = new System.Drawing.Point(346, 43);
            this.dataGridViewPodmienky.Name = "dataGridViewPodmienky";
            this.dataGridViewPodmienky.Size = new System.Drawing.Size(461, 448);
            this.dataGridViewPodmienky.TabIndex = 7;
            // 
            // bindingNavigatorPodmienky
            // 
            this.bindingNavigatorPodmienky.AddNewItem = this.toolStripButton1;
            this.bindingNavigatorPodmienky.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bindingNavigatorPodmienky.CountItem = this.toolStripLabel1;
            this.bindingNavigatorPodmienky.DeleteItem = this.toolStripButton2;
            this.bindingNavigatorPodmienky.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigatorPodmienky.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripButton2});
            this.bindingNavigatorPodmienky.Location = new System.Drawing.Point(346, 494);
            this.bindingNavigatorPodmienky.MoveFirstItem = this.toolStripButton3;
            this.bindingNavigatorPodmienky.MoveLastItem = this.toolStripButton6;
            this.bindingNavigatorPodmienky.MoveNextItem = this.toolStripButton5;
            this.bindingNavigatorPodmienky.MovePreviousItem = this.toolStripButton4;
            this.bindingNavigatorPodmienky.Name = "bindingNavigatorPodmienky";
            this.bindingNavigatorPodmienky.PositionItem = this.toolStripTextBox1;
            this.bindingNavigatorPodmienky.Size = new System.Drawing.Size(249, 25);
            this.bindingNavigatorPodmienky.TabIndex = 8;
            this.bindingNavigatorPodmienky.Text = "bindingNavigator2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Přidat nový";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "z {0}";
            this.toolStripLabel1.ToolTipText = "Celkový počet položek";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Odstranit";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Přesunout na první";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Přesunout na předchozí";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Umístění";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Aktuální pozice";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Přesunout na další";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Přesunout na poslední";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // labelProcesy
            // 
            this.labelProcesy.AutoSize = true;
            this.labelProcesy.Location = new System.Drawing.Point(12, 12);
            this.labelProcesy.Name = "labelProcesy";
            this.labelProcesy.Size = new System.Drawing.Size(45, 13);
            this.labelProcesy.TabIndex = 9;
            this.labelProcesy.Text = "Procesy";
            // 
            // labelPodmienky
            // 
            this.labelPodmienky.AutoSize = true;
            this.labelPodmienky.Location = new System.Drawing.Point(343, 12);
            this.labelPodmienky.Name = "labelPodmienky";
            this.labelPodmienky.Size = new System.Drawing.Size(100, 13);
            this.labelPodmienky.TabIndex = 10;
            this.labelPodmienky.Text = "Podmienky procesu";
            // 
            // buttonUmiestnitPDF
            // 
            this.buttonUmiestnitPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUmiestnitPDF.Location = new System.Drawing.Point(687, 494);
            this.buttonUmiestnitPDF.Name = "buttonUmiestnitPDF";
            this.buttonUmiestnitPDF.Size = new System.Drawing.Size(120, 25);
            this.buttonUmiestnitPDF.TabIndex = 11;
            this.buttonUmiestnitPDF.Text = "Umiestniť &PDF do ...";
            this.buttonUmiestnitPDF.UseVisualStyleBackColor = true;
            // 
            // buttonZdrojovyPriecinok
            // 
            this.buttonZdrojovyPriecinok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZdrojovyPriecinok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZdrojovyPriecinok.Location = new System.Drawing.Point(837, 295);
            this.buttonZdrojovyPriecinok.Name = "buttonZdrojovyPriecinok";
            this.buttonZdrojovyPriecinok.Size = new System.Drawing.Size(120, 54);
            this.buttonZdrojovyPriecinok.TabIndex = 12;
            this.buttonZdrojovyPriecinok.Text = "&Zdrojový priečinok";
            this.buttonZdrojovyPriecinok.UseVisualStyleBackColor = true;
            // 
            // buttonSpracovanyPriecinok
            // 
            this.buttonSpracovanyPriecinok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSpracovanyPriecinok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSpracovanyPriecinok.Location = new System.Drawing.Point(837, 367);
            this.buttonSpracovanyPriecinok.Name = "buttonSpracovanyPriecinok";
            this.buttonSpracovanyPriecinok.Size = new System.Drawing.Size(120, 54);
            this.buttonSpracovanyPriecinok.TabIndex = 13;
            this.buttonSpracovanyPriecinok.Text = "&Spracovaný priečinok";
            this.buttonSpracovanyPriecinok.UseVisualStyleBackColor = true;
            // 
            // labelSpracovavam
            // 
            this.labelSpracovavam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSpracovavam.Location = new System.Drawing.Point(12, 541);
            this.labelSpracovavam.Name = "labelSpracovavam";
            this.labelSpracovavam.Size = new System.Drawing.Size(945, 13);
            this.labelSpracovavam.TabIndex = 14;
            this.labelSpracovavam.Text = "Spracovávam ...";
            // 
            // labelPerioda
            // 
            this.labelPerioda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerioda.AutoSize = true;
            this.labelPerioda.Location = new System.Drawing.Point(834, 43);
            this.labelPerioda.Name = "labelPerioda";
            this.labelPerioda.Size = new System.Drawing.Size(116, 13);
            this.labelPerioda.TabIndex = 16;
            this.labelPerioda.Text = "Perioda spustenia [min]";
            // 
            // textBoxPerioda
            // 
            this.textBoxPerioda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPerioda.Location = new System.Drawing.Point(837, 59);
            this.textBoxPerioda.Name = "textBoxPerioda";
            this.textBoxPerioda.Size = new System.Drawing.Size(113, 20);
            this.textBoxPerioda.TabIndex = 17;
            this.textBoxPerioda.Text = "5";
            // 
            // checkBoxSpustene
            // 
            this.checkBoxSpustene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSpustene.AutoSize = true;
            this.checkBoxSpustene.Location = new System.Drawing.Point(837, 94);
            this.checkBoxSpustene.Name = "checkBoxSpustene";
            this.checkBoxSpustene.Size = new System.Drawing.Size(71, 17);
            this.checkBoxSpustene.TabIndex = 18;
            this.checkBoxSpustene.Text = "Spustené";
            this.checkBoxSpustene.UseVisualStyleBackColor = true;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCopyright.Location = new System.Drawing.Point(12, 587);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelCopyright.Size = new System.Drawing.Size(945, 13);
            this.labelCopyright.TabIndex = 19;
            this.labelCopyright.Text = "Software by Zdenko Sekerák, www.trsek.com";
            this.labelCopyright.Click += new System.EventHandler(this.labelCopyright_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 603);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.checkBoxSpustene);
            this.Controls.Add(this.textBoxPerioda);
            this.Controls.Add(this.labelPerioda);
            this.Controls.Add(this.labelSpracovavam);
            this.Controls.Add(this.buttonSpracovanyPriecinok);
            this.Controls.Add(this.buttonZdrojovyPriecinok);
            this.Controls.Add(this.buttonUmiestnitPDF);
            this.Controls.Add(this.labelPodmienky);
            this.Controls.Add(this.labelProcesy);
            this.Controls.Add(this.bindingNavigatorPodmienky);
            this.Controls.Add(this.dataGridViewPodmienky);
            this.Controls.Add(this.dataGridViewProcesy);
            this.Controls.Add(this.bindingNavigatorProcesy);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonUlozit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "WinTool-JSON";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorProcesy)).EndInit();
            this.bindingNavigatorProcesy.ResumeLayout(false);
            this.bindingNavigatorProcesy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPodmienky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPodmienky)).EndInit();
            this.bindingNavigatorPodmienky.ResumeLayout(false);
            this.bindingNavigatorPodmienky.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUlozit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.BindingNavigator bindingNavigatorProcesy;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView dataGridViewProcesy;
        private System.Windows.Forms.DataGridView dataGridViewPodmienky;
        private System.Windows.Forms.BindingNavigator bindingNavigatorPodmienky;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label labelProcesy;
        private System.Windows.Forms.Label labelPodmienky;
        private System.Windows.Forms.Button buttonUmiestnitPDF;
        private System.Windows.Forms.Button buttonZdrojovyPriecinok;
        private System.Windows.Forms.Button buttonSpracovanyPriecinok;
        private System.Windows.Forms.Label labelSpracovavam;
        private System.Windows.Forms.Label labelPerioda;
        private System.Windows.Forms.TextBox textBoxPerioda;
        private System.Windows.Forms.CheckBox checkBoxSpustene;
        private System.Windows.Forms.Label labelCopyright;
    }
}

