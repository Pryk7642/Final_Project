using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Final
{
    internal class Camera : Device
    {
        private string battery;
        public Camera(string name , string price, string quantity , string battery) : base(name, price, quantity)
        {
            this.battery = battery;
        }

        public string getBattery()
        {
            return battery;
        }
    }
}
