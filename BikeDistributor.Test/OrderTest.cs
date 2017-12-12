using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", (int)Bike.Catalog.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", (int)Bike.Catalog.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", (int)Bike.Catalog.FiveThousand);

        [TestMethod]
        public void ReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(ResultStatementOneDefy, order.Receipt());
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";

        [TestMethod]
        public void ReceiptTwentyDefy()
        {
            var order = new Order("Shark Bike Shop");
            order.AddLine(new Line(Defy, 20));
            Assert.AreEqual(ResultStatementTwentyDefy, order.Receipt());
        }

        private const string ResultStatementTwentyDefy = @"Order Receipt for Shark Bike Shop
	20 x Giant Defy 1 = $18,000.00
Sub-Total: $18,000.00
Tax: $1,305.00
Total: $19,305.00";

        [TestMethod]
        public void ReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(ResultStatementOneElite, order.Receipt());
        }

        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00";

        [TestMethod]
        public void ReceiptTenElite()
        {
            var order = new Order("Shark Bike Shop");
            order.AddLine(new Line(Elite, 10));
            Assert.AreEqual(ResultStatementTenElite, order.Receipt());
        }

        private const string ResultStatementTenElite = @"Order Receipt for Shark Bike Shop
	10 x Specialized Venge Elite = $16,000.00
Sub-Total: $16,000.00
Tax: $1,160.00
Total: $17,160.00";

        [TestMethod]
        public void ReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(ResultStatementOneDuraAce, order.Receipt());
        }

        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";

        [TestMethod]
        public void ReceiptFiveDuraAce()
        {
            var order = new Order("Shark Bike Shop");
            order.AddLine(new Line(DuraAce, 5));
            Assert.AreEqual(ResultStatementFiveDuraAce, order.Receipt());
        }

        private const string ResultStatementFiveDuraAce = @"Order Receipt for Shark Bike Shop
	5 x Specialized S-Works Venge Dura-Ace = $20,000.00
Sub-Total: $20,000.00
Tax: $1,450.00
Total: $21,450.00";

        [TestMethod]
        public void HtmlReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(HtmlResultStatementOneDefy, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptTwentyDefy()
        {
            var order = new Order("Shark Bike Shop");
            order.AddLine(new Line(Defy, 20));
            Assert.AreEqual(HtmlResultStatementTwentyDefy, order.HtmlReceipt());
        }

        private const string HtmlResultStatementTwentyDefy = @"<html><body><h1>Order Receipt for Shark Bike Shop</h1><ul><li>20 x Giant Defy 1 = $18,000.00</li></ul><h3>Sub-Total: $18,000.00</h3><h3>Tax: $1,305.00</h3><h2>Total: $19,305.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(HtmlResultStatementTenElite, order.HtmlReceipt());
        }

        private const string HtmlResultStatementTenElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptTenElite()
        {
            var order = new Order("Shark Bike Shop");
            order.AddLine(new Line(Elite, 10));
            Assert.AreEqual(HtmlResultStatementOneElite, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Shark Bike Shop</h1><ul><li>10 x Specialized Venge Elite = $16,000.00</li></ul><h3>Sub-Total: $16,000.00</h3><h3>Tax: $1,160.00</h3><h2>Total: $17,160.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptFiveDuraAce()
        {
            var order = new Order("Shark Bike Shop");
            order.AddLine(new Line(DuraAce, 5));
            Assert.AreEqual(HtmlResultStatementFiveDuraAce, order.HtmlReceipt());
        }

        private const string HtmlResultStatementFiveDuraAce = @"<html><body><h1>Order Receipt for Shark Bike Shop</h1><ul><li>5 x Specialized S-Works Venge Dura-Ace = $20,000.00</li></ul><h3>Sub-Total: $20,000.00</h3><h3>Tax: $1,450.00</h3><h2>Total: $21,450.00</h2></body></html>";
    }
}