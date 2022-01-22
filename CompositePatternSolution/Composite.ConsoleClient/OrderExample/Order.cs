using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite.ConsoleClient.OrderExample
{
    //Component
    public abstract class OrderComponent
    {       
        public string Description { get; set; }
        public int Total { get; set; }
        public abstract int GetTotal();
    }

    //Composite
    public class Order : OrderComponent
    {
        public string CustomerCode { get; }
        public List<OrderComponent> OrderItems = new List<OrderComponent>();      
        
        //ctor
        public Order(string customerCode)
        {
            CustomerCode = customerCode;           
        }              

        //Collection
        public void Add(OrderComponent orderItem)
        {
            OrderItems.Add(orderItem);
        }


        public override int GetTotal()
        {
            IEnumerator<OrderComponent> itr = this.OrderItems.GetEnumerator();
            while (itr.MoveNext()) //recursion
            {
                //childrens
                var childComponent = itr.Current;
                var childTotal = childComponent.GetTotal(); //delegating to child
                Total += childTotal;
            }
            return Total;
        }
    }

    //Leaf
    public class OrderItem : OrderComponent
    {
        public string Code { get; set; }         

        //ctor
        public OrderItem(string code, string description, int total)
        {
            Code = code;
            Description = description; //was Name
            Total = total; //was price
        }

        public override int GetTotal()
        {           
            return Total;
        }

    }






    public class OrderOld
    {
        public string CustomerCode { get; }
        public List<OrderItemOld> OrderItems = new List<OrderItemOld>();
        //ctor
        public OrderOld(string customerCode)
        {
            CustomerCode = customerCode;
        }
        public string Description => $"Order total for Customer {CustomerCode} is {Total}";
        public int Total => OrderItems.Sum(item => item.Price);

        //Collection
        public void Add(OrderItemOld orderItem)
        {
            OrderItems.Add(orderItem);
        }
        //other methods e.g. remove etc
    }
    public class OrderItemOld
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        //ctor
        public OrderItemOld(string code, string name, int price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
}
