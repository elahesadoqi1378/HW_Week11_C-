
namespace HW_Week11.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Price { get; set; }
        public static bool IsValidCategoryId(int categoryId)
        {
            
            var validCategoryIds = new List<int> { 1, 2, 3, 4 }; 
            return validCategoryIds.Contains(categoryId);
        }
    }
}
