   M S B A M L   `   `   `  ����N  JQuyenND_SE1813_AS01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuyenND_SE1813_AS01QuyenND_SE1813_AS01  5   	   $    QuyenND_SE1813_AS01.RoomsPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:QuyenND_SE1813_AS01     5   	     � Title$  
RoomsPopup��5   	   $	��350��6   $	��700��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��5* �6   �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      � $��0��6    5      �� 5      �� 5      �� 5      �� 5      .+�5      � $��0��6    5      �� 5      $
��0.5* �6+   �� 5      .+�5      �� $	��ID:��6    $��0��6+   $��13(�5    %   $��Center=�5!      $��10 0 0 0q�5"      �� 5#      -   5         ��Name$ 	txtRoomId��5#      $��1��61   $��10 15q�6A    �� 
IsReadOnly$
 True��6P   5$      � 5%      $��1��6    5&      �� 5'      $
��0.5* �6+   �� 5(      .+�5*      �� $��RoomNumber:��6    $��0��63   $��13(�5+      $��Center=�5,   
   $��10 0 0 0q�5-      �� 5.      -   5        $ txtRoomNumber��5.      $��1��65   $��10 15q�6E   5/      � 50      $��2��6    51      �� 52      $
��0.5* �6+   �� 53      .+�55      �� $��Description:��6    $��0��64   $��13(�56      $��Center=�57      $��10 0 0 0q�58      �� 59      -   5        $ txtRoomDescription��59      $��1��6:   $��10 15q�6J   5:      � 5;      $��3��6    5<      �� 5=      $
��0.5* �6+   �� 5>      .+�5@      �� $��MaxCapacity:��6    $��0��64   $��13(�5A      $��Center=�5B      $��10 0 0 0q�5C      �� 5D      -   5        $ txtRoomMaxCapacity��5D      $��1��6:   $��10 15q�6J   5E      5F      � 5G      $��1��6    5H      �� 5I      �� 5J      �� 5K      �� 5L      .+�5N      � $��0��6    5O      �� 5P      $
��0.5* �6+   �� 5Q      .+�5S      �� $��
RoomPrice:��6    $��0��62   $��13(�5T      $��Center=�5U      $��10 0 0 0q�5V      �� 5W      -   5        $ txtRoomPrice��5W      $��1��64   $��10 15q�6D   5X      � 5Y      $��1��6    5Z      �� 5[      $
��0.5* �6+   �� 5\      .+�5^      �� $��RoomTypeID:��6    $��0��63   $��13(�5_      $��Center=�5`      $��10 0 0 0q�5a      �� 5b      -   5         ��Name$ cbRoomTypeID��5b      $��1��5c      $��10 15q�6   6    5d      � 5e      $��2��6    5f      �� 5g      $
��0.5* �6+   �� 5h      .+�5j      �� $��	RoomType:��6    $��0��61   $��13(�5k      $��Center=�5l      $��10 0 0 0q�5m      �� 5n      -   5        $ 
cbRoomType��5n      $��1��5o   
   $��10 15q�6   6)   5p      5q      5r      � 5s   
   $��1��6   .+�5t      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5u      �� -   5         ��Name$ 
btnAddRoom��5u      $	��Add��6-   $��5q�6;   $��80��6F   6m   �� 5v      -	   5        $ btnBackRoom��5v      $
��Back��6.   $��5q�6=   $��80��6H   6p   5w      5x      5y      5z      