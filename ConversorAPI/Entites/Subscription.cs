namespace ConversorAPI.Entites
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AmountOfConversion { get; set; }
        public List<User> Users { get; set; }
    }
}
