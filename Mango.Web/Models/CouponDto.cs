using System.ComponentModel.DataAnnotations;

namespace Mango.Web {

    public class CouponDto {

        public int CouponId { get; set; }
        [Required]
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }

}

