using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;
using PlateDetector;

namespace IPSS
{
    public partial class frmDemo : Form
    {
        VideoCaptureDevice m_videoSource;
        Detector detector;
        Thread t2;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public frmDemo()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopLoading()
        {
            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;
            progressBar1.Visible = false;
            label2.Text = "";
            btnGetPlate.Enabled = true;
            btnStartScan.Enabled = true;
        }       
       
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsValidPlate(string plate)
        {
            if (plate.Length <10)
                return false;
            return true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()        
        {
            cbCamera.Items.Clear();
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {                
                StopLoading();
                MessageBox.Show("Can not find camera");
            }
            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add("Camera " + (i + 1).ToString());
            }
            cbCamera.SelectedIndex = 0;
            if (videosources != null)
            {
                m_videoSource = new VideoCaptureDevice(videosources[0].MonikerString);
                m_videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
                m_videoSource.Start();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitModel()
        {
            label2.Text = "Loading data, please wait...";
            detector = new Detector();
            btnStartScan.Enabled = true;
            StopLoading();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            picCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(picCamera.Image);
            string result = detector.GetLicensePlate(bmp);
            if (IsValidPlate(result))
            {
                txtResult.Text= result;
                timer1.Stop();
                StopLoading();
                btnStartScan.Text = "Start";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStartScan.Text == "Start")
            {
                txtResult.Text = "";
                btnStartScan.Text = "Stop";
                timer1.Start();
                timerProgressbar.Start();
                progressBar1.Visible = true;
            }
            else
            {
                btnStartScan.Text = "Start";
                timer1.Stop();
                StopLoading();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            t2 = new Thread(new ThreadStart(InitModel));
            t2.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopTimer()
        {
            timer1.Stop();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_videoSource !=null)
                m_videoSource.Stop();   
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnStart_EnabledChanged(object sender, EventArgs e)
        {
            if (btnStartScan.Enabled)
            {
                StopLoading();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cbCamera.SelectedIndex].MonikerString);
                m_videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
                m_videoSource.Start();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnGetPlate_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
                return;
            Bitmap bmp = new Bitmap(txtFilePath.Text);
            txtResult.Text = detector.GetLicensePlate(bmp);
            picCamera.Image = bmp;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCamera.Checked)
            {
                grpCamera.Visible = true;
                grpImage.Visible = false;
                InitCamera();
            }
            else
            {
                grpCamera.Visible = false;
                grpImage.Visible = true;
                if (m_videoSource != null)
                {
                    m_videoSource.Stop();
                    picCamera.Image = null;
                }
                    
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files |*.bmp;*.jpg;*.png;*.BMP;*.JPG;*.PNG";
            ofd.ShowDialog();
            txtFilePath.Text = ofd.FileName;
        }


    }
}
