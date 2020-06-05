using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTestingWare
{
    public class Card
    {
        public String Name;
        public String Comment;

        public override string ToString()
        {
            if(Comment != null && Comment != "")
            {
                return Name + " (" + Comment + ")";
            }
            return Name;
        }
    }
}
