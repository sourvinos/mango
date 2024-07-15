namespace Mango.Web {

    public interface IProductService {

        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductAsync(string ProductCode);
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto ProductDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto ProductDto);
        Task<ResponseDto?> DeleteProductAsync(int id);

    }

}