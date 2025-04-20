using MedBridge.Models.ProductModels;

namespace MedBridge.Models
{
    public class Favourite
    {
        public int Id { get; set; }

        public string UserId { get; set; }    // المستخدم اللي عمل الفيفوريت

        public int ProductId { get; set; }    // المنتج اللي عمله Favorite

        // العلاقات
        public virtual ProductModel Product { get; set; }
    }
}
