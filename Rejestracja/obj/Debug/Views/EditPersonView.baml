   M S B A M L   `   `   `  ����F  BRejestracja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RejestracjaRejestracja  5      &     Rejestracja.Views.EditPersonView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Rejestracja     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  
EditPerson��5
      .��5      � .+�5   
   � $
��Left=�6   $	��419��6*   $��-93,-55,0,0q�67   $	��Top=�6L   $	��802��6d   .+�5      �� $��Wybierz OSOBE��6   $
��Left=�6,   $��342,152,0,0q�6G   $	��Top=�6\   �� 5      -   5        $��ComboBoxEdit��5      $
��Left=�6t   $��243,181,0,0q�6�   $	��Top=�6�   $	��310��6�   ��6,   �� *ComboBoxPerson+ �� SelectedIndex 6S   �� *Index+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectionChangedCommand+5      5      �� 5      $��Imie:��6   $
��Left=�6%   $��291,224,0,0q�6@   $	��Top=�6U    J� RenderTransformOrigin$ 
1.25,0.671&�6m   �� 5      -   5        $��SurnameText��5      $
��Left=�6�   $��23��6�   $��331,266,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6)   �� *	Surname+ �� ValidatesOnDataErrors . 	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5      $��	Nazwisko:��6   $
��Left=�6(   $��268,263,0,0q�6C   $	��Top=�6X   $ 
1.25,0.671&�6p   �� 5      -   5        $��NameText��5      $
��Left=�6|   $��23��6�   $��331,224,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $ 
0.145,0.64&�6�   ��6&   �� *Name+ . $	 PropertyChanged=�6�   �� 5      $��Edytuj OSOBE��6   $
��Left=�6+   $��342,106,0,0q�6F   $	��Top=�6[   �� 5      $��Wprowadz zmiany��6   $
��Left=�6U   $��301,323,0,0q�6p   $	��Top=�6�   $	��150��6�   ��6/   �� *EditPersonCommand+6�   5      5      5      