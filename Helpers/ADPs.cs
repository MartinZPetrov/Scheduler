using Scheduler.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Scheduler
{
    public class ADPs
    {
        public static bool GetIsCellSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCellSelectedProperty);
        }

        public static void SetIsCellSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCellSelectedProperty, value);
        }
        public static readonly DependencyProperty IsCellSelectedProperty =
            DependencyProperty.RegisterAttached("IsCellSelected", typeof(bool), typeof(ADPs), new UIPropertyMetadata(false,
              (o, e) =>
              {
                  if (o is DataGridCell)
                  {
                      DataGridRow row = VisualTreeHelpers.FindVisualParent<DataGridRow>(o as DataGridCell);
                      row.SetValue(ADPs.IsCellSelectedProperty, e.NewValue);
                  }
              }));




        public static readonly DependencyProperty TagProperty = DependencyProperty.RegisterAttached(
           "Tag",
           typeof(object),
           typeof(ADPs),
           new FrameworkPropertyMetadata(null));

        public static object GetTag(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(TagProperty);
        }

        public static void SetTag(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(TagProperty, value);
        } 
    }
}
