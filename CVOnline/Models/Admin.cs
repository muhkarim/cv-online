﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }

        public int User_Id { get; set; }
        public User User { get; set; }
    }
}
