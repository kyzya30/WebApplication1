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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.AdditionProductsForProducts = new HashSet<AdditionProductsForProduct>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Ingridients = new HashSet<Ingridient>();
        }
    
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
        public System.DateTime AddDate { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdditionProductsForProduct> AdditionProductsForProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ProductWeightDetail ProductWeightDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingridient> Ingridients { get; set; }
    }
}
