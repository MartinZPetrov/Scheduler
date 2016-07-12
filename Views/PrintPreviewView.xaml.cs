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

namespace Scheduler.Views
{
    /// <summary>
    /// Interaction logic for PrintPreviewView.xaml
    /// </summary>
    /// 

    public partial class PrintPreviewView : UserControl
    {
        public IDocumentPaginatorSource Document
        {
            get { return viewer.Document; }
            set { viewer.Document = value; }
        }
        public PrintPreviewView()
        {
            InitializeComponent();
        }
    }
}
