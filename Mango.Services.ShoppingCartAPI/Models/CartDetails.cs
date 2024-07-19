using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI {

    public class CartDetails {

        [Key]
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public required CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public required ProductDto Product { get; set; }
        public int Count { get; set; }

    }

}