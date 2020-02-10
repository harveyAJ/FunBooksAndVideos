using System.Collections.Generic;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Models.enums;
using FunBooksAndVideos.Api.Services;
using FunBooksAndVideos.Domain.enums;
using Moq;
using NUnit.Framework;

namespace FunBooksAndVideos.Tests
{
    public class PurchaseOrderServiceTests
    {
        private IPurchaseOrderService _purchaseOrderService;
        private Mock<IList<IBusinessRule>> _businessRules;
        private Mock<IBusinessRule> _businessRule1;
        private Mock<IBusinessRule> _businessRule2;

        private readonly PurchaseOrder _purchaseOrder = new PurchaseOrder
        {
            CustomerId = 135,
            Id = 1,
            TotalPrice = 10,
            Items = new List<Item> {
                new Item { Id = 1, Type = ItemType.Membership },
                new Item { Id = 2, Type = ItemType.Product }
            }
        };

        [SetUp]
        public void Setup()
        {
            _businessRule1 = new Mock<IBusinessRule>();
            _businessRule2 = new Mock<IBusinessRule>();
            var businessRules = new List<IBusinessRule>
            {
                _businessRule1.Object,
                _businessRule2.Object
            };

            _businessRules = new Mock<IList<IBusinessRule>>();
            _businessRules.Setup(x => x.GetEnumerator()).Returns(businessRules.GetEnumerator());
        }

        [Test]
        public void When_PurchaseOrder_Is_Processed_Each_Business_Rule_Is_Applied_With_Right_Parameter()
        {
            //Given
            _purchaseOrderService = new PurchaseOrderService(_businessRules.Object);

            //When
            _purchaseOrderService.Process(_purchaseOrder);

            //Then
            _businessRule1.Verify(x => x.Apply(_purchaseOrder), Times.Once);
            _businessRule2.Verify(x => x.Apply(_purchaseOrder), Times.Once);
        }
    }
}