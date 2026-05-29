using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class TopMenuBarControl : UserControl
    {
 
        // ── File ──
        /// <inheritdoc/>
        public event EventHandler? FileOpenHandler;
        /// <inheritdoc/>
        public event EventHandler? FileReloadHandler;
#pragma warning disable CS0067
        /// <inheritdoc/>
        public event EventHandler? FileSaveHandler;
#pragma warning restore CS0067
        /// <inheritdoc/>
        public event EventHandler? FilePrintPhotoListHandler;
        /// <inheritdoc/>
        public event EventHandler? FilePrintInspectionHistoryHandler;
        /// <inheritdoc/>
        public event EventHandler? FileImportCSVHandler;
        /// <inheritdoc/>
        public event EventHandler? FileExportCSVHandler;
        /// <inheritdoc/>
        public event EventHandler? FileTransferHandler;
        /// <inheritdoc/>
        public event EventHandler? FileImportTransferDataHandler;
        /// <inheritdoc/>
        public event EventHandler? FileExportTransferDataHandler;
        /// <inheritdoc/>
        public event EventHandler? FileExitHandler;

        //// ── View ──
        ///// <inheritdoc/>
        //public event EventHandler<TEZViewStyle>? FolderDisplaySizeHandler;
        ///// <inheritdoc/>
        //public event EventHandler<TEZViewStyle>? DescriptionSizeHandler;
        ///// <inheritdoc/>
        //public event EventHandler<TEZViewStyle>? ImageListSizeHandler;
        /// <inheritdoc/>
        public event EventHandler? NextPhotoClicked;
        /// <inheritdoc/>
        public event EventHandler? PrevPhotoClicked;
        /// <inheritdoc/>
        public event EventHandler? OpenPhotoConfirmClicked;
        /// <inheritdoc/>
        public event EventHandler? DisplayPhotoClicked;
        /// <inheritdoc/>
        public event EventHandler? InfoPanelClicked;
        /// <inheritdoc/>
        public event EventHandler? TreeViewDisplayClicked;
        /// <inheritdoc/>
        //public event EventHandler<RotateState>? RotateStateHandler;
        /// <inheritdoc/>
        public event EventHandler<double>? ZoomHandler;
        /// <inheritdoc/>
        public event EventHandler? ConstructionInfoPhotoXmlClicked;
        /// <inheritdoc/>
        public event EventHandler? ConstructionInfoIndexCClicked;

        /// <summary>
        /// Event fired when the 'View -> 写真・参考図切替' flat menu item is clicked.
        /// Replaces the old TogglePhoto/ToggleDiagram submenu pattern.
        /// </summary>
        public event EventHandler? ToggleReferenceHandler;

        // ── Toggle kept for interface compat (not wired to menu items) ──
#pragma warning disable CS0067
        /// <inheritdoc/>
        public event EventHandler? TogglePhotoHandler;
        /// <inheritdoc/>
        public event EventHandler? ToggleDiagramHandler;
#pragma warning restore CS0067

        /// <inheritdoc/>
        //public event EventHandler<SortStyle>? SortImageItemsByStyle;
        /// <inheritdoc/>
        public event EventHandler<bool>? SortImageItemsByInverseStatus;

        // ── Help ──
        /// <inheritdoc/>
        public event EventHandler? HelpVersionInfoHandler;
        // Kept for interface compat — no longer wired to menu items (FrmViewer only has VersionInfo)
#pragma warning disable CS0067
        /// <inheritdoc/>
        public event EventHandler? HelpTableOfContentsHandler;
        /// <inheritdoc/>
        public event EventHandler? HelpKeywordSearchHandler;
        /// <inheritdoc/>
        public event EventHandler? HelpDescriptionHandler;
#pragma warning restore CS0067

        // ── Tools ──
        /// <inheritdoc/>
        public event EventHandler? NoToNGHandler;
        /// <inheritdoc/>
        public event EventHandler? OkToNGHandler;
        /// <inheritdoc/>
        public event EventHandler? FileInfoTooltipToggled;
        /// <inheritdoc/>
        public event EventHandler? SearchMenuItemClicked;
        /// <inheritdoc/>
        public event EventHandler? CopyImageItemClicked;

        // ── Display Mode ──
        /// <inheritdoc/>
        public event EventHandler? DisplayModePhotoListClicked;
        /// <inheritdoc/>
        public event EventHandler? DisplayModePhotoInfoGridClicked;
        /// <inheritdoc/>
        public event EventHandler? DisplayModeFileInfoClicked;

        // ── Grid Column Settings ──
        /// <inheritdoc/>
        public event EventHandler? GridColumnSettingsClicked;

        // ── Title Toggle ──
        /// <inheritdoc/>
        //public event EventHandler<EViewTitleMode>? TitleToggleHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopMenuBarControl"/> class.
        /// </summary>
        public TopMenuBarControl()
        {
            InitializeComponent();
            SetupEvents();

            //_localResourceManager = new ResourceManager(typeof(TopMenuBarControl).FullName!, Assembly.GetExecutingAssembly());

            //LocalizationManager.Instance.LanguageChanged += Instance_LanguageChanged;
            SetupViews();
        }

        //public void SetConstructionInfoUiService(IConstructionInfoUiService service)
        //{
        //    _constructionInfoUiService = service ?? throw new ArgumentNullException(nameof(service));
        //}

        /// <summary>
        /// Sets up event handlers for all menu items in the top menu bar.
        /// </summary>
        private void SetupEvents()
        {
            // File — FolderSelect fires FileOpenHandler (folder-open action)
            mItem_File_FolderSelect.Click += OnFileOpenClick;
            mItem_File_Reload.Click += OnFileReloadClick;
            mItem_File_PrintPhotoList.Click += OnFilePrintPhotoListClick;
            mItem_File_PrintInspectionHistory.Click += OnFilePrintInspectionHistoryClick;
            mItem_File_ImportCSV.Click += OnFileImportCSVClick;
            mItem_File_ExportCSV.Click += OnFileExportCSVClick;
            mItem_File_Transfer.Click += OnFileTransferClick;
            mItem_File_ImportTransferData.Click += OnFileImportTransferDataClick;
            mItem_File_ExportTransferData.Click += OnFileExportTransferDataClick;
            mItem_File_Exit.Click += OnFileExitClick;

            // Edit
            mItem_Edit_Copy.Click += OnCopyImageClick;

            // View
            // View — Construction Info
            mItem_View_PhotoInfoXML.Click += (s, e) => ConstructionInfoPhotoXmlClicked?.Invoke(this, e);
            mItem_View_ConstructionInfoXML.Click += (s, e) => ConstructionInfoIndexCClicked?.Invoke(this, e);

            mItem_View_NextPhoto.Click += OnNextPhotoClicked;
            mItem_View_PreviousPhoto.Click += OnPreviousPhotoClicked;

            mItem_View_FolderDisplaySizeSmall.Click += OnFolderDisplaySizeSmallClicked;
            mItem_View_FolderDisplaySizeMedium.Click += OnFolderDisplaySizeMediumClicked;
            mItem_View_FolderDisplaySizeLarge.Click += OnFolderDisplaySizeLargeClicked;

            mItem_View_DescriptionDisplaySizeSmall.Click += OnDescriptionSizeSmallClicked;
            mItem_View_DescriptionDisplaySizeMedium.Click += OnDescriptionSizeMediumClicked;
            mItem_View_DescriptionDisplaySizeLarge.Click += OnDescriptionSizeLargeClicked;

            mItem_View_PhotoConfirmation.Click += OnOpenPhotoConfirmFormClicked;
            mItem_View_PhotoDisplay.Click += OnDisplayPhotoClicked;
            mItem_View_PhotoInfoDisplay.Click += OnPhotoInfoDisplayClicked;
            mItem_View_TreeViewDisplay.Click += OnTreeViewDisplayClicked;

            // Toggle Reference — flat item replacing old submenu
            mItem_View_ToggleReference.Click += OnToggleReferenceClick;

            // Rotate
            mItem_View_RotateDefault.Click += OnRotateDefaultClick;
            mItem_View_Rotate90.Click += OnRotate90Click;
            mItem_View_Rotate180.Click += OnRotate180Click;
            mItem_View_Rotate270.Click += OnRotate270Click;

            // Zoom
            mItem_View_ZoomFit.Click += OnZoomFitClick;
            mItem_View_Zoom25.Click += OnZoom25Click;
            mItem_View_Zoom50.Click += OnZoom50Click;
            mItem_View_Zoom100.Click += OnZoom100Click;
            mItem_View_Zoom200.Click += OnZoom200Click;
            mItem_View_Zoom400.Click += OnZoom400Click;
            mItem_View_Zoom800.Click += OnZoom800Click;

            mItem_View_SortName.Click += OnSortByNameClick;
            mItem_View_SortTime.Click += OnSortByTimeClick;
            mItem_View_SortAscendingOrder.Click += OnSortAscendingClick;
            mItem_View_SortDescendingOrder.Click += OnSortDescendingClick;

            // Settings - Size Toggle
            mItem_Settings_SizeToggleSmall.Click += OnImageListSizeSmallClicked;
            mItem_Settings_SizeToggleMedium.Click += OnImageListSizeMediumClicked;
            mItem_Settings_SizeToggleLarge.Click += OnImageListSizeLargeClicked;
            mItem_Settings_SizeToggle4Photos.Click += OnImageListSize4PhotosClicked;

            // Settings - Inspection Comment
            mItem_Settings_InspectionCommentDashToNG.Click += OnToolsCommentDashClick;
            mItem_Settings_InspectionCommentInspectedToNG.Click += OnToolsCommentInspectedClick;

            // Settings - File Info Tooltip (ファイル情報のヒント表示)
            mItem_Settings_FileInfoTooltip.Click += OnFileInfoTooltipClick;

            // Display Mode (表示切替)
            mItem_View_DisplayModePhotoList.Click += OnDisplayModePhotoListClick;
            mItem_View_DisplayModePhotoInfo.Click += OnDisplayModePhotoInfoGridClick;
            mItem_View_DisplayModeFileInfo.Click += OnDisplayModeFileInfoClick;

            // Title Toggle (写真一覧タイトル切替)
            mItem_Settings_TitleToggleFileName.Click += OnTitleToggleFileNameClick;
            mItem_Settings_TitleTogglePhotoTitle.Click += OnTitleTogglePhotoTitleClick;
            mItem_Settings_TitleToggleLocation.Click += OnTitleToggleLocationClick;

            // Settings - Grid Column Settings (一覧表示項目設定)
            mItem_Settings_ListDisplaySettings.Click += (_, e) => GridColumnSettingsClicked?.Invoke(this, e);

            // Help — only VersionInfo remains
            mItem_Help_VersionInfo.Click += OnHelpVersionInfoClick;
        }

        private void OnSortByNameClick(object? sender, EventArgs e) {
            //SetSortStyleDisplay(SortStyle.ssFileName);
        } 
        private void OnSortByTimeClick(object? sender, EventArgs e){
           // SetSortStyleDisplay(SortStyle.ssUpdateDT);
        } 
        private void OnSortAscendingClick(object? sender, EventArgs e) => SetSortAscedingStatusDisplay(false);
        private void OnSortDescendingClick(object? sender, EventArgs e) => SetSortAscedingStatusDisplay(true);

        /// <summary>
        /// Initializes the visual components and default states of the control.
        /// </summary>
        private void SetupViews()
        {
            // Apply CustomMenuItemRender to all menus and their sub-menu dropdowns recursively
            var renderer = new CustomMenuItemRender();
            ApplyRenderer(menuFile, renderer);
            ApplyRenderer(menuEdit, renderer);
            ApplyRenderer(menuView, renderer);
            ApplyRenderer(menuSettings, renderer);
            ApplyRenderer(menuHelp, renderer);

            //mItem_View_TreeViewDisplay.MarkCheck = EMarkCheckIcon.Check;
            mItem_View_TreeViewDisplay.Checked = true;
            //mItem_View_PhotoInfoDisplay.MarkCheck = EMarkCheckIcon.Check;
            mItem_View_PhotoInfoDisplay.Checked = true;
            mItem_View_PhotoDisplay.MarkCheck = EMarkCheckIcon.Check;
            mItem_View_PhotoDisplay.Checked = true;

            // Rotate
            //mItem_View_RotateDefault.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Rotate90.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Rotate180.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Rotate270.MarkCheck = EMarkCheckIcon.Dot;

            // Zoom
            //mItem_View_ZoomFit.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Zoom25.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Zoom50.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Zoom100.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Zoom200.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Zoom400.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_Zoom800.MarkCheck = EMarkCheckIcon.Dot;

            // Folder display size
            //mItem_View_FolderDisplaySizeSmall.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_FolderDisplaySizeMedium.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_FolderDisplaySizeLarge.MarkCheck = EMarkCheckIcon.Dot;

            // Description display size
            //mItem_View_DescriptionDisplaySizeSmall.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_DescriptionDisplaySizeMedium.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_DescriptionDisplaySizeLarge.MarkCheck = EMarkCheckIcon.Dot;

            // Sort
            //mItem_View_SortAscendingOrder.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_SortDescendingOrder.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_SortName.MarkCheck = EMarkCheckIcon.Dot;
            //mItem_View_SortTime.MarkCheck = EMarkCheckIcon.Dot;

            // Settings - Inspection Comment
            //mItem_Settings_InspectionCommentDashToNG.MarkCheck = EMarkCheckIcon.Check;
            //mItem_Settings_InspectionCommentInspectedToNG.MarkCheck = EMarkCheckIcon.Check;

            // Settings - File Info Tooltip
            //mItem_Settings_FileInfoTooltip.MarkCheck = EMarkCheckIcon.Check;

            // Display Mode (表示切替) — dot-style radio selection
            //mItem_View_DisplayModePhotoList.MarkCheck = EMarkCheckIcon.Check;
            //mItem_View_DisplayModePhotoInfo.MarkCheck = EMarkCheckIcon.Check;
            //mItem_View_DisplayModeFileInfo.MarkCheck = EMarkCheckIcon.Check;
            //mItem_View_DisplayModePhotoList.Checked = true; // default: PhotoList

            //_localResourceManager = new ResourceManager(typeof(TopMenuBarControl).FullName!, Assembly.GetExecutingAssembly());
        }

        // ── Toggle Reference ──────────────────────────────────────────────────

        /// <summary>
        /// Recursively applies a renderer to a ToolStrip and all nested sub-menu dropdowns.
        /// </summary>
        private static void ApplyRenderer(ToolStrip strip, ToolStripRenderer renderer)
        {
            strip.Renderer = renderer;
            foreach (ToolStripItem item in strip.Items)
                if (item is ToolStripMenuItem mi)
                    ApplyRendererToDropDown(mi, renderer);
        }

        private static void ApplyRendererToDropDown(ToolStripMenuItem item, ToolStripRenderer renderer)
        {
            if (item.HasDropDownItems)
            {
                item.DropDown.Renderer = renderer;
                foreach (ToolStripItem child in item.DropDownItems)
                    if (child is ToolStripMenuItem mi)
                        ApplyRendererToDropDown(mi, renderer);
            }
        }

        /// <summary>
        /// Handles the click event for the '写真・参考図切替 (&S)' flat menu item.
        /// </summary>
        private void OnToggleReferenceClick(object? sender, EventArgs e)
        {
            ToggleReferenceHandler?.Invoke(this, EventArgs.Empty);
        }

        // ── Tools ────────────────────────────────────────────────────────────

        /// <summary>
        /// Handles the click event for the 'Auto NG from None' menu item.
        /// </summary>
        private void OnToolsCommentDashClick(object? sender, EventArgs e)
        {
            mItem_Settings_InspectionCommentDashToNG.Checked = !mItem_Settings_InspectionCommentDashToNG.Checked;
            NoToNGHandler?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles the click event for the 'Auto NG from OK' menu item.
        /// </summary>
        private void OnToolsCommentInspectedClick(object? sender, EventArgs e)
        {
            mItem_Settings_InspectionCommentInspectedToNG.Checked = !mItem_Settings_InspectionCommentInspectedToNG.Checked;
            OkToNGHandler?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets the initial checked state of the comment modification options.
        /// </summary>
        public void SetCommentOptions(bool isNoToNG, bool isOkToNG)
        {
            mItem_Settings_InspectionCommentDashToNG.Checked = isNoToNG;
            mItem_Settings_InspectionCommentInspectedToNG.Checked = isOkToNG;
        }

        /// <summary>
        /// Handles the click event for the 'ファイル情報のヒント表示(&H)' menu item.
        /// </summary>
        private void OnFileInfoTooltipClick(object? sender, EventArgs e)
        {
            mItem_Settings_FileInfoTooltip.Checked = !mItem_Settings_FileInfoTooltip.Checked;
            FileInfoTooltipToggled?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets the checked state of the file-info tooltip menu item.
        /// </summary>
        public void SetFileInfoTooltip(bool enabled)
        {
            mItem_Settings_FileInfoTooltip.Checked = enabled;
        }

        private void OnCopyImageClick(object? sender, EventArgs e) => CopyImageItemClicked?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Sets the checked state of the search photo menu item.
        /// </summary>
        public void SetSearchPhotoChecked(bool isChecked)
        {
            // Search menu item is no longer visible, but keep method for interface compatibility
        }

        // ── Sort ─────────────────────────────────────────────────────────────

        /// <summary>
        /// Loads the initial status of the sort menu items.
        /// </summary>
        //public void LoadSortMenuItemsStatus(SortStyle sortStyle, bool isInverse)
        //{
        //    //mItem_View_SortName.Checked = sortStyle == SortStyle.ssFileName;
        //    //mItem_View_SortTime.Checked = sortStyle == SortStyle.ssUpdateDT;
        //    mItem_View_SortAscendingOrder.Checked = !isInverse;
        //    mItem_View_SortDescendingOrder.Checked = isInverse;
        //}

        //private void SetSortStyleDisplay(SortStyle sortStyle)
        //{
        //    //SortImageItemsByStyle?.Invoke(null, sortStyle);
        //    mItem_View_SortName.Checked = sortStyle == SortStyle.ssFileName;
        //    mItem_View_SortTime.Checked = sortStyle == SortStyle.ssUpdateDT;
        //}

        private void SetSortAscedingStatusDisplay(bool isInverse)
        {
            SortImageItemsByInverseStatus?.Invoke(null, isInverse);
            mItem_View_SortAscendingOrder.Checked = !isInverse;
            mItem_View_SortDescendingOrder.Checked = isInverse;
        }

        // ── Help ─────────────────────────────────────────────────────────────

        private void OnHelpVersionInfoClick(object? sender, EventArgs e) => HelpVersionInfoHandler?.Invoke(sender, e);

        // ── File ─────────────────────────────────────────────────────────────

        private void OnFileOpenClick(object? sender, EventArgs e) => FileOpenHandler?.Invoke(sender, e);
        private void OnFileReloadClick(object? sender, EventArgs e) => FileReloadHandler?.Invoke(this, e);
        private void OnFileExitClick(object? sender, EventArgs e) => FileExitHandler?.Invoke(sender, e);
        private void OnFileExportTransferDataClick(object? sender, EventArgs e) => FileExportTransferDataHandler?.Invoke(sender, e);
        private void OnFileImportTransferDataClick(object? sender, EventArgs e) => FileImportTransferDataHandler?.Invoke(sender, e);
        private void OnFileTransferClick(object? sender, EventArgs e) => FileTransferHandler?.Invoke(sender, e);
        private void OnFileExportCSVClick(object? sender, EventArgs e) => FileExportCSVHandler?.Invoke(sender, e);
        private void OnFileImportCSVClick(object? sender, EventArgs e) => FileImportCSVHandler?.Invoke(sender, e);
        private void OnFilePrintInspectionHistoryClick(object? sender, EventArgs e) => FilePrintInspectionHistoryHandler?.Invoke(sender, e);
        private void OnFilePrintPhotoListClick(object? sender, EventArgs e) => FilePrintPhotoListHandler?.Invoke(sender, e);

        // ── Zoom ─────────────────────────────────────────────────────────────

        private void OnZoom800Click(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, 8);
        private void OnZoom400Click(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, 4);
        private void OnZoom200Click(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, 2);
        private void OnZoom100Click(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, 1);
        private void OnZoom50Click(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, 0.5);
        private void OnZoom25Click(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, 0.25);
        private void OnZoomFitClick(object? sender, EventArgs e) => ZoomHandler?.Invoke(this, -1);

        // ── Rotate ───────────────────────────────────────────────────────────

        private void OnRotate270Click(object? sender, EventArgs e) {
            //RotateStateHandler?.Invoke(this, RotateState.rs270); SetRotateStateStyle(RotateState.rs270); 
        }
        private void OnRotate180Click(object? sender, EventArgs e) {
            //RotateStateHandler?.Invoke(this, RotateState.rs180); SetRotateStateStyle(RotateState.rs180);
        }
        private void OnRotate90Click(object? sender, EventArgs e) { 
            //RotateStateHandler?.Invoke(this, RotateState.rs90); SetRotateStateStyle(RotateState.rs90); 
        }
        private void OnRotateDefaultClick(object? sender, EventArgs e) {
            //RotateStateHandler?.Invoke(this, RotateState.rsNone); SetRotateStateStyle(RotateState.rsNone); 
        }

        // ── View misc ────────────────────────────────────────────────────────

        private void OnDisplayPhotoClicked(object? sender, EventArgs e)
        {
            this.mItem_View_PhotoDisplay.Checked = !mItem_View_PhotoDisplay.Checked;
            DisplayPhotoClicked?.Invoke(this, e);
        }
        private void OnPhotoInfoDisplayClicked(object? sender, EventArgs e)
        {
            mItem_View_PhotoDisplay.Checked = !mItem_View_PhotoDisplay.Checked;
             InfoPanelClicked?.Invoke(this, e);
        }
        private void OnTreeViewDisplayClicked(object? sender, EventArgs e) => TreeViewDisplayClicked?.Invoke(this, e);
        private void OnOpenPhotoConfirmFormClicked(object? sender, EventArgs e) => OpenPhotoConfirmClicked?.Invoke(this, EventArgs.Empty);
        private void OnNextPhotoClicked(object? sender, EventArgs e) => NextPhotoClicked?.Invoke(this, e);
        private void OnPreviousPhotoClicked(object? sender, EventArgs e) => PrevPhotoClicked?.Invoke(this, e);

        private void OnFolderDisplaySizeSmallClicked(object? sender, EventArgs e){}
        private void OnFolderDisplaySizeMediumClicked(object? sender, EventArgs e) { }
        private void OnFolderDisplaySizeLargeClicked(object? sender, EventArgs e) { }
        private void OnDescriptionSizeSmallClicked(object? sender, EventArgs e) { }
        private void OnDescriptionSizeMediumClicked(object? sender, EventArgs e) { }
        private void OnDescriptionSizeLargeClicked(object? sender, EventArgs e) { }
        private void OnImageListSizeSmallClicked(object? sender, EventArgs e) { }
        private void OnImageListSizeMediumClicked(object? sender, EventArgs e) { }
        private void OnImageListSizeLargeClicked(object? sender, EventArgs e) { }
        private void OnImageListSize4PhotosClicked(object? sender, EventArgs e) { }

        // ── Localization ─────────────────────────────────────────────────────

        private void Instance_LanguageChanged(object? sender, EventArgs e)
        {
            // ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            //btnFile.Text = _localResourceManager.GetString("btnFile") + "(&F)";
            //btnView.Text = _localResourceManager.GetString("btnView") + "(&V)";
            //btnHelp.Text = _localResourceManager.GetString("btnHelp") + "(&H)";

            //mItem_File_Reload.Text = _localResourceManager.GetString("mItem_File_Reload") + "(&R)";
            //mItem_File_Print.Text = _localResourceManager.GetString("mItem_File_Print") + "(&P)";
            //mItem_File_PrintPhotoList.Text = _localResourceManager.GetString("mItem_File_PrintPhotoList") + "(&P)...";
            //mItem_File_PrintInspectionHistory.Text = _localResourceManager.GetString("mItem_File_PrintInspectionHistory") + "(&L)...";
            //mItem_File_ImportCSV.Text = _localResourceManager.GetString("mItem_File_ImportCSV") + "(&I)...";
            //mItem_File_ExportCSV.Text = _localResourceManager.GetString("mItem_File_ExportCSV") + "(&O)...";
            //mItem_File_Transfer.Text = _localResourceManager.GetString("mItem_File_Transfer") + "(&T)...";
            //mItem_File_ImportTransferData.Text = _localResourceManager.GetString("mItem_File_ImportTransferData") + "(&I)...";
            //mItem_File_ExportTransferData.Text = _localResourceManager.GetString("mItem_File_ExportTransferData") + "(&O)...";
            //mItem_File_Exit.Text = _localResourceManager.GetString("mItem_File_Exit") + "(&X)";

            //mItem_View_PhotoConfirmation.Text = _localResourceManager.GetString("mItem_View_PhotoConfirmation") + "(&C)";
            //mItem_View_PhotoDisplay.Text = _localResourceManager.GetString("mItem_View_PhotoDisplay") + "(&V)";
            //mItem_View_PreviousPhoto.Text = _localResourceManager.GetString("mItem_View_PreviousPhoto") + "(&P)";
            //mItem_View_NextPhoto.Text = _localResourceManager.GetString("mItem_View_NextPhoto") + "(&N)";
            //mItem_View_ToggleReference.Text = _localResourceManager.GetString("mItem_View_ToggleReference") + "(&S)";
            //mItem_View_Rotate.Text = _localResourceManager.GetString("mItem_View_Rotate") + "(&R)";
            //mItem_View_Zoom.Text = _localResourceManager.GetString("mItem_View_Zoom") + "(&Z)";
            //mItem_View_ZoomFit.Text = _localResourceManager.GetString("mItem_View_ZoomFit") + "(&Z)";
            //mItem_View_SortAscendingOrder.Text = _localResourceManager.GetString("mItem_View_SortAscendingOrder") + "(&U)";
            //mItem_View_SortDescendingOrder.Text = _localResourceManager.GetString("mItem_View_SortDescendingOrder") + "(&D)";
            //mItem_View_FolderDisplaySize.Text = _localResourceManager.GetString("mItem_View_FolderDisplaySize") + "(&Y)";
            //mItem_View_FolderDisplaySizeSmall.Text = _localResourceManager.GetString("mItem_View_FolderDisplaySizeSmall") + "(&S)";
            //mItem_View_FolderDisplaySizeMedium.Text = _localResourceManager.GetString("mItem_View_FolderDisplaySizeMedium") + "(&M)";
            //mItem_View_FolderDisplaySizeLarge.Text = _localResourceManager.GetString("mItem_View_FolderDisplaySizeLarge") + "(&L)";
            //mItem_View_DescriptionDisplaySize.Text = _localResourceManager.GetString("mItem_View_DescriptionDisplaySize") + "(&E)";
            //mItem_View_DescriptionDisplaySizeSmall.Text = _localResourceManager.GetString("mItem_View_DescriptionDisplaySizeSmall") + "(&S)";
            //mItem_View_DescriptionDisplaySizeMedium.Text = _localResourceManager.GetString("mItem_View_DescriptionDisplaySizeMedium") + "(&M)";
            //mItem_View_DescriptionDisplaySizeLarge.Text = _localResourceManager.GetString("mItem_View_DescriptionDisplaySizeLarge") + "(&L)";

            //mItem_Help_VersionInfo.Text = _localResourceManager.GetString("mItem_Help_VersionInfo") + "(&A)...";
        }

        // ── Button click → show context menu ─────────────────────────────────

        private void button1_Click(object sender, EventArgs e) => menuFile.Show(btnFile, new Point(0, btnFile.Height));
        private void button2_Click(object sender, EventArgs e) => menuView.Show(btnView, new Point(0, btnView.Height));
        private void button4_Click(object sender, EventArgs e) => menuHelp.Show(btnHelp, new Point(0, btnHelp.Height));
        private void button5_Click(object sender, EventArgs e) => menuEdit.Show(btnEdit, new Point(0, btnEdit.Height));
        private void button6_Click(object sender, EventArgs e) => menuSettings.Show(btnSettings, new Point(0, btnSettings.Height));

        // ── ITopMenuBarView public API ────────────────────────────────────────

        /// <inheritdoc/>
        public void SetConstructionInfoEnabled(bool photoXmlEnabled, bool indexCEnabled, string? kojKnrFileName)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => SetConstructionInfoEnabled(photoXmlEnabled, indexCEnabled, kojKnrFileName)));
                return;
            }

            //var svc = _constructionInfoUiService ?? new ConstructionInfoUiService();
            //svc.ApplyConstructionInfoState(
            //    enabled => mItem_View_PhotoInfoXML.Enabled = enabled,
            //    enabled => mItem_View_ConstructionInfoXML.Enabled = enabled,
            //    text => mItem_View_ConstructionInfoXML.Text = text,
            //    photoXmlEnabled,
            //    indexCEnabled,
            //    kojKnrFileName);
        }

        /// <inheritdoc/>
        public void SetRotateEnabled(bool enable) => mItem_View_Rotate.Enabled = enable;
        /// <inheritdoc/>
        public void SetZoomEnabled(bool enable) => mItem_View_Zoom.Enabled = enable;
        /// <inheritdoc/>
        public void SetToggleEnabled(bool enable) => mItem_View_ToggleReference.Enabled = enable;
        /// <inheritdoc/>
        public void SetNextPhotoEnabled(bool enable) => mItem_View_NextPhoto.Enabled = enable;
        /// <inheritdoc/>
        public void SetPreviousPhotoEnabled(bool enable) => mItem_View_PreviousPhoto.Enabled = enable;

        /// <inheritdoc/>
        //public void SetFolderDisplaySizeStyle(TEZViewStyle style)
        //{
        //    mItem_View_FolderDisplaySizeSmall.Checked = style == TEZViewStyle.evSmall;
        //    mItem_View_FolderDisplaySizeMedium.Checked = style == TEZViewStyle.evMedium;
        //    mItem_View_FolderDisplaySizeLarge.Checked = style == TEZViewStyle.evLarge;
        //}

        ///// <inheritdoc/>
        //public void SetDescriptionSizeStyle(TEZViewStyle style)
        //{
        //    mItem_View_DescriptionDisplaySizeSmall.Checked = style == TEZViewStyle.evSmall;
        //    mItem_View_DescriptionDisplaySizeMedium.Checked = style == TEZViewStyle.evMedium;
        //    mItem_View_DescriptionDisplaySizeLarge.Checked = style == TEZViewStyle.evLarge;
        //}

        ///// <inheritdoc/>
        //public void SetImageListSizeStyle(TEZViewStyle style)
        //{
        //    mItem_Settings_SizeToggleSmall.Checked = style == TEZViewStyle.evSmall;
        //    mItem_Settings_SizeToggleMedium.Checked = style == TEZViewStyle.evMedium;
        //    mItem_Settings_SizeToggleLarge.Checked = style == TEZViewStyle.evLarge;
        //    mItem_Settings_SizeToggle4Photos.Checked = style == TEZViewStyle.evFour;
        //}

        ///// <inheritdoc/>
        //public void SetRotateStateStyle(RotateState state)
        //{
        //    mItem_View_RotateDefault.Checked = false;
        //    mItem_View_Rotate90.Checked = false;
        //    mItem_View_Rotate180.Checked = false;
        //    mItem_View_Rotate270.Checked = false;
        //    switch (state)
        //    {
        //        case RotateState.rs90: mItem_View_Rotate90.Checked = true; break;
        //        case RotateState.rs180: mItem_View_Rotate180.Checked = true; break;
        //        case RotateState.rs270: mItem_View_Rotate270.Checked = true; break;
        //        default: mItem_View_RotateDefault.Checked = true; break;
        //    }
        //}

        /// <inheritdoc/>
        public void SetPhotoEnabled(bool enable)
        {
            mItem_View_PhotoConfirmation.Enabled = enable;
            mItem_View_PreviousPhoto.Enabled = enable;
            mItem_View_NextPhoto.Enabled = enable;
            mItem_View_Rotate.Enabled = enable;
            mItem_View_Zoom.Enabled = enable;
            mItem_Edit_Copy.Enabled = enable;
        }

        /// <inheritdoc/>
        public void SetDisplayPhotoChecked(bool check) => mItem_View_PhotoDisplay.Checked = check;
        /// <inheritdoc/>
        public void SetDisplayPhotoEnabled(bool enable) => mItem_View_PhotoDisplay.Enabled = enable;
        /// <inheritdoc/>
        public void SetInfoPanelChecked(bool check) => mItem_View_PhotoInfoDisplay.Checked = check;
        /// <inheritdoc/>
        public void SetInfoPanelEnabled(bool enable) => mItem_View_PhotoInfoDisplay.Enabled = enable;
        /// <inheritdoc/>
        public void SetTreeViewChecked(bool check) => mItem_View_TreeViewDisplay.Checked = check;
        /// <inheritdoc/>
        public void SetTreeViewEnabled(bool enable) => mItem_View_TreeViewDisplay.Enabled = enable;
        /// <inheritdoc/>
        public void SetDescriptionEnabled(bool enable) => mItem_View_DescriptionDisplaySize.Enabled = enable;
        /// <inheritdoc/>
        public void SetSearchPhotoEnabled(bool enable) { }

        /// <inheritdoc/>
        public void SetZoomValue(double zoom)
        {
            mItem_View_ZoomFit.Checked = false;
            mItem_View_Zoom25.Checked = false;
            mItem_View_Zoom50.Checked = false;
            mItem_View_Zoom100.Checked = false;
            mItem_View_Zoom200.Checked = false;
            mItem_View_Zoom400.Checked = false;
            mItem_View_Zoom800.Checked = false;
            switch (zoom)
            {
                case 0.25: mItem_View_Zoom25.Checked = true; break;
                case 0.5: mItem_View_Zoom50.Checked = true; break;
                case 1: mItem_View_Zoom100.Checked = true; break;
                case 2: mItem_View_Zoom200.Checked = true; break;
                case 4: mItem_View_Zoom400.Checked = true; break;
                case 8: mItem_View_Zoom800.Checked = true; break;
                default: mItem_View_ZoomFit.Checked = true; break;
            }
        }

        /// <summary>
        /// No-op: the old photo/diagram toggle submenu has been replaced by the flat 
        /// 写真・参考図切替 item. Kept for <see cref="ITopMenuBarView"/> compatibility.
        /// </summary>
        public void SetToggleState(bool isPhotoSelected) { }

        // ── Display Mode ─────────────────────────────────────────────────────

        private void OnDisplayModePhotoListClick(object? sender, EventArgs e) =>
            DisplayModePhotoListClicked?.Invoke(this, EventArgs.Empty);

        private void OnDisplayModePhotoInfoGridClick(object? sender, EventArgs e) =>
            DisplayModePhotoInfoGridClicked?.Invoke(this, EventArgs.Empty);

        private void OnDisplayModeFileInfoClick(object? sender, EventArgs e) =>
            DisplayModeFileInfoClicked?.Invoke(this, EventArgs.Empty);

        /// <inheritdoc/>
        //public void SetDisplayModeChecked(EShowMode mode)
        //{
        //    mItem_View_DisplayModePhotoList.Checked = mode == EShowMode.PhotoList;
        //    mItem_View_DisplayModePhotoInfo.Checked = mode == EShowMode.PhotoInfoGrid;
        //    mItem_View_DisplayModeFileInfo.Checked = mode == EShowMode.FileInfo;
        //}

        // ── Title Toggle ─────────────────────────────────────────────────────

        private void OnTitleToggleFileNameClick(object? sender, EventArgs e) { }

        private void OnTitleTogglePhotoTitleClick(object? sender, EventArgs e) { }

        private void OnTitleToggleLocationClick(object? sender, EventArgs e) { }

        /// <inheritdoc/>
        //public void SetViewTitleMode(EViewTitleMode mode)
        //{
        //    mItem_Settings_TitleToggleFileName.Checked = mode == EViewTitleMode.FileName;
        //    mItem_Settings_TitleTogglePhotoTitle.Checked = mode == EViewTitleMode.PhotoTitle;
        //    mItem_Settings_TitleToggleLocation.Checked = mode == EViewTitleMode.Location;
        //}

        // ── Keyboard shortcut triggers ────────────────────────────────────────

        /// <summary>Programmatically triggers File → Reload.</summary>
        public void PerformFileReload() => mItem_File_Reload.PerformClick();
        /// <summary>Programmatically triggers File → Print Photo List.</summary>
        public void PerformFilePrintPhotoList() => mItem_File_PrintPhotoList.PerformClick();
        /// <summary>Programmatically triggers View → Previous Photo.</summary>
        public void PerformViewPreviousPhoto() => mItem_View_PreviousPhoto.PerformClick();
        /// <summary>Programmatically triggers View → Next Photo.</summary>
        public void PerformViewNextPhoto() => mItem_View_NextPhoto.PerformClick();
        /// <summary>
        /// Programmatically triggers Search functionality (no longer in menu, but kept for keyboard shortcuts).
        /// </summary>
        public void PerformToolsSearch()
        {
            // Search menu item removed from UI per DskViewCSharp structure,
            // but trigger the event directly for keyboard shortcut support
            SearchMenuItemClicked?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Programmatically triggers Help → Version Info (replaces Description shortcut;
        /// kept for F1 key binding in <see cref="MainForm"/>).
        /// </summary>
        public void PerformHelpDescription() => mItem_Help_VersionInfo.PerformClick();
    }
}
