using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas.Shared
{
    public class ComboBox : IComboBox
    {
        public ComboBox()
        {
            Combo = new List<IComboItem>();
            Enabled = true;
            readOnly = false;
        }
        public IList<IComboItem> Combo { get; set; }
        public string Selected { get; set; }
        public bool Enabled { get; set; }
        public bool readOnly { get; set; }
    }

    public class ComboItem : IComboItem
    {
        public int id { get; set; }
        public string description { get; set; }
    }
}
