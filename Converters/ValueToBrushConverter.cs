using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Scheduler
{
    public class ValueToBrushConverter : IMultiValueConverter
    {
        public Brush CustomUserBrush { get; set; }
        public Brush DefaultColor { get; set; }

        private SchedulerContext  db = new SchedulerContext();


        public ValueToBrushConverter()
        {
            DefaultColor = Brushes.Transparent;
        }



        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (values[1] == DependencyProperty.UnsetValue ||values[0] == DependencyProperty.UnsetValue)
            {
               return DefaultColor; 
            }

            if (values != null && values.Count() == 2)
             {
                if(string.IsNullOrEmpty(values[0].ToString().Trim()))
                {
                    return DefaultColor;
                }

                var cellValue = values[0] as string;
                if(values[1] != null)
                {
                    int workerValue = int.Parse(values[1].ToString());
                    Group group = db.Groups.FirstOrDefault(e => e.Group_Ref == workerValue);
                    if(group != null)
                    {
                        var bc = new BrushConverter();
                        CustomUserBrush = (Brush)bc.ConvertFrom(group.Color);
                        return CustomUserBrush;
                    }
                }
            }
            return DefaultColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
