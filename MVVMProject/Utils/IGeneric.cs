using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProject.Utils
{
    public class IGeneric : IEnlace
    {
        #region Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCahnged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
