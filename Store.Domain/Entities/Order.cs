namespace Store.Domain.Entities;

public class Order : Entity
{
    public Order(Customer customer, decimal deliveryFee, Discount discount)
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(customer, "Customer", "CLiente inválido")
            );

        Customer = customer;
        Date = DateTime.Now;
        Number = Guid.NewGuid().ToString().Substring(0, 8);
        Status = EOrderStatus.WaitingPayment;
        DeliveryFee = deliveryFee;
        Discount = discount;
        Items = new List<OrderItem>();
    }

    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public string Number { get; set; }
    public EOrderStatus Status { get; set; }
    public decimal DeliveryFee { get; set; }
    public Discount Discount { get; set; }
    public IList<OrderItem> Items { get; set; }

    public void AddItem(Product product, int quantity)
    {
        var item = new OrderItem(product, quantity);
        Items.Add(item);
        
        if (item.IsValid)
            Items.Add(item);
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.Total();
        }

        total += DeliveryFee;
        total -= Discount != null ? Discount.Value() : 0;

        return total;
    }

    public void Pay(decimal amount)
    {
        if (amount == Total())
            this.Status = EOrderStatus.WaitingDelivery;
    }

    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
    }
}