using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio6
{
    [Serializable]
    public class Division
    {
        private string name;
        List<Persona> personal = new List<Persona>();

        public Division(string name, List<Persona> personal)
        {
            this.name = name;
            this.personal = personal;
        }

        public string Name { get => name; set => name = value; }
        public List<Persona> Personal { get => personal; set => personal = value; }
    }
}
