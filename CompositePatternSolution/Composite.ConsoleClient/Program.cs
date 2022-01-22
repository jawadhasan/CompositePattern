using Composite.ConsoleClient.MenuExample;
using Composite.ConsoleClient.OrderExample;
using Composite.ConsoleClient.Structural;
using System;

namespace Composite.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StructrualExample();


            //Uncomment below function calls for other examples:

            //MenuExample();


            //OrderCode();
            //MergeOrderByCopy();
            //MergeOrderByComposite();

            Console.ReadLine();
        }

        public static void StructrualExample()
        {
            //Create a Tree Structure
            var root = new Structural.Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp1 = new Structural.Composite("Composite C1");
            comp1.Add(new Leaf("Leaf C1-A"));
            comp1.Add(new Leaf("Leaf C1-B"));

            var comp2 = new Structural.Composite("Composite C2");
            comp2.Add(new Leaf("Leaf C2-A"));

            //add comp2 to comp1
            comp1.Add(comp2);

            //add comp1 to root
            root.Add(comp1);
            root.Add(new Leaf("Leaf C"));

            //Add and Remove a Leaf
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            //Recursively display tree
            root.PrimaryOperation(1); //or comp2.PrimaryOperation
        }

        public static void MenuExample()
        {

            //Main
            //---->Safety
            //---->Claims
            //-------->Personal
            Menu mainMenu = new Menu("Main", "/main");

            MenuItem SafetyMenuItem = new MenuItem("Safety", "/safety");

            //add to MainMenu
            mainMenu.Add(SafetyMenuItem);


            Menu claimsSubMenu = new Menu("Claims", "/claims");
            //add to MainMenu
            mainMenu.Add(claimsSubMenu);


            //personal claims
            MenuItem personalClaims = new MenuItem("Personal-Claims", "/personal");
            claimsSubMenu.Add(personalClaims);

            Console.WriteLine(mainMenu.Display());
        }

        public static void OrderCode()
        {
            var order1 = new Order("cust-1");
            order1.Add(new OrderItem("111", "Item-1", 10));
            order1.Add(new OrderItem("222", "Item-2", 20));
            order1.Add(new OrderItem("333", "Item-3", 100));

            Console.WriteLine(order1.Description);
        }

        public static void MergeOrderByCopy()
        {
            var order1 = new OrderOld("cust-1");
            order1.Add(new OrderItemOld("111", "Item-1", 10));           

            //some delay and other orders.....

            var order2 = new OrderOld("cust-1");
            order2.Add(new OrderItemOld("444", "Item-4", 10));
            order2.Add(new OrderItemOld("555", "Item-5", 60));


            var finalOrder = new OrderOld("cust-1");
            foreach(var item in order1.OrderItems)
            {
                finalOrder.Add(item);
            }
            foreach (var item in order2.OrderItems)
            {
                finalOrder.Add(item);
            }
            Console.WriteLine(order1.Description);           
        }

        public static void MergeOrderByComposite()
        {
            var order1 = new Order("cust-1");
            order1.Add(new OrderItem("111", "Item-1", 10));

            //some delay and other orders.....

            var order2 = new Order("cust-1");
            order2.Add(new OrderItem("444", "Item-4", 10));
            order2.Add(new OrderItem("555", "Item-5", 60));


            var finalOrder = new Order("cust-1");
            finalOrder.Add(order1);
            finalOrder.Add(order2);
            

            Console.WriteLine($"Order Total: {finalOrder.GetTotal()}");
        }
    }
}
