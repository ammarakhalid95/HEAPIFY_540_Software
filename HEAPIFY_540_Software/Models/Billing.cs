//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HEAPIFY_540_Software.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Billing
    {
        public int BillingID { get; set; }
        public Nullable<int> CurrentProceduralTerminologyID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public double Payment { get; set; }
        public Nullable<int> AdjustmentCodeID { get; set; }
        public int PaymentModeID { get; set; }
        public System.DateTime DatePaid { get; set; }
        public string PaidBy { get; set; }
        public string Notes { get; set; }
        public int PatientID { get; set; }
        public int InsuranceID { get; set; }
    
        public virtual AdjustmentCode AdjustmentCode { get; set; }
        public virtual CurrentProceduralTerminology CurrentProceduralTerminology { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
    }
}
