using System;
namespace AdapterExample
{
    // Система яку будемо адаптовувати
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }

    // НОВЕ: Ще одна система для адаптації (Американська система)
    class AmericanElectricitySystem
    {
        public string MatchFlatSocket()
        {
            return "american system (flat pins)";
        }
    }

    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }

    // Адаптер для старої системи
    class Adapter : INewElectricitySystem
    {
        private readonly OldElectricitySystem _adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            return _adaptee.MatchThinSocket();
        }
    }

    // НОВЕ: Адаптер для американської системи
    class AmericanAdapter : INewElectricitySystem
    {
        private readonly AmericanElectricitySystem _adaptee;

        public AmericanAdapter(AmericanElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            // Адаптуємо виклик
            return _adaptee.MatchFlatSocket();
        }
    }

     class ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            // 1) Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);
            
            // 2) Ми повинні адаптуватися до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            // 3) НОВЕ: Адаптуємося до американської системи
            Console.WriteLine("--- Connecting to American grid ---");
            var americanSystem = new AmericanElectricitySystem();
            var americanAdapter = new AmericanAdapter(americanSystem);
            ElectricityConsumer.ChargeNotebook(americanAdapter);

            Console.ReadKey();
        }
    }
}