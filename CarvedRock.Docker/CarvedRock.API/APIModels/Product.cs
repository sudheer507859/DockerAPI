namespace CarvedRock.API.APIModels
{
    public record Product
    {
        public int ProdcuID { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; } = null;
        public decimal? Price { get; set; }
        public string? Category { get; set; }

    }
}
