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
    /// Logika interakcji dla klasy EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Page
    {
        public EditAppointment()
        {
            InitializeComponent();
            DatapickerEdit.BlackoutDates.AddDatesInPast();
         //DatapickerAdd.BlackoutDates.Add(new CalendarDateRange(Start,End)); //end data wizyty -1  start-DateTime.Now.AddDays(-1)
        }
    }
}
