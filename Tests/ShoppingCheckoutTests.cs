using System;
using Xunit;
using ShoppingCheckout.Models;
using ShoppingCheckout.Services;

namespace ShoppingCheckout.Tests
{
    public class SupermarketCheckoutTests
    {
        [Fact]
        public void Checkout_NoItems_ReturnsZero()
        {
            // Arrange
            var checkoutService = new CheckoutService();

            // Act
            var totalPrice = checkoutService.Checkout("");

            // Assert
            Assert.Equal(0, totalPrice);
        }

        [Fact]
        public void Checkout_SingleItem_ReturnsCorrectPrice()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            checkoutService.AddItem(new Item("A", 50));

            // Act
            var totalPrice = checkoutService.Checkout("A");

            // Assert
            Assert.Equal(50, totalPrice);
        }

        [Fact]
        public void Checkout_MultipleItems_ReturnsCorrectPrice()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            checkoutService.AddItem(new Item("A", 50));
            checkoutService.AddItem(new Item("B", 30));

            // Act
            var totalPrice = checkoutService.Checkout("AB");

            // Assert
            Assert.Equal(80, totalPrice);
        }

        // Add more test methods as needed
    }
}