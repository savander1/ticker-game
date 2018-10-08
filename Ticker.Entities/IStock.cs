namespace Ticker.Entities
{
    public interface IStock
    {
        string Name { get; }
        decimal Value { get; set; }
    }
}