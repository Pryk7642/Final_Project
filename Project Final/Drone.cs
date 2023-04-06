using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Final
{
    internal class Drone : Device
    {
        private string color;

        public Drone(string name,string price ,string quantity, string color) : base(name,price ,quantity)
        {
            this.color = color;
        }
        public string getColor()
        {
            return color;
        }
    }
}
