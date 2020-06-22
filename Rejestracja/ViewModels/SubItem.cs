using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace Rejestracja.ViewModels
{
    public class SubItem
    { public int IdSubItem;
        public string Name { get;}
       
    public SubItem(string name, int _idSubItem)
        {
            Name = name;
            IdSubItem = _idSubItem;
        }
    }
}
