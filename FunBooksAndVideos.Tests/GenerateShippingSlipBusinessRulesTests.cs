using System.Collections.Generic;
using FunBooksAndVideos.Api.BusinessRules;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Models.enums;
using FunBooksAndVideos.Domain.enums;
using Moq;
using NUnit.Framework;

namespace FunBooksAndVideos.Tests
{
    class GenerateShippingSlipsBusinessRulesTests
    {
        private Mock<IShippingSlipService> _shippingSlipService;
        private GenerateShippingSlipBusinessRule _generateShippingSlipBusinessRule; 

        [SetUp]
        public void Setup()
        {
            _shippingSlipService = new Mock<IShippingSlipService>();
            _generateShippingSlipBusinessRule = new GenerateShippingSlipBusinessRule(_shippingSlipService.Object);
        }

        [Test]
        public void When_BusinessRule1_Is_Called_Without_Product_Generate_Shipping_Slip_Is_Never_Called()
        {
            //Given
            _shippingSlipService.Setup(x => x.Generate(It.IsAny<PurchaseOrder>()))
                .Verifiable();

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 135,
                Id = 1,
                TotalPrice = 10,
                Items = new List<Item> { new Item { Id = 1, Type = ItemType.Membership } }
            };

            //When
            _generateShippingSlipBusinessRule.Apply(purchaseOrder);

            //Then
            _shippingSlipService.Verify(x => x.Generate(It.IsAny<PurchaseOrder>()), Times.Never);
        }

        [Test]
        public void
            When_PurchaseOrder_Contains_N_Product_Items_Generate_Shipping_Slip_Is_Called_With_Right_Params()
        {
            //Given 
            _shippingSlipService.Setup(x => x.Generate(It.IsAny<PurchaseOrder>()))
                .Verifiable();

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 135,
                Id = 1,
                TotalPrice = 10,
                Items = new List<Item>() {
                    new Item { Id = 1, Type = ItemType.Product },
                    new Item { Id = 2, Type = ItemType.Product }
                }
            };

            //When 
            _generateShippingSlipBusinessRule.Apply(purchaseOrder);

            //Then
            _shippingSlipService.Verify(x => x.Generate(purchaseOrder), Times.Once);
        }
    }
}