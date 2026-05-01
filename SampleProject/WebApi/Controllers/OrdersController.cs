using BusinessEntities;
using Core.Services.Orders;
using Data.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers;
using WebApi.Models.Orders;
namespace Web.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IGetOrdersService _getOrdersService;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(
            ICreateOrderService createOrderService,
            IUpdateOrderService updateOrderService,
            IDeleteOrderService deleteOrderService,
            IGetOrderService getOrderService,
            IGetOrdersService getOrdersService,
            IOrderRepository orderRepository)
        {
            _createOrderService = createOrderService;
            _updateOrderService = updateOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _getOrdersService = getOrdersService;
            _orderRepository = orderRepository;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order data is required.");
            }

            var order = _createOrderService.Create(
                orderId,
                model.UserId,
                model.ProductIds,
                model.TotalAmount,
                model.Status);

            return Request.CreateResponse(HttpStatusCode.OK, new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPut]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order data is required.");
            }

            var order = _getOrderService.Get(orderId);

            if (order == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order was not found.");
            }

            _updateOrderService.Update(
                order,
                model.UserId,
                model.ProductIds,
                model.TotalAmount,
                model.Status);

            _orderRepository.Save(order);

            return Request.CreateResponse(HttpStatusCode.OK, new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            _deleteOrderService.Delete(orderId);

            return Request.CreateResponse(HttpStatusCode.OK, "Order deleted successfully.");
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.Get(orderId);

            if (order == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order was not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(Guid? userId = null, OrderStatus? status = null)
        {
            var orders = _getOrdersService.Get(userId, status);

            return Request.CreateResponse(
                HttpStatusCode.OK,
                orders.Select(order => new OrderData(order)));
        }
    }
}