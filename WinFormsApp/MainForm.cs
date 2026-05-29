using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WinFormsApp
{
    public partial class MainForm : System.Windows.Forms.Form
    {

        public MainForm()
        {
            InitializeComponent();
            this.btnInfoView.Click += (s, e) => InfoPanelButtonClicked(this, e);
            this.menuBarCtrl.DisplayPhotoClicked += MenuBarCtrl_DisplayPhotoClicked;
            this.btnPrintPhotoList.Click += (s, e) => OnPrintClicked(this, e);
            this.btnPrintHistory.Click += (s, e) => OnPrintHistoryClicked(this, e);

        }

        private void OnPrintHistoryClicked(MainForm mainForm, EventArgs e)
        {
            ShowInformation("PrintHistoryMessage", "PrintHistoryCaption");
        }

        private void OnPrintClicked(MainForm mainForm, EventArgs e)
        {
            ShowInformation("PrintMessage", "PrintCaption");
        }

        private void MenuBarCtrl_DisplayPhotoClicked(object? sender, EventArgs e)
        {
            this.userCtl.Visible = this.menuBarCtrl.mItem_View_PhotoDisplay.Checked;
            this.btnInfoView.Checked = this.menuBarCtrl.mItem_View_PhotoDisplay.Checked;
        }

        private void InfoPanelButtonClicked(MainForm mainForm, EventArgs e)
        {
            this.userCtl.Visible = this.btnInfoView.Checked;
            this.menuBarCtrl.mItem_View_PhotoDisplay.Checked = this.btnInfoView.Checked;
            Console.WriteLine("InfoPanelButtonClicked = " + this.btnInfoView.Checked);
        }

        private void OnClickBtn_Click(object sender, EventArgs e)
        {
            this.resultLb.Text = "Ket qua";
            this.userCtl.resultLb.Text = "Ket qua";
            this.userCtl.resultLb.AccessibleDescription = "Ket qua";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.resultLb.Text = "btnOpen_Click";
            this.panelLb.Visible = !this.panelLb.Visible;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void ShowInformation(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
