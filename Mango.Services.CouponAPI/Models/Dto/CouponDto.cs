namespace Mango.Services.CouponAPI {

    public class CouponDto {

        public int CouponId { get; set; }
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }

}

