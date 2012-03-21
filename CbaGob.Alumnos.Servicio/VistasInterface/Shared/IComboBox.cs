using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface.Shared
{
    public interface IComboBox
    {
        IList<IComboItem> Combo { get; set; }
        string Selected { get; set; }
        bool Enabled { get; set; }
        bool readOnly { get; set; }
    }

    public interface IComboItem
    {
        int id { get; set; }
        string description { get; set; }
    }
}
