using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace ProtectedMultipleObjects
{
    class Computer
    {
        protected string _Type;
        protected float _Price;
        protected string _Cpu;

        public Computer()
        {
            _Type = string.Empty;
            _Price = 0;
            _Cpu = string.Empty;
        }

        public Computer(string type, float price, string cpu)
        {
            _Type = type;
            _Price = price;
            _Cpu = cpu;
        }

        public virtual void addChange()
        {
            Console.Write("Type of Computer: ");
            _Type = Console.ReadLine();
            Console.Write("Price: $");
            _Price = float.Parse(Console.ReadLine());
            Console.Write("What CPU does it have? ");
            _Cpu = Console.ReadLine();


        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"Type of hardware: {_Type}");
            Console.WriteLine($"Hardware price: {_Price}");
            Console.WriteLine($"CPU: {_Cpu}");
        }
    }
    class Laptop : Computer
    {
        protected string _Brand;
        protected string _Model;

        public Laptop()
            : base()
        {
            _Brand = string.Empty;
            _Model = string.Empty;
        }
        public Laptop(string type, float price, string cpu, string brand, string model)
            : base(type, price, cpu)
        {
            _Brand = brand;
            _Model = model;
        }

        public override void addChange()
        {
            base.addChange();
            Console.Write("Brand: ");
            _Brand = Console.ReadLine();
            Console.Write("Modle: ");
            _Model = Console.ReadLine();
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"Brand: {_Brand}");
            Console.WriteLine($"Model: {_Model}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many Computers would you like to enter? ");
            int maxComp;
            while (!int.TryParse(Console.ReadLine(), out maxComp))
                Console.WriteLine("Please enter a whole number.");
            Computer[] comp = new Computer[maxComp];

            Console.WriteLine("How many Laptops would you like to enter? ");
            int maxLaptop;
            while (!int.TryParse(Console.ReadLine(), out maxLaptop))
                Console.WriteLine("Please enter a while number.");
            Laptop[] lappy = new Laptop[maxLaptop];


            int choice, rec, type;
            int compCounter = 0, lappyCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Computer or 2 for Laptop");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Computer or 2 for Laptop");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (compCounter < maxComp)
                                {
                                    comp[compCounter] = new Computer();
                                    comp[compCounter].addChange();
                                    compCounter++;
                                }
                                else { Console.WriteLine("The maximum number of computers has been added"); }

                            }
                            else
                            {
                                if (lappyCounter < maxLaptop)
                                {
                                    lappy[lappyCounter] = new Laptop();
                                    lappy[lappyCounter].addChange();
                                    lappyCounter++;
                                }
                                else { Console.WriteLine("The maximum number of laptops has been added"); }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                for (int i = 0; i < compCounter; i++)
                                    comp[i].addChange();
                            }
                            else
                            {
                                for (int i = 0; i < lappyCounter; i++)
                                    lappy[i].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < compCounter; i++) comp[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < lappyCounter; i++) lappy[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();
            }
        }
        private static int Menu()
        {
            Console.WriteLine("\nPlease make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}