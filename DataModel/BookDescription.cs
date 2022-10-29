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

    
    public class BookDescription : Printed, IDataErrorInfo
    {
        public BookDescription()
        {
            DetaledInfo = new DetaledInfo();
        }

        public   string Fake { get; set; }

     //   public virtual SeriaElement? IsMemberOfSeria { get; set; }

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

        public virtual Ganre Ganre { get; set; }

        private DetaledInfo? detaledInfo;
        public DetaledInfo? DetaledInfo
        {
            get => detaledInfo;

            set
            {
                detaledInfo = value;
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