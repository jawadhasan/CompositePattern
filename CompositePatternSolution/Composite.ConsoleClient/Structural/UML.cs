using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.ConsoleClient.Structural
{
    public abstract class Component
    {
        public string Name { get; }
        //ctor
        public Component(string name)
        {
            Name = name;
        }
       
        // PrimaryOperation: 
        //This is main operation of the pattern, that can be executed both by composite or leaf node.
        public abstract void PrimaryOperation(int depth);
    }


    public class Leaf : Component
    {
        //ctor
        public Leaf(string name) : base(name)
        {
        }

        //Primary Operation
        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }
    }


    public class Composite : Component
    {

        //because its a composite, we want it to have a list of its own children
        private List<Component> _children = new List<Component>();

        //ctor
        public Composite(string name) : base(name)
        {
        }

        //Primary Operation
        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
            foreach (var component in _children)
            {
                component.PrimaryOperation(depth + 2);
            }
        }

        //Notice we implement add/remove operation for a composite
        public void Add(Component c)
        {
            _children.Add(c);
        }

        public void Remove(Component c)
        {
            _children.Remove(c);
        }
    }

}
