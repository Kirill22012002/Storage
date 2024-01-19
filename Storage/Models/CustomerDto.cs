using System.Collections.Generic;

namespace Storage.Models
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public List<PurchaseDto> Purchases { get; set; } = new List<PurchaseDto>();
    }
}