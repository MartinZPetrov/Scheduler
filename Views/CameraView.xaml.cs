﻿using Microsoft.Expression.Encoder.Devices;
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
using System.Windows.Shapes;


namespace Scheduler.Views
{
    /// <summary>
    /// Interaction logic for CameraView.xaml
    /// </summary>
    public partial class CameraView : Window
    {
        public string FilePath { get; set; }
        public event EventHandler<EventArgs> OnPicutureTaken;
        public event EventHandler OnClosing;
        public string VideoPath { get; set; }
        public string PicturePath { get; set; }
        public CameraView()
        {
            InitializeComponent();
            this.Closed += CameraView_Closed;
            Binding binding_1 = new Binding("SelectedValue");
            binding_1.Source = VideoDevicesComboBox;
            WebcamCtrl.SetBinding(Webcam.VideoDeviceProperty, binding_1);

            Binding binding_2 = new Binding("SelectedValue");
            binding_2.Source = AudioDevicesComboBox;
            WebcamCtrl.SetBinding(Webcam.AudioDeviceProperty, binding_2);

            // Create directory for saving video files
            VideoPath = @"C:\VideoClips";

            if (!Directory.Exists(VideoPath))
            {
                Directory.CreateDirectory(VideoPath);
            }
            // Create directory for saving image files
            PicturePath = @"C:\WebcamSnapshots";

            if (!Directory.Exists(PicturePath))
            {
                Directory.CreateDirectory(PicturePath);
            }

            // Set some properties of the Webcam control
            WebcamCtrl.VideoDirectory = VideoPath;
            WebcamCtrl.ImageDirectory = PicturePath;
            WebcamCtrl.FrameRate = 30;
            WebcamCtrl.FrameSize = new System.Drawing.Size(640, 480);

            // Find available a/v devices
            var vidDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
            var audDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
            VideoDevicesComboBox.ItemsSource = vidDevices;
            AudioDevicesComboBox.ItemsSource = audDevices;
            VideoDevicesComboBox.SelectedIndex = 0;
            AudioDevicesComboBox.SelectedIndex = 0;
        }

        void CameraView_Closed(object sender, EventArgs e)
        {
            if (OnClosing != null)
            {
                OnClosing(this, EventArgs.Empty);
            }
        }

        private void StartCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Display webcam video
                WebcamCtrl.StartPreview();
            }
            catch (Microsoft.Expression.Encoder.SystemErrorException ex)
            {
                MessageBox.Show("Device is in use by another application");
            }
        }

        private void StopCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            // Stop the display of webcam video.
            WebcamCtrl.StopPreview();
        }

        private void StartRecordingButton_Click(object sender, RoutedEventArgs e)
        {
            // Start recording of webcam video to harddisk.
            WebcamCtrl.StartRecording();
        }

        private void StopRecordingButton_Click(object sender, RoutedEventArgs e)
        {
            // Stop recording of webcam video to harddisk.
            WebcamCtrl.StopRecording();
        }

        private void TakeSnapshotButton_Click(object sender, RoutedEventArgs e)
        {
            // Take snapshot of webcam video.
            WebcamCtrl.TakeSnapshot();
            if (OnPicutureTaken != null)
            {
                FilePath = WebcamCtrl.FilePath;
                OnPicutureTaken(this, new EventArgs());
            }
        }
    }
}
