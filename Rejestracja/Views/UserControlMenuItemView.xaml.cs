using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Rejestracja.ViewModels;

namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        PackIconKind Icon;
        MainWindow _context;
        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();
            _context=context;
            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;
            this.DataContext = itemMenu;
            Icon = itemMenu.Icon;
        }
      
        private void ListViewMenuSelection(object sender, SelectionChangedEventArgs args)
        {
            int SelectedId = ((SubItem)((ListView)sender).SelectedItem).IdSubItem;
            _context.SwitchScreen(SelectedId);
        }
    }
}
