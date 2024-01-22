using System;

#nullable disable

namespace Storage.Models
{
    public class ProductWithInfoDto
    {
        public string Name { get; set; }
        public int? Amount { get; set; }
        public DateTime? Datefiling { get; set; }
        public string Barcode { get; set; }
        public string Cell { get; set; }
    }
}