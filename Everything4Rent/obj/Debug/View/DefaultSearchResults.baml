   M S B A M L   `   `   `  ����J  FEverything4Rent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Everything4Rent.ViewEverything4Rent.View  5   	   /    )Everything4Rent.View.DefaultSearchResults   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Everything4Rent.View     5   	     � Title$  DefaultSearchResults��5   	   $	��490��6&   $	��300��63   .��5	      � -   5         �Name$ MyGrid��5	      ��5
   
   �� 5       �� ImageSource$D >pack://application:,,,/Everything4Rent;component/backround.jpg��6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��200 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   �� $��Center=�6   $
��Bold"�61   $��20(�6C   $��2��6Q   Search Results6v   �� 5   
   -   5         ��Name$ ChosenItemsForPackage��5      $��Center=�5      $	��200��5      $��Center=�5      $��1��5       $��2��5!      $	��200��5"      
�������$��1��65   ��5#      �� 5$      .R�5%      ��  �� Orientation$ 
Horizontal=�6!   .+�5&      �� ��6$   �� 5'      5(      5*      � 5+   
   -   5        $ borrow��5+      $��4��6   $��2��60   $��2��6=    5,      �� 5-      6%   �� 5.      6%    50      �� 51      $��50 �6    �� 52      $��50 �6!   �� 53      $��50 �6    �� 54      $��50 �6    .+�57      �� -   5         ��Name$ ItemToBorrow��57      $y�	Collapsed=�6.   $��0��6E   $
��Left=�6R   $��Center=�6n   $��2��6�   $��16��6�   $	��134��6�   Choose Item to Borrow6�   �� 59      -   5         ��Name$ ItemsToBorrowCombo��59      $��1��5:      $��0��5;      $��Center=�5<      $��32��5=      $��Center=�5>      $��96��5?      $y�	Collapsed=�5@      	 �� SelectedIndex$	 0��5A      5B      �� 5D      -   5        $ ItemsToChange��5D      $��0��61   $
��Left=�6>   $��Center=�6Y   $��2��6t   $��16��6�   $	��134��6�   Choose Item to Trade6�   �� 5F      -   5        $ ItemsToChangeCombo��5F      $��1��5G      $��0��5H      $��Center=�5I      $��32��5J      $��Center=�5K      $��96��5L      $	 0��5M      5N      �� 5R      $��1��6   $��0��6"   
Start Date6>   (  "System.Windows.Controls.DatePicker  5S   
   -   5        
  Name$
 	DateStart��5S      $��1��6(   $	��Top=�65   $��1��6N   $	��120��6_   $��30��6k   6y   �� 5U   
   $��2��6   
End Date6+     5V   
   -	   5        $
 DateEnd��5V      $	��Top=�6&   $��2��6>   $��1��6K   $	��120��6\   $��30��6h   6v   �� 5Y   
   -
   5         ��Name$ Borrow��5Y      $��3��66   $��0��6C   $��Center=�6S   $��2��6q   $��Borrow��6�   
�������$��12(�6�      GlassButton#���   6�   $��0q�6�   $	��Top=�6�   $	��150��6  $��30��6  5Z      5[      5\      5]      