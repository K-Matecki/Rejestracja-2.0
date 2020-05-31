﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace Rejestracja
{
    public class ItemMenu
    {
        public string Header { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        PackIconKind Icon { get;  set; }
 

        public ItemMenu(string header, List<SubItem> subItems ,PackIconKind icon)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;

        }
      
    }
}
