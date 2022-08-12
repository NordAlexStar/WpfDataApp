using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

using DataModel;

namespace ViewModel
{
    public class View : DataElement
    {

        public static RoutedCommand Add { get; set; }

        public ObservableCollection<BookDescription> BookDescriptions { get; set; }
    }
}