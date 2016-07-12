using Scheduler.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.IO;
using Scheduler.Models;

namespace Scheduler.Views
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public string FilePathPic { get; set; }
        private UsersViewModel ViewModel { get; set; } 
        public UsersView()
        {
            InitializeComponent();
            ViewModel = this.DataContext as UsersViewModel;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBoxEmail = sender as TextBox;
            if(textBoxEmail == null)
            {
                return;
            }
            if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                var result = MessageBox.Show("Enter a valid email.", "Attention", MessageBoxButton.OK,
                                                    MessageBoxImage.Question);
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                
            }
        }
        private void btnPic_click(object sender, RoutedEventArgs e)
        {
            var picControl = new CameraView();
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
            FilePathPic = snd.FilePath;

            if(FilePathPic == null)
            {
                return;
            }
            var uriSource = new Uri(FilePathPic, UriKind.Absolute);

            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            var bitmapImage = new BitmapImage(uriSource);
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            
            
            ViewModel.PicFilePath = FilePathPic;
            if (ViewModel.UserImageSelection != null)
            {
                ViewModel.UserImageSelection = new UserImage
                {
                    Image_Ref = ViewModel.UserImageSelection.Image_Ref,
                    User_Ref = ViewModel.UserImageSelection.User_Ref,
                    User = ViewModel.UserImageSelection.User,
                    Image = data
                };
            }
   
        }
    }
}
