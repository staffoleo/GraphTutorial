using GraphQL;

namespace Orders.Schema
{
    public class OrdersSchema : GraphQL.Types.Schema 
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}