
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp
{
    partial class TopMenuBarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnFile = new Button();
            btnEdit = new Button();
            btnView = new Button();
            btnSettings = new Button();
            btnHelp = new Button();
            menuFile = new ContextMenuStrip(components);
            mItem_File_FolderSelect = new CustomMenuItem();
            mItem_File_Reload = new CustomMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mItem_File_Print = new CustomMenuItem();
            mItem_File_PrintPhotoList = new CustomMenuItem();
            mItem_File_PrintInspectionHistory = new CustomMenuItem();
            mItem_File_PrintFileInfo = new CustomMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mItem_File_ImportCSV = new CustomMenuItem();
            mItem_File_ExportCSV = new CustomMenuItem();
            mItem_File_ExportFileInfoCSV = new CustomMenuItem();
            toolStripSeparator15 = new ToolStripSeparator();
            mItem_File_Transfer = new CustomMenuItem();
            mItem_File_ImportTransferData = new CustomMenuItem();
            mItem_File_ExportTransferData = new CustomMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            mItem_File_Exit = new CustomMenuItem();
            menuEdit = new ContextMenuStrip(components);
            mItem_Edit_Copy = new CustomMenuItem();
            menuView = new ContextMenuStrip(components);
            mItem_View_PhotoInfoXML = new CustomMenuItem();
            mItem_View_ConstructionInfoXML = new CustomMenuItem();
            toolStripSeparator16 = new ToolStripSeparator();
            mItem_View_TreeViewDisplay = new CustomMenuItem();
            mItem_View_PhotoInfoDisplay = new CustomMenuItem();
            mItem_View_PhotoDisplay = new CustomMenuItem();
            toolStripSeparator17 = new ToolStripSeparator();
            mItem_View_DisplayMode = new CustomMenuItem();
            mItem_View_DisplayModePhotoList = new CustomMenuItem();
            mItem_View_DisplayModePhotoInfo = new CustomMenuItem();
            mItem_View_DisplayModeFileInfo = new CustomMenuItem();
            mItem_View_PhotoConfirmation = new CustomMenuItem();
            mItem_View_PhotoCompare = new CustomMenuItem();
            toolStripSeparator18 = new ToolStripSeparator();
            mItem_View_PreviousPhoto = new CustomMenuItem();
            mItem_View_NextPhoto = new CustomMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            mItem_View_ToggleReference = new CustomMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            mItem_View_Rotate = new CustomMenuItem();
            mItem_View_RotateDefault = new CustomMenuItem();
            mItem_View_Rotate90 = new CustomMenuItem();
            mItem_View_Rotate180 = new CustomMenuItem();
            mItem_View_Rotate270 = new CustomMenuItem();
            mItem_View_Gamma = new CustomMenuItem();
            mItem_View_GammaPlus5 = new CustomMenuItem();
            mItem_View_GammaPlus4 = new CustomMenuItem();
            mItem_View_GammaPlus3 = new CustomMenuItem();
            mItem_View_GammaPlus2 = new CustomMenuItem();
            mItem_View_GammaPlus1 = new CustomMenuItem();
            mItem_View_Gamma0 = new CustomMenuItem();
            mItem_View_GammaMinus1 = new CustomMenuItem();
            mItem_View_GammaMinus2 = new CustomMenuItem();
            mItem_View_GammaMinus3 = new CustomMenuItem();
            mItem_View_Zoom = new CustomMenuItem();
            mItem_View_ZoomFit = new CustomMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            mItem_View_Zoom25 = new CustomMenuItem();
            mItem_View_Zoom50 = new CustomMenuItem();
            mItem_View_Zoom100 = new CustomMenuItem();
            mItem_View_Zoom200 = new CustomMenuItem();
            mItem_View_Zoom400 = new CustomMenuItem();
            mItem_View_Zoom800 = new CustomMenuItem();
            menuSettings = new ContextMenuStrip(components);
            mItem_Settings_TitleToggle = new CustomMenuItem();
            mItem_Settings_TitleToggleFileName = new CustomMenuItem();
            mItem_Settings_TitleTogglePhotoTitle = new CustomMenuItem();
            mItem_Settings_TitleToggleLocation = new CustomMenuItem();
            mItem_Settings_SizeToggle = new CustomMenuItem();
            mItem_Settings_SizeToggleSmall = new CustomMenuItem();
            mItem_Settings_SizeToggleMedium = new CustomMenuItem();
            mItem_Settings_SizeToggleLarge = new CustomMenuItem();
            mItem_Settings_SizeToggle4Photos = new CustomMenuItem();
            mItem_Settings_FileInfoTooltip = new CustomMenuItem();
            toolStripSeparator19 = new ToolStripSeparator();
            mItem_Settings_TreeSort = new CustomMenuItem();
            mItem_Settings_TreeSortByImport = new CustomMenuItem();
            mItem_Settings_TreeSortByName = new CustomMenuItem();
            toolStripSeparator20 = new ToolStripSeparator();
            mItem_Settings_TreeSortAscending = new CustomMenuItem();
            mItem_Settings_TreeSortDescending = new CustomMenuItem();
            mItem_Settings_PhotoSort = new CustomMenuItem();
            mItem_Settings_PhotoSortByCategory = new CustomMenuItem();
            mItem_Settings_PhotoSortByFileName = new CustomMenuItem();
            mItem_Settings_PhotoSortByTitle = new CustomMenuItem();
            mItem_Settings_PhotoSortByLocation = new CustomMenuItem();
            mItem_Settings_PhotoSortByDate = new CustomMenuItem();
            toolStripSeparator21 = new ToolStripSeparator();
            mItem_Settings_PhotoSortAscending = new CustomMenuItem();
            mItem_Settings_PhotoSortDescending = new CustomMenuItem();
            toolStripSeparator22 = new ToolStripSeparator();
            mItem_Settings_ConstructionValuesGrid = new CustomMenuItem();
            toolStripSeparator23 = new ToolStripSeparator();
            mItem_Settings_ApplicableStandards = new CustomMenuItem();
            mItem_Settings_ShowNecessitySymbols = new CustomMenuItem();
            toolStripSeparator24 = new ToolStripSeparator();
            mItem_Settings_ListDisplaySettings = new CustomMenuItem();
            mItem_Settings_TreeDisplaySettings = new CustomMenuItem();
            toolStripSeparator25 = new ToolStripSeparator();
            mItem_Settings_InspectionCommentSettings = new CustomMenuItem();
            mItem_Settings_InspectionCommentDashToNG = new CustomMenuItem();
            mItem_Settings_InspectionCommentInspectedToNG = new CustomMenuItem();
            menuHelp = new ContextMenuStrip(components);
            mItem_Help_VersionInfo = new CustomMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            // Sort items kept for Settings sort use
            mItem_View_Sort = new CustomMenuItem();
            mItem_View_SortName = new CustomMenuItem();
            mItem_View_SortTime = new CustomMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            mItem_View_SortAscendingOrder = new CustomMenuItem();
            mItem_View_SortDescendingOrder = new CustomMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            mItem_View_FolderDisplaySize = new CustomMenuItem();
            mItem_View_FolderDisplaySizeSmall = new CustomMenuItem();
            mItem_View_FolderDisplaySizeMedium = new CustomMenuItem();
            mItem_View_FolderDisplaySizeLarge = new CustomMenuItem();
            mItem_View_DescriptionDisplaySize = new CustomMenuItem();
            mItem_View_DescriptionDisplaySizeSmall = new CustomMenuItem();
            mItem_View_DescriptionDisplaySizeMedium = new CustomMenuItem();
            mItem_View_DescriptionDisplaySizeLarge = new CustomMenuItem();
            flowLayoutPanel1.SuspendLayout();
            menuFile.SuspendLayout();
            menuEdit.SuspendLayout();
            menuView.SuspendLayout();
            menuSettings.SuspendLayout();
            menuHelp.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            //
            flowLayoutPanel1.Controls.Add(btnFile);
            flowLayoutPanel1.Controls.Add(btnEdit);
            flowLayoutPanel1.Controls.Add(btnView);
            flowLayoutPanel1.Controls.Add(btnSettings);
            flowLayoutPanel1.Controls.Add(btnHelp);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1093, 28);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnFile
            // 
            btnFile.FlatAppearance.BorderSize = 0;
            btnFile.FlatStyle = FlatStyle.Flat;
            btnFile.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFile.Location = new Point(0, 0);
            btnFile.Margin = new Padding(0);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(74, 28);
            btnFile.TabIndex = 0;
            btnFile.Text = "ファイル(&F) ";
            btnFile.UseVisualStyleBackColor = true;
            btnFile.Click += button1_Click;
            //
            // btnEdit
            //
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(74, 0);
            btnEdit.Margin = new Padding(0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(70, 28);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "編集(&E)";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += button5_Click;
            //
            // btnView
            //
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnView.Location = new Point(144, 0);
            btnView.Margin = new Padding(0);
            btnView.Name = "btnView";
            btnView.Size = new Size(70, 28);
            btnView.TabIndex = 1;
            btnView.Text = "表示(&V)";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += button2_Click;
            //
            // btnSettings
            //
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.Location = new Point(214, 0);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(70, 28);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "設定(&S)";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += button6_Click;
            //
            // btnHelp
            //
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHelp.Location = new Point(284, 0);
            btnHelp.Margin = new Padding(0);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(70, 28);
            btnHelp.TabIndex = 3;
            btnHelp.Text = "ヘルプ(&H)";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += button4_Click;
            // 
            // menuFile — items: FolderSelect, Reload, sep, Print(submenu), sep, ImportCSV, ExportCSV, ExportFileInfoCSV, sep, Transfer(submenu), sep, Exit
            // 
            menuFile.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuFile.ImageScalingSize = new Size(20, 16);
            menuFile.Items.AddRange(new ToolStripItem[] { mItem_File_FolderSelect, mItem_File_Reload, toolStripSeparator1, mItem_File_Print, toolStripSeparator2, mItem_File_ImportCSV, mItem_File_ExportCSV, mItem_File_ExportFileInfoCSV, toolStripSeparator15, mItem_File_Transfer, toolStripSeparator4, mItem_File_Exit });
            menuFile.Name = "contextMenuStrip1";
            menuFile.Size = new Size(202, 246);
            //
            // mItem_File_FolderSelect
            //
            //mItem_File_FolderSelect.Image = Properties.Resources.folder_select_icon;
            //mItem_File_FolderSelect.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_FolderSelect.Name = "mItem_File_FolderSelect";
            mItem_File_FolderSelect.Size = new Size(201, 22);
            mItem_File_FolderSelect.Text = "フォルダ選択 (&F)...";
            // 
            // mItem_File_Reload — text fixed to 再読み込み (&R)
            //
            //mItem_File_Reload.Image = Properties.Resources.reload_icon;
            //mItem_File_Reload.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_Reload.Name = "mItem_File_Reload";
            mItem_File_Reload.ShortcutKeys = Keys.F5;
            mItem_File_Reload.Size = new Size(201, 22);
            mItem_File_Reload.Text = "再読み込み (&R)";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(198, 6);
            // 
            // mItem_File_Print — text fixed to 印刷 (&P)...
            //
            mItem_File_Print.DropDownItems.AddRange(new ToolStripItem[] { mItem_File_PrintPhotoList, mItem_File_PrintInspectionHistory, mItem_File_PrintFileInfo });
            //mItem_File_Print.Image = Properties.Resources.print_icon;
            //mItem_File_Print.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_Print.Name = "mItem_File_Print";
            mItem_File_Print.Size = new Size(201, 22);
            mItem_File_Print.Text = "印刷 (&P)...";
            // 
            // mItem_File_PrintPhotoList
            // 
            //mItem_File_PrintPhotoList.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_PrintPhotoList.Name = "mItem_File_PrintPhotoList";
            mItem_File_PrintPhotoList.ShortcutKeys = Keys.Control | Keys.P;
            mItem_File_PrintPhotoList.Size = new Size(200, 22);
            mItem_File_PrintPhotoList.Text = "写真一覧印刷 (&P)...";
            // 
            // mItem_File_PrintInspectionHistory
            //
            //mItem_File_PrintInspectionHistory.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_PrintInspectionHistory.Name = "mItem_File_PrintInspectionHistory";
            mItem_File_PrintInspectionHistory.Size = new Size(200, 22);
            mItem_File_PrintInspectionHistory.Text = "検査履歴印刷 (&L)...";
            //
            // mItem_File_PrintFileInfo
            //
            //mItem_File_PrintFileInfo.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_PrintFileInfo.Name = "mItem_File_PrintFileInfo";
            mItem_File_PrintFileInfo.Size = new Size(200, 22);
            mItem_File_PrintFileInfo.Text = "ファイル情報印刷 (&F)...";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(198, 6);
            // 
            // mItem_File_ImportCSV
            //
            //mItem_File_ImportCSV.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_ImportCSV.Name = "mItem_File_ImportCSV";
            mItem_File_ImportCSV.Size = new Size(201, 22);
            mItem_File_ImportCSV.Text = "検査履歴CSV取り込み (&I)...";
            //
            // mItem_File_ExportCSV
            //
            //mItem_File_ExportCSV.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_ExportCSV.Name = "mItem_File_ExportCSV";
            mItem_File_ExportCSV.Size = new Size(201, 22);
            mItem_File_ExportCSV.Text = "検査履歴CSV出力 (&O)...";
            //
            // mItem_File_ExportFileInfoCSV
            //
            //mItem_File_ExportFileInfoCSV.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_ExportFileInfoCSV.Name = "mItem_File_ExportFileInfoCSV";
            mItem_File_ExportFileInfoCSV.Size = new Size(201, 22);
            mItem_File_ExportFileInfoCSV.Text = "ファイル情報CSV出力 (&L)...";
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new Size(198, 6);
            //
            // mItem_File_Transfer — text fixed to 検査履歴の引継ぎ(&T)...
            // 
            mItem_File_Transfer.DropDownItems.AddRange(new ToolStripItem[] { mItem_File_ImportTransferData, mItem_File_ExportTransferData });
            //mItem_File_Transfer.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_Transfer.Name = "mItem_File_Transfer";
            mItem_File_Transfer.Size = new Size(201, 22);
            mItem_File_Transfer.Text = "検査履歴の引継ぎ(&T)...";
            // 
            // mItem_File_ImportTransferData
            // 
            //mItem_File_ImportTransferData.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_ImportTransferData.Name = "mItem_File_ImportTransferData";
            mItem_File_ImportTransferData.Size = new Size(192, 22);
            mItem_File_ImportTransferData.Text = "引継ぎデータ取り込み(&I)...";
            // 
            // mItem_File_ExportTransferData
            // 
            //mItem_File_ExportTransferData.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_ExportTransferData.Name = "mItem_File_ExportTransferData";
            mItem_File_ExportTransferData.Size = new Size(192, 22);
            mItem_File_ExportTransferData.Text = "引継ぎデータ出力(&O)...";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(198, 6);
            //
            // mItem_File_Exit
            //
            //mItem_File_Exit.Image = Properties.Resources.exit;
            mItem_File_Exit.ImageTransparentColor = Color.Magenta;
            //mItem_File_Exit.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_File_Exit.Name = "mItem_File_Exit";
            mItem_File_Exit.Size = new Size(201, 22);
            mItem_File_Exit.Text = "終了 (&X)";
            //
            // menuEdit
            //
            menuEdit.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuEdit.ImageScalingSize = new Size(20, 16);
            menuEdit.Items.AddRange(new ToolStripItem[] { mItem_Edit_Copy });
            menuEdit.Name = "menuEdit";
            menuEdit.Size = new Size(214, 26);
            //
            // mItem_Edit_Copy
            //
            //mItem_Edit_Copy.Image = Properties.Resources.copy_icon;
            //mItem_Edit_Copy.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Edit_Copy.Name = "mItem_Edit_Copy";
            mItem_Edit_Copy.Size = new Size(213, 22);
            mItem_Edit_Copy.Text = "クリップボードへコピー(&C)";
            //
            // menuView — items per FrmViewer: no Sort/FolderSize/PhotoListSize/DescSize (moved to Settings)
            //
            menuView.AccessibleName = "menuView";
            menuView.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuView.ImageScalingSize = new Size(20, 16);
            menuView.Items.AddRange(new ToolStripItem[] { mItem_View_PhotoInfoXML, mItem_View_ConstructionInfoXML, toolStripSeparator16, mItem_View_TreeViewDisplay, mItem_View_PhotoInfoDisplay, mItem_View_PhotoDisplay, toolStripSeparator17, mItem_View_DisplayMode, mItem_View_PhotoConfirmation, mItem_View_PhotoCompare, toolStripSeparator18, mItem_View_PreviousPhoto, mItem_View_NextPhoto, toolStripSeparator7, mItem_View_ToggleReference, toolStripSeparator8, mItem_View_Rotate, mItem_View_Gamma, mItem_View_Zoom });
            menuView.Name = "menuView";
            menuView.Size = new Size(270, 400);
            //
            // mItem_View_PhotoInfoXML
            //
            //mItem_View_PhotoInfoXML.Image = Properties.Resources.photo_info_icon;
            //mItem_View_PhotoInfoXML.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_PhotoInfoXML.Name = "mItem_View_PhotoInfoXML";
            mItem_View_PhotoInfoXML.Size = new Size(260, 22);
            mItem_View_PhotoInfoXML.Text = "写真管理情報 - PHOTO.XML (&P)...";
            mItem_View_PhotoInfoXML.Enabled = false;
            //
            // mItem_View_ConstructionInfoXML
            //
            //mItem_View_ConstructionInfoXML.Image = Properties.Resources.construction_info_icon;
            //mItem_View_ConstructionInfoXML.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_ConstructionInfoXML.Name = "mItem_View_ConstructionInfoXML";
            mItem_View_ConstructionInfoXML.Size = new Size(260, 22);
            mItem_View_ConstructionInfoXML.Text = "工事管理情報 - INDEX_C.XML (&X)...";
            mItem_View_ConstructionInfoXML.Enabled = false;
            //
            // toolStripSeparator16
            //
            toolStripSeparator16.Name = "toolStripSeparator16";
            toolStripSeparator16.Size = new Size(257, 6);
            //
            // mItem_View_TreeViewDisplay
            //
            //mItem_View_TreeViewDisplay.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_View_TreeViewDisplay.Name = "mItem_View_TreeViewDisplay";
            mItem_View_TreeViewDisplay.Size = new Size(260, 22);
            mItem_View_TreeViewDisplay.Text = "分類ツリー表示(&T)";
            //
            // mItem_View_PhotoInfoDisplay
            //
            //mItem_View_PhotoInfoDisplay.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_View_PhotoInfoDisplay.Name = "mItem_View_PhotoInfoDisplay";
            mItem_View_PhotoInfoDisplay.Size = new Size(260, 22);
            mItem_View_PhotoInfoDisplay.Text = "写真情報表示(&I)";
            //
            // mItem_View_PhotoDisplay
            //
           // mItem_View_PhotoDisplay.AccessibleName = "mItem_View_PhotoDisplay";
            mItem_View_PhotoDisplay.MarkCheck = EMarkCheckIcon.Check;
            mItem_View_PhotoDisplay.Name = "mItem_View_PhotoDisplay";
            mItem_View_PhotoDisplay.Size = new Size(260, 22);
            mItem_View_PhotoDisplay.Text = "写真表示(&V)";
            //
            // toolStripSeparator17
            //
            toolStripSeparator17.Name = "toolStripSeparator17";
            toolStripSeparator17.Size = new Size(257, 6);
            //
            // mItem_View_DisplayMode
            //
            mItem_View_DisplayMode.DropDownItems.AddRange(new ToolStripItem[] { mItem_View_DisplayModePhotoList, mItem_View_DisplayModePhotoInfo, mItem_View_DisplayModeFileInfo });
            //mItem_View_DisplayMode.Image = Properties.Resources.display_mode_icon;
            //mItem_View_DisplayMode.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_DisplayMode.Name = "mItem_View_DisplayMode";
            mItem_View_DisplayMode.Size = new Size(260, 22);
            mItem_View_DisplayMode.Text = "表示切替(&F)";
            //
            // mItem_View_DisplayModePhotoList
            //
            //mItem_View_DisplayModePhotoList.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_DisplayModePhotoList.Name = "mItem_View_DisplayModePhotoList";
            mItem_View_DisplayModePhotoList.Size = new Size(200, 22);
            mItem_View_DisplayModePhotoList.Text = "写真一覧表示(&L)";
            //
            // mItem_View_DisplayModePhotoInfo
            //
            //mItem_View_DisplayModePhotoInfo.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_DisplayModePhotoInfo.Name = "mItem_View_DisplayModePhotoInfo";
            mItem_View_DisplayModePhotoInfo.Size = new Size(200, 22);
            mItem_View_DisplayModePhotoInfo.Text = "写真情報一覧表示(&G)";
            //
            // mItem_View_DisplayModeFileInfo
            //
            //mItem_View_DisplayModeFileInfo.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_DisplayModeFileInfo.Name = "mItem_View_DisplayModeFileInfo";
            mItem_View_DisplayModeFileInfo.Size = new Size(200, 22);
            mItem_View_DisplayModeFileInfo.Text = "ファイル情報一覧表示(&F)";
            //
            // mItem_View_PhotoConfirmation
            //
            //mItem_View_PhotoConfirmation.Image = Properties.Resources.view_photo_icon;
            //mItem_View_PhotoConfirmation.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_PhotoConfirmation.Name = "mItem_View_PhotoConfirmation";
            mItem_View_PhotoConfirmation.Size = new Size(260, 22);
            mItem_View_PhotoConfirmation.Text = "写真確認(&C)";
            //
            // mItem_View_PhotoCompare
            //
            //mItem_View_PhotoCompare.Image = Properties.Resources.photo_compare_icon;
            //mItem_View_PhotoCompare.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_PhotoCompare.Name = "mItem_View_PhotoCompare";
            mItem_View_PhotoCompare.Size = new Size(260, 22);
            mItem_View_PhotoCompare.Text = "写真比較(&H)";
            //
            // toolStripSeparator18
            //
            toolStripSeparator18.Name = "toolStripSeparator18";
            toolStripSeparator18.Size = new Size(257, 6);
            // 
            // mItem_View_PreviousPhoto — text fixed to 前の写真 (&P)
            //
            //mItem_View_PreviousPhoto.Image = Properties.Resources.prev_photo;
            //mItem_View_PreviousPhoto.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_PreviousPhoto.Name = "mItem_View_PreviousPhoto";
            mItem_View_PreviousPhoto.ShortcutKeys = Keys.Control | Keys.PageUp;
            mItem_View_PreviousPhoto.Size = new Size(200, 22);
            mItem_View_PreviousPhoto.Text = "前の写真 (&P)";
            // 
            // mItem_View_NextPhoto — text fixed to 次の写真 (&N)
            //
            //mItem_View_NextPhoto.Image = Properties.Resources.next_photo;
            //mItem_View_NextPhoto.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_NextPhoto.Name = "mItem_View_NextPhoto";
            mItem_View_NextPhoto.ShortcutKeys = Keys.Control | Keys.Next;
            mItem_View_NextPhoto.Size = new Size(200, 22);
            mItem_View_NextPhoto.Text = "次の写真 (&N)";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(197, 6);
            //
            // mItem_View_ToggleReference — flat item (no submenu), text 写真・参考図切替 (&S)
            //
            //mItem_View_ToggleReference.Image = Properties.Resources.toggle_photo_diagram_icon;
            //mItem_View_ToggleReference.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_ToggleReference.Name = "mItem_View_ToggleReference";
            mItem_View_ToggleReference.Size = new Size(200, 22);
            mItem_View_ToggleReference.Text = "写真・参考図切替 (&S)";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(197, 6);
            // 
            // mItem_View_Rotate — text 写真回転(&R)
            //
            mItem_View_Rotate.DropDownItems.AddRange(new ToolStripItem[] { mItem_View_RotateDefault, mItem_View_Rotate90, mItem_View_Rotate180, mItem_View_Rotate270 });
            //mItem_View_Rotate.Image = Properties.Resources.rotate_icon;
            //mItem_View_Rotate.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Rotate.Name = "mItem_View_Rotate";
            mItem_View_Rotate.Size = new Size(200, 22);
            mItem_View_Rotate.Text = "写真回転(&R)";
            // 
            // mItem_View_RotateDefault — text &0°
            // 
            //mItem_View_RotateDefault.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_RotateDefault.Name = "mItem_View_RotateDefault";
            mItem_View_RotateDefault.Size = new Size(114, 22);
            mItem_View_RotateDefault.Text = "&0°";
            // 
            // mItem_View_Rotate90 — text &90°
            // 
            //mItem_View_Rotate90.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Rotate90.Name = "mItem_View_Rotate90";
            mItem_View_Rotate90.Size = new Size(114, 22);
            mItem_View_Rotate90.Text = "&90°";
            // 
            // mItem_View_Rotate180 — text &180°
            // 
            //mItem_View_Rotate180.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Rotate180.Name = "mItem_View_Rotate180";
            mItem_View_Rotate180.Size = new Size(114, 22);
            mItem_View_Rotate180.Text = "&180°";
            // 
            // mItem_View_Rotate270 — text &270°
            // 
            //mItem_View_Rotate270.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Rotate270.Name = "mItem_View_Rotate270";
            mItem_View_Rotate270.Size = new Size(114, 22);
            mItem_View_Rotate270.Text = "&270°";
            //
            // mItem_View_Gamma — parent text changed to 明るさ補正(&A); sub-items reversed: +5…-3
            //
            mItem_View_Gamma.DropDownItems.AddRange(new ToolStripItem[] { mItem_View_GammaPlus5, mItem_View_GammaPlus4, mItem_View_GammaPlus3, mItem_View_GammaPlus2, mItem_View_GammaPlus1, mItem_View_Gamma0, mItem_View_GammaMinus1, mItem_View_GammaMinus2, mItem_View_GammaMinus3 });
            //mItem_View_Gamma.Image = Properties.Resources.gamma_icon;
            //mItem_View_Gamma.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Gamma.Name = "mItem_View_Gamma";
            mItem_View_Gamma.Size = new Size(200, 22);
            mItem_View_Gamma.Text = "明るさ補正(&A)";
            //
            // mItem_View_GammaPlus5
            //
            //mItem_View_GammaPlus5.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaPlus5.Name = "mItem_View_GammaPlus5";
            mItem_View_GammaPlus5.Size = new Size(80, 22);
            mItem_View_GammaPlus5.Text = "+5";
            //
            // mItem_View_GammaPlus4
            //
            //mItem_View_GammaPlus4.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaPlus4.Name = "mItem_View_GammaPlus4";
            mItem_View_GammaPlus4.Size = new Size(80, 22);
            mItem_View_GammaPlus4.Text = "+4";
            //
            // mItem_View_GammaPlus3
            //
            //mItem_View_GammaPlus3.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaPlus3.Name = "mItem_View_GammaPlus3";
            mItem_View_GammaPlus3.Size = new Size(80, 22);
            mItem_View_GammaPlus3.Text = "+3";
            //
            // mItem_View_GammaPlus2
            //
            //mItem_View_GammaPlus2.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaPlus2.Name = "mItem_View_GammaPlus2";
            mItem_View_GammaPlus2.Size = new Size(80, 22);
            mItem_View_GammaPlus2.Text = "+2";
            //
            // mItem_View_GammaPlus1
            //
            //mItem_View_GammaPlus1.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaPlus1.Name = "mItem_View_GammaPlus1";
            mItem_View_GammaPlus1.Size = new Size(80, 22);
            mItem_View_GammaPlus1.Text = "+1";
            //
            // mItem_View_Gamma0
            //
            //mItem_View_Gamma0.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Gamma0.Name = "mItem_View_Gamma0";
            mItem_View_Gamma0.Size = new Size(80, 22);
            mItem_View_Gamma0.Text = "0";
            //
            // mItem_View_GammaMinus1
            //
            //mItem_View_GammaMinus1.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaMinus1.Name = "mItem_View_GammaMinus1";
            mItem_View_GammaMinus1.Size = new Size(80, 22);
            mItem_View_GammaMinus1.Text = "-1";
            //
            // mItem_View_GammaMinus2
            //
            //mItem_View_GammaMinus2.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaMinus2.Name = "mItem_View_GammaMinus2";
            mItem_View_GammaMinus2.Size = new Size(80, 22);
            mItem_View_GammaMinus2.Text = "-2";
            //
            // mItem_View_GammaMinus3
            //
            //mItem_View_GammaMinus3.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_GammaMinus3.Name = "mItem_View_GammaMinus3";
            mItem_View_GammaMinus3.Size = new Size(80, 22);
            mItem_View_GammaMinus3.Text = "-3";
            // 
            // mItem_View_Zoom — text 写真表示倍率 (&Z)
            //
            mItem_View_Zoom.DropDownItems.AddRange(new ToolStripItem[] { mItem_View_ZoomFit, toolStripSeparator10, mItem_View_Zoom25, mItem_View_Zoom50, mItem_View_Zoom100, mItem_View_Zoom200, mItem_View_Zoom400, mItem_View_Zoom800 });
            //mItem_View_Zoom.Image = Properties.Resources.zoom_icon;
            //mItem_View_Zoom.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Zoom.Name = "mItem_View_Zoom";
            mItem_View_Zoom.Size = new Size(200, 22);
            mItem_View_Zoom.Text = "写真表示倍率 (&Z)";
            // 
            // mItem_View_ZoomFit — text 全体表示 (&Z)
            // 
            //mItem_View_ZoomFit.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_ZoomFit.Name = "mItem_View_ZoomFit";
            mItem_View_ZoomFit.Size = new Size(110, 22);
            mItem_View_ZoomFit.Text = "全体表示 (&Z)";
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(107, 6);
            // 
            // mItem_View_Zoom25 — text 25 %
            // 
            //mItem_View_Zoom25.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Zoom25.Name = "mItem_View_Zoom25";
            mItem_View_Zoom25.Size = new Size(110, 22);
            mItem_View_Zoom25.Text = "25 %";
            // 
            // mItem_View_Zoom50 — text 50 %
            // 
            //mItem_View_Zoom50.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Zoom50.Name = "mItem_View_Zoom50";
            mItem_View_Zoom50.Size = new Size(110, 22);
            mItem_View_Zoom50.Text = "50 %";
            // 
            // mItem_View_Zoom100 — text 100 %
            // 
            //mItem_View_Zoom100.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Zoom100.Name = "mItem_View_Zoom100";
            mItem_View_Zoom100.Size = new Size(110, 22);
            mItem_View_Zoom100.Text = "100 %";
            // 
            // mItem_View_Zoom200 — text 200 %
            // 
            //mItem_View_Zoom200.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Zoom200.Name = "mItem_View_Zoom200";
            mItem_View_Zoom200.Size = new Size(110, 22);
            mItem_View_Zoom200.Text = "200 %";
            // 
            // mItem_View_Zoom400 — text 400 %
            // 
            //mItem_View_Zoom400.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Zoom400.Name = "mItem_View_Zoom400";
            mItem_View_Zoom400.Size = new Size(110, 22);
            mItem_View_Zoom400.Text = "400 %";
            // 
            // mItem_View_Zoom800 — text 800 %
            //
            //mItem_View_Zoom800.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_Zoom800.Name = "mItem_View_Zoom800";
            mItem_View_Zoom800.Size = new Size(110, 22);
            mItem_View_Zoom800.Text = "800 %";
            // 
            // Sort items (not shown in View menu; kept for Settings/sort use in code)
            //
            //mItem_View_Sort.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_Sort.Name = "mItem_View_Sort";
            mItem_View_Sort.Text = "写真の並べ替え(&S)";
            //mItem_View_SortName.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_SortName.Name = "mItem_View_SortName";
            mItem_View_SortName.Text = "写真ファイル名(&F)";
            //mItem_View_SortTime.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_SortTime.Name = "mItem_View_SortTime";
            mItem_View_SortTime.Text = "更新日時(&T)";
            //mItem_View_SortAscendingOrder.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_SortAscendingOrder.Name = "mItem_View_SortAscendingOrder";
            mItem_View_SortAscendingOrder.Text = "昇順(&U)";
            //mItem_View_SortDescendingOrder.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_SortDescendingOrder.Name = "mItem_View_SortDescendingOrder";
            mItem_View_SortDescendingOrder.Text = "降順(&D)";
            //
            // FolderDisplaySize items (not in View menu; used by code via SetFolderDisplaySizeStyle)
            //
            mItem_View_FolderDisplaySize.DropDownItems.AddRange(new ToolStripItem[] { mItem_View_FolderDisplaySizeSmall, mItem_View_FolderDisplaySizeMedium, mItem_View_FolderDisplaySizeLarge });
            //mItem_View_FolderDisplaySize.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_FolderDisplaySize.Name = "mItem_View_FolderDisplaySize";
            mItem_View_FolderDisplaySize.Text = "フォルダー表示サイズ(&Y)";
            //mItem_View_FolderDisplaySizeSmall.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_FolderDisplaySizeSmall.Name = "mItem_View_FolderDisplaySizeSmall";
            mItem_View_FolderDisplaySizeSmall.Text = "小(&S)";
            //mItem_View_FolderDisplaySizeMedium.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_FolderDisplaySizeMedium.Name = "mItem_View_FolderDisplaySizeMedium";
            mItem_View_FolderDisplaySizeMedium.Text = "中(&M)";
            //mItem_View_FolderDisplaySizeLarge.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_FolderDisplaySizeLarge.Name = "mItem_View_FolderDisplaySizeLarge";
            mItem_View_FolderDisplaySizeLarge.Text = "大(&L)";
            //
            // DescriptionDisplaySize items
            //
            mItem_View_DescriptionDisplaySize.DropDownItems.AddRange(new ToolStripItem[] { mItem_View_DescriptionDisplaySizeSmall, mItem_View_DescriptionDisplaySizeMedium, mItem_View_DescriptionDisplaySizeLarge });
            //mItem_View_DescriptionDisplaySize.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_View_DescriptionDisplaySize.Name = "mItem_View_DescriptionDisplaySize";
            mItem_View_DescriptionDisplaySize.Text = "説明文表示サイズ(&E)";
            //mItem_View_DescriptionDisplaySizeSmall.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_DescriptionDisplaySizeSmall.Name = "mItem_View_DescriptionDisplaySizeSmall";
            mItem_View_DescriptionDisplaySizeSmall.Text = "小(&S)";
            //mItem_View_DescriptionDisplaySizeMedium.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_DescriptionDisplaySizeMedium.Name = "mItem_View_DescriptionDisplaySizeMedium";
            mItem_View_DescriptionDisplaySizeMedium.Text = "中(&M)";
            //mItem_View_DescriptionDisplaySizeLarge.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_View_DescriptionDisplaySizeLarge.Name = "mItem_View_DescriptionDisplaySizeLarge";
            mItem_View_DescriptionDisplaySizeLarge.Text = "大(&L)";
            //
            // menuSettings
            //
            menuSettings.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuSettings.ImageScalingSize = new Size(20, 16);
            menuSettings.Items.AddRange(new ToolStripItem[] { mItem_Settings_TitleToggle, mItem_Settings_SizeToggle, mItem_Settings_FileInfoTooltip, toolStripSeparator19, mItem_Settings_TreeSort, mItem_Settings_PhotoSort, toolStripSeparator22, mItem_Settings_ConstructionValuesGrid, toolStripSeparator23, mItem_Settings_ApplicableStandards, mItem_Settings_ShowNecessitySymbols, toolStripSeparator24, mItem_Settings_ListDisplaySettings, mItem_Settings_TreeDisplaySettings, toolStripSeparator25, mItem_Settings_InspectionCommentSettings });
            menuSettings.Name = "menuSettings";
            menuSettings.Size = new Size(260, 308);
            //
            // mItem_Settings_TitleToggle — text 写真一覧タイトル切替(&T)
            //
            mItem_Settings_TitleToggle.DropDownItems.AddRange(new ToolStripItem[] { mItem_Settings_TitleToggleFileName, mItem_Settings_TitleTogglePhotoTitle, mItem_Settings_TitleToggleLocation });
            //mItem_Settings_TitleToggle.Image = Properties.Resources.title_toggle_icon;
            //mItem_Settings_TitleToggle.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_TitleToggle.Name = "mItem_Settings_TitleToggle";
            mItem_Settings_TitleToggle.Size = new Size(259, 22);
            mItem_Settings_TitleToggle.Text = "写真一覧タイトル切替(&T)";
            //
            // mItem_Settings_TitleToggleFileName
            //
            //mItem_Settings_TitleToggleFileName.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TitleToggleFileName.Name = "mItem_Settings_TitleToggleFileName";
            mItem_Settings_TitleToggleFileName.Size = new Size(160, 22);
            mItem_Settings_TitleToggleFileName.Text = "ファイル名(&F)";
            //
            // mItem_Settings_TitleTogglePhotoTitle — accelerator &T (was &P)
            //
            //mItem_Settings_TitleTogglePhotoTitle.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TitleTogglePhotoTitle.Name = "mItem_Settings_TitleTogglePhotoTitle";
            mItem_Settings_TitleTogglePhotoTitle.Size = new Size(160, 22);
            mItem_Settings_TitleTogglePhotoTitle.Text = "写真タイトル(&T)";
            //
            // mItem_Settings_TitleToggleLocation — accelerator &K (was &L)
            //
            //mItem_Settings_TitleToggleLocation.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TitleToggleLocation.Name = "mItem_Settings_TitleToggleLocation";
            mItem_Settings_TitleToggleLocation.Size = new Size(160, 22);
            mItem_Settings_TitleToggleLocation.Text = "撮影箇所(&K)";
            //
            // mItem_Settings_SizeToggle — text サイズ切替(&M)
            //
            mItem_Settings_SizeToggle.DropDownItems.AddRange(new ToolStripItem[] { mItem_Settings_SizeToggleSmall, mItem_Settings_SizeToggleMedium, mItem_Settings_SizeToggleLarge, mItem_Settings_SizeToggle4Photos });
            //mItem_Settings_SizeToggle.Image = Properties.Resources.size_toggle_icon;
            //mItem_Settings_SizeToggle.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_SizeToggle.Name = "mItem_Settings_SizeToggle";
            mItem_Settings_SizeToggle.Size = new Size(259, 22);
            mItem_Settings_SizeToggle.Text = "サイズ切替(&M)";
            //
            // mItem_Settings_SizeToggleSmall
            //
            //mItem_Settings_SizeToggleSmall.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_SizeToggleSmall.Name = "mItem_Settings_SizeToggleSmall";
            mItem_Settings_SizeToggleSmall.Size = new Size(110, 22);
            mItem_Settings_SizeToggleSmall.Text = "小(&S)";
            //
            // mItem_Settings_SizeToggleMedium
            //
            //mItem_Settings_SizeToggleMedium.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_SizeToggleMedium.Name = "mItem_Settings_SizeToggleMedium";
            mItem_Settings_SizeToggleMedium.Size = new Size(110, 22);
            mItem_Settings_SizeToggleMedium.Text = "中(&M)";
            //
            // mItem_Settings_SizeToggleLarge
            //
            //mItem_Settings_SizeToggleLarge.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_SizeToggleLarge.Name = "mItem_Settings_SizeToggleLarge";
            mItem_Settings_SizeToggleLarge.Size = new Size(110, 22);
            mItem_Settings_SizeToggleLarge.Text = "大(&L)";
            //
            // mItem_Settings_SizeToggle4Photos
            //
            //mItem_Settings_SizeToggle4Photos.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_SizeToggle4Photos.Name = "mItem_Settings_SizeToggle4Photos";
            mItem_Settings_SizeToggle4Photos.Size = new Size(110, 22);
            mItem_Settings_SizeToggle4Photos.Text = "4枚(&4)";
            //
            // mItem_Settings_FileInfoTooltip — text ファイル情報のヒント表示(&H)
            //
            //mItem_Settings_FileInfoTooltip.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_Settings_FileInfoTooltip.Name = "mItem_Settings_FileInfoTooltip";
            mItem_Settings_FileInfoTooltip.Size = new Size(259, 22);
            mItem_Settings_FileInfoTooltip.Text = "ファイル情報のヒント表示(&H)";
            //
            // toolStripSeparator19
            //
            toolStripSeparator19.Name = "toolStripSeparator19";
            toolStripSeparator19.Size = new Size(256, 6);
            //
            // mItem_Settings_TreeSort — text 分類ツリーの並べ替え(&S)
            //
            mItem_Settings_TreeSort.DropDownItems.AddRange(new ToolStripItem[] { mItem_Settings_TreeSortByImport, mItem_Settings_TreeSortByName, toolStripSeparator20, mItem_Settings_TreeSortAscending, mItem_Settings_TreeSortDescending });
            //mItem_Settings_TreeSort.Image = Properties.Resources.tree_sort_icon;
            //mItem_Settings_TreeSort.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_TreeSort.Name = "mItem_Settings_TreeSort";
            mItem_Settings_TreeSort.Size = new Size(259, 22);
            mItem_Settings_TreeSort.Text = "分類ツリーの並べ替え(&S)";
            //
            // mItem_Settings_TreeSortByImport — text 取り込み順(&T)
            //
            //mItem_Settings_TreeSortByImport.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TreeSortByImport.Name = "mItem_Settings_TreeSortByImport";
            mItem_Settings_TreeSortByImport.Size = new Size(160, 22);
            mItem_Settings_TreeSortByImport.Text = "取り込み順(&T)";
            //
            // mItem_Settings_TreeSortByName — text 分類名順(&B)
            //
            //mItem_Settings_TreeSortByName.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TreeSortByName.Name = "mItem_Settings_TreeSortByName";
            mItem_Settings_TreeSortByName.Size = new Size(160, 22);
            mItem_Settings_TreeSortByName.Text = "分類名順(&B)";
            //
            // toolStripSeparator20
            //
            toolStripSeparator20.Name = "toolStripSeparator20";
            toolStripSeparator20.Size = new Size(157, 6);
            //
            // mItem_Settings_TreeSortAscending
            //
            //mItem_Settings_TreeSortAscending.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TreeSortAscending.Name = "mItem_Settings_TreeSortAscending";
            mItem_Settings_TreeSortAscending.Size = new Size(160, 22);
            mItem_Settings_TreeSortAscending.Text = "昇順(&U)";
            //
            // mItem_Settings_TreeSortDescending
            //
            //mItem_Settings_TreeSortDescending.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_TreeSortDescending.Name = "mItem_Settings_TreeSortDescending";
            mItem_Settings_TreeSortDescending.Size = new Size(160, 22);
            mItem_Settings_TreeSortDescending.Text = "降順(&D)";
            //
            // mItem_Settings_PhotoSort — text 写真の並べ替え(&N)
            //
            mItem_Settings_PhotoSort.DropDownItems.AddRange(new ToolStripItem[] { mItem_Settings_PhotoSortByCategory, mItem_Settings_PhotoSortByFileName, mItem_Settings_PhotoSortByTitle, mItem_Settings_PhotoSortByLocation, mItem_Settings_PhotoSortByDate, toolStripSeparator21, mItem_Settings_PhotoSortAscending, mItem_Settings_PhotoSortDescending });
            //mItem_Settings_PhotoSort.Image = Properties.Resources.photo_sort_icon;
            //mItem_Settings_PhotoSort.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_PhotoSort.Name = "mItem_Settings_PhotoSort";
            mItem_Settings_PhotoSort.Size = new Size(259, 22);
            mItem_Settings_PhotoSort.Text = "写真の並べ替え(&N)";
            //
            // mItem_Settings_PhotoSortByCategory — text 分類順(&B)
            //
            //mItem_Settings_PhotoSortByCategory.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortByCategory.Name = "mItem_Settings_PhotoSortByCategory";
            mItem_Settings_PhotoSortByCategory.Size = new Size(180, 22);
            mItem_Settings_PhotoSortByCategory.Text = "分類順(&B)";
            //
            // mItem_Settings_PhotoSortByFileName — text ファイル名順(&F)
            //
            //mItem_Settings_PhotoSortByFileName.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortByFileName.Name = "mItem_Settings_PhotoSortByFileName";
            mItem_Settings_PhotoSortByFileName.Size = new Size(180, 22);
            mItem_Settings_PhotoSortByFileName.Text = "ファイル名順(&F)";
            //
            // mItem_Settings_PhotoSortByTitle — text タイトル順(&T)
            //
            //mItem_Settings_PhotoSortByTitle.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortByTitle.Name = "mItem_Settings_PhotoSortByTitle";
            mItem_Settings_PhotoSortByTitle.Size = new Size(180, 22);
            mItem_Settings_PhotoSortByTitle.Text = "タイトル順(&T)";
            //
            // mItem_Settings_PhotoSortByLocation — text 撮影箇所順(&K)
            //
            //mItem_Settings_PhotoSortByLocation.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortByLocation.Name = "mItem_Settings_PhotoSortByLocation";
            mItem_Settings_PhotoSortByLocation.Size = new Size(180, 22);
            mItem_Settings_PhotoSortByLocation.Text = "撮影箇所順(&K)";
            //
            // mItem_Settings_PhotoSortByDate — text 撮影年月日順(&N)
            //
            //mItem_Settings_PhotoSortByDate.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortByDate.Name = "mItem_Settings_PhotoSortByDate";
            mItem_Settings_PhotoSortByDate.Size = new Size(180, 22);
            mItem_Settings_PhotoSortByDate.Text = "撮影年月日順(&N)";
            //
            // toolStripSeparator21
            //
            toolStripSeparator21.Name = "toolStripSeparator21";
            toolStripSeparator21.Size = new Size(177, 6);
            //
            // mItem_Settings_PhotoSortAscending
            //
            //mItem_Settings_PhotoSortAscending.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortAscending.Name = "mItem_Settings_PhotoSortAscending";
            mItem_Settings_PhotoSortAscending.Size = new Size(180, 22);
            mItem_Settings_PhotoSortAscending.Text = "昇順(&U)";
            //
            // mItem_Settings_PhotoSortDescending
            //
            //mItem_Settings_PhotoSortDescending.MarkCheck = Services.Enums.EMarkCheckIcon.Dot;
            mItem_Settings_PhotoSortDescending.Name = "mItem_Settings_PhotoSortDescending";
            mItem_Settings_PhotoSortDescending.Size = new Size(180, 22);
            mItem_Settings_PhotoSortDescending.Text = "降順(&D)";
            //
            // toolStripSeparator22
            //
            toolStripSeparator22.Name = "toolStripSeparator22";
            toolStripSeparator22.Size = new Size(256, 6);
            //
            // mItem_Settings_ConstructionValuesGrid — text 施工管理値を表形式で表示(&L)
            //
            //mItem_Settings_ConstructionValuesGrid.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_Settings_ConstructionValuesGrid.Name = "mItem_Settings_ConstructionValuesGrid";
            mItem_Settings_ConstructionValuesGrid.Size = new Size(259, 22);
            mItem_Settings_ConstructionValuesGrid.Text = "施工管理値を表形式で表示(&L)";
            //
            // toolStripSeparator23
            //
            toolStripSeparator23.Name = "toolStripSeparator23";
            toolStripSeparator23.Size = new Size(256, 6);
            //
            // mItem_Settings_ApplicableStandards — text 適用基準（案）選択(&K)...
            //
            //mItem_Settings_ApplicableStandards.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_ApplicableStandards.Name = "mItem_Settings_ApplicableStandards";
            mItem_Settings_ApplicableStandards.Size = new Size(259, 22);
            mItem_Settings_ApplicableStandards.Text = "適用基準（案）選択(&K)...";
            //
            // mItem_Settings_ShowNecessitySymbols — text 記入必要度の記号を表示(&Z)
            //
            //mItem_Settings_ShowNecessitySymbols.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_Settings_ShowNecessitySymbols.Name = "mItem_Settings_ShowNecessitySymbols";
            mItem_Settings_ShowNecessitySymbols.Size = new Size(259, 22);
            mItem_Settings_ShowNecessitySymbols.Text = "記入必要度の記号を表示(&Z)";
            //
            // toolStripSeparator24
            //
            toolStripSeparator24.Name = "toolStripSeparator24";
            toolStripSeparator24.Size = new Size(256, 6);
            //
            // mItem_Settings_ListDisplaySettings — text 一覧表示項目設定(&I)...
            //
            //mItem_Settings_ListDisplaySettings.Image = Properties.Resources.list_settings_icon;
            //mItem_Settings_ListDisplaySettings.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_ListDisplaySettings.Name = "mItem_Settings_ListDisplaySettings";
            mItem_Settings_ListDisplaySettings.Size = new Size(259, 22);
            mItem_Settings_ListDisplaySettings.Text = "一覧表示項目設定(&I)...";
            //
            // mItem_Settings_TreeDisplaySettings — text 分類ツリー表示項目設定(&B)...
            //
            //mItem_Settings_TreeDisplaySettings.Image = Properties.Resources.tree_settings_icon;
            //mItem_Settings_TreeDisplaySettings.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_TreeDisplaySettings.Name = "mItem_Settings_TreeDisplaySettings";
            mItem_Settings_TreeDisplaySettings.Size = new Size(259, 22);
            mItem_Settings_TreeDisplaySettings.Text = "分類ツリー表示項目設定(&B)...";
            //
            // toolStripSeparator25
            //
            toolStripSeparator25.Name = "toolStripSeparator25";
            toolStripSeparator25.Size = new Size(256, 6);
            //
            // mItem_Settings_InspectionCommentSettings
            //
            mItem_Settings_InspectionCommentSettings.DropDownItems.AddRange(new ToolStripItem[] { mItem_Settings_InspectionCommentDashToNG, mItem_Settings_InspectionCommentInspectedToNG });
            //mItem_Settings_InspectionCommentSettings.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Settings_InspectionCommentSettings.Name = "mItem_Settings_InspectionCommentSettings";
            mItem_Settings_InspectionCommentSettings.Size = new Size(259, 22);
            mItem_Settings_InspectionCommentSettings.Text = "検査コメント入力時の設定 (&O)";
            //
            // mItem_Settings_InspectionCommentDashToNG — 「－」→「指摘あり」 (&U)
            //
            //mItem_Settings_InspectionCommentDashToNG.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_Settings_InspectionCommentDashToNG.Name = "mItem_Settings_InspectionCommentDashToNG";
            mItem_Settings_InspectionCommentDashToNG.Size = new Size(200, 22);
            mItem_Settings_InspectionCommentDashToNG.Text = "「－」 → 「指摘あり」 (&U)";
            //
            // mItem_Settings_InspectionCommentInspectedToNG — 「－」→「検査済」 (&I)
            //
            //mItem_Settings_InspectionCommentInspectedToNG.MarkCheck = Services.Enums.EMarkCheckIcon.Check;
            mItem_Settings_InspectionCommentInspectedToNG.Name = "mItem_Settings_InspectionCommentInspectedToNG";
            mItem_Settings_InspectionCommentInspectedToNG.Size = new Size(200, 22);
            mItem_Settings_InspectionCommentInspectedToNG.Text = "「－」 → 「検査済」 (&I)";
            //
            // menuHelp — only バージョン情報 (&A)... remains
            // 
            menuHelp.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuHelp.ImageScalingSize = new Size(20, 16);
            menuHelp.Items.AddRange(new ToolStripItem[] { mItem_Help_VersionInfo });
            menuHelp.Name = "contextMenuStrip1";
            menuHelp.Size = new Size(185, 26);
            // 
            // mItem_Help_VersionInfo — text バージョン情報 (&A)...
            // 
            //mItem_Help_VersionInfo.MarkCheck = Services.Enums.EMarkCheckIcon.None;
            mItem_Help_VersionInfo.Name = "mItem_Help_VersionInfo";
            mItem_Help_VersionInfo.Size = new Size(184, 22);
            mItem_Help_VersionInfo.Text = "バージョン情報 (&A)...";
            // 
            // toolStripSeparator14 — kept as declared field (not added to any menu)
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(164, 6);
            // 
            // TopMenuBarControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "TopMenuBarControl";
            Size = new Size(1093, 28);
            flowLayoutPanel1.ResumeLayout(false);
            menuFile.ResumeLayout(false);
            menuEdit.ResumeLayout(false);
            menuView.ResumeLayout(false);
            menuSettings.ResumeLayout(false);
            menuHelp.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ContextMenuStrip menuFile;
        private CustomMenuItem mItem_File_FolderSelect;
        private CustomMenuItem mItem_File_Reload;
        private CustomMenuItem mItem_File_Print;
        private CustomMenuItem mItem_File_PrintFileInfo;
        private CustomMenuItem mItem_File_ImportCSV;
        private CustomMenuItem mItem_File_ExportFileInfoCSV;
        private System.Windows.Forms.ContextMenuStrip menuEdit;
        private CustomMenuItem mItem_Edit_Copy;
        private System.Windows.Forms.ContextMenuStrip menuView;
        private CustomMenuItem mItem_View_PhotoInfoXML;
        private CustomMenuItem mItem_View_ConstructionInfoXML;
        private CustomMenuItem mItem_View_TreeViewDisplay;
        private CustomMenuItem mItem_View_PhotoInfoDisplay;
        public CustomMenuItem mItem_View_PhotoDisplay;
        private CustomMenuItem mItem_View_DisplayMode;
        private CustomMenuItem mItem_View_DisplayModePhotoList;
        private CustomMenuItem mItem_View_DisplayModePhotoInfo;
        private CustomMenuItem mItem_View_DisplayModeFileInfo;
        private CustomMenuItem mItem_View_PhotoConfirmation;
        private CustomMenuItem mItem_View_PhotoCompare;
        private CustomMenuItem mItem_View_PreviousPhoto;
        private CustomMenuItem mItem_View_NextPhoto;
        private CustomMenuItem mItem_View_ToggleReference;
        private CustomMenuItem mItem_View_Gamma;
        private CustomMenuItem mItem_View_Gamma0;
        private CustomMenuItem mItem_View_GammaMinus1;
        private CustomMenuItem mItem_View_GammaMinus2;
        private CustomMenuItem mItem_View_GammaMinus3;
        private CustomMenuItem mItem_View_GammaPlus1;
        private CustomMenuItem mItem_View_GammaPlus2;
        private CustomMenuItem mItem_View_GammaPlus3;
        private CustomMenuItem mItem_View_GammaPlus4;
        private CustomMenuItem mItem_View_GammaPlus5;
        private System.Windows.Forms.ContextMenuStrip menuSettings;
        private CustomMenuItem mItem_Settings_TitleToggle;
        private CustomMenuItem mItem_Settings_TitleToggleFileName;
        private CustomMenuItem mItem_Settings_TitleTogglePhotoTitle;
        private CustomMenuItem mItem_Settings_TitleToggleLocation;
        private CustomMenuItem mItem_Settings_SizeToggle;
        private CustomMenuItem mItem_Settings_SizeToggleSmall;
        private CustomMenuItem mItem_Settings_SizeToggleMedium;
        private CustomMenuItem mItem_Settings_SizeToggleLarge;
        private CustomMenuItem mItem_Settings_SizeToggle4Photos;
        private CustomMenuItem mItem_Settings_FileInfoTooltip;
        private CustomMenuItem mItem_Settings_TreeSort;
        private CustomMenuItem mItem_Settings_TreeSortByImport;
        private CustomMenuItem mItem_Settings_TreeSortByName;
        private CustomMenuItem mItem_Settings_TreeSortAscending;
        private CustomMenuItem mItem_Settings_TreeSortDescending;
        private CustomMenuItem mItem_Settings_PhotoSort;
        private CustomMenuItem mItem_Settings_PhotoSortByCategory;
        private CustomMenuItem mItem_Settings_PhotoSortByFileName;
        private CustomMenuItem mItem_Settings_PhotoSortByTitle;
        private CustomMenuItem mItem_Settings_PhotoSortByLocation;
        private CustomMenuItem mItem_Settings_PhotoSortByDate;
        private CustomMenuItem mItem_Settings_PhotoSortAscending;
        private CustomMenuItem mItem_Settings_PhotoSortDescending;
        private CustomMenuItem mItem_Settings_ConstructionValuesGrid;
        private CustomMenuItem mItem_Settings_ApplicableStandards;
        private CustomMenuItem mItem_Settings_ShowNecessitySymbols;
        private CustomMenuItem mItem_Settings_ListDisplaySettings;
        private CustomMenuItem mItem_Settings_TreeDisplaySettings;
        private CustomMenuItem mItem_Settings_InspectionCommentSettings;
        private CustomMenuItem mItem_Settings_InspectionCommentDashToNG;
        private CustomMenuItem mItem_Settings_InspectionCommentInspectedToNG;
        private System.Windows.Forms.ContextMenuStrip menuHelp;
        private CustomMenuItem mItem_Help_VersionInfo;
        private CustomMenuItem mItem_File_PrintPhotoList;
        private CustomMenuItem mItem_File_PrintInspectionHistory;
        private CustomMenuItem mItem_File_ExportCSV;
        private CustomMenuItem mItem_File_Transfer;
        private CustomMenuItem mItem_File_ImportTransferData;
        private CustomMenuItem mItem_File_ExportTransferData;
        private CustomMenuItem mItem_File_Exit;
        private CustomMenuItem mItem_View_Rotate;
        private CustomMenuItem mItem_View_Zoom;
        private CustomMenuItem mItem_View_Sort;
        private CustomMenuItem mItem_View_FolderDisplaySize;
        private CustomMenuItem mItem_View_DescriptionDisplaySize;
        private CustomMenuItem mItem_View_RotateDefault;
        private CustomMenuItem mItem_View_Rotate90;
        private CustomMenuItem mItem_View_Rotate180;
        private CustomMenuItem mItem_View_Rotate270;
        private CustomMenuItem mItem_View_ZoomFit;
        private CustomMenuItem mItem_View_Zoom25;
        private CustomMenuItem mItem_View_Zoom50;
        private CustomMenuItem mItem_View_Zoom100;
        private CustomMenuItem mItem_View_Zoom200;
        private CustomMenuItem mItem_View_Zoom400;
        private CustomMenuItem mItem_View_Zoom800;
        private CustomMenuItem mItem_View_SortName;
        private CustomMenuItem mItem_View_SortTime;
        private CustomMenuItem mItem_View_SortAscendingOrder;
        private CustomMenuItem mItem_View_SortDescendingOrder;
        private CustomMenuItem mItem_View_FolderDisplaySizeSmall;
        private CustomMenuItem mItem_View_FolderDisplaySizeMedium;
        private CustomMenuItem mItem_View_FolderDisplaySizeLarge;
        private CustomMenuItem mItem_View_DescriptionDisplaySizeSmall;
        private CustomMenuItem mItem_View_DescriptionDisplaySizeMedium;
        private CustomMenuItem mItem_View_DescriptionDisplaySizeLarge;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripSeparator toolStripSeparator23;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripSeparator toolStripSeparator25;
    }
}
