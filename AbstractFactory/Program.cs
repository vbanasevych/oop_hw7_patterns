using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    //ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }
    
    // ConcreteProductA3
    class Mersedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mersedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }
    
    // ConcreteProductB3
    class MersedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mersedes Engine 5.0");
        }
    }

    //ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }
    }
    
    // ConcreteFactory3
    class MersedesFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Mersedes();
        }
        Engine ICarFactory.CreateEngine()
        {
            return new MersedesEngine();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;

        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
        }

        public void Run()
        {
            car.GetType();
            //Абстрагування варіантів використання
            car.Interact(engine);
        }
    }

    class AbstractFactoryApp
    {static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();
            
            carFactory = new FordFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            // --- Демонстрація нової фабрики --- 
            Console.WriteLine("\n--- Testing Mersedes Factory ---");
            carFactory = new MersedesFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine(); 
            myEngine.GetPower();

            Console.ReadKey();
        }
    }
}
