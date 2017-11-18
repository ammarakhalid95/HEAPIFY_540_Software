using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HEAPIFY_540_Software.Models
{
    public class HEAPIFY_540_SoftwareContext : DbContext
    //public class HEAPConnection : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public HEAPIFY_540_SoftwareContext() : base("name=HEAPIFY_540_SoftwareContext")
        {
        }
        //public HEAPConnection() : base("name=HEAPConnection")
        //{
        //}
        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AccountsAdmin> AccountsAdmins { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AccountType> AccountTypes { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Modify> Modifies { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.ActiveSStanding> ActiveSStandings { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AddLabReport> AddLabReports { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AdjustmentCode> AdjustmentCodes { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AlchoholStanding> AlchoholStandings { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AllergiesName> AllergiesNames { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.AllergyType> AllergyTypes { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Billing> Billings { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.CurrentProceduralTerminology> CurrentProceduralTerminologies { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Insurance> Insurances { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.PaymentMode> PaymentModes { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.CreateOrderInternal> CreateOrderInternals { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Demographic> Demographics { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.DrugAbuse> DrugAbuses { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.EmergencyContact> EmergencyContacts { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Ethnicity> Ethnicities { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Occupation> Occupations { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.Race> Races { get; set; }

        public System.Data.Entity.DbSet<HEAPIFY_540_Software.Models.SmokingStanding> SmokingStandings { get; set; }
    }
}
