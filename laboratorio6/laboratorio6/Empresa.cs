using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio6
{
    [Serializable]
    public class Empresa
    {
        private string name;
        private string rut;
        List<Division> divisions = new List<Division>();

        public Empresa(string name, string rut, List<Division> divisions)
        {
            this.name = name;
            this.rut = rut;
            this.divisions = divisions;
        }

        public string Name { get => name; set => name = value; }
        public string Rut { get => rut; set => rut = value; }
        public List<Division> Divisions { get => divisions; set => divisions = value; }
    }
}
