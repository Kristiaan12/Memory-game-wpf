   M S B A M L   `   `   `  ����J  FMemory game WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Memory_game_WPFMemory_game_WPF  5   	        Memory_game_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Memory_game_WPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5         �Name$ GameGrid��5	       � ColumnDefinitions 5
   
   �� 5      $��6* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   � -   5        $ 	Speelveld��5      $��0��6#   5      � 5   
   -   5        $ Gridcol1��5      $��1��6!    � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��8* �6    .+�5      �� -   5         ��Name$ 
LblSpeler1��5      $
��Naam��6(   $��0��67   �� 5      -   5        $ 	LblTijdP1��5      $
��Tijd��6'   $��1��66   �� 5      -   5        $ 
LblScorep1��5      $��Score:��6(   $��2��69   5      � 5   
   -   5        $ Gridcol2��5      $��2��6!    5      �� 5      -   5         ��Name$
 Row1��5       �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+      �� -	   5        $ 
LblSpeler2��5+      $
��Naam��6(   $��0��67   �� 5,      -
   5        $ 	LblTijdP2��5,      $
��Tijd��6'   $��1��66    � BindingGroup 5-      &   System.Windows.Data.BindingGroup  5.      50      �� 51      -   5        $ 
LblScorep2��51      $��Score:��6(   $��2��69   �� 52      -   5         ��Name$ 	Btn_Start��52      $��Start��6(   $��4��68   6E   �� 53      $��Pauze��6   $��5��6%   �� 54      $��Reset��6   $��6��6%   55      56      57      