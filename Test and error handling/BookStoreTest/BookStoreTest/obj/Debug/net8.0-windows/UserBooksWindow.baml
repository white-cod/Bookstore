   M S B A M L   `   `   `  ����H  DBookStoreTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BookStoreTestBookStoreTest  5   	   #    BookStoreTest.UserBooksWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BookStoreTest     5   	     � Title$  
Your Books��5   	   $	��500��6   $	��725��6)    � 
ResizeMode$ NoResize=�65   .��5	      � .+�5
   
   �� -   5        $��userBooksListView��5
      $��Disabled=�6c    �� SelectionMode$ Single=�6�   $
��Left=�6�   $	��710��6�   $	��387��6�   $	��Top=�6�   $��0,24,0,0q�6�    �� View 5      �� 5      .P�5      �� $��Cover��6%    �� Width$	 100��64    �� CellTemplate 5      �� 5      .R�5   "   �� $	��100��6F   $��50��6R   ��6(   �� *
CoverImage+6R   5      5      �� 5      $��Title��6%   $	 180��6[    �� DisplayMemberBinding 64   �� *Title+6[   �� 5      $��Author��6%   $	 173��6]    65   �� *Author+6]   �� 5      $��	Publisher��6%   $	 150��6c    68   �� *	Publisher+6c   �� 5      $��
Sale Price��6%   $	 100��6d    69   �� *	SalePrice+6d   5      5      �� 5   
   -   5         ��Name$ editBookButton��5   .   $��Edit Selected Book��6   ${�False��6F   $��30��6X   $	��110��6d   $
��Left=�6�   $��Bottom=�6�   $��	10,0,0,10q�6�    J� RenderTransformOrigin$ 0.76,-12.074&�6�   �� 5   
   -   5        $ removeBookButton��5   "   $��Remove��6   ${�False��6<   $��30��6N   $	��110��6Z   $
��Left=�6�   $��Bottom=�6�   $��
125,0,0,10q�6�   $ 0.76,-12.074&�6�   �� 5   
   -   5        $ CancelButton��5   !   $��Close��6   
���z���$��30��6P   $��80��6\   $
��Left=�6g   $��Bottom=�6�   $��
620,0,0,10q�6�   $ 0.76,-12.074&�6�   6�   5      5      