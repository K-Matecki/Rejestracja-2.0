﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rejestracja
{
    /// <summary>
    /// Logika interakcji dla klasy RemovePerson.xaml
    /// </summary>
    public partial class PRemove : Page
    {
        
        private int Menu;
        public PRemove()
        {
            InitializeComponent();
          
        }
        public PRemove(int MenuID):this()
        {
            Menu = MenuID;
            UpdateComboBoxRemove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(DataBase.PersonList[ComboBoxRemove.SelectedIndex].Remove())
            MessageBox.Show($"Usunięto {DataBase.PersonList[ComboBoxRemove.SelectedIndex].Name}");
           // DataBase.PersonList.Remove(DataBase.PersonList[ComboBoxRemove.SelectedIndex]);
            UpdateComboBoxRemove();
        }
        private void UpdateComboBoxRemove()
        {
            
            ComboBoxRemove.ItemsSource = DataBase.GetComboBoxList(Menu);
        }
    }
}
