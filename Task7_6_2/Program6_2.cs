using System;
using System.Collections;
using System.Text;

namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            // Create a tree structure
            Console.OutputEncoding = Encoding.UTF8;

            Component shape = new Composite("Фігури");
            shape.Add(new Leaf("Коло"));
            shape.Add(new Leaf("Трикутник"));

            Component comp1 = new Composite("Чотирикутник");
            Component comp2 = new Composite("Прямокутник");
            comp2.Add(new Leaf("Квадрат"));
            comp1.Add(comp2);
            comp1.Add(new Leaf("Трапеція"));
            shape.Add(comp1);

            shape.Add(new Leaf("П'ятикутник"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Шестикутник");
            shape.Add(leaf);
            shape.Remove(leaf);

            // Recursively display tree
            shape.Display(1);

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        protected string name;
        // Constructor
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    // "Composite"
    class Composite : Component
    {
        private ArrayList children = new ArrayList();
        // Constructor
        public Composite(string name)
            : base(name)
        {
        }
        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    // "Leaf"
    class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
            : base(name)
        {
        }
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

    }
}
