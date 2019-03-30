using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public class ProtagoinstFactory
    {
        public static Protagonist1 CreateProtagoinst(int type)
        {
            Protagonist1 protagonist = null;
            switch (type)
            {
                case 1:
                    protagonist = ProtagonistYan.GetProtagonist();
                    break;
                case 2:
                    protagonist = ProtagonistYin.GetProtagonist();
                    break;
                case 3:
                    protagonist = ProtagonistMo.GetProtagonist();
                    break;
            }
            return protagonist;
        }
    }
}
