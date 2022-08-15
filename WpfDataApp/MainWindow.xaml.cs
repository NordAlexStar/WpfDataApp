using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xaml;
using System.Xml.Serialization;

using DataModel;

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

        private void CommandBinding_CanExecute_2(object sender, CanExecuteRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                e.CanExecute = !model.IsEditedMode;
            }
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                
                using (TextWriter writer = new StreamWriter("Data.xml"))
                {
                    XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<BookDescription>));
                    x.Serialize(writer, model.Books);
                }
            }
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                using (TextReader writer = new StreamReader("Data.xml"))
                {
                    XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<BookDescription>));
                    model.Books = x.Deserialize(writer) as ObservableCollection<BookDescription>;
                }
            }
        }

        private void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                model.Books.Remove(lbData.SelectedItem as BookDescription);
            }
        }
    }
}
