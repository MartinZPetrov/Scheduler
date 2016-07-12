using Scheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler.Views
{
    /// <summary>
    /// Interaction logic for WorkView.xaml
    /// </summary>
    public partial class WorkView : UserControl
    {
        public WorkViewModel ViewModel { get; set; }
        public bool IsWorkStatPicture { get; set; }
        public WorkView()
        {
            InitializeComponent();
            ViewModel = this.DataContext as WorkViewModel;
        }

        private void btnPic_Click(object sender, RoutedEventArgs e)
        {
            var picControl = new CameraView();
            ViewModel.IsPicStartTaken = true;

            IsWorkStatPicture = true;
            picControl.Show();
            picControl.OnPicutureTaken += picControl_OnPicutureTaken;
            picControl.OnClosing += picControl_OnClosing;
        }

        void picControl_OnClosing(object sender, EventArgs e)
        {
            var snd = sender as CameraView;
            DirectoryInfo di = new DirectoryInfo(snd.PicturePath);
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();

                }
                catch (Exception)
                {
                }

            }
        }

        void picControl_OnPicutureTaken(object sender, EventArgs e)
        {
            var snd = sender as CameraView;
            if(snd == null)
            {
                return;
            }
            

            if (snd.FilePath == null)
            {
                return;
            }
            var uriSource = new Uri(snd.FilePath, UriKind.Absolute);

            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            var bitmapImage = new BitmapImage(uriSource);
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            if (IsWorkStatPicture)
            {
                ViewModel.PictureStartTaken = data;
            }
            else
            {
                ViewModel.PictureEndTaken = data;
            }
        }

        private void btnPicEnd_Click(object sender, RoutedEventArgs e)
        {
            var picControl = new CameraView();
            ViewModel.IsPicStartTaken = false;
            IsWorkStatPicture = false;
            picControl.Show();
            picControl.OnPicutureTaken += picControl_OnPicutureTaken;
            picControl.OnClosing += picControl_OnClosing;
            
            
        }
    }
}
