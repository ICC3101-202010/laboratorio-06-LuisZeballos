using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio6
{
    [Serializable]
    public class Departamento : Division
    {
        public Departamento(string name, List<Persona> personal) : base(name, personal)
        {

        }
    }
}
