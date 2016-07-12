using Scheduler.Helpers;
using Scheduler.Models;
using Scheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ScheduleControl.xaml
    /// </summary>
    public partial class ScheduleControl : UserControl
    {
        private static double currentPositionX = 0;
        public readonly Dictionary<DataGridCellInfo, int[]> cellInfoToTableRowAndColumn = new Dictionary<DataGridCellInfo, int[]>();
        public int MonthSchedule { get; set; }

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(ScheduleControl), new PropertyMetadata(null));

        public ScheduleViewModel ViewModel { get; set; }

        public ScheduleControl()
        {
            InitializeComponent();
            this.GotFocus += ScheduleControl_GotFocus;
        }

        void ScheduleControl_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.ScheduleClicked = this.MonthSchedule;
            ViewModel.RefreshSheduleDetails();

        }

        private void Context_Copy(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedItemsToCopy.Clear();
            foreach (var item in dgSchedules.SelectedCells)
            {
                ViewModel.SelectedItemsToCopy.Add(item.Item as Scheduledetail);
            }
        }


        private void Context_Paste(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toBindedList = (Scheduledetail)item.SelectedCells[0].Item;

            ViewModel.PasteSheduleDetails(toBindedList);

        }

        private void Context_Delete(object sender, RoutedEventArgs e)
        {
            List<Scheduledetail> itemsToDelete = new List<Scheduledetail>();
            foreach (var item in dgSchedules.SelectedCells)
            {
                itemsToDelete.Add(item.Item as Scheduledetail);
            }

            this.ViewModel.DeleteScheduleDetails(itemsToDelete);
        }

        private void Context_Insert(object sender, RoutedEventArgs e)
        {

            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toBindedList = (Scheduledetail)item.SelectedCells[0].Item;

            //Remove the toDeleteFromBindedList object from your ObservableCollection
            this.ViewModel.AddScheduleDetails(toBindedList);
        }

        private void CopyDay(object sender, RoutedEventArgs e)
        {

            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toBindedList = (Scheduledetail)item.SelectedCells[0].Item;

            ViewModel.CopyAllPerDay(toBindedList);

        }

        private void PasteDay(object sender, RoutedEventArgs e)
        {
            ViewModel.PasteAllPerDay();
        }

        private void CLose_CLick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
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

        private void CopyWeek(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toBindedList = (Scheduledetail)item.SelectedCells[0].Item;

            ViewModel.CopyAllPerWeek(toBindedList);

        }

        private void PasteWeek(object sender, RoutedEventArgs e)
        {

            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toBindedList = (Scheduledetail)item.SelectedCells[0].Item;

            ViewModel.PasteAllPerWeek(toBindedList);
        }

        private void dgSchedules_CurrentCellChanged(object sender, EventArgs e)
        {
            var dg = sender as DataGrid;
        }

        private void dgSchedules_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            ItemContainerGenerator generator = dg.ItemContainerGenerator;
            if (dg.SelectedCells.Count > 0)
            {
                cellInfoToTableRowAndColumn.Clear();
            }
            foreach (var cell in dg.SelectedCells)
            {
                if (dg.SelectedCells.Count > 1) return;
                int row = generator.IndexFromContainer(generator.ContainerFromItem(cell.Item));
                int column = cell.Column.DisplayIndex;
                //cellInfoToTableRowAndColumn[cell] = new[] { row, column };
                cellInfoToTableRowAndColumn.Add(cell, new[] { row, column });
            }

            if (dg.SelectedCells.Count > 0 && dg.SelectedCells[0].Item != null)
            {
                ViewModel.DgSelectedScheduleDetail = dg.SelectedCells[0].Item as Scheduledetail;
                ViewModel.GetEmployeesPerSiteAndGroup(dg.SelectedCells[0].Item as Scheduledetail);
            }
        }


        private bool CheckSelectedCellsRef(IList<DataGridCellInfo> selectedCells)
        {
            int scheduleRef = 0;
            bool isValid = true;
            for (int i = 0; i < selectedCells.Count; i++)
            {
                if (i == 0)
                {
                    scheduleRef = ((Scheduledetail)selectedCells[i].Item).Schedule_Ref;
                }
                else
                {
                    if (((Scheduledetail)selectedCells[i].Item).Schedule_Ref != scheduleRef)
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }

        private void dgSchedules_MouseMove(object sender, MouseEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            int direction;
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                return;
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (dg.SelectedCells.Count > 1 && CheckSelectedCellsRef(dg.SelectedCells))
                {
                    double deltaDirection = currentPositionX - e.GetPosition(this).X;
                    direction = deltaDirection > 0 ? 1 : -1;
                    currentPositionX = e.GetPosition(this).X;

                    var cellInfos = dg.SelectedCells;
                    List<string> list1 = new List<string>();
                    string cellValue = string.Empty;
                    //first we check if right is needed

                    bool first = true;
                    if (direction == -1)
                    {
                        //TextBlock checkContent = cellInfos[0].Column.GetCellContent(cellInfos[0].Item) as TextBlock;
                        foreach (DataGridCellInfo cellInfo in cellInfos)
                        {
                            if (cellInfo.IsValid)
                            {
                                var content = cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock;
                                var binding = content.GetBindingExpression(TextBlock.TextProperty);
                                if (content != null)
                                {
                                    if (first)
                                    {
                                        cellValue = content.Text;
                                        first = false;
                                    }
                                    else
                                    {
                                        content.SetValue(TextBlock.TextProperty, cellValue);
                                        binding.UpdateSource();
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        for (int i = cellInfos.Count - 1; i >= 0; i--)
                        {
                            if (cellInfos[i].IsValid)
                            {
                                var content = cellInfos[i].Column.GetCellContent(cellInfos[i].Item) as TextBlock;
                                var binding = content.GetBindingExpression(TextBlock.TextProperty);
                                if (content != null)
                                {
                                    if (first)
                                    {
                                        cellValue = content.Text;
                                        first = false;
                                    }
                                    else
                                    {

                                        content.SetValue(TextBlock.TextProperty, cellValue);
                                        binding.UpdateSource();
                                    }
                                }
                            }
                        }

                    }

                }
            }
            else
            {
                currentPositionX = e.GetPosition(this).X;
            }

        }

        private void Choose_Week(object sender, RoutedEventArgs e)
        {
            this.favWeekControl.Visibility = Visibility.Visible;
            this.favWeekControl.dgFavWeek.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ViewModel.SetFavouriteWeeksData() });
        }

        private void dgSchedules_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var a = (column.Binding as Binding).Path;
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "Col10")
                    {
                        int rowIndex = e.Row.GetIndex();
                    }
                }
            }

        }


        private void Choose_Employee(object sender, RoutedEventArgs e)
        {
            this.empPL.Visibility = Visibility.Visible;
        }
    }
}
