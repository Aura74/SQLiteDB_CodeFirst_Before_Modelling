using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeidoDemoModels
{
    
    public class Pearl
    {

        
        [Key]
        [Column("PearlID")]
        public Guid PearlID { get; set; }

        [Column("NecklaceID")]
        public Guid NecklaceID { get; set; }

        [Column(TypeName = "nvarchar (200)")]
        public string Comment { get; set; }
        

        
        public Pearl(Guid necklaceId)
        {
            PearlID = Guid.NewGuid();
            this.NecklaceID = necklaceId; 
            Comment = $"{PearlID} specific comment for Necklace {necklaceId}";
        }

    }
    
}
