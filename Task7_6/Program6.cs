using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator //Creator
    {
        public abstract CreditCard FactoryMethod(int type);
    }

    public class CreditCardFactory : Creator// ConcreteCreator : Creator
    {
        public override CreditCard FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new Platinum();
                //повертає об'єкт B, якщо type==2  
                case 2: return new Titanium();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class CreditCard //абстрактний клас продукт
    {
        public abstract string Info();
    } 

    //конкретні продукти з різною реалізацією
    public class Platinum : CreditCard 
    {
        public override string Info()
        {
            return "Card Type: Platinum Plus\nCredit Limit: 35000";
        }
    }

    public class Titanium : CreditCard 
    {
        public override string Info()
        {
            return "Card Type: Titanium Edge\nCredit Limit: 25000";
        }
    }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new CreditCardFactory();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created \n{1} \n", i, product.Info());
            }
            Console.ReadKey();
        }
    }
}