   M S B A M L   `   `   `  ����J  FEverything4Rent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Everything4Rent.ViewEverything4Rent.View  5   	   *    $Everything4Rent.View.Item_Operations   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Everything4Rent.View     5   	     � Title$  Item_Operations��5   	   $	��300��6!   $	��300��6.   .��5	      � ��5
   
   �� 5       �� ImageSource$D >pack://application:,,,/Everything4Rent;component/backround.jpg��6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      $��50 �6   �� 5      �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$
 Tile��5      $��0��6#   $��Center=�60   $
��Bold"�6K   $��	AR BLANCA)�6]   $��20(�6t   $��Center=�6�   $��2��6�   Item Operations6�   �� 5   
   -   5        $ duration��5      $��15(�6&   $��1��64   $
��Left=�6A   $��Center=�6]   $��10,6,0,0q�6x   $��41��6�   $
��Wrap=�6�   Choose Item to Delete6�   �� 5   
   -   5         ��Name$ Delete��5      $��2��67   $��1��6D   $��40��6T   $	��100��6`   $��15(�6l      GlassButton#���   6|   .��6�   Delete Item6�   �� 5   
   -   5         ��Name$ comboDelete��5      $��1��6(   $��1��65   $��30��6E   $	��100��6Q   6_   �� 5    
   -   5        $
 show��5       $��15(�6"   $��3��60   $
��Left=�6=   $��Center=�6Y   $
��Wrap=�6t   $��	10,0,0,10q�6�   $	��134��6�    Choose Item to Show and Update6�   �� 5!   
   -   5        $
 Show��5!      $��4��6   $��1��6@   $��40��6P   $	��100��6\   $��15(�6h   #���   6x   .��6�   	Show Item6�   �� 5"   
   -   5        $ showItem��5"      $��3��6&   $��1��63   $��30��6C   $	��100��6O   6]   5$      5%      