   M S B A M L   `   `   `  ����J  FEverything4Rent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Everything4Rent.ViewEverything4Rent.View  5   	   +    %Everything4Rent.View.SecondHandSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Everything4Rent.View     5   	     � Title$  SecondHandSearch��5   	   $	��300��6"   $	��300��6/   .��5
      � -   5         �Name$ MyGrid��5
      ��5   
   �� 5       �� ImageSource$D >pack://application:,,,/Everything4Rent;component/backround.jpg��6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��20(�61   $��2��6?   $��Center=�6S   $
��Bold"�6n   Second Hand Search6�   �� 5    
   -   5         ��Name$ txtCost��5       $y�	Collapsed=�6%   $��1��6<   $
��Left=�6I   $��Center=�6e   $��10,0,0,0q�6�   $��2��6�   $��16��6�   $	��134��6�   
Max Cost6�   �� 5!   
   -   5        $ txtPatioalCost��5!      $��1��6,   $y�	Collapsed=�69   $
��Left=�6Q   $��Center=�6m   $��10,0,0,0q�6�   $��2��6�   $��16��6�   $	��134��6�   Max Patioal Cost6�   �� 5"   
   -   5        $ 
txtDeposit��5"      $��1��6(   $y�	Collapsed=�65   $
��Left=�6M   $��Center=�6i   $��10,0,0,0q�6�   $��2��6�   $��16��6�   $	��134��6�   Max Deposit6�   �� 5#   
   -   5         ��Name$ priceAllCatecories��5#      $
��1000��6.    �� TextAlignment$ Center=�6:   
���   �$��0,0,0,1q�6e   
������ $��1��6�   $��1��6�   $��32��6�   $	��120��6�   6�   �� 5%   
   -   5        $ txtPurchace��5%      $��2��6)   $
��Left=�68   $��Center=�6T   $��10,0,0,0q�6o   $��16��6�   $	��134��6�   Purchase Date6�   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ purchaseDate��5&      $��2��6,   $��1��69   $	��120��6I   $��Center=�6U   6r   �� 5(   
   $��3��6   $
��Left=�6$   $��Center=�6@   $��10,0,0,0q�6[   $��16��6m   $	��134��6y   	Quality6�   �� 5)   
   -   5        	 ��Name$	 
typQuality��5)      $��1��5*      $��Center=�5+      $��3��5,      $	��120��5-      $��28��6   $��Center=�5.      
 �� SelectedIndex$
 0��5/      .@�50      �� .��6   
Like New6%   �� 51      .��6   
New in Box6'   �� 52      .��6   Used6!   �� 53      .��6   Needed repair6*   �� 54      .��6   	Irelevant6&   55      �� 56   
   $��4��6   $
��Left=�6$   $��Center=�6@   $��10,0,0,0q�6[   $��16��6m   $	��134��6y   Type6�   �� 57   
   -	   5        $	 typType��57      $��1��58      $��Center=�59      $��4��5:      $	��120��5;      $��28��6   $��Center=�5<      $
 0��5=      .@�5>      �� .��6   
Electrical6'   �� 5?      .��6   	Furniture6&   �� 5@      .��6   Sport6"   �� 5A      .��6   Graden6#   �� 5B      .��6   	Furniture6&   �� 5C      .��6   
Cellular6%   �� 5D      .��6   Other6"   5E      �� 5G   
   -
   5         ��Name$ Search��5G      $��5��66   $��0��6C   $��Center=�6S   $��2��6q   $��Search��6�   
�������$��12(�6�      GlassButton#���   6�   $��0q�6�   $	��Top=�6�   $	��150��6  $��30��6  5H      5K      5L      