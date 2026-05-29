namespace WinFormsApp
{
    partial class MainForm
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
            panelLb = new Panel();
            label1 = new Label();
            tsMenu = new ToolStrip();
            btnOpen = new ToolStripButton();
            btnInfoView = new ToolStripButton();
            panelMenu = new Panel();
            clickBtn = new Button();
            resultLb = new TextBox();
            menuBarCtrl = new TopMenuBarControl();
            userCtl = new UserCtl();
            checkBox1 = new CheckBox();
            ezTreeViewControl = new EZTreeViewControl();
            this.btnPrint = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnPrintPhotoList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintFileInfo = new System.Windows.Forms.ToolStripMenuItem();
            panelLb.SuspendLayout();
            tsMenu.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelLb
            // 
            panelLb.BorderStyle = BorderStyle.FixedSingle;
            panelLb.Controls.Add(label1);
            panelLb.Dock = DockStyle.Top;
            panelLb.Enabled = false;
            panelLb.Location = new Point(0, 125);
            panelLb.Margin = new Padding(9, 6, 9, 6);
            panelLb.Name = "panelLb";
            panelLb.Size = new Size(1486, 83);
            panelLb.TabIndex = 1;
            panelLb.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 41);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // tsMenu
            // 
            tsMenu.GripStyle = ToolStripGripStyle.Hidden;
            tsMenu.ImageScalingSize = new Size(20, 20);
            tsMenu.Items.AddRange(new ToolStripItem[] { btnOpen, btnInfoView, btnPrint });
            tsMenu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            tsMenu.Location = new Point(0, 0);
            tsMenu.Name = "tsMenu";
            tsMenu.RenderMode = ToolStripRenderMode.System;
            tsMenu.Size = new Size(1484, 41);
            tsMenu.TabIndex = 0;
            tsMenu.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintPhotoList,
            this.btnPrintHistory,
            this.btnPrintFileInfo});
           
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShowDropDownArrow = false;
            this.btnPrint.Size = new System.Drawing.Size(60, 35);
            this.btnPrint.Text = "印　刷";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // btnPrintPhotoList
            // 
            this.btnPrintPhotoList.Name = "btnPrintPhotoList";
            this.btnPrintPhotoList.Size = new System.Drawing.Size(231, 26);
            this.btnPrintPhotoList.Text = "写真一覧印刷 (&P)...";
            // 
            // btnPrintHistory
            // 
            this.btnPrintHistory.Name = "btnPrintHistory";
            this.btnPrintHistory.Size = new System.Drawing.Size(231, 26);
            this.btnPrintHistory.Text = "検査履歴印刷 (&L)...";
            // 
            // btnPrintFileInfo
            // 
            this.btnPrintFileInfo.Name = "btnPrintFileInfo";
            this.btnPrintFileInfo.Size = new System.Drawing.Size(231, 26);
            this.btnPrintFileInfo.Text = "ファイル情報印刷 (&F)...";
            // 
            // btnOpen
            // 
            btnOpen.AutoSize = false;
            btnOpen.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpen.ImageAlign = ContentAlignment.TopCenter;
            btnOpen.ImageScaling = ToolStripItemImageScaling.None;
            btnOpen.ImageTransparentColor = Color.Magenta;
            btnOpen.Margin = new Padding(2, 0, 0, 0);
            btnOpen.Name = "btnOpen";
            btnOpen.Overflow = ToolStripItemOverflow.Never;
            btnOpen.Size = new Size(60, 35);
            btnOpen.Text = "Open Folder";
            btnOpen.TextAlign = ContentAlignment.BottomCenter;
            btnOpen.TextImageRelation = TextImageRelation.Overlay;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnInfoView
            // 
            btnInfoView.AutoSize = false;
            btnInfoView.Checked = true;
            btnInfoView.CheckOnClick = true;
            btnInfoView.CheckState = CheckState.Checked;
            btnInfoView.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInfoView.ImageAlign = ContentAlignment.TopCenter;
            btnInfoView.ImageScaling = ToolStripItemImageScaling.None;
            btnInfoView.ImageTransparentColor = Color.Magenta;
            btnInfoView.Name = "btnInfoView";
            btnInfoView.Overflow = ToolStripItemOverflow.Never;
            btnInfoView.Size = new Size(60, 35);
            btnInfoView.Text = "InfoView";
            btnInfoView.TextAlign = ContentAlignment.BottomCenter;
            btnInfoView.TextImageRelation = TextImageRelation.Overlay;
            // 
            // panelMenu
            // 
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(tsMenu);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 42);
            panelMenu.Margin = new Padding(9, 6, 9, 6);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1486, 83);
            panelMenu.TabIndex = 1;
            // 
            // clickBtn
            // 
            clickBtn.Location = new Point(258, 301);
            clickBtn.Margin = new Padding(6, 6, 6, 6);
            clickBtn.Name = "clickBtn";
            clickBtn.Size = new Size(139, 49);
            clickBtn.TabIndex = 0;
            clickBtn.Text = "click";
            clickBtn.UseVisualStyleBackColor = true;
            clickBtn.Click += OnClickBtn_Click;
            // 
            // resultLb
            // 
            resultLb.Location = new Point(700, 343);
            resultLb.Margin = new Padding(6, 6, 6, 6);
            resultLb.Name = "resultLb";
            resultLb.Size = new Size(63, 39);
            resultLb.TabIndex = 1;
            resultLb.Text = "result";
            // 
            // menuBarCtrl
            // 
            menuBarCtrl.BackColor = Color.White;
            menuBarCtrl.Dock = DockStyle.Top;
            menuBarCtrl.Location = new Point(0, 0);
            menuBarCtrl.Margin = new Padding(0);
            menuBarCtrl.Name = "menuBarCtrl";
            menuBarCtrl.Size = new Size(1486, 42);
            menuBarCtrl.TabIndex = 2;
            // 
            // userCtl
            // 
            userCtl.BackColor = Color.White;
            userCtl.Location = new Point(548, 148);
            userCtl.Margin = new Padding(0);
            userCtl.Name = "userCtl";
            userCtl.Size = new Size(929, 640);
            userCtl.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.Location = new Point(0, 0);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 24);
            checkBox1.TabIndex = 0;
            // 
            // ezTreeViewControl
            // 
            ezTreeViewControl.Location = new Point(9, 214);
            ezTreeViewControl.Margin = new Padding(0);
            ezTreeViewControl.Name = "ezTreeViewControl";
            ezTreeViewControl.Size = new Size(500, 3008);
            ezTreeViewControl.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(ezTreeViewControl);
            Controls.Add(resultLb);
            Controls.Add(clickBtn);
            Controls.Add(panelLb);
            Controls.Add(panelMenu);
            Controls.Add(userCtl);
            Controls.Add(menuBarCtrl);
            Margin = new Padding(6, 6, 6, 6);
            Name = "MainForm";
            Text = "Form1";
            panelLb.ResumeLayout(false);
            panelLb.PerformLayout();
            tsMenu.ResumeLayout(false);
            tsMenu.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private System.Windows.Forms.Panel panelLb;
        private System.Windows.Forms.Panel panelMenu;
        private ToolStrip tsMenu;
        private Button clickBtn;
        private TextBox resultLb;
        private ToolStripButton btnOpen;
        private Label label1;
        private TopMenuBarControl menuBarCtrl;
        private System.Windows.Forms.ToolStripButton btnInfoView;
         private UserCtl userCtl;
        private CheckBox checkBox1;
        private EZTreeViewControl ezTreeViewControl;
        private ToolStripDropDownButton btnPrint;
        private ToolStripMenuItem btnPrintPhotoList;
        private ToolStripMenuItem btnPrintHistory;
        private ToolStripMenuItem btnPrintFileInfo;
    }
}
