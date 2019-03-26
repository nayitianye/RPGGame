using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    class Context
    {
        private PersonStrategy personStrategy;
 
        public Context(PersonStrategy personStrategy)
        {
            this.personStrategy = personStrategy;
        }
        public Protagonist ContextInterface(Protagonist protagonist)
        {
           return  personStrategy.SetAttribute(protagonist);
        }
    }
}
