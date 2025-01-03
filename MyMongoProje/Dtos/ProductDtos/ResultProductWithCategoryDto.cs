namespace MyMongoProje.Dtos.ProductDtos
{
	public class ResultProductWithCategoryDto
	{
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public int ProductStock { get; set; }
		public decimal ProductPrice { get; set; }
		public string CategoryName { get; set; }
	}
}
