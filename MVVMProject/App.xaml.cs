using MVVMProject.Connectors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMProject
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DbConnector db = new DbConnector();
        public static DbConnector Db
        {
            get
            {
                return App.db;
            }
        }
    }
}
