   M S B A M L   `   `   `  ����F  BRejestracja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RejestracjaRejestracja  5      *    $Rejestracja.Views.AddAppointmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Rejestracja     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  AddAppointment��5
      .��5      � .+�5   
   � $
��Left=�6   $	��450��6*   $��0,0,-2,0q�67   $	��Top=�6I   $	��802��6a   .+�5      �� $��Dodaj termin��6   $
��Left=�6V   $��307,326,0,0q�6q   $	��Top=�6�   $	��124��6�    J� RenderTransformOrigin$ 0.464,-1&�6�   ��6,   �� *AddAppointmentCommand+6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DatapickerAdd��5      $
��Left=�6N   $��307,239,0,0q�6i   $	��Top=�6~   $��44��6�   $	��129��6�      IsTodayHighlighted .    SelectedDateFormat$
 Long=�6�      SelectedDate 60   �� *Date+6�   $  MaterialDesignThemes.Wpf.Clock  5      -   5        $��ClockAdd��5   #   $
��Left=�6J   $��	0,-30,0,0q�6e   $	��Top=�6x   $	��480��6�   $	��286��6�   4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm .    	Is24Hours .    IsPostMeridiem . 	   Time	 63   �� *Time+6�   �� 5      -   5        $��ComboBoxPatient��5      $
��Left=�6~   $��307,206,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6/   �� *ComboBoxPatient+
 �� SelectedIndex
 6W   �� *IndexPatient+6�   �� 5      -   5        $��ComboBoxDoctor��5      $
��Left=�6{   $��307,153,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6.   �� *ComboBoxDoctor+
 6U   �� *IndexDoctor+6�   �� 5      $��Lekarz��6   $
��Left=�6%   $��307,131,0,0q�6@   $	��Top=�6U   $��22��6m   $��99��6y   �� 5      $��Pacjent��6   $
��Left=�6&   $��307,186,0,0q�6A   $	��Top=�6V   $��28��6n   $��99��6z   �� 5      $
��Data��6   $
��Left=�6#   $��307,239,0,0q�6>   $	��Top=�6S   $��38��6k   $��99��6w   5      5      5      