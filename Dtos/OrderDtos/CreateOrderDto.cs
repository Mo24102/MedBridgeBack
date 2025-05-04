namespace MedBridge.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int UserId { get; set; } // لتحديد المستخدم
        public List<CreateOrderItemDto> Items { get; set; } // قائمة العناصر في الطلب
    }

    public class CreateOrderItemDto
    {
        public int ProductId { get; set; } // معرف المنتج
        public int Quantity { get; set; } // الكمية المطلوبة
    }
}
