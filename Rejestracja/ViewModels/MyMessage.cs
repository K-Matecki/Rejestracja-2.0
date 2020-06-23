using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rejestracja.ViewModels
{
    public class MyMessage
    {
        public string MessageText { get; set; }
         

        static public void ProcessMessage(MyMessage message)
        {
            MessageBox.Show(message.MessageText);
        }

    }
}
