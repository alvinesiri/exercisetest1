using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retailstore.service.Models
{
    public class Bill
    {
        public decimal Amount { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsGroceries { get; set; }
    }
}
