using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika13
{
    class MobilePhone
    {
        private string model;
        private string proizvoditel;
        private string tipekrana;
        private string os;
        private int battery;


        public MobilePhone(string model, string proizvoditel, string tipekrana, string os, int battery)
        {
            this.model = model;
            this.proizvoditel = proizvoditel;
            this.tipekrana = tipekrana;
            this.os = os;
            this.battery = battery;
           

        }
        public string getModel()
        { 
        return this.model;
        }
        public string getProizvoditel()
        {
            return this.proizvoditel;
        }
        public string getTipekrana()
        {
            return this.tipekrana;
        }
        public string getOs()
        {
            return this.os;
        }
        public int getBattery()
        {
            return this.battery;
        }
        public void setModel(string model)
        {
            this.model = model;
        }
        public void setProizvoditel(string proizvoditel)
        {
            this.proizvoditel= proizvoditel;
        }
        public void setTipekranar(string tipekrana)
        {
            this.tipekrana = tipekrana;
        }
        public void setOs(string os)
        {
            this.os = os;
        }
        public void setBattery(int battery)
        {
            this.battery = battery;
        }
    }
}
    

