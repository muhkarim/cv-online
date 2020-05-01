using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.ViewModels
{
    public class JobVM
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public bool isActive { get; set; }
        public Nullable<DateTimeOffset> DueDate { get; set; }
    }
}
