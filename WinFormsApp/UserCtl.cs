using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WinFormsApp
{
    public partial class UserCtl : UserControl
    {
        Image? image;
        private CancellationTokenSource? _loadImageDataCts;
        public UserCtl()
        {
            InitializeComponent();
            pictureBox.Image = null;
            pictureBox.AccessibleName = "NoImage";

            _loadImageDataCts?.Cancel();
            _loadImageDataCts = new CancellationTokenSource();
            var token = _loadImageDataCts.Token;
            string loadPath = @"C:\Shared\Standard Data\PHOTO03\PHOTO03\PHOTO\PIC\P0000001.JPG";
            LoadImageAsync(loadPath);
        }

        public async Task LoadImageAsync(string path)
        {
            _loadImageDataCts?.Cancel();
            _loadImageDataCts = new CancellationTokenSource();
            var token = _loadImageDataCts.Token;
            image = await Task.Run(() =>
            {
                token.ThrowIfCancellationRequested();
                return GetImage(path);
            }, token);
        }

        public Image? GetImage(string path)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(path);

                using (MemoryStream ms = new MemoryStream(imageData))
                using (Image tempImage = Image.FromStream(ms))
                {
                    return new Bitmap(tempImage);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox.Image = image;
                pictureBox.AccessibleName = "HasImage";
            }
            else
            {
                pictureBox.Image = null;
                pictureBox.AccessibleName = "NoImage";
            }

        }
    }
}
