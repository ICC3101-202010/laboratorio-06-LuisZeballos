using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio6
{
    [Serializable]
    public class Persona
    {
        private string name;
        private string apellido;
        private string rut;
        private string cargo;

        public Persona(string name, string apellido, string rut, string cargo)
        {
            this.name = name;
            this.apellido = apellido;
            this.rut = rut;
            this.cargo = cargo;
        }

        public string Name { get => name; set => name = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Rut { get => rut; set => rut = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
