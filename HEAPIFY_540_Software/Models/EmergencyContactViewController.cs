using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HEAPIFY_540_Software.Models
{
    public class EmergencyContactViewController : Controller
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public Nullable<int> DepartmentId { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        //Custom attribute
        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
        public string SiteName { get; set; }
    }
}