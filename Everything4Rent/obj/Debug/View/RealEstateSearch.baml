   M S B A M L   `   `   `  ����J  FEverything4Rent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Everything4Rent.ViewEverything4Rent.View  5   	   +    %Everything4Rent.View.RealEstateSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Everything4Rent.View     5   	     � Title$  RealEstateSearch��5   	   $	��300��6"   $	��300��6/   .��5	      � -   5         �Name$ MyGrid��5	      ��5
   
   �� 5       �� ImageSource$D >pack://application:,,,/Everything4Rent;component/backround.jpg��6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��20(�61   $��2��6?   $��Center=�6S   $
��Bold"�6n   Real Estate Search6�   �� 5!   
   -   5         ��Name$ txtCost��5!      $y�	Collapsed=�6%   $��1��6<   $
��Left=�6I   $��Center=�6e   $��10,0,0,0q�6�   $��2��6�   $��16��6�   $	��134��6�   
Max Cost6�   �� 5"   
   -   5        $ txtPatioalCost��5"      $��1��6,   $y�	Collapsed=�69   $
��Left=�6Q   $��Center=�6m   $��10,0,0,0q�6�   $��2��6�   $��16��6�   $	��134��6�   Max Patioal Cost6�   �� 5#   
   -   5        $ 
txtDeposit��5#      $��1��6(   $y�	Collapsed=�65   $
��Left=�6M   $��Center=�6i   $��10,0,0,0q�6�   $��2��6�   $��16��6�   $	��134��6�   Max Deposit6�   �� 5&   
   -   5         ��Name$ priceAllCatecories��5&      $
��1000��6.    �� TextAlignment$ Center=�6:   
���   �$��0,0,0,1q�6e   
������ $��1��6�   $��1��6�   $��32��6�   $	��120��6�   6�   �� 5(   
   $��2��6   $
��Left=�6#   $��Center=�6?   $��10,0,0,0q�6Z   $��2��6l   $��16��6�   $	��134��6�   City6�   �� 5+   
   -   5        $
 city��5+      
���   �$��0,0,0,1q�64   
������ $��2��6i   $��1��6v   $��32��6�   $ Center=�6�   $	��120��6�   $��Netanya��6�   6�   �� 5.   
   $��3��6   $
��Left=�6#   $��Center=�6?   $��10,0,0,0q�6Z   $��2��6l   $��16��6�   $	��134��6�   Size in meter6�   �� 5/   
   -   5        $
 size��5/      
���   �$��0,0,0,1q�64   
������ $��3��6i   $��1��6v   $��32��6�   $ Center=�6�   $	��120��6�   $	��200��6�   6�   �� 51   
   $��4��6   $
��Left=�6#   $��Center=�6?   $��10,0,0,0q�6Z   $��2��6l   $��16��6�   $	��134��6�   Type6�   �� 52   
   -   5        $
 type��52      
���   �$��0,0,0,1q�64   
������ $��4��6i   $��1��6v   $��32��6�   $ Center=�6�   $	��120��6�   $��Villa��6�   6�   �� 53   
   -	   5         ��Name$ Search��53      $��5��68   $��0��6E   $��Center=�6U   $��2��6s   $��Search��6�   
�������$��12(�6�      GlassButton#���   6�   $��0q�6�   $	��Top=�6�   $	��150��6  $��30��6  54      57      58      