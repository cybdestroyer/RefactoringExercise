namespace BikeDistributor
{
    public class Line
    {
        public int Quantity { get; private set; }

        public Bike Bike { get; private set; }

        public Line(Bike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;
        }
    }
}
