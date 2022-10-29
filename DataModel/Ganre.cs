using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Ganre
    {
        public Ganre()
        {
            ChildGanres = new ObservableCollection<Ganre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }


        public virtual Ganre ParentGanre { get; set; }

        public virtual ICollection<Ganre> ChildGanres { get; set; }
    }
}
