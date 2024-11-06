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

        [Test(Description = "Testing that all four items total the sum of their individual prices")]
        public void ScanAllItemsOnce()
        {
            // Arrange: Scan each item once
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(115));
        }

        [Test(Description = "Testing all items including one of the two multipriced items")]
        public void ScanAllItemsAndOneMultiPriced()
        {
            // Arrange: Scan each item including item A three times to get multiprice discount
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(195));
        }

        [Test(Description = "Testing all items including both of the two multipriced items")]
        public void ScanAllItemsAndBothMultiPriced()
        {
            // Arrange: Scan each item including item A three times and item B twice to get multiprice discounts
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(210));
        }

        [Test(Description = "Testing scanning item A five times so that one multiprice is triggered, plus two individual prices")]
        public void ScanItemAFiveTimes()
        {
            // Arrange: Scan item A five times
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(230));
        }

        [Test(Description = "Testing scanning item A six times so that two multiprices are triggered")]
        public void ScanItemASixTimes()
        {
            // Arrange: Scan item A six times
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(260));
        }

        [Test(Description = "Testing scanning item A seven times so that two multiprices are triggered and one individual price")]
        public void ScanItemASevenTimes()
        {
            // Arrange: Scan item A seven times
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(310));
        }

        [Test(Description = "Testing scanning a mixture of multiple multiprice and non-multiprice items")]
        public void ScanMultipleMultiAndNonMultiItems()
        {
            // Arrange: Scan multiprice and non-multiprice items
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("C");
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("D");
            _checkout.Scan("D");

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(215));
        }

        [Test(Description = "Testing that the total is zero when the cart is empty")]
        public void NoItemsScanned()
        {
            // Arrange: Don't scan any items

            // Act: Call 'GetTotalPrice' method to test
            int totalPrice = _checkout.GetTotalPrice();

            // Assert: Confirm that the sum is correct
            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test(Description = "Testing that scanning an item not on the list throws an informative error")]
        public void ScanningInvalidItem()
        {
            // Arrange: Scan invalid item
            _checkout.Scan("E");

            // Act & Assert: Confirm that exception is thrown with correct message
            var exception = Assert.Throws<KeyNotFoundException>(() => _checkout.Scan("F"));
            Assert.That(exception.Message, Is.EqualTo("Invalid item. Please scan a valid item"));
        }
    }
}