namespace SAModels
{
    public class LineItem
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Item: {Item}\nQuantity: {Quantity}";
        }
    }
}