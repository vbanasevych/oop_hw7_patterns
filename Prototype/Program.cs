using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2);
            clone = prototype.Clone();

            Console.WriteLine("\n--- Демонстрація Трикутника ---");

            Triangle originalTriangle = new Triangle(3, 10.0, 15.0, 20.0);
            Console.WriteLine($"Оригінал (Id={originalTriangle.Id}): Сторони ({originalTriangle.SideA}, {originalTriangle.SideB}, {originalTriangle.SideC})");

            Triangle clonedTriangle = (Triangle)originalTriangle.Clone();
            Console.WriteLine($"Клон (Id={clonedTriangle.Id}): Сторони ({clonedTriangle.SideA}, {clonedTriangle.SideB}, {clonedTriangle.SideC})");

            Console.ReadKey();
        }
    }
    
    // "Prototype"
    abstract class Prototype
    {
        public int Id { get; private set; }
        public Prototype(int id)
        {
            this.Id = id;
        }
        public abstract Prototype Clone();
    }

    // "ConcretePrototype1"
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id)
        : base(id)
        { }
        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    // "ConcretePrototype2"
    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id)
        : base(id)
        { }
        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }
    }

    // "ConcretePrototype3" - Нове
    class Triangle : Prototype
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(int id, double sideA, double sideB, double sideC)
            : base(id)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public override Prototype Clone()
        {
            Console.WriteLine($"Клонування трикутника з Id={this.Id}...");
            
            return new Triangle(this.Id, this.SideA, this.SideB, this.SideC);
        }
    }
}