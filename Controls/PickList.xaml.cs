using GalaSoft.MvvmLight.Messaging;
using Scheduler.Messages;
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

namespace Scheduler.Controls
{
    /// <summary>
    /// Interaction logic for PickList.xaml
    /// </summary>
    public partial class PickList : UserControl
    {
        public PickList() : base()
        {
            InitializeComponent();
            MakeDraggable(this, this);
        }

        public void MakeDraggable(System.Windows.UIElement moveThisElement, System.Windows.UIElement movedByElement)
        {
            Point? OriginalWindowPoint = new Point?();

            bool isMousePressed = false;
            System.Windows.Media.TranslateTransform transform = new System.Windows.Media.TranslateTransform(0, 0);

            moveThisElement.RenderTransform = transform;

            System.Windows.Point originalPoint = new System.Windows.Point(0, 0), currentPoint;

            movedByElement.MouseLeftButtonDown += (a, b) =>
            {
                isMousePressed = true;
                originalPoint = ((System.Windows.Input.MouseEventArgs)b).GetPosition(moveThisElement);
            };

            movedByElement.MouseLeftButtonUp += (a, b) => isMousePressed = false;

            movedByElement.MouseLeave += (a, b) => isMousePressed = false;

            movedByElement.MouseMove += (a, b) =>
            {
                if (!OriginalWindowPoint.HasValue)
                    OriginalWindowPoint = this.TransformToAncestor(Window.GetWindow(this)).Transform(new Point(0, 0));

                if (!isMousePressed) return;

                currentPoint = ((System.Windows.Input.MouseEventArgs)b).GetPosition(moveThisElement);

                Size windowSize = new Size(((FrameworkElement)(Window.GetWindow(this).Content)).ActualWidth, ((FrameworkElement)(Window.GetWindow(this).Content)).ActualHeight);

                if (OriginalWindowPoint.Value.X + +transform.X + currentPoint.X - originalPoint.X > windowSize.Width - this.ActualWidth)
                    transform.X = 0 - OriginalWindowPoint.Value.X + windowSize.Width - this.ActualWidth;
                else
                    if (OriginalWindowPoint.Value.X + transform.X + currentPoint.X - originalPoint.X < 0)
                        transform.X = 0 - OriginalWindowPoint.Value.X;
                    else
                        transform.X += currentPoint.X - originalPoint.X;


                if (OriginalWindowPoint.Value.Y + transform.Y + currentPoint.Y - originalPoint.Y > windowSize.Height - this.ActualHeight)
                    transform.Y = 0 - OriginalWindowPoint.Value.Y + windowSize.Height - this.ActualHeight;
                else
                    if (OriginalWindowPoint.Value.Y + transform.Y + currentPoint.Y - originalPoint.Y < 0)
                        transform.Y = 0 - OriginalWindowPoint.Value.Y;
                    else
                        transform.Y += currentPoint.Y - originalPoint.Y;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lstbox = sender as ListBox;
            if (lstbox == null) return;
            lstbox.SelectedIndex = -1;
        }
    }
}
