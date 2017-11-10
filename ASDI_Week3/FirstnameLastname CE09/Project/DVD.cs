using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE09
{
    class DVD
    {
        public string Title;
        public decimal Price;
        public float Rating;

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Title, Price, Rating);
        }
    }
}
