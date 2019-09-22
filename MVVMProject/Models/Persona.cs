using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProject.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Persona(int id,string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
    public class PersonaCollection : ObservableCollection<Persona>
    {

    }
}
