using System;

namespace zadanie_1

{
    /*
    public class Animal
    {
        public string Name { get; protected set; }
        public Animal(string name)
        {
            Name = name;
        }
        public virtual void Makesound()
        {
            Console.WriteLine("говорит:");
        }
            public virtual void Info()
            {
                Console.WriteLine($"Имя: {Name} Тип: {GetType().Name}");
            }

    }
    public interface ICanFly 
    {
        void Fly();
    }
    public class Lion : Animal 
    {
        public Lion(string name):base(name)
        {

        }
        public override void Makesound() { Console.WriteLine("рычит Р-Р-Р"); }
            public override void Info() 
            {
                base.Info(); 
            }
        }
    public class Elephant : Animal
    {
        public Elephant(string name) : base(name)
        {

        }
        public override void Makesound() { Console.WriteLine("трубит Тууу"); }
            public override void Info()
            {
                base.Info();
            }

        }
    public class Parrot : Animal, ICanFly
    {
        public Parrot(string name) : base(name)
        {

        }
        public override void Makesound() { Console.WriteLine("говорит Привет"); }
        public void Fly() => Console.WriteLine("Летает");
            public override void Info()
            {
                base.Info();
            }
        }
    class Program 
    {
        static void Main(string[] args)
        {
            Animal[] animals = { new Lion("Сим"), new Elephant("Наш слоняра"), new Parrot("Жора") };
            foreach (var anim in animals) 
            {
                anim.Makesound();
                anim.Info();
                if (anim is ICanFly parrot)
                {
                    parrot.Fly();
                }
            }

        }

    }


    namespace zadaniy_2 
    {
        using System;

        public class BankAccount
        {
            private decimal _balance;

            public BankAccount(decimal initialBalance)
            {
                _balance = initialBalance;
            }

            public virtual void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма должна быть положительной.");
                    return;
                }
                _balance += amount;
                Console.WriteLine($"Внесено: {amount}. Текущий баланс: {_balance}");
            }

            public virtual void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма должна быть положительной.");
                    return;
                }
                if (_balance < amount)
                {
                    Console.WriteLine("Недостаточно средств для снятия.");
                    return;
                }
                _balance -= amount;
                Console.WriteLine($"Снято: {amount}. Текущий баланс: {_balance}");
            }

            public decimal GetBalance()
            {
                return _balance;
            }
        }

        public class SavingsAccount : BankAccount
        {
            public SavingsAccount(decimal initialBalance) : base(initialBalance)
            {
            }

            public override void Withdraw(decimal amount)
            {
                Console.WriteLine("Снятие средств с накопительного счета невозможно.");
            }
        }

        public class CreditAccount : BankAccount
        {
            private const decimal CreditLimit = -1000;

            public CreditAccount(decimal initialBalance) : base(initialBalance)
            {
            }

            public override void Withdraw(decimal amount)
            {
                if (GetBalance() - amount < CreditLimit)
                {
                    Console.WriteLine("Превышен лимит кредита.");
                    return;
                }
                base.Withdraw(amount);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                BankAccount savings = new SavingsAccount(500);
                savings.Deposit(200);
                savings.Withdraw(100); // Не должно сработать
                Console.WriteLine($"Баланс накопительного счета: {savings.GetBalance()}");

                BankAccount credit = new CreditAccount(500);
                credit.Deposit(200);
                credit.Withdraw(600); 
                credit.Withdraw(200); // Превышение лимита
                Console.WriteLine($"Баланс кредитного счета: {credit.GetBalance()}");
            }
        }
    }
    */

    namespace zadanie_3
    {
        using System;

        public interface IDiscountable
        {
            void ApplyDiscount(decimal percent);
        }

        public class Product : IDiscountable
        {
            private string _name;
            private decimal _price;

            public Product(string name, decimal price)
            {
                _name = name;
                _price = price;
            }

            public string Name => _name; 
            public decimal Price => _price; 

            public void ApplyDiscount(decimal percent)
            {
                if (percent < 0 || percent > 100)
                {
                    Console.WriteLine("Скидка должна быть в диапазоне от 0 до 100.");
                    return;
                }

                _price -= _price * (percent / 100);
                Console.WriteLine($"Скидка {percent}% применена. Новая цена: {_price:C}");
            }
        }

        public class FoodProduct : Product
        {
            public int ShelfLife { get; private set; } 

            public FoodProduct(string name, decimal price, int shelfLife)
                : base(name, price)
            {
                ShelfLife = shelfLife;
            }
        }

        public class Electronics : Product
        {
            public int Warranty { get; private set; }

            public Electronics(string name, decimal price, int warranty)
                : base(name, price)
            {
                Warranty = warranty;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Product apple = new FoodProduct("Яблоко", 1.2m, 30);
                Product laptop = new Electronics("Ноутбук", 1200m, 24);

                Console.WriteLine($"Продукт: {apple.Name}, Цена: {apple.Price:C}");
                apple.ApplyDiscount(10);

                Console.WriteLine($"Продукт: {laptop.Name}, Цена: {laptop.Price:C}");
                laptop.ApplyDiscount(15);
            }
        }
    }
}
namespace zadanie_3
{
    using System;

    public interface IRefuelable
    {
        void Refuel(decimal amount);
    }

    public abstract class Vehicle
    {
        protected decimal speed;

        public Vehicle(decimal speed)
        {
            this.speed = speed;
        }

        public abstract void Move();
    }

    public class Car : Vehicle, IRefuelable
    {
        private string brand; 

        public Car(string brand, decimal speed) : base(speed)
        {
            this.brand = brand;
        }

        public override void Move()
        {
            Console.WriteLine($"Автомобиль {brand} движется со скоростью {speed} км/ч.");
        }

        public void Refuel(decimal amount)
        {
            Console.WriteLine($"Автомобиль {brand} заправлен на {amount} литров.");
        }
    }

    public class Motorcycle : Vehicle, IRefuelable
    {
        private string type; 

        public Motorcycle(string type, decimal speed) : base(speed)
        {
            this.type = type;
        }

        public override void Move()
        {
            Console.WriteLine($"Мотоцикл типа {type} движется со скоростью {speed} км/ч.");
        }

        public void Refuel(decimal amount)
        {
            Console.WriteLine($"Мотоцикл типа {type} заправлен на {amount} литров.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myCar = new Car("Toyota", 120);
            Vehicle myMotorcycle = new Motorcycle("Sport", 180);

            myCar.Move();
            myMotorcycle.Move(); 

            IRefuelable refuelableCar = (IRefuelable)myCar;
            refuelableCar.Refuel(50);

            IRefuelable refuelableMotorcycle = (IRefuelable)myMotorcycle;
            refuelableMotorcycle.Refuel(20);
        }
    }
}