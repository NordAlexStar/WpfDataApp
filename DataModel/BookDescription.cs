using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataModel
{
    public enum Genre
    {
        SciFi, Science, Classic
    }

    public class BookDescription: DataElement, IDataErrorInfo
    {
        private string? title;

        public string Title
        {
            get => title ?? "";
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string? description;

        public string? Description
        {
            get => description;

            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private string? author;

      
        public string? Author
        {
            get => author;

            set
            {
                author = value;
                OnPropertyChanged();
            }
        }


        private Genre? genre;
        public Genre? Genre
        {
            get => genre;

            set
            {
                genre = value;
                OnPropertyChanged();
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Title): if (string.IsNullOrEmpty(Title)) error = "Please input Title";
                        break;
                    case "Author":
                        if (string.IsNullOrEmpty(Author)) error = "Please input Author";
                        break;
                }
                return error;
            }
        }
    }
}