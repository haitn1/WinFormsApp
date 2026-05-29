using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public enum TEZViewStyle
    {
        evSmall = 0,
        evMedium,
        evLarge,
        evFour
    }
    public interface IEzTreeData
    {
        /// <summary>
        /// Gets or sets the display name of the tree node.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the absolute index of the tree node.
        /// </summary>
        int AbsoluteIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the parent node.
        /// </summary>
        int ParentIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tree node is expanded.
        /// </summary>
        bool Expand { get; set; }

        /// <summary>
        /// Gets or sets the count of pictures associated with this node.
        /// </summary>
        int PctCount { get; set; } // Picture Count

        /// <summary>
        /// Gets or sets the count of errors associated with this node.
        /// </summary>
        int ErrCount { get; set; } // Error Count
    }
    public partial class EZTreeViewControl : UserControl
    {
        /// <summary>
        /// Manages localized resources for the control.
        /// </summary>
        private ResourceManager _localResourceManager;

        /// <inheritdoc/>
        public event EventHandler<IEzTreeData>? FolderSeletedHandler;
        /// <inheritdoc/>
        public event EventHandler<TEZViewStyle>? TreeViewStyleHandler;
        /// <inheritdoc/>
        public event EventHandler<string>? ChangeFolderPathInFormTitleHandler;
        /// <inheritdoc/>
        public event EventHandler? ToggleSearchPanelRequested;

        /// <summary>
        /// Stores the default width of the tree view's icons.
        /// </summary>
        private int _folderTreeIconSizeDefault;
        /// <summary>
        /// Caches the currently selected tree node.
        /// </summary>
        TreeNode _selectedNode = new TreeNode();
        /// <summary>
        /// A flag to indicate that a right-click mouse action is in progress.
        /// </summary>
        private bool _isRightClicking = false;
        /// <summary>
        /// Gets the underlying TreeView control.
        /// </summary>
        public TreeView FolderTree => _treeView;
        /// <summary>
        /// Initializes a new instance of the <see cref="EZTreeViewControl"/> class.
        /// </summary>
        public EZTreeViewControl()
        {
            InitializeComponent();

            // WHY: Set HideSelection to false to keep the selected node highlighted even when the control loses focus.
            _treeView.HideSelection = false;
            if (_treeView.ImageList != null)
                _folderTreeIconSizeDefault = _treeView.ImageList.ImageSize.Width;
            _localResourceManager = new ResourceManager(typeof(EZTreeViewControl).FullName!, Assembly.GetExecutingAssembly());
          
            SetupEvents();
            SetupViews();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int State { get; set; }

     
        public void ExecuteModalLoadingWork(string message, Func<Task> work, CancellationTokenSource cts)
        {
           
        
            // WHY: After the loading form is closed (either by completion or cancellation),
            // expand nodes based on their data's Expand property instead of expanding all.
            ExpandNodesBasedOnData();

            // WHY: After expanding, the TreeView sometimes scrolls to the last node.
            // We want to ensure the top of the tree is visible and the first node is selected.
            if (_treeView.Nodes.Count > 0)
            {
                TreeNode firstNode = _treeView.Nodes[0];
                _treeView.SelectedNode = firstNode;
                firstNode.EnsureVisible();
            }
        }

        /// <summary>
        /// Sets up the context menu items and their click handlers.
        /// </summary>
        private void SetupEvents()
        {
            _treeView.MouseDown += FolderTree_MouseDown;
            _treeView.AfterSelect += FolderTree_AfterSelect;
            _treeView.Enter += (s, e) => _treeView.SelectedNode?.TreeView?.Invalidate();
            _treeView.Leave += (s, e) => _treeView.SelectedNode?.TreeView?.Invalidate();
            mItem_ResizeSmall.Click += OnResizeSmallClicked;
            mItem_ResizeMedium.Click += OnResizeMediumClicked;
            mItem_ResizeLarge.Click += OnResizeLargeClicked;
            mItem_Expand.Click += ExpandSelectedNode;
            mItem_Collapse.Click += CollapseSelectedNode;
            mItem_Search.Click += OnSearchClicked;
        }

        /// <summary>
        /// Shows the check mark depend on check status.
        /// </summary>
        public void UpdateSearchCheckStatus(bool isChecked)
        {
            mItem_Search.Checked = isChecked;
        }

        /// <summary>
        /// Handles the click event for the 'Search' menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSearchClicked(object? sender, EventArgs e)
        {
            ToggleSearchPanelRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles the click event for the 'Resize Large' menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnResizeLargeClicked(object? sender, EventArgs e)
        {
            TreeViewStyleHandler?.Invoke(this, TEZViewStyle.evLarge);
        }

        /// <summary>
        /// Handles the click event for the 'Resize Medium' menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnResizeMediumClicked(object? sender, EventArgs e)
        {
            TreeViewStyleHandler?.Invoke(this, TEZViewStyle.evMedium);
        }

        /// <summary>
        /// Handles the click event for the 'Resize Small' menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnResizeSmallClicked(object? sender, EventArgs e)
        {
            TreeViewStyleHandler?.Invoke(this, TEZViewStyle.evSmall);
        }

        /// <summary>
        /// Initializes the visual components and default states of the control.
        /// </summary>
        private void SetupViews()
        {
            CheckMarkRendererHelper.ApplyRenderer(menuPopup, new CustomMenuItemRender());
            mItem_ResizeSmall.MarkCheck = EMarkCheckIcon.Dot;
            mItem_ResizeMedium.MarkCheck = EMarkCheckIcon.Dot;
            mItem_ResizeLarge.MarkCheck = EMarkCheckIcon.Dot;
            mItem_Search.MarkCheck = EMarkCheckIcon.Check;
        }

        /// <summary>
        /// Handles the language changed event to re-apply localized strings.
        /// </summary>
        private void Instance_LanguageChanged(object? sender, EventArgs e)
        {
            //ApplyLanguage();
        }

        /// <summary>
        /// Applies localized text to the context menu items.
        /// </summary>
        private void ApplyLanguage()
        {
            mItem_Expand.Text = _localResourceManager.GetString("mItem_Expand") + "(&O)";
            mItem_Collapse.Text = _localResourceManager.GetString("mItem_Collapse") + "(&C)";
            mItem_Search.Text = _localResourceManager.GetString("mItem_Search") + "(&S)";
            mItem_Resize.Text = _localResourceManager.GetString("mItem_Resize") + "(&Z)";
            mItem_ResizeSmall.Text = _localResourceManager.GetString("mItem_ResizeSmall") + "(&S)";
            mItem_ResizeMedium.Text = _localResourceManager.GetString("mItem_ResizeMedium") + "(&M)";
            mItem_ResizeLarge.Text = _localResourceManager.GetString("mItem_ResizeLarge") + "(&L)";
        }

        /// <summary>
        /// Expands the currently selected node.
        /// </summary>
        private void ExpandSelectedNode(object? sender, EventArgs e)
        {
            if (_treeView.SelectedNode == null) return;
            _treeView.SelectedNode.ExpandAll();

        }
        /// <summary>
        /// Collapses the currently selected node.
        /// </summary>
        private void CollapseSelectedNode(object? sender, EventArgs e)
        {
            if (_treeView.SelectedNode == null) return;
            _treeView.SelectedNode.Collapse();
        }

        /// <inheritdoc/>
        public void ResizeTreeView(TEZViewStyle style)
        {
            mItem_ResizeSmall.Checked = false;
            mItem_ResizeMedium.Checked = false;
            mItem_ResizeLarge.Checked = false;
            switch (style)
            {
                case TEZViewStyle.evSmall:
                    mItem_ResizeSmall.Checked = true;
                    ZoomFolderListTree(9);
                    break;
                case TEZViewStyle.evMedium:
                    mItem_ResizeMedium.Checked = true;
                    ZoomFolderListTree(12);
                    break;
                case TEZViewStyle.evLarge:
                    mItem_ResizeLarge.Checked = true;
                    ZoomFolderListTree(15);
                    break;
            }
        }

        /// <inheritdoc/>
        public void UpdateTreeNodeNameByErrorPhotoNumber(string nodeName, int errCount)
        {
            TreeNode selNode = _selectedNode;
            if (selNode != null)
            {
                string errCountDisplay = "";
                if (errCount != 0) errCountDisplay = "R[" + errCount + "]";
                string replacePattern = @"R\[.*?\]";

                if (Regex.IsMatch(selNode.Text, replacePattern))
                    selNode.Text = Regex.Replace(selNode.Text, replacePattern, errCountDisplay);
                else
                    selNode.Text += errCountDisplay;

            }
        }

        /// <summary>
        /// A dictionary to map an AbsoluteIndex to a TreeNode for efficient lookup when parenting.
        /// </summary>
        private Dictionary<int, TreeNode> _nodeMap = new Dictionary<int, TreeNode>();

        /// <inheritdoc/>
        public void ClearTree()
        {
            _treeView.BeginUpdate();
            _treeView.Nodes.Clear();
            _nodeMap.Clear();
            _treeView.EndUpdate();
        }

        /// <inheritdoc/>
        public void AddNode(IEzTreeData item)
        {
            // This method will be called from the UI thread via IProgress<T>,
            // so direct manipulation of the TreeView is safe.
            string name = item.Name;
            int containedImageNumber = item.PctCount;
            if (containedImageNumber > 0) name += " B[" + containedImageNumber + "]";

            int commentedImageNumber = item.ErrCount;
            if (commentedImageNumber > 0) name += "R[" + commentedImageNumber + "]";

            var newNode = new TreeNode(name) { Tag = item };
            _nodeMap[item.AbsoluteIndex] = newNode;

            if (item.ParentIndex != -1 && _nodeMap.ContainsKey(item.ParentIndex))
            {
                // This is a child node.
                _nodeMap[item.ParentIndex].Nodes.Add(newNode);
            }
            else
            {
                // This is a root node.
                _treeView.Nodes.Add(newNode);
            }
        }
        /// <summary>
        /// Adjusts the font size and icon size of the tree view.
        /// </summary>
        /// <param name="fontSize">The new font size.</param>
        private void ZoomFolderListTree(int fontSize)
        {
            _treeView.Font = new Font("MS UI Gothic", fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            if (_treeView.ImageList == null) return;

            float sizeRate = fontSize / 9f;
            ImageList newImageList = new ImageList();
            newImageList.ImageSize = new Size(
                (int)(_folderTreeIconSizeDefault * sizeRate),
                (int)(_folderTreeIconSizeDefault * sizeRate)
            );

            foreach (Image icon in _treeView.ImageList.Images)
            {
                newImageList.Images.Add(icon);
            }
            _treeView.ImageList = newImageList;
        }

        /// <summary>
        /// Custom draws the tree node to apply different colors and styles to parts of the text.
        /// When selected, the node text becomes bold, with only the main part having a highlight background.
        /// </summary>
        private void FolderTree_DrawNode(object? sender, DrawTreeNodeEventArgs e)
        {
            // WHY: Ensure node and graphics context are valid before proceeding.
            if (e.Node == null || e.Graphics == null) return;

            TreeNode node = e.Node;
            string nodeText = node.Text;
            bool isSelected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;

            // WHY: Use a bold font for selected nodes to improve visibility, otherwise use the default font.
            using (Font drawFont = new Font(node.TreeView.Font, isSelected ? FontStyle.Bold : FontStyle.Regular))
            {
                // Parse the nodeText into its components
                string mainText = nodeText;
                string blueText = string.Empty;
                string redText = string.Empty;

                int indexB = nodeText.IndexOf(" B[");
                int indexR = nodeText.IndexOf("R[");

                // WHY: Extract main text, blue count, and red count based on their prefixes.
                if (indexB != -1)
                {
                    mainText = nodeText.Substring(0, indexB); // e.g., "MyFolder"
                    if (indexR != -1 && indexR > indexB)
                    {
                        // Both B and R are present
                        string bluePartWithPrefix = nodeText.Substring(indexB + 1, indexR - (indexB + 1)); // e.g., "B[3]"
                        int blueBracketIndex = bluePartWithPrefix.IndexOf('[');
                        blueText = (blueBracketIndex != -1) ? bluePartWithPrefix.Substring(blueBracketIndex) : string.Empty; // e.g., "[3]"

                        string redPartWithPrefix = nodeText.Substring(indexR); // e.g., "R[1]"
                        int redBracketIndex = redPartWithPrefix.IndexOf('[');
                        redText = (redBracketIndex != -1) ? redPartWithPrefix.Substring(redBracketIndex) : string.Empty; // e.g., "[1]"
                    }
                    else
                    {
                        // Only B is present
                        string bluePartWithPrefix = nodeText.Substring(indexB + 1); // e.g., "B[3]"
                        int blueBracketIndex = bluePartWithPrefix.IndexOf('[');
                        blueText = (blueBracketIndex != -1) ? bluePartWithPrefix.Substring(blueBracketIndex) : string.Empty; // e.g., "[3]"
                    }
                }
                else if (indexR != -1)
                {
                    // Only R is present (no B)
                    mainText = nodeText.Substring(0, indexR);
                    string redPartWithPrefix = nodeText.Substring(indexR);
                    int redBracketIndex = redPartWithPrefix.IndexOf('[');
                    redText = (redBracketIndex != -1) ? redPartWithPrefix.Substring(redBracketIndex) : string.Empty;
                }

                // --- Drawing Logic ---
                // WHY: Fill the entire node bounds with the default window background first.
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

                int currentX = e.Bounds.X;

                // 1. Draw mainText
                Size mainTextSize = TextRenderer.MeasureText(e.Graphics, mainText, drawFont, Size.Empty, TextFormatFlags.VerticalCenter);
                Rectangle mainTextBounds = new Rectangle(currentX, e.Bounds.Y, mainTextSize.Width, e.Bounds.Height);
                Color mainBackColor = isSelected ? SystemColors.Highlight : SystemColors.Window;
                Color mainForeColor = isSelected ? SystemColors.HighlightText : node.ForeColor;

                using (SolidBrush backBrush = new SolidBrush(mainBackColor))
                {
                    e.Graphics.FillRectangle(backBrush, mainTextBounds);
                }
                TextRenderer.DrawText(e.Graphics, mainText, drawFont, mainTextBounds, mainForeColor, TextFormatFlags.VerticalCenter);
                currentX = mainTextBounds.Right;

                // 2. Draw the space (if custom parts exist)
                if (!string.IsNullOrEmpty(blueText) || !string.IsNullOrEmpty(redText))
                {
                    string singleSpace = " ";
                    // WHY: Use NoPadding for the space to get the tightest measurement and prevent it from appearing too wide.
                    Size singleSpaceSize = TextRenderer.MeasureText(e.Graphics, singleSpace, drawFont, Size.Empty, TextFormatFlags.NoPadding);
                    Rectangle singleSpaceBounds = new Rectangle(currentX, e.Bounds.Y, singleSpaceSize.Width, e.Bounds.Height);
                    // WHY: The space should always have the window background, even if the node is selected.
                    using (SolidBrush spaceBackBrush = new SolidBrush(SystemColors.Window))
                    {
                        e.Graphics.FillRectangle(spaceBackBrush, singleSpaceBounds);
                    }
                    TextRenderer.DrawText(e.Graphics, singleSpace, drawFont, singleSpaceBounds, node.ForeColor, TextFormatFlags.VerticalCenter);
                    currentX = singleSpaceBounds.Right;
                }

                // 3. Draw blueText
                if (!string.IsNullOrEmpty(blueText))
                {
                    Size blueTextSize = TextRenderer.MeasureText(e.Graphics, blueText, drawFont, Size.Empty, TextFormatFlags.VerticalCenter);
                    Rectangle blueTextBounds = new Rectangle(currentX, e.Bounds.Y, blueTextSize.Width, e.Bounds.Height);
                    TextRenderer.DrawText(e.Graphics, blueText, drawFont, blueTextBounds, Color.Blue, TextFormatFlags.VerticalCenter);
                    currentX = blueTextBounds.Right;
                }

                // 4. Draw redText
                if (!string.IsNullOrEmpty(redText))
                {
                    Size redTextSize = TextRenderer.MeasureText(e.Graphics, redText, drawFont, Size.Empty, TextFormatFlags.VerticalCenter);
                    Rectangle redTextBounds = new Rectangle(currentX, e.Bounds.Y, redTextSize.Width, e.Bounds.Height);
                    TextRenderer.DrawText(e.Graphics, redText, drawFont, redTextBounds, Color.Red, TextFormatFlags.VerticalCenter);
                    currentX = redTextBounds.Right;
                }

                // 5. Draw focus rectangle around the selected node's text when the TreeView has focus
                DrawTreeNodeFocusRectangle(e, mainTextBounds);
            }
        }

        public static void DrawTreeNodeFocusRectangle(DrawTreeNodeEventArgs e, Rectangle textBounds)
        {
            if ((e.State & TreeNodeStates.Selected) != 0 && e.Node?.TreeView?.Focused == true)
                ControlPaint.DrawFocusRectangle(e.Graphics, textBounds);
        }
        /// <summary>
        /// Handles selection changes in the tree view from any source (mouse, keyboard).
        /// </summary>
        private void FolderTree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            // If the selection was triggered by a right-click, only update the UI state
            // without loading data. Otherwise, load the data for left-clicks and keyboard navigation.
            if (_isRightClicking)
            {
                ProcessSelectedNode(e.Node, false); // Don't load data
                _isRightClicking = false; // Reset the flag immediately
            }
            else
            {
                ProcessSelectedNode(e.Node, true); // Load data
            }
        }

        /// <summary>
        /// Processes the currently selected node, updating models and UI elements.
        /// </summary>
        /// <param name="node">The node to process.</param>
        /// <param name="loadData">If true, triggers the data loading process.</param>
        private void ProcessSelectedNode(TreeNode node, bool loadData)
        {
            if (node == null || node.TreeView != _treeView) return; // Ensure the node is valid and attached to this TreeView

            _selectedNode = node;

            if (loadData && _selectedNode.Tag != null )
            {
                FolderSelected(_selectedNode.Tag);
            }

            // Show or hide context menu items based on whether the node has children.
            if (_selectedNode.Nodes.Count > 0)
            {
                mItem_separator1.Visible = true;
                mItem_Expand.Visible = true;
                mItem_Collapse.Visible = true;
            }
            else
            {
                mItem_separator1.Visible = false;
                mItem_Expand.Visible = false;
                mItem_Collapse.Visible = false;
            }

            string fullPath = node.Text;
            TreeNode currentNode = node.Parent;
            while (currentNode != null)
            {
                fullPath = currentNode.Text + _treeView.PathSeparator + fullPath;
                currentNode = currentNode.Parent;
            }
            ChangeFolderPathInFormTitleHandler?.Invoke(this, fullPath);
        }

        /// <summary>
        /// Handles the MouseDown event to detect right-clicks before other events fire.
        /// </summary>
        private void FolderTree_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _isRightClicking = true;
                // Select the node under the cursor to ensure it's the target for the context menu.
                TreeNode node = _treeView.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    _treeView.SelectedNode = node;
                }
            }
        }

        /// <summary>
        /// Handles node clicks to select the node and trigger the folder selected event.
        /// </summary>
        private void FolderTree_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (_treeView.Nodes.Count == 0) return; // If the tree is empty, no valid node can be clicked.

            // AfterSelect does not fire when re-clicking an already selected node.
            // This ensures that a left-click re-selection still triggers a data reload.
            if (e.Button == MouseButtons.Left && e.Node == _treeView.SelectedNode)
            {
                TreeViewHitTestInfo info = _treeView.HitTest(e.Location);
                if (info.Location == TreeViewHitTestLocations.Label ||
                    info.Location == TreeViewHitTestLocations.Image)
                {
                    ProcessSelectedNode(e.Node, true);
                }
            }
        }

        /// <summary>
        /// Invokes the FolderSeletedHandler event.
        /// </summary>
        /// <param name="data">The data of the selected folder.</param>
        private void FolderSelected(object data)
        {
           // FolderSeletedHandler?.Invoke(this, data);
        }

        /// <inheritdoc/>
        public void TriggerSelectedNodeClick()
        {
            TreeNode currentNode = _treeView.SelectedNode;
            if (currentNode != null && currentNode.Tag != null)
            {
                // Invoke the primary folder selection handler
                FolderSelected(currentNode.Tag);

                // Also invoke the handler to update the form title, mimicking the original click event
                string fullPath = currentNode.Text;
                TreeNode parent = currentNode.Parent;
                while (parent != null)
                {
                    fullPath = parent.Text + _treeView.PathSeparator + fullPath;
                    parent = parent.Parent;
                }
                ChangeFolderPathInFormTitleHandler?.Invoke(this, fullPath);
            }
        }

        /// <summary>
        /// Helper method to find a node by its data's AbsoluteIndex recursively.
        /// </summary>
        /// <param name="nodes">The collection of nodes to search within.</param>
        /// <param name="index">The AbsoluteIndex of the node to find.</param>
        /// <returns>The TreeNode if found, otherwise null.</returns>
        private TreeNode? FindNodeByAbsoluteIndex(TreeNodeCollection nodes, int index)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is IEzTreeData data && data.AbsoluteIndex == index)
                {
                    return node;
                }
                // Recursively search in child nodes
                TreeNode? foundNode = FindNodeByAbsoluteIndex(node.Nodes, index);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }

        /// <inheritdoc/>
        public void FocusTreeView()
        {
            this.BeginInvoke((Action)(() => _treeView.Focus()));
        }

        /// <summary>
        /// Expands tree nodes based on their data's Expand property.
        /// This method runs AFTER all nodes are loaded to ensure nodes have children before expansion.
        /// </summary>
        private void ExpandNodesBasedOnData()
        {
            void ExpandRecursive(TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag is IEzTreeData data && data.Expand)
                    {
                        node.Expand();
                    }
                    ExpandRecursive(node.Nodes);
                }
            }

            _treeView.BeginUpdate();
            ExpandRecursive(_treeView.Nodes);
            _treeView.EndUpdate();
        }

        /// <inheritdoc/>
        public void RestoreSelection(int absoluteIndex)
        {
            if (absoluteIndex != -1 && _treeView.Nodes.Count > 0)
            {
                TreeNode? nodeToSelect = FindNodeByAbsoluteIndex(_treeView.Nodes, absoluteIndex);
                if (nodeToSelect != null)
                {
                    _treeView.SelectedNode = nodeToSelect;
                    nodeToSelect.EnsureVisible();
                }
            }
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Unsubscribe from all events to prevent memory leaks
               
                _treeView.MouseDown -= FolderTree_MouseDown;
                _treeView.AfterSelect -= FolderTree_AfterSelect;
                _treeView.DrawNode -= FolderTree_DrawNode;
                _treeView.NodeMouseClick -= FolderTree_NodeMouseClick;
                mItem_ResizeSmall.Click -= OnResizeSmallClicked;
                mItem_ResizeMedium.Click -= OnResizeMediumClicked;
                mItem_ResizeLarge.Click -= OnResizeLargeClicked;
                mItem_Expand.Click -= ExpandSelectedNode;
                mItem_Collapse.Click -= CollapseSelectedNode;
                mItem_Search.Click -= OnSearchClicked;

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
