namespace BikeDistributor
{
    public class Order : ReceiptPrinter
    {
        public string Company { get; private set; }

        public Order(string company) : base()
        {
            Company = company;
        }

        public void AddLine(Line line)
        {
            Add(line);
        }

        public string Receipt()
        {
            return BuildReceipt(Company, ReceiptPrinter.Template.PlainText);
        }

        public string HtmlReceipt()
        {
            return BuildReceipt(Company, ReceiptPrinter.Template.HtmlMarkup);
        }

    }
}