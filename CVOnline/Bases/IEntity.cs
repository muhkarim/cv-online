using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Bases
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
