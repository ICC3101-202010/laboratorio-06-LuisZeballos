using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio6
{
    [Serializable]
    public class Bloque : Division
    {
        List<Persona> personal = new List<Persona>();
        public Bloque(string name, List<Persona> personal) : base(name, personal)
        {
            this.personal = personal;
        }

    }
}
