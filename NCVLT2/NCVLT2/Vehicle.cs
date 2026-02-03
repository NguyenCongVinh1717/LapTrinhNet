using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCVLT2
{
    internal class Vehicle
    {
        private string id;
        private string maker;
        private string model;
        private int year;
        private double price;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Maker
        {
            get { return maker; }
            set { maker = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set {  year = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public Vehicle()
        {

        }
        public Vehicle(string id)
        {
            this.id = id;
        }
        public Vehicle(string id,string maker,string model,int year,double price)
        {
            this.id = id;
            this.maker = maker;
            this.model = model;
            this.year = year;
            this.price = price;
        }
        public virtual void Input()
        {
            do
            {
                Console.Write("Id: ");
                this.Id = Console.ReadLine();
                if(Program.checkExist(this.Id) == true)
                {
                    Console.WriteLine("Mã bị trùng, nhập lại");
                }
            }while(Program.checkExist(this.Id)==true);
            Console.Write("Maker: ");
            this.Maker = Console.ReadLine();
            Console.Write("Model: ");
            this.Model = Console.ReadLine();
            do
            {
                Console.Write("Year: ");
                if(int.TryParse(Console.ReadLine(), out var y)&& y > 0){
                    this.Year=y;
                    break;
                }
                else
                {
                    Console.WriteLine("Nhập lại năm");
                }
            } while (true);
            do
            {
                Console.Write("Price: ");
                if (double.TryParse(Console.ReadLine(), out var p) && p > 0)
                {
                    this.Price = p;
                    break;
                }
                else
                {
                    Console.WriteLine("Nhập lại giá");
                }
            } while (true);

        }
        public virtual void Output()
        {
            Console.Write($"{this.Id,-8} | {this.Maker,-12} | {this.Model,-12} | {this.Year,-6} | {this.Price,10}");

        }
    }
}
