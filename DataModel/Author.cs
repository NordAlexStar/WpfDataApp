using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{

    public class Author : DataElement
    {
        public Author()
        {
            Books = new ObservableCollection<BookDescription>();
        }

        public int Id { get; set; }

        string name;

        [Required]
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); OnPropertyChanged(nameof(Info)); } }

        string surname;

        [Required]
        public string Surname { get { return surname; } set { surname = value; OnPropertyChanged(); OnPropertyChanged(nameof(Info)); } }

        string? about;
        public string? About { get { return about; } set { about = value; OnPropertyChanged(); } }

        string? about_;
        public string? About_ { get { return about_; } set { about_ = value; OnPropertyChanged(); } }

        public virtual ICollection<BookDescription> Books { get; set; }

        public string Info { get { return Name + " " + Surname; } }


    }
}
