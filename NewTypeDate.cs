using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Prakticheskaya4
{
    internal class NewTypeDate
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        private int money;
        public string Money 
        {
            get 
            {   
                return money.ToString();
            }
            set
            {
                if (Int32.Parse(value) > 0)
                {
                    money = Int32.Parse(value);
                }
                else if (Int32.Parse(value) < 0)
                {
                    money = Int32.Parse(value) * -1;
                }
            } 
        }
        
        public bool Vichet { get; set; }
        
        public NewTypeDate(string name, string typename, string money, bool vichet)
        {
            this.Name = name;
            this.TypeName = typename;
            this.Money = money;
            this.Vichet = vichet;
        }
    }
}
