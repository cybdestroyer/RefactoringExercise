using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class ReceiptPrinter
    {
        protected const double TaxRate = .0725d;

        protected readonly IList<Line> _lines = new List<Line>();

        protected void Add(Line line)
        {
            _lines.Add(line);
        }

        protected string BuildReceipt(string Company, Template template)
        {
            var totalAmount = 0d;
            var format = new Format.PlainText() as Format; // default is always plaintext

            // Extract method to retrieve format
            switch (template)
            {
                case Template.PlainText:
                    format = new Format.PlainText();
                    break;
                case Template.HtmlMarkup:
                    format = new Format.HtmlMarkup();
                    break;
                // Space for more templates/formats
                default: break;
            }

            var receipt = new StringBuilder(string.Format(format.Header, Company));

            if (_lines.Any())
            {
                foreach (var line in _lines)
                {
                    var thisAmount = Amount(line);

                    receipt.Append(string.Format(format.Item, line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                    totalAmount += thisAmount;
                }

                receipt.Append(string.Format(format.SubTotal, totalAmount.ToString("C")));

                var tax = totalAmount * TaxRate;
                receipt.Append(string.Format(format.Tax, tax.ToString("C")));
                receipt.Append(string.Format(format.Total, (totalAmount + tax).ToString("C")));
            }

            receipt.Append(format.Footer);

            return receipt.ToString();
        }

        private double Amount(Line line)
        {
            var price = 0d;

            switch (line.Bike.Price)
            {
                case (int)Bike.Catalog.OneThousand:
                    if (line.Quantity >= 20)
                        price += line.Quantity * line.Bike.Price * .9d;
                    else
                        price += line.Quantity * line.Bike.Price;
                    break;
                case (int)Bike.Catalog.TwoThousand:
                    if (line.Quantity >= 10)
                        price += line.Quantity * line.Bike.Price * .8d;
                    else
                        price += line.Quantity * line.Bike.Price;
                    break;
                case (int)Bike.Catalog.FiveThousand:
                    if (line.Quantity >= 5)
                        price += line.Quantity * line.Bike.Price * .8d;
                    else
                        price += line.Quantity * line.Bike.Price;
                    break;
                default: break;
            }

            return price;
        }

        protected enum Template
        {
            PlainText, HtmlMarkup, JSON
        }

        private abstract class Format
        {
            public abstract string Header { get; }
            public abstract string Item { get; }
            public abstract string SubTotal { get; }
            public abstract string Tax { get; }
            public abstract string Total { get; }
            public abstract string Footer { get; }

            public class HtmlMarkup : Format
            {

                public override string Header { get { return "<html><body><h1>Order Receipt for {0}</h1><ul>"; } }
                public override string Item { get { return "<li>{0} x {1} {2} = {3}</li>"; } }
                public override string SubTotal { get { return "</ul><h3>Sub-Total: {0}</h3>"; } }
                public override string Tax { get { return "<h3>Tax: {0}</h3>"; } }
                public override string Total { get { return "<h2>Total: {0}</h2>"; } }
                public override string Footer { get { return "</body></html>"; } }
            }

            public class PlainText : Format
            {
                public override string Header { get { return "Order Receipt for {0}" + Environment.NewLine; } }
                public override string Item { get { return "\t{0} x {1} {2} = {3}" + Environment.NewLine; } }
                public override string SubTotal { get { return "Sub-Total: {0}" + Environment.NewLine; } }
                public override string Tax { get { return "Tax: {0}" + Environment.NewLine; } }
                public override string Total { get { return "Total: {0}"; } }
                public override string Footer { get { return ""; } }
            }

            // Sample of 
            public class JSON : Format
            {
                public override string Header => throw new NotImplementedException();
                public override string Item => throw new NotImplementedException();
                public override string SubTotal => throw new NotImplementedException();
                public override string Tax => throw new NotImplementedException();
                public override string Total => throw new NotImplementedException();
                public override string Footer => throw new NotImplementedException();
            }
        }
    }
}