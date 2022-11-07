using System;
using System.Text;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Create ConcreteComponent and two Decorators
            Tree t = new Tree();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();
            // Link decorators
            d1.SetComponent(t);
            d2.SetComponent(d1);

            d2.Operation();
            
            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component //Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class Tree : Component //Component
    {
        public override void Operation()
        {
            //Console.WriteLine("Ялинка");
        }
    }
    // "Decorator"
    abstract class Decorator : Component //Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "декорована ялинковими прикрасами";
            Console.WriteLine("Декорована прикрасами");
        }
    }

    // "ConcreteDecoratorB" 
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();            
            Console.WriteLine("Додано гірлянди");
            AddedBehavior();
        }
        void AddedBehavior()
        {
            Console.WriteLine("Ялинка світиться");
        }
    }
}