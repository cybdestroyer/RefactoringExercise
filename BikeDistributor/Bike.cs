namespace BikeDistributor
{
    public class Bike
    {
        public int Price { get; set; }

        public string Brand { get; private set; }
        public string Model { get; private set; }

        public enum Catalog
        {
            OneThousand = 1000,
            TwoThousand = 2000,
            FiveThousand = 5000
        }

        public Bike(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }
    }
}
