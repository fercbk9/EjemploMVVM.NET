using MVVMProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProject.Connectors
{
    public class DbConnector
    {
        public PersonaCollection ListarPersonas()
        {
            PersonaCollection lista = new PersonaCollection();
            lista.Add(new Persona(1, "Pedro"));
            lista.Add(new Persona(2, "Pepe"));
            lista.Add(new Persona(3, "Luis"));
            lista.Add(new Persona(4, "Fer"));
            lista.Add(new Persona(5, "Jose"));
            return lista;
        }
        public void ListarPersonas(PersonaCollection lista)
        {
            lista.Add(new Persona(1, "Pedro"));
            lista.Add(new Persona(2, "Pepe"));
            lista.Add(new Persona(3, "Luis"));
            lista.Add(new Persona(4, "Fer"));
            lista.Add(new Persona(5, "Jose"));
        }
        public PersonaCollection EliminarPersona(PersonaCollection lista,Persona p)
        {
            lista.Remove(p);
            return lista;
        }
    }
}
