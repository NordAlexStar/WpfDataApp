using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DataModel
{
    public enum Genre
    {
        SciFi, Science, Classic
    }

    public class BookDescription : DataElement, IDataErrorInfo
    {
        public int Id { get; set; }

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

        private Author? author;
        public virtual Author? Author
        {
            get
            {
                return author;
            }
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

        public override string ToString()
        {
            return Title;
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Title):
                        if (string.IsNullOrEmpty(Title)) error = "Please input Title";
                        break;

                }
                return error;
            }
        }
    }
}