using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.ViewModels
{
    public class RequestApplicationVM
    {
        public int Id { get; set; }
        public int Job_Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string status { get; set; }
    }
}
