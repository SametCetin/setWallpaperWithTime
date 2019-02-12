using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace setWallPaperWithTime
{
    public partial class Form1 : Form
    {

        
        

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        public Form1()
        {
            InitializeComponent();
            
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            this.Hide();
            tmrSetWallPaper.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Form1 form1 = new Form1();
            form1.Visible = false;
            form1.Hide();
            this.Opacity = 1;
            */
        }

        private void tmrSetWallPaper_Tick(object sender, EventArgs e)
        {
            tmrSetWallPaper.Enabled = false;
            SetWallpaper("C:\\Windows\\Web\\Wallpaper\\Windows\\img0.jpg");
            Application.Exit();
            //SetWallpaper("C:\\Windows\\Web\\Wallpaper\\Theme1\\img2.jpg");
            /* this.Opacity = 100;
            this.Show();
            MessageBox.Show("abcd");
            */

        }

        public void SetWallpaper(String path)
        {
            try
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                    SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
            catch
            { }
        }

    }
}
