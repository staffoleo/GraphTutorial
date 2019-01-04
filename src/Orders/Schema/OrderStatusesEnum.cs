using GraphQL.Types;

namespace Orders.Schema
{
    public class OrderStatusesEnum : EnumerationGraphType
    {
        public OrderStatusesEnum()
        {
            Name = "OrderStatuses";
            AddValue("Created", "Order was created", 2);
            AddValue("Processing", "Order is being processed", 4);
            AddValue("Completed", "Order is completed", 8);
            AddValue("Cancelled", "Order is cancelled", 16);
            AddValue("Closed", "Order is closed", 32);
        }
    }
}