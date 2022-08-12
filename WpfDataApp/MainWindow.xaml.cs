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

namespace WpfDataApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        static MainWindow()
        {

        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new View();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            View? model = DataContext as View;

            if (model != null)
            {
                if (DataUGrid.IsEnabled == false)
                {
                    e.CanExecute = true;
                }
                else e.CanExecute = false;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                DataModel.BookDescription NewBook = new DataModel.BookDescription();
                model.Books.Add(NewBook);
                this.lbData.SelectedItem = NewBook;
                model.IsEditedMode = true;
                tbTitle.Focus();
            }
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                model.IsEditedMode = !model.IsEditedMode;
            }
        }
    }
}
