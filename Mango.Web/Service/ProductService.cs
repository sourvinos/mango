namespace Mango.Web {

    public class ProductService : IProductService {

        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService) {
            _baseService = baseService;
        }

        public async Task<ResponseDto> GetAllProductsAsync() {
            return await _baseService.SendAsync(new RequestDto() {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/Product"
            });
        }

        public async Task<ResponseDto> GetProductAsync(string ProductCode) {
            return await _baseService.SendAsync(new RequestDto() {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/Product/getByCode" + ProductCode
            });
        }

        public async Task<ResponseDto> GetProductByIdAsync(int id) {
            return await _baseService.SendAsync(new RequestDto() {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/Product/" + id
            });
        }

        public async Task<ResponseDto> CreateProductAsync(ProductDto ProductDto) {
            return await _baseService.SendAsync(new RequestDto() {
                ApiType = StaticDetails.ApiType.POST,
                Data = ProductDto,
                Url = StaticDetails.ProductAPIBase + "/api/Product"
            });
        }

        public async Task<ResponseDto> UpdateProductAsync(ProductDto ProductDto) {
            return await _baseService.SendAsync(new RequestDto() {
                ApiType = StaticDetails.ApiType.PUT,
                Data = ProductDto,
                Url = StaticDetails.ProductAPIBase + "/api/Product"
            });
        }

        public async Task<ResponseDto> DeleteProductAsync(int id) {
            return await _baseService.SendAsync(new RequestDto() {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductAPIBase + "/api/Product/" + id
            });
        }

    }

}