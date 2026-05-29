namespace WinFormsApp
{
    partial class EZTreeViewControl
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EZTreeViewControl));
            _treeView = new SmoothTreeView();
            menuPopup = new ContextMenuStrip(components);
            mItem_Expand = new CustomMenuItem();
            mItem_Collapse = new CustomMenuItem();
            mItem_separator1 = new ToolStripSeparator();
            mItem_Search = new CustomMenuItem();
            mItem_separator2 = new ToolStripSeparator();
            mItem_Resize = new CustomMenuItem();
            mItem_ResizeSmall = new CustomMenuItem();
            mItem_ResizeMedium = new CustomMenuItem();
            mItem_ResizeLarge = new CustomMenuItem();
            _imageList = new ImageList(components);
            menuPopup.SuspendLayout();
            SuspendLayout();
            // 
            // _treeView
            // 
            _treeView.ContextMenuStrip = menuPopup;
            _treeView.Dock = DockStyle.Fill;
            _treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _treeView.ImageIndex = 0;
            _treeView.ImageList = _imageList;
            _treeView.Location = new Point(0, 0);
            _treeView.Margin = new Padding(0);
            _treeView.Name = "_treeView";
            _treeView.SelectedImageIndex = 0;
            _treeView.Size = new Size(266, 705);
            _treeView.TabIndex = 2;
            _treeView.DrawNode += FolderTree_DrawNode;
            _treeView.NodeMouseClick += FolderTree_NodeMouseClick;
            // 
            // menuPopup
            // 
            menuPopup.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuPopup.ImageScalingSize = new Size(20, 20);
            menuPopup.Items.AddRange(new ToolStripItem[] { mItem_Expand, mItem_Collapse, mItem_separator1, mItem_Search, mItem_separator2, mItem_Resize });
            menuPopup.Name = "contextMenuStrip1";
            menuPopup.Size = new Size(142, 104);
            // 
            // mItem_Expand
            // 
            mItem_Expand.MarkCheck = EMarkCheckIcon.None;
            mItem_Expand.Name = "mItem_Expand";
            mItem_Expand.Size = new Size(141, 22);
            mItem_Expand.Text = "全て開く(O)";
            // 
            // mItem_Collapse
            // 
            mItem_Collapse.MarkCheck = EMarkCheckIcon.None;
            mItem_Collapse.Name = "mItem_Collapse";
            mItem_Collapse.Size = new Size(141, 22);
            mItem_Collapse.Text = "全て閉じる (C)";
            // 
            // mItem_separator1
            // 
            mItem_separator1.Name = "mItem_separator1";
            mItem_separator1.Size = new Size(138, 6);
            // 
            // mItem_Search
            // 
            mItem_Search.MarkCheck = EMarkCheckIcon.None;
            mItem_Search.Name = "mItem_Search";
            mItem_Search.Size = new Size(141, 22);
            mItem_Search.Text = "検索 (S)";
            // 
            // mItem_separator2
            // 
            mItem_separator2.Name = "mItem_separator2";
            mItem_separator2.Size = new Size(138, 6);
            // 
            // mItem_Resize
            // 
            mItem_Resize.DropDownItems.AddRange(new ToolStripItem[] { mItem_ResizeSmall, mItem_ResizeMedium, mItem_ResizeLarge });
            mItem_Resize.MarkCheck = EMarkCheckIcon.None;
            mItem_Resize.Name = "mItem_Resize";
            mItem_Resize.Size = new Size(141, 22);
            mItem_Resize.Text = "サイズ (Z)";
            // 
            // mItem_ResizeSmall
            // 
            mItem_ResizeSmall.MarkCheck = EMarkCheckIcon.None;
            mItem_ResizeSmall.Name = "mItem_ResizeSmall";
            mItem_ResizeSmall.Size = new Size(99, 22);
            mItem_ResizeSmall.Text = "小(S)";
            // 
            // mItem_ResizeMedium
            // 
            mItem_ResizeMedium.MarkCheck = EMarkCheckIcon.None;
            mItem_ResizeMedium.Name = "mItem_ResizeMedium";
            mItem_ResizeMedium.Size = new Size(99, 22);
            mItem_ResizeMedium.Text = "中(M)";
            // 
            // mItem_ResizeLarge
            // 
            mItem_ResizeLarge.MarkCheck = EMarkCheckIcon.None;
            mItem_ResizeLarge.Name = "mItem_ResizeLarge";
            mItem_ResizeLarge.Size = new Size(99, 22);
            mItem_ResizeLarge.Text = "大(L)";
            // 
            // _imageList
            // 
            _imageList.ColorDepth = ColorDepth.Depth32Bit;
            _imageList.TransparentColor = Color.Magenta;
            // 
            // EZTreeViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_treeView);
            Margin = new Padding(0);
            Name = "EZTreeViewControl";
            Size = new Size(266, 705);
            menuPopup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SmoothTreeView _treeView;
        private ImageList _imageList;
        private ContextMenuStrip menuPopup;
        private CustomMenuItem mItem_Expand;
        private CustomMenuItem mItem_Collapse;
        private ToolStripSeparator mItem_separator1;
        private CustomMenuItem mItem_Search;
        private ToolStripSeparator mItem_separator2;
        private CustomMenuItem mItem_Resize;
        private CustomMenuItem mItem_ResizeSmall;
        private CustomMenuItem mItem_ResizeMedium;
        private CustomMenuItem mItem_ResizeLarge;
    }
}
