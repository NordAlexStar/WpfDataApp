using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataModel
{
    public enum Genre
    {
        SciFi, Science, Classic
    }

    public class BookDescription: DataElement
    {
        private string? title;

        [Required]
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

        [Required]
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

        


    }
}