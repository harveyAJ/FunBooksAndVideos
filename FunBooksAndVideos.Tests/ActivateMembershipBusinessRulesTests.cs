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
    class ActivateMembershipBusinessRulesTests
    {
        private Mock<ICustomerAccountService> _customerAccountService;
        private ActivateMembershipBusinessRule _activateMembershipBusinessRule; 

        [SetUp]
        public void Setup()
        {
            _customerAccountService = new Mock<ICustomerAccountService>();
            _activateMembershipBusinessRule = new ActivateMembershipBusinessRule(_customerAccountService.Object);
        }

        [Test]
        public void When_BusinessRule1_Is_Called_Without_Membership_ActivateMembership_Is_Never_Called()
        {
            //Given
            _customerAccountService.Setup(x => x.ActivateMembership(It.IsAny<int>(), It.IsAny<int>()))
                .Verifiable();

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 135,
                Id = 1,
                TotalPrice = 10,
                Items = new List<Item> { new Item { Id = 1, Type = ItemType.Product } }
            };

            //When
            _activateMembershipBusinessRule.Apply(purchaseOrder);

            //Then
            _customerAccountService.Verify(x => x.ActivateMembership(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void
            When_PurchaseOrder_Contains_N_MemberShip_Items_ActivateMembership_Is_Called_N_Times_With_Right_Parameter()
        {
            //Given 
            _customerAccountService.Setup(x => x.ActivateMembership(It.IsAny<int>(), It.IsAny<int>()))
                .Verifiable();

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 131,
                Id = 5,
                TotalPrice = 100,
                Items = new List<Item>() {
                    new Item { Id = 1, Type = ItemType.Membership },
                    new Item { Id = 2, Type = ItemType.Membership } }
            };

            //When 
            _activateMembershipBusinessRule.Apply(purchaseOrder);

            //Then
            _customerAccountService.Verify(x => x.ActivateMembership(131, 1), Times.Once);
            _customerAccountService.Verify(x => x.ActivateMembership(131, 2), Times.Once);
        }
    }
}