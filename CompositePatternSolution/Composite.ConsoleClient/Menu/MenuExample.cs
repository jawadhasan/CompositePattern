using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.ConsoleClient.MenuExample
{
    //component
    public abstract class MenuComponent
    {
        public string Name { get; set; }
        public string URL { get; set; }       
        public abstract string Display();

        public string Print(MenuComponent menuComponent)
        {
            var sb = new StringBuilder(Name);
            sb.Append($":{URL}{Environment.NewLine}");
            return sb.ToString();
        }
    }

    //leaf
    public class MenuItem : MenuComponent
    {
        public MenuItem(string name, string url)
        {
            this.Name = name;
            this.URL = url;
        }
        public override string Display()
        {
            return base.Print(this);
        }
    }

    //composite
    public class Menu : MenuComponent
    {
        public List<MenuComponent> MenuComponents = new List<MenuComponent>();

        //ctor  
        public Menu(string name, string url)
        {
            this.Name = name;
            this.URL = url;
        }
        public override string Display()
        {
            var sb = new StringBuilder();
            var menuPrint = Print(this);
            sb.Append(menuPrint);

            IEnumerator<MenuComponent> itr = this.MenuComponents.GetEnumerator();
            while (itr.MoveNext()) //recursion
            {
                //childrens
                var childComponent = itr.Current;
                var childPrint = childComponent.Display();
                sb.Append(childPrint); //delegating to child
            }
            return sb.ToString();
        }

        //stuff related to childrens
        public MenuComponent Add(MenuComponent menuComponent)
        {
            MenuComponents.Add(menuComponent);
            return menuComponent; //optional, otherwise void
        }

        public MenuComponent Remove(MenuComponent menuComponent)
        {
            MenuComponents.Remove(menuComponent);
            return menuComponent;
        }


        
    }


}
