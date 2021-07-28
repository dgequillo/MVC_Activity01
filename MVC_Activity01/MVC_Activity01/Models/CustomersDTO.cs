﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Activity01.Models
{

    public class CustomersDTO
    {
       
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Middlename { get; set; }

        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string EmailAdress { get; set; }
        public string Status { get; set; }
    }


}