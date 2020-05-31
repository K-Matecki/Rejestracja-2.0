using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace Rejestracja
{
    public class SubItem
    { public int IdSubItem;
        public string Name { get; private set; }
       
    public SubItem(string name, int _idSubItem)
        {
            Name = name;
            IdSubItem = _idSubItem;
        }
    }
}
