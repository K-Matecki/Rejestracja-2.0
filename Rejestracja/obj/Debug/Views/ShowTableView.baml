   M S B A M L   `   `   `  ����F  BRejestracja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RejestracjaRejestracja  5      +    %Rejestracja.Views.ShowPersonTableView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Rejestracja     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  	ShowTable��5
      .��5   
   � .+�5   
   � $
��Left=�6   $	��419��6*   $��	-2,10,0,0q�67   $	��Top=�6J   $	��802��6b   .+�5      �� $��Wybierz��6   $
��Left=�6&   $��
267,85,0,0q�6A   $	��Top=�6U   $��39��6m    J� RenderTransformOrigin$ 0.5,0.5&�6y   $	��230��6�   &   System.Windows.Controls.DataGrid  5      -   5        $��AppointmentsTableDoctor��5         AutoGenerateColumns .  $��135,271,265,24q�6�      
IsReadOnly .    CanUserSortColumns .     CanUserAddRows .  ��66   �� *AppointmentList+y�6^   �� *ShouldBeVisible[0]+    BooleanToVisibilityConverter �� 	Converter# [     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Termin��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� 
 �� Path$
 AppointmentDate�  5      $ Imie i nazwisko pacjenta��6)   	 6K   �� *PatientFullName+5        5      -   5        $��AppointmentsTablePatient��5       .  $��135,271,265,24q�6�    .  .   .  ��67   �� *AppointmentList+y�6_   �� *ShouldBeVisible[1]+# [   5        5      $ Imie i nazwisko Lekarza��6)   	 6J   �� *DoctorFullName+  5      $ Termin��6)   	 69   �� $
 AppointmentDate�5      �� 5      -   5        $��ComboBoxShow��5      $
��Left=�6~   $��135,132,0,0q�6�   $	��Top=�6�   $	��382��6�   ��6+   �� *ComboBoxPerson+ �� SelectedIndex 6R   �� *Index+ �� Mode$ TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5       /  )System.Windows.Interactivity.EventTrigger  5!         	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5"      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *SelectionChangedCommand+5#      5%        5&      -   5        $��PersonTable��5&       .  $��135,180,285,153q�6n    .  .   .  ��6*   �� *SelectedPerson+ 5'        5(      $
 Imie��6)   	 67   �� $

 Name�  5)      $ Nazwisko��6)   	 6;   �� $
 Surname�  5*      $ Pesel��6)   	 68   �� $
 Pesel�  5+      $
 Wiek��6)   	 67   �� $	
 Age�  5,      $ Płeć��6)   	 67   �� $	
 Sex�5.      5/      50      51      