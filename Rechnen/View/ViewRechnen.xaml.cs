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
using System.Windows.Shapes;
using Rechnen.ViewModel;

namespace Rechnen.View
{
    /// <summary>
    /// Interaction logic for ViewRechnen.xaml
    /// </summary>
    public partial class ViewRechnen : Window
    {
        public ViewRechnen()
        {
            InitializeComponent();
            // Binding to runtime, declare the Form 
            this._rvm.Formular = this;
            // important for binding of ViewModel with View
            // property DataContext
            this.DataContext = _rvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        RechnenViewModel _rvm = new RechnenViewModel();
    }
}
