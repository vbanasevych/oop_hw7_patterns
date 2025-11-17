using System;
using System.Text;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            BasicChristmasTree basicTree = new BasicChristmasTree();
            Console.WriteLine("--- Звичайна ялинка ---");
            basicTree.Display();
            Console.WriteLine();

            OrnamentDecorator ornamentDecorator = new OrnamentDecorator("Червоні кульки", 20);
            
            GarlandDecorator garlandDecorator = new GarlandDecorator();

            ornamentDecorator.SetComponent(basicTree);

            garlandDecorator.SetComponent(ornamentDecorator);

            Console.WriteLine("--- Прикрашена ялинка ---");
            garlandDecorator.Display();
            Console.WriteLine();

            Console.WriteLine("--- Вмикаємо гірлянди ---");
            garlandDecorator.Glow(); 

            Console.Read();
        }
    }

    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Display();
    }

    // "ConcreteComponent"
    class BasicChristmasTree : ChristmasTree
    {
        public override void Display()
        {
            Console.WriteLine("Це звичайна ялинка.");
        }
    }

    // "Decorator"
    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetComponent(ChristmasTree tree)
        {
            this.tree = tree;
        }
        
        public override void Display()
        {
            if (tree != null)
            {
                tree.Display();
            }
        }
    }

    // "ConcreteDecoratorA" - Прикраси (з полями)
    class OrnamentDecorator : TreeDecorator
    {
        private string ornamentType;
        private int count;

        public OrnamentDecorator(string type, int count)
        {
            this.ornamentType = type;
            this.count = count;
        }

        public override void Display()
        {
            base.Display(); 
            Console.WriteLine($" * Прикрашена {ornamentType} ({count} шт.)");
        }
    }

    // "ConcreteDecoratorB" - Гірлянди (з методом)
    class GarlandDecorator : TreeDecorator
    {
        public override void Display()
        {
            base.Display();
            
            Console.WriteLine(" * Обвішана гірляндами.");
        }

        // --- Завдання: Додати Метод ---
        public void Glow()
        {
            Console.WriteLine("Ялинка починає світитися вогниками! ");
        }
    }
}