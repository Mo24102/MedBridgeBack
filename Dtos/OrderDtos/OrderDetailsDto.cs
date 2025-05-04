namespace MedBridge.Dtos.OrderDtos
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; } // معرف الطلب
        public string UserName { get; set; } // اسم المستخدم
        public DateTime OrderDate { get; set; } // تاريخ الطلب
        public string Status { get; set; } // حالة الطلب (مثال: قيد التنفيذ، مكتمل، إلخ)
        public decimal TotalPrice { get; set; } // المجموع الكلي للطلب
        public List<OrderDetailsItemDto> Items { get; set; } // قائمة بالعناصر في الطلب
    }

    public class OrderDetailsItemDto
    {
        public string ProductName { get; set; } // اسم المنتج
        public int Quantity { get; set; } // الكمية المطلوبة
        public decimal UnitPrice { get; set; } // سعر الوحدة
    }
}
