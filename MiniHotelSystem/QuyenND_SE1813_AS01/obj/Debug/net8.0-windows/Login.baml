   M S B A M L   `   `   `  ����N  JQuyenND_SE1813_AS01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLyQuanBiaQuanLyQuanBia  5   	       QuanLyQuanBia.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLyQuanBia     5   	     � Title$  Login��5   	   $	��300��6   $	��350��6$   .��5	      � $��	10,10,0,0q�6    � RowDefinitions 5
   
   �� 5      $��0* �6   �� 5      $
��Auto �6   $	��275��6*   �� 5      $
��Auto �6   $��0��6*   �� 5      $
��Auto �6   $��0��6*   �� 5      $
��Auto �6   $��0��6*   �� 5      $��0* �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $
��Auto �6   �� 5      $��0* �6   �� 5      �� 5      $��0* �6   .+�5   
   �� $��3��6   $��Center=�6%   $��Center=�6@   $	��250��6]   $	��252��6i   $��1��6v   .+�5      �� $��Hotel Management��6   $��Center=�60   $��Center=�6K   $��0,0,0,5q�6h   $��25(�6y   $
��Bold"�5      
���  ��6$   �� 5       �� Orientation$ Vertical=�6   .+�5      �� $��Email:��6   $��Center=�6*   $
��Left=�6E   $��0,0,0,5q�6`   �� 5       -   5         ��Name$ txtEmail��5       $	��215��6,   $��30��68   $��Center=�6D   $
��Left=�6_   $��0,0,0,10q�6z   �� 5"      $��	Password:��6   $��Center=�6-   $
��Left=�6H   $��0,0,0,5q�6c   G� 5#      -   5         G�Name$ txtPassword��5#      $	��215��63   $��30��6?   $��Center=�6K   $
��Left=�6f   $��0,0,0,10q�6�   �� 5%      $ 
Horizontal=�6   $��Center=�66   $��	0,20,40,0q�6S   $	��220��6f   .+�5&      �� -   5         ��Name$ btnLogin��5&      $��Login��6/   $	��100��6?   $��30��6K   $��5q�6W   6b   �� 5'      -   5        $ btnExit��5'      $
��Exit��6.   $	��100��6=   $��30��6I   $��5q�6U   6`   5(      5)      5*      5+      5,      