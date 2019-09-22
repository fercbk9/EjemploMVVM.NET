using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVMProject.Models;
using MVVMProject.Utils;
using MVVMProject.Utils.Commands;

namespace MVVMProject.ViewModels
{
    public class PersonaViewModel : IGeneric
    {
        private PersonaCollection listaPersonas = new PersonaCollection();
        public PersonaCollection ListaPersonas
        {
            get{ return listaPersonas; }
            set{ listaPersonas = value;
                RaisePropertyCahnged("ListaPersonas");
                if (value != null && value.Count > 0)
                {
                    CurrentPersona = value[0];
                }
            }
        }
        private Persona currentPersona;
        public Persona CurrentPersona
        {
            get { return currentPersona; }
            set { currentPersona = value;
                RaisePropertyCahnged("CurrentPersona");
                RaisePropertyCahnged("CanShowInfo");
            }
        }
        private ICommand listarPersonasCommand;
        public ICommand ListarPersonasCommand
        {
            get
            {
                if (listarPersonasCommand == null)
                    listarPersonasCommand = new RelayCommand(new Action(ListarPersonas));
                return listarPersonasCommand;
            }
        }



        private ICommand verInfo2Command;
        public ICommand VerInfo2Command
        {
            get
            {
                if (verInfo2Command == null)
                {
                    verInfo2Command = new ParamCommand(new Action<object>(VerInfo2), () => CanShowInfo);
                }
                return verInfo2Command;
            }
        }


        private ICommand eliminarCommand;
        public ICommand EliminarCommand
        {
            get
            {
                if (eliminarCommand == null)
                {
                    eliminarCommand = new ParamCommand(new Action<object>(EliminarPersonas), () => CanShowInfo);
                }
                return eliminarCommand;
            }
        }

        private ICommand verInfoCommand;
        public ICommand VerInfoCommand
        {
            get
            {
                if (verInfoCommand == null)
                {
                    verInfoCommand = new RelayCommand(new Action(VerInfo),() => CanShowInfo);
                }
                return verInfoCommand;
            }
        }
        private void ListarPersonas()
        {
            ListaPersonas = App.Db.ListarPersonas();
        }
        private void EliminarPersonas(object obj)
        {
            if (obj != null)
            {
                CurrentPersona = (Persona)obj;
                ListaPersonas = App.Db.EliminarPersona(listaPersonas, currentPersona);
            }
            else
            {
                MessageBox.Show("No hay ninguna persona Seleccionada");
            }
        }
        private void VerInfo()
        {
            if (currentPersona != null)
            { 
                MessageBox.Show(CurrentPersona.Nombre);
            }
            else
            {
                MessageBox.Show("No hay ninguna persona Seleccionada");
            }
        }
        private void VerInfo2(object obj)
        {
            if (obj != null)
            {
                CurrentPersona = (Persona)obj;
                MessageBox.Show(CurrentPersona.Nombre);
            }
            else
            {
                MessageBox.Show("No hay ninguna persona Seleccionada");
            }
        }

        private bool CanShowInfo => CurrentPersona != null;


        public PersonaViewModel()
        {

        }
    }
}
