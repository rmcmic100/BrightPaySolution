using BrightPaySolution;

namespace BrightPaySolution.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void ScanItem()
        {
            // Arrange: Scan item with the price of 50
            _checkout.Scan("A");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the price of item A has been retrieved correctly
            Assert.That(totalPrice, Is.EqualTo(50));
        }
    }
}