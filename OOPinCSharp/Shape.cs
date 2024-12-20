using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public abstract class Shape
    {
        public int measure { get; set; }
        public abstract double CalculateArea(int measure);
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double CalculateArea(int Radius)
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class BankAccount
    {
        private decimal CurrentBalance;
        public decimal GetBalance()
        {
            return CurrentBalance;
        }
        public void Deposit(decimal amount)
        {
            this.CurrentBalance = this.CurrentBalance + amount;
        }
        public void Withdraw(decimal amount)
        {
            this.CurrentBalance -= amount;
        }
    }
    
        public class Square : Shape
    {
        public double Side { get; set; }

        public override double CalculateArea(int Side)
        {
            return Side * Side;
        }
        public static void Main9(string[] args)
        {
            Shape sqr = new Square();
            Console.WriteLine(sqr.CalculateArea(4));
            Shape crcl = new Circle();
            Console.WriteLine(crcl.CalculateArea(54));
            BankAccount account = new BankAccount();
            var initialbalance = account.GetBalance();
            Console.WriteLine(initialbalance);
            account.Deposit(200);
            decimal currentBalance = account.GetBalance();
            Console.WriteLine(currentBalance);
            account.Withdraw(50);

            Console.WriteLine(account.GetBalance());

        }
    }

}
