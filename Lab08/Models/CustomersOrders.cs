namespace Lab08.Models
{
    public class CustomersOrders
    {
        public virtual Customer? Customer { get; set; }
        public virtual Order? Order { get; set; }
    }
}
