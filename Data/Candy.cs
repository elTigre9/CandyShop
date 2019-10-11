using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Data
{
    public class Candy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        // foreign key connects Manufacturer table
        public int MID { get; set; }
        [ForeignKey("MID")]
        public Manufacturer Manufacturers { get; set; }
        
        // foreign key connects Store table
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Stores { get; set; }
    }
}
