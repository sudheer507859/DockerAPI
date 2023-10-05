namespace CarvedRock.API.APIModels
{
    public record QuickOrder
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
