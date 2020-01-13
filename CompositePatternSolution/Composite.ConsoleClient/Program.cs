using System;
using Composite.Structural;

namespace Composite.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
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


            comp1.Add(comp2);

            root.Add(comp1);
            root.Add(new Leaf("Leaf C"));

            //Add and Remove a Leaf
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            //Recursively display tree
            root.PrimaryOperation(1); //or comp2.PrimaryOperation

            Console.ReadLine();
        }
    }
}
