using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCVLT2
{
    internal class Car:Vehicle
    {
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public Car():base()
        {
        }
        public Car(string id, string maker, string model, int year, double price, string color)
            : base(id, maker, model, year, price)
        {
            this.color = color;
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Color: ");
            this.Color=Console.ReadLine();
        }
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"|{this.Color,10}");
        }
    }
}
