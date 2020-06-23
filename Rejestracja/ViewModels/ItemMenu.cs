using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace Rejestracja.ViewModels

{
    public class ItemMenu
    {
        public string Header { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public PackIconKind Icon { get; set; }


        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;

        }

    }
}
