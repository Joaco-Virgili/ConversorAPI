namespace ConversorAPI.Entites
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Value { get; set; } = 0;
    }
}
