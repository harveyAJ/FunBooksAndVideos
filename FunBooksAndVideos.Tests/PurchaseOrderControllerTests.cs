using System.Collections.Generic;
using FluentAssertions;
using FunBooksAndVideos.Api.Controllers;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Models.enums;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace FunBooksAndVideos.Tests
{
    public class PurchaseOrderControllerTests
    {
        private PurchaseOrderController _purchaseOrderController;
        private Mock<IPurchaseOrderService> _purchaseOrderService;

        private readonly PurchaseOrder _purchaseOrder = new PurchaseOrder
        {
            Id = 1256,
            CustomerId = 546,
            Items = new List<Item>
            {
                new Item { Id = 1, Type = ItemType.Membership, Price = 100 },
                new Item { Id = 2, Type = ItemType.Product, Price = 20 }
            },
            TotalPrice = 120
        };

        [SetUp]
        public void Setup()
        {
            _purchaseOrderService = new Mock<IPurchaseOrderService>();
            _purchaseOrderController = new PurchaseOrderController(_purchaseOrderService.Object);
        }

        [Test]
        public void When_Place_Order_Is_Called_Ok_Is_Returned()
        {
            //Given 
            _purchaseOrderService.Setup(x => x.Process(It.IsAny<PurchaseOrder>())).Verifiable();

            //When 
            var statusCodeResult = _purchaseOrderController.PlaceOrder(_purchaseOrder);

            //Then
            statusCodeResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Test]
        public void When_Place_Order_Is_Called_Process_Method_Is_Called_With_Right_Parameters()
        {
            //Given
            _purchaseOrderService.Setup(x => x.Process(It.IsAny<PurchaseOrder>())).Verifiable();

            //When
            var statusCodeResult = _purchaseOrderController.PlaceOrder(_purchaseOrder);

            //Then
            _purchaseOrderService.Verify(x => x.Process(It.Is<PurchaseOrder>(p => p == _purchaseOrder)));
        }
    }
}