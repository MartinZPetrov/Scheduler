using Scheduler.Models;
using Scheduler.Support;
using Scheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using doc = System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using shp = System.Windows.Shapes;
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.Data;
using System.IO;
using System.Windows.Media;
using Scheduler.Controls;
using System.Windows.Controls.Primitives;


namespace Scheduler.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        private ScheduleViewModel ViewModel { get; set; }
        public ScheduleControl ctrlScheduleJan { get; set; }
        public ScheduleControl ctrlScheduleFeb { get; set; }
        public ScheduleControl ctrlScheduleMarch { get; set; }
        public ScheduleControl ctrlScheduleApr { get; set; }
        public ScheduleControl ctrlScheduleMay { get; set; }
        public ScheduleControl ctrlScheduleJun { get; set; }
        public ScheduleControl ctrlScheduleJul { get; set; }
        public ScheduleControl ctrlScheduleAug { get; set; }
        public ScheduleControl ctrlScheduleSep { get; set; }
        public ScheduleControl ctrlScheduleOct { get; set; }
        public ScheduleControl ctrlScheduleNov { get; set; }
        public ScheduleControl ctrlScheduleDec { get; set; }

        public ScheduleView()
        {
            InitializeComponent();
            this.ViewModel = this.DataContext as ScheduleViewModel;

            ViewModel.OnExpandDatagrid += ViewModel_OnExpandDatagrid;
            ViewModel.OnCreateScheduleDetails += ViewModel_OnCreateScheduleDetails;
            ViewModel.OnGetDataGridItemsHandler += ViewModel_OnGetDataGridItemsHandler;
            ViewModel.OnShowEmployeePickList += ViewModel_OnShowEmployeePickList;
            ViewModel.OnSetDataGridData += ViewModel_OnSetDataGridData;
            this.Loaded += ScheduleView_Loaded;
        }

        void ViewModel_OnSetDataGridData(object sender, EventArgs e)
        {
            var scheduleCtrl = GetScheduleControl();

            foreach (DataGridCellInfo cellInfo in scheduleCtrl.cellInfoToTableRowAndColumn.Keys)
            {
                if (cellInfo.IsValid)
                {
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock;
                    var lisItem = ViewModel.PlSelectedItem as User;
                    if (lisItem == null) return;

                    if (content != null)
                    {
                        if (!string.IsNullOrEmpty(content.Text))
                        {
                            content.Text = content.Text + " " + lisItem.User_ref;
                        }
                        else
                        {
                            content.Text = lisItem.User_ref.ToString();
                        }
                    }
                }
            }
        }

        void ViewModel_OnShowEmployeePickList(object sender, EventArgs e)
        {
            var sheduleCtrl = GetScheduleControl();
            sheduleCtrl.empPL.Visibility = System.Windows.Visibility.Visible;
        }

        void ScheduleView_Loaded(object sender, RoutedEventArgs e)
        {
            ControlTemplate templateJan = tmpJan.Template;
            ctrlScheduleJan = (ScheduleControl)templateJan.FindName("ctrlScheduleJan", tmpJan);
            ctrlScheduleJan.ViewModel = this.ViewModel;
            ctrlScheduleJan.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateFeb = tmpFeb.Template;
            ctrlScheduleFeb = (ScheduleControl)templateFeb.FindName("ctrlScheduleFeb", tmpFeb);
            ctrlScheduleFeb.ViewModel = this.ViewModel;
            ctrlScheduleFeb.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateMar = tmpMarch.Template;
            ctrlScheduleMarch = (ScheduleControl)templateMar.FindName("ctrlScheduleMarch", tmpMarch);
            ctrlScheduleMarch.ViewModel = this.ViewModel;
            ctrlScheduleMarch.ViewModel = this.ViewModel;

            ControlTemplate templateAprl = tmpApril.Template;
            ctrlScheduleApr = (ScheduleControl)templateAprl.FindName("ctrlScheduleApr", tmpApril);
            ctrlScheduleApr.ViewModel = this.ViewModel;
            ctrlScheduleApr.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateMay = tmpMay.Template;
            ctrlScheduleMay = (ScheduleControl)templateMay.FindName("ctrlScheduleMay", tmpMay);
            ctrlScheduleMay.ViewModel = this.ViewModel;
            ctrlScheduleMay.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateJun = tmpJun.Template;
            ctrlScheduleJun = (ScheduleControl)templateJun.FindName("ctrlScheduleJun", tmpJun);
            ctrlScheduleJun.ViewModel = this.ViewModel;
            ctrlScheduleJun.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateJul = tmpJul.Template;
            ctrlScheduleJul = (ScheduleControl)templateJul.FindName("ctrlScheduleJul", tmpJul);
            ctrlScheduleJul.ViewModel = this.ViewModel;
            ctrlScheduleJul.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateAug = tmpAug.Template;
            ctrlScheduleAug = (ScheduleControl)templateAug.FindName("ctrlScheduleAug", tmpAug);
            ctrlScheduleAug.ViewModel = this.ViewModel;
            ctrlScheduleAug.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templateSep = tmpSep.Template;
            ctrlScheduleSep = (ScheduleControl)templateSep.FindName("ctrlScheduleSep", tmpSep);
            ctrlScheduleSep.ViewModel = this.ViewModel;
            ctrlScheduleSep.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templatOct = tmpOct.Template;
            ctrlScheduleOct = (ScheduleControl)templatOct.FindName("ctrlScheduleOct", tmpOct);
            ctrlScheduleOct.ViewModel = this.ViewModel;
            ctrlScheduleOct.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templatNov = tmpNov.Template;
            ctrlScheduleNov = (ScheduleControl)templatNov.FindName("ctrlScheduleNov", tmpNov);
            ctrlScheduleNov.ViewModel = this.ViewModel;
            ctrlScheduleNov.favWeekControl.ViewModel = this.ViewModel;

            ControlTemplate templatDec = tmpDec.Template;
            ctrlScheduleDec = (ScheduleControl)templatDec.FindName("ctrlScheduleDec", tmpDec);
            ctrlScheduleDec.ViewModel = this.ViewModel;
            ctrlScheduleDec.favWeekControl.ViewModel = this.ViewModel;

            this.ViewModel.CheckAcceptedSchedule();
        }


        void ViewModel_OnExpandDatagrid(object sender, EventArgs e)
        {
            var viewModel = sender as ScheduleViewModel;
            if (ViewModel == null)
            {
                throw new ArgumentException("viewmodel");
            }

            var ctrlSchedule = GetScheduleControl();

            Collection<Expander> collection = VisualTreeHelpers.GetVisualChildren<Expander>(ctrlSchedule.dgSchedules);

            foreach (Expander expander in collection)
                expander.IsExpanded = viewModel.IsExpandedAll;
        }

        void ViewModel_OnCreateScheduleDetails(object sender, CurrentEntityChangedEventArgs e)
        {
            if (e.NewEntity == null) return;
            var snd = sender as ScheduleViewModel;
            var entity = e.NewEntity as Schedule;
            int startTime = entity.StartTime;
            int diff = (entity.EndTime - entity.StartTime);

            var ctrlSchedule = GetScheduleControl();

            if (ctrlSchedule.dgSchedules != null)
            {
                //  first we hide them 
                for (int i = 0; i < ctrlSchedule.dgSchedules.Columns.Count - 1; i++)
                {
                    ctrlSchedule.dgSchedules.Columns[i].Visibility = Visibility.Collapsed;
                }
                for (int i = 0, j = startTime; i <= diff; i++, j++)
                {
                    ctrlSchedule.dgSchedules.Columns[startTime].Visibility = System.Windows.Visibility.Visible;
                    ctrlSchedule.dgSchedules.Columns[startTime].Header = startTime++;
                }
            }

            ctrlSchedule.dgSchedules.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = snd.GetViewSourceForMonth() });
        }



        private void PasteDay(object sender, RoutedEventArgs e)
        {
            ViewModel.PasteAllPerDay();
        }

        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.ViewModel == null)
            {
                return;
            }
            this.ViewModel.CheckAcceptedSchedule();
        }

        private ScheduleControl GetScheduleControl()
        {
            int monthClicked = ViewModel.ScheduleClicked;
            string scheduleCaption = ViewModel.CurrentSelectedYear.ToString() + " Time: " + ViewModel.StartTime.Hour.ToString() + " - " +
                                                                                            ViewModel.EndTime.Hour.ToString();
            switch (monthClicked)
            {
                case 1:
                    ctrlScheduleJan.Visibility = Visibility.Visible;
                    ctrlScheduleJan.Caption = "January " + scheduleCaption;
                    return ctrlScheduleJan;
                case 2:
                    ctrlScheduleFeb.Visibility = Visibility.Visible;
                    ctrlScheduleFeb.Caption = "February " + scheduleCaption;
                    return ctrlScheduleFeb;
                case 3:
                    ctrlScheduleMarch.Visibility = Visibility.Visible;
                    ctrlScheduleMarch.Caption = "March " + scheduleCaption;
                    return ctrlScheduleMarch;
                case 4:
                    ctrlScheduleApr.Caption = "April " + scheduleCaption;
                    ctrlScheduleApr.Visibility = Visibility.Visible;
                    return ctrlScheduleApr;
                case 5:
                    ctrlScheduleMay.Caption = "May " + scheduleCaption;
                    ctrlScheduleMay.Visibility = Visibility.Visible;
                    return ctrlScheduleMay;
                case 6:
                    ctrlScheduleJun.Caption = "June " + scheduleCaption;
                    ctrlScheduleJun.Visibility = Visibility.Visible;
                    return ctrlScheduleJun;
                case 7:
                    ctrlScheduleJul.Caption = "July " + scheduleCaption;
                    ctrlScheduleJul.Visibility = Visibility.Visible;
                    return ctrlScheduleJul;
                case 8:
                    ctrlScheduleAug.Caption = "August " + scheduleCaption;
                    ctrlScheduleAug.Visibility = Visibility.Visible;
                    return ctrlScheduleAug;
                case 9:
                    ctrlScheduleSep.Caption = "September " + scheduleCaption;
                    ctrlScheduleSep.Visibility = Visibility.Visible;
                    return ctrlScheduleSep;
                case 10:
                    ctrlScheduleOct.Caption = "Octomber " + scheduleCaption;
                    ctrlScheduleOct.Visibility = Visibility.Visible;
                    return ctrlScheduleOct;
                case 11:
                    ctrlScheduleNov.Caption = "November " + scheduleCaption;
                    ctrlScheduleNov.Visibility = Visibility.Visible;
                    return ctrlScheduleNov;
                case 12:
                    ctrlScheduleDec.Caption = "December " + scheduleCaption;
                    ctrlScheduleDec.Visibility = Visibility.Visible;
                    return ctrlScheduleDec;
                default:
                    break;
            }

            return new ScheduleControl();
        }

        void ViewModel_OnGetDataGridItemsHandler(object sender, EventArgs e)
        {
            int starTime = ViewModel.StartTime.Hour;
            int endTime = ViewModel.EndTime.Hour;
            string filename = ViewModel.PDFFileName;   // @"C:\Temp\Test.pdf";
            if (string.IsNullOrEmpty(ViewModel.PDFFileName))
            {
                return;
            }
            int pdfCols = endTime - starTime + 3;
            var doc = new Document(new Rectangle(1300f, 600f));

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Scheduler", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            doc.Open();

            var scheduleCtrl = GetScheduleControl();

            PdfPTable table = new PdfPTable(pdfCols);

            table.HorizontalAlignment = 1;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            string caption = "Schedule for " + ViewModel.GetMonth() + " " + ViewModel.CurrentSelectedYear.ToString();
            Font font = FontFactory.GetFont(FontFactory.COURIER_BOLD);
            Chunk beginning = new Chunk(caption, font);
            Paragraph p = new Paragraph(beginning);
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);

            int hdr = starTime;
            for (int i = 0; i < pdfCols; i++)
            {
                PdfPCell cell = null;

                if (i == 0)
                {
                    cell = new PdfPCell(new Phrase("Date"));
                    cell.Colspan = 1;
                    cell.Border = 0;
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);

                }
                else if (i == pdfCols - 1)
                {
                    cell = new PdfPCell(new Phrase("Worker"));
                    cell.Colspan = 1;
                    cell.Border = 0;
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);

                }
                else
                {
                    cell = new PdfPCell(new Phrase(hdr.ToString()));
                    cell.Colspan = 1;
                    hdr++;
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                }
            }

            bool isDifferentDay = false;
            DateTime? checkDate = null;

            for (int row = 0; row < scheduleCtrl.dgSchedules.Items.Count; row++)
            {
                DataGridRow datarow = (DataGridRow)scheduleCtrl.dgSchedules.ItemContainerGenerator.ContainerFromIndex(row);
                Scheduledetail entity = datarow.Item as Scheduledetail;
                DateTime? day = entity.Day;
                if (row != 0 && day != checkDate)
                {
                    checkDate = day;
                    isDifferentDay = true;
                }
                else
                {
                    checkDate = day;
                    isDifferentDay = false;
                }

                Group group = ViewModel.db.Groups.FirstOrDefault(a => a.Group_Ref == entity.Group_Ref);
                string color = string.Empty;
                if (group != null)
                {
                    color = group.Color;
                }

                PdfPCell cellDifferentDate = new PdfPCell();
                PdfPCell cell = new PdfPCell();
                string dateText = String.Format("{0:MM/dd/yyyy}", day);



                if (isDifferentDay)
                {
                    cellDifferentDate.Border = Rectangle.TOP_BORDER;
                    cellDifferentDate.BorderColorTop = BaseColor.GRAY;
                    cellDifferentDate.BorderWidthTop = 1f;
                    cellDifferentDate.Phrase = new Phrase(dateText);
                    table.AddCell(cellDifferentDate);
                }
                else
                {
                    cell.Phrase = new Phrase(dateText);
                    cell.Border = Rectangle.NO_BORDER;
                    table.AddCell(cell);
                }

                for (int col = 0; col < scheduleCtrl.dgSchedules.Columns.Count; col++)
                {
                    if (scheduleCtrl.dgSchedules.Columns[col].Visibility == Visibility.Visible)
                    {
                        var element = scheduleCtrl.dgSchedules.Columns[col].GetCellContent(datarow);
                        string value = string.Empty;
                        if (element.GetType().Name == "TextBlock")
                        {
                            TextBlock tb = element as TextBlock;
                            value = tb.Text;
                            CreateCellByValue(table, value, color, isDifferentDay);

                        }
                        if (element.GetType().Name == "TextBlockComboBox")
                        {
                            ComboBox cb = element as ComboBox;
                            value = cb.Text;

                            if (isDifferentDay)
                            {
                                cellDifferentDate.Border = Rectangle.TOP_BORDER;
                                cellDifferentDate.BorderColorTop = BaseColor.GRAY;
                                cellDifferentDate.BorderWidthTop = 1f;
                                cellDifferentDate.Phrase = new Phrase(value);
                                table.AddCell(cellDifferentDate);
                            }
                            else
                            {
                                cell.Phrase = new Phrase(value);
                                cell.Border = Rectangle.NO_BORDER;
                                table.AddCell(cell);
                            }
                        }
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }


        private void CreateCellByValue(PdfPTable table, string value, string clr, bool isDifferentDay = false)
        {
            System.Drawing.Color sysColor;
            if (string.IsNullOrEmpty(clr))
            {
                sysColor = System.Drawing.Color.Yellow; // default color if not selected
            }
            else
            {
                sysColor = System.Drawing.Color.FromArgb(Convert.ToInt32(clr.Substring(1), 16));
            }
            string[] splitItems = value.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Font courier = new Font(Font.FontFamily.COURIER, 8f);
            var cell = new PdfPCell();
      
            if (splitItems.Count() == 2)
            {
                switch (splitItems[1])
                {
                    case "1":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }

                            cell.Phrase = new Phrase(splitItems[0], courier);
                            cell.BackgroundColor = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                            break;
                        }
                    case "+30":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }

                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Phrase = new Phrase(splitItems[0], courier);
                            cell.BorderColorLeft = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthLeft = 40f;
                            break;
                        }
                    case "+45":
                        {
                            cell.Phrase = new Phrase(splitItems[0], courier);
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;

                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;

                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }

                            cell.BorderColorLeft = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthLeft = 60f;
                            break;
                        }
                    case "-30":
                        {

                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;

                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.Phrase = new Phrase(splitItems[0], courier);
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cell.BorderColorRight = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthRight = 40f;
                            break;
                        }

                    case "-45":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }

                            cell.Phrase = new Phrase(splitItems[0], courier);
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cell.BorderColorRight = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthRight = 60f;
                            break;
                        }
                }
            }
    
            if (splitItems.Count() == 4)
            {
                switch (splitItems[1])
                {
                    case "1":
                        {

                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }

                            cell.BackgroundColor = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            break;
                        }
                    case "+30":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorLeft = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthLeft = 40f;

                            break;
                        }
                    case "+45":
                        {

                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorLeft = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthLeft = 60f;
                            break;
                        }
                    case "-30":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorRight = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthRight = 40f;
                            break;
                        }

                    case "-45":
                        {
                            if (isDifferentDay)
                            {
                                
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorRight = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthRight = 60f;
                            break;
                        }
                }


                switch (splitItems[3])
                {
                    case "1":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BackgroundColor = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            break;
                        }
                    case "+30":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorLeft = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthLeft = 40f;
                            break;
                        }
                    case "+45":
                        {

                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorLeft = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthLeft = 60f;
                            break;

                        }
                    case "-30":
                        {
                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }
                            cell.BorderColorRight = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthRight = 40f;
                            break;
                        }

                    case "-45":
                        {

                            if (isDifferentDay)
                            {
                                cell.Border = Rectangle.TOP_BORDER;
                                cell.BorderColorTop = BaseColor.GRAY;
                                cell.BorderWidthTop = 1f;
                            }
                            else
                            {
                                cell.Border = Rectangle.NO_BORDER;
                            }

                            cell.BorderColorRight = new BaseColor(sysColor.R, sysColor.G, sysColor.B);
                            cell.BorderWidthRight = 60f;
                            break;
                        }
                }
                cell.AddElement((new Paragraph(GetChunk(splitItems[0], courier, false)) { Alignment = Element.ALIGN_LEFT }));
                cell.AddElement((new Paragraph(GetChunk(splitItems[2], courier, true)) { Alignment = Element.ALIGN_RIGHT }));
            }
            table.AddCell(cell);
        }

        private Chunk GetChunk(string text, Font font, bool second)
        {
            Chunk chunk = new Chunk(text, font);
            if (!second)
            {
                chunk.setLineHeight(6);
            }
            else
            {
                chunk.setLineHeight(1f);
            }
            return chunk;
        }

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.CheckAcceptedSchedule();
        }

        private void tmpJan_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpJan, Canvas.GetLeft(tmpJan) + e.HorizontalChange);
            Canvas.SetTop(tmpJan, Canvas.GetTop(tmpJan) + e.VerticalChange);
        }

        private void tmpFeb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpFeb, Canvas.GetLeft(tmpFeb) + e.HorizontalChange);
            Canvas.SetTop(tmpFeb, Canvas.GetTop(tmpFeb) + e.VerticalChange);
        }

        private void tmpMarch_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpMarch, Canvas.GetLeft(tmpMarch) + e.HorizontalChange);
            Canvas.SetTop(tmpMarch, Canvas.GetTop(tmpMarch) + e.VerticalChange);
        }

        private void tmpApril_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpApril, Canvas.GetLeft(tmpApril) + e.HorizontalChange);
            Canvas.SetTop(tmpApril, Canvas.GetTop(tmpApril) + e.VerticalChange);
        }

        private void tmpMay_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpMay, Canvas.GetLeft(tmpMay) + e.HorizontalChange);
            Canvas.SetTop(tmpMay, Canvas.GetTop(tmpMay) + e.VerticalChange);
        }

        private void tmpJun_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpJun, Canvas.GetLeft(tmpJun) + e.HorizontalChange);
            Canvas.SetTop(tmpJun, Canvas.GetTop(tmpJun) + e.VerticalChange);
        }

        private void tmpJul_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpJul, Canvas.GetLeft(tmpJul) + e.HorizontalChange);
            Canvas.SetTop(tmpJul, Canvas.GetTop(tmpJul) + e.VerticalChange);
        }

        private void tmpAug_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpAug, Canvas.GetLeft(tmpAug) + e.HorizontalChange);
            Canvas.SetTop(tmpAug, Canvas.GetTop(tmpAug) + e.VerticalChange);
        }

        private void tmpSep_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpSep, Canvas.GetLeft(tmpSep) + e.HorizontalChange);
            Canvas.SetTop(tmpSep, Canvas.GetTop(tmpSep) + e.VerticalChange);
        }

        private void tmpOct_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpOct, Canvas.GetLeft(tmpOct) + e.HorizontalChange);
            Canvas.SetTop(tmpOct, Canvas.GetTop(tmpOct) + e.VerticalChange);
        }

        private void tmpNov_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpNov, Canvas.GetLeft(tmpNov) + e.HorizontalChange);
            Canvas.SetTop(tmpNov, Canvas.GetTop(tmpNov) + e.VerticalChange);
        }

        private void tmpDec_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(tmpDec, Canvas.GetLeft(tmpDec) + e.HorizontalChange);
            Canvas.SetTop(tmpDec, Canvas.GetTop(tmpDec) + e.VerticalChange);
        }
    }
}
