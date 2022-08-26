using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using DataModel;

namespace WpfDataApp
{
    public class View : DataElement
    {
        public static RoutedCommand Add { get; set; }
        public static RoutedCommand Delete { get; set; }
        public static RoutedCommand ChangeMode { get; set; }
        public static RoutedCommand Load { get; set; }
        public static RoutedCommand Save { get; set; }

        static View()
        {
            Add = new RoutedCommand("Add", typeof(MainWindow));
            Delete = new RoutedCommand("Delete", typeof(MainWindow));
            ChangeMode = new RoutedCommand("ChangeMode", typeof(MainWindow));
            Load = new RoutedCommand("Load", typeof(MainWindow));
            Save = new RoutedCommand("Save", typeof(MainWindow));
        }

        public DB DataBase { get; set; } = new DB();

        public View()
        {
            IsEditedMode = false;
            LoadData();
        }

        public async void LoadData()
        {
            Books = new ObservableCollection<BookDescription>(await DataBase.BookDescriptions.ToListAsync());
            Authors = new ObservableCollection<Author>(await DataBase.Authors.ToListAsync());
        }

        private bool isEditedMode;
        public bool IsEditedMode { get => isEditedMode; set { isEditedMode = value; OnPropertyChanged(); } }

        private ObservableCollection<Author> authors;

        public ObservableCollection<Author> Authors
        {
            get => authors; set
            {
                { authors = value; OnPropertyChanged(); }
            }
        }

        private ObservableCollection<BookDescription>? books;

        public ObservableCollection<BookDescription>? Books
        {
            get => books; set
            {
                { books = value; OnPropertyChanged(); }
            }
        }
        public List<Genre> Genres { get => Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList(); }

    }
}
