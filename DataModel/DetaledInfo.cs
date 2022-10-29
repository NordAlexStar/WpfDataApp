using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [ComplexType]
    public class DetaledInfo: DataElement
    {
        string? description;
        public string? Description { get { return description; } set { description = value; OnPropertyChanged(); } }

        DateTime? beginDate;

        public DateTime? BeginDate { get { return beginDate; } set { beginDate = value; OnPropertyChanged(); } }

        DateTime? endDate;

        public DateTime? EndDate { get { return endDate; } set { endDate = value; OnPropertyChanged(); } }

    }
}
