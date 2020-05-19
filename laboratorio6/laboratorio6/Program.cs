using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace laboratorio6
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Division> divisiones = new List<Division>(); List<Persona> jefes = new List<Persona>(); List<Persona> empleados = new List<Persona>();
            Persona persona1 = new Persona("Luis", "Zeballos", "20167525-1", "Jefe"); Persona persona2 = new Persona("Marina", "Zeballos", "20167525-2", "Jefe"); Persona persona3 = new Persona("Laura", "Zeballos", "20167525-3", "Jefe"); Persona persona4 = new Persona("Cecilia", "Carvajal", "20167525-4", "Empleado"); Persona persona5 = new Persona("Oscar", "Carvajal", "20167525-5", "Empleado"); Persona persona6 = new Persona("Pedro", "Carvajal", "20167525-6", "Empleado"); Persona persona7 = new Persona("Juan", "Carvajal", "20167525-7", "Empleado"); Persona persona8 = new Persona("Peter", "Carvajal", "20167525-8", "Empleado");
            jefes.Add(persona1); jefes.Add(persona2); jefes.Add(persona3); empleados.Add(persona4); empleados.Add(persona5); empleados.Add(persona6); empleados.Add(persona7); empleados.Add(persona8);
            List<Persona> personald1 = new List<Persona>(); List<Persona> personals1 = new List<Persona>(); List<Persona> personalb1 = new List<Persona>(); List<Persona> personalb2 = new List<Persona>();
            personals1.Add(jefes[rnd.Next(0, 2)]); personald1.Add(jefes[rnd.Next(0, 2)]); personalb1.Add(jefes[rnd.Next(0, 2)]); personalb1.Add(empleados[rnd.Next(0, 4)]); personalb1.Add(empleados[rnd.Next(0, 4)]); personalb2.Add(jefes[rnd.Next(0, 2)]); personalb2.Add(empleados[rnd.Next(0, 4)]); personalb2.Add(empleados[rnd.Next(0, 4)]);
            Departamento departamento = new Departamento("Departamento 1", personald1); Seccion seccion = new Seccion("Seccion 1", personals1); Bloque bloque = new Bloque("Bloque 1", personalb1); Bloque bloque2 = new Bloque("Bloque 2", personalb2);
            divisiones.Add(departamento); divisiones.Add(seccion); divisiones.Add(bloque); divisiones.Add(bloque2);
            Console.WriteLine("¿Quiere utilizar un archivo para cargar la información de la empresa? (a)SI / (b)NO");
            string res = Console.ReadLine();
            if (res == "a")
            {
                try
                {
                    Deserializar();
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("\nArchivo inexistente");
                    FileStream fs = new FileStream("empresa.bin", FileMode.CreateNew);
                    Console.WriteLine("\nArchivo empresa.bin creado\n");

                }
            }
            else if (res == "b")
            {
                Console.WriteLine("Escriba el nombre de la empresa");
                string nombre = Console.ReadLine();
                Console.WriteLine("Escriba el rut de la empresa");
                string rut = Console.ReadLine();
                Empresa empresa = new Empresa(nombre, rut, divisiones);
                try
                {
                    Serializar(empresa);
                    Console.WriteLine("Empresa agregada al archivo empresa.bin");
                    Thread.Sleep(2000);

                }
                catch (FileNotFoundException ex)
                {
                    FileStream fs = new FileStream("empresa.bin", FileMode.CreateNew);
                    Console.WriteLine("\nArchivo empresa.bin creado\n");
                }

            }
            Console.ReadLine();


        }
        static void Serializar(Empresa empresa)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresa);
            stream.Close();
        }
        static void Deserializar()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                Empresa empresa = (Empresa)formatter.Deserialize(stream);
                Console.WriteLine("Nombre y rut empresa: " + empresa.Name + " " + empresa.Rut);
                Console.WriteLine("Posee las siguientes divisones:");
                foreach (Division division in empresa.Divisions)
                {
                    Console.WriteLine("\n" + division.Name + " y su personal es: \n");
                    foreach (Persona persona in division.Personal)
                    {
                        Console.WriteLine(persona.Name + " " + persona.Apellido + " que es: " + persona.Cargo);
                    }
                }
                Thread.Sleep(3000);
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                Console.WriteLine("No existe ninguna empresa todavía");
                Thread.Sleep(2000);
            }

            stream.Close();
        }



    }
}
