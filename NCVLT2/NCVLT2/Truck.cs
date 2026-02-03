using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCVLT2
{
    internal class Truck: Vehicle
    {
        private int truckload;

        public Truck() : base() { }

        public Truck(string id, string maker, string model, int year, double price, int truckload)
            : base(id, maker, model, year, price)
        {
            this.truckload = truckload;
        }

        public int Truckload { get => truckload; set => truckload = value; }

        public override void Input()
        {
            base.Input();
            do
            {
                Console.Write("Truckload: ");
                if (int.TryParse(Console.ReadLine(), out var td) && td > 0)
                {
                    this.Truckload = td;
                    break;
                }
                else
                {
                    Console.WriteLine("Nhập lại trọng tải");
                }
            } while (true);

        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"|{this.Truckload,10}");
        }
    }
}
