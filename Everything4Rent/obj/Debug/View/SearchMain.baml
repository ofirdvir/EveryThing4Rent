   M S B A M L   `   `   `  ����J  FEverything4Rent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Everything4Rent.ViewEverything4Rent.View  5   	   %    Everything4Rent.View.SearchMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Everything4Rent.View     5   	     � Title$  	SeachMail��5   	   $	��350��6   $	��300��6(   .��5	      � -   5         �Name$ MyGrid��5	      ��5
   
   �� 5       �� ImageSource$D >pack://application:,,,/Everything4Rent;component/backround.jpg��6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��20(�62   $��2��6@   Search6]   �� 5    
   $��1��6   Choose Type6.   �� 5!   
   -   5         ��Name$ 	TypeCombo��5!      $��1��6&   $��1��63    �� SelectedIndex$ 0��6D   $	��120��6V   $��30��6c   .@�5"      �� .��6   Items6"   �� 5#      .��6   	Package6$   5$      �� 5&   
   $��2��6   Choose Action60   �� 5'   
   -   5        $ ActionCombo��5'      $��2��6(   $��1��65   $��30��6E   $ 0��6R   $	��120��6d   .@�5(      �� .��6   Rent6!   �� 5)      .��6   
Exchange6%   �� 5*      .��6   
Donation6%   5,      �� 5.   
   -   5         ��Name$ titleCat��5.      $��3��6&   Choose Category6D   �� 5/   
   -   5        $ CategoryCombo��5/      $��3��6*   $��1��67   $ 0��6H   $��30��6Z   $	��120��6f   .@�50      �� .��6   	Vehicle6$   �� 51      .��6   Second Hand6(   �� 52      .��6   Real Estate6(   �� 53      .��6   Pet6    54      �� 56   
   $��4��6   
Start Date6-   (  "System.Windows.Controls.DatePicker  57   
   -   5          Name$ 	DateStart��57      $��4��6(   $��1��65   $	��120��6F   $��30��6R   6`   �� 59   
   $��5��6   
End Date6+     5:   
   -   5        $ DateEnd��5:      $��5��6&   $��1��63   $	��120��6D   $��30��6P   6^   �� 5<   
   -   5        	 ��Name$	 Search��5<      $��6��66   $��0��6C   $��Center=�6S   $��2��6q   $��Search��6�   
�������$��12(�6�      GlassButton#���   6�   $��0q�6�   $	��Top=�6�   $	��150��6  $��30��6  5=      �� 5@   
   -	   5        $	 AdvancedSearch��5@      $��7��6F   $��0��6S   $��Center=�6c   $��2��6�   $��Advanced Search��6�   
�������$��12(�6�   #���   6�   $��0q�6�   $	��Top=�6  $	��150��6$  $��30��60  5A      5C      5D      