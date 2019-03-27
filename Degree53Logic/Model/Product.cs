namespace Degree53.Model
{
    public class Product
    {
        public decimal Cost { get; }

        public string Code { get; }

        public string Description { get; }
        
        public Product(string code, decimal cost, string description)
        {
            Cost = cost;
            Description = description;
            Code = code;
        }
    }
}
