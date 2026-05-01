using BusinessEntities;
using Core.Services.Products;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace Web.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductByIdService _getProductService;
        private readonly IGetProductsService _getProductsService;

        public ProductsController(
            ICreateProductService createProductService,
            IUpdateProductService updateProductService,
            IDeleteProductService deleteProductService,
            IGetProductByIdService getProductService,
            IGetProductsService getProductsService)
        {
            _createProductService = createProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _getProductsService = getProductsService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product data is required.");
            }

            var product = _createProductService.Create(
                productId,
                model.Name,
                model.Description,
                model.Price,
                model.StockQuantity);

            return Request.CreateResponse(HttpStatusCode.OK, new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product data is required.");
            }

            var product = _getProductService.Get(productId);

            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product was not found.");
            }

            _updateProductService.Update(
                product,
                model.Name,
                model.Description,
                model.Price,
                model.StockQuantity);

            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
            _deleteProductService.Delete(productId);

            return Request.CreateResponse(HttpStatusCode.OK, "Product deleted successfully.");
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.Get(productId);

            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product was not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(
            string name = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            var products = _getProductsService.Get(name, minPrice, maxPrice);

            return Request.CreateResponse(
                HttpStatusCode.OK,
                products.Select(product => new ProductData(product)));
        }
    }
}