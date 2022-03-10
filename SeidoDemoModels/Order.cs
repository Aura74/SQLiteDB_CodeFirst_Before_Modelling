using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeidoDemoModels
{
    
    public class Order
    {
        #region Uncomment to create the Data model
        
        [Key]
        [Column("OrderID")]
        public Guid OrderID { get; set; }

        [Column("CustomerID")]
        public Guid CustomerID { get; set; }

        [Column(TypeName = "nvarchar (200)")]
        public string Comment { get; set; }
        
        #endregion

        #region Uncomment to seed and query the Database
        
        public Order(Guid CustomerID)
        {
            OrderID = Guid.NewGuid();
            this.CustomerID = CustomerID; 
            Comment = $"{OrderID} specific comment for Customer {CustomerID}";
        }
        
        #endregion
    }
    
}
