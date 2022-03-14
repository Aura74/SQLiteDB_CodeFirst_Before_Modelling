using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeidoDemoModels
{
     
    public class Necklace
    {

        
        [Key]
        [Column("NecklaceID")]
        public Guid NecklaceID { get; set; }

        [Column(TypeName = "nvarchar (200)")]
        public string Comment { get; set; }

        public virtual List<Pearl> Orders { get; set; } = new List<Pearl>();
        
        public Necklace ()
        {
            NecklaceID = Guid.NewGuid();
            Comment = $"{NecklaceID} specific comment";
        }
        

    }
    
}
