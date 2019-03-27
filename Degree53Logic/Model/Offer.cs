namespace Degree53.Model
{
    public class Offer
    {
        public string Code { get; }

        public int Quantity { get; }

        public decimal Cost { get; }

        public Offer(string code, int quantity, decimal cost)
        {
            Code = code;
            Quantity = quantity;
            Cost = cost;
        }
    }
}
