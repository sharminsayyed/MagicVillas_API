﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVillaAPI.Model
{
    public class Villa
    {
        [Key] // primary key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto increment
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Details  { get; set; }
        public double Rate  { get; set; }
        public int Sqft  { get; set; }
        public int Occupancy  { get; set; }
        public string ImageUrl  { get; set; }
        public string Amenity  { get; set; }
        public DateTime CreatedDate  { get; set; }
        public DateTime UpdatedDate  { get; set; }

    
    }
}
