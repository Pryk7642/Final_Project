using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Final
{
    internal class Device
    {
        private string name;
        private string price;
        private string quantity;

        public Device(string name, string price, string quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public string getName()
        {
            return name;
        }

        public string getPrice()
        {
            return price;
        }
        public string getQuantity()
        {
            return quantity;
        }
    }
}
