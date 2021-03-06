namespace OOPEksamensprojekt.Core
{
    public class Product
    {
        private static int _idCount = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public bool CanBeBoughtOnCredit { get; private set; }

        public Product(int id, string name, decimal price, bool active)
        {
            Name = name;
            Price = price;
            Active = active;
            Id = id;
        }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void EnableBuyOnCredit()
        {
            CanBeBoughtOnCredit = true;
        }

        public void DisableBuyOnCredit()
        {
            CanBeBoughtOnCredit = false;
        }
        
        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} Price: {Price} ";
        }
    }
}