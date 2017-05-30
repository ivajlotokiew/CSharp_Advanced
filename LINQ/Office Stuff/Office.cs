namespace _13.Office_Stuff
{
    public class Office
    {
        public Office(string company, int amount, string product)
        {
            this.Company = company;
            this.Amount = amount;
            this.Product = product;
        }

        public string Company { get; set; }

        public int Amount { get; set; }

        public string Product { get; set; }
    }
}