//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string NameRus { get; set; }
        public string NameUkr { get; set; }
        public int NumberOfOrders { get; set; }
        public Nullable<int> Count { get; set; }
        public string Energy { get; set; }
        public int Balance { get; set; }
        public decimal Price { get; set; }
        public bool Sale { get; set; }
        public bool IsHided { get; set; }
        public System.DateTime AddDate { get; set; }
        public string IngridientsRus { get; set; }
        public string IngridientsUkr { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ProductWeightDetail ProductWeightDetail { get; set; }
    }
}
