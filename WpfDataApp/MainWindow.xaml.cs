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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
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
                BookDescription NewBook = new DataModel.BookDescription();

                model.Books.Add(NewBook);
                model.DataBase.BookDescriptions.Add(NewBook);

                this.lbData.SelectedItem = NewBook;
                model.IsEditedMode = true;
                tbTitle.Focus();
            }
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private async void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                model.IsEditedMode = !model.IsEditedMode;
                if (model.IsEditedMode == false) await model.DataBase.SaveChangesAsync();
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
           (DataContext as View).LoadData();
        }

        private async void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            await (DataContext as View)?.DataBase.SaveChangesAsync();
        }

        private async void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (model != null)
            {
                model.DataBase.BookDescriptions.Remove(lbData.SelectedItem as BookDescription);
                model.Books.Remove(lbData.SelectedItem as BookDescription);
                await model.DataBase.SaveChangesAsync();


            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View? model = DataContext as View;
            if (lbData.SelectedItem != null)
            {

                if (lbData.SelectedItem as BookDescription is BookDescription book)
                {
                    if (book.Author == null)
                    {
                        book.Author = new Author();
                        if (model != null)
                        {
                            model.Authors.Add(book.Author);
                        }
                    }
                }
            }
        }
    }
}
