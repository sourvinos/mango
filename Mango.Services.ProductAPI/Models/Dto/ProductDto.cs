namespace Mango.Services.ProductAPI {

    public class ProductDto {

        public int ProductId { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public required string CategoryName { get; set; }
        public required string ImageUrl { get; set; }

    }

}
