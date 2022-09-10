using System;
using System.Collections.Generic;

namespace UserService.Models
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }
        public string EmailId { get; set; } = null!;
        public int? BookId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PaymentMode { get; set; }
        public bool? IsRefund { get; set; }
        public string? PurchaseStatus { get; set; }

        public virtual Book? Book { get; set; }
    }
}
