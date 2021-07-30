using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Activity01.Models
{
    public class FilterData
    {
        public List<SelectListItem> Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}