   M S B A M L   `   `   `  ����D  @BookShelf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShelf.MVVM.ViewBookShelf.MVVM.View  5      '    !BookShelf.MVVM.View.BooksListView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:BookShelf.MVVM.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��Search results��6   $��36(�5      $��/Files/Fonts/INTER/#Inter)�5      $��SemiBold"�5      $��Center=�5      $
��Left=�5      $��0��5      $��50,0,0,0q�5      �� 5   
   $��Center=�6   $��Center=�5      $	��630��5      $
��1200��5      $��1��5      ��5      �� *SearchedBooks+��5      �� 5        �� 
TargetType" ��6   .�5!      ��  �� Property � �� �� Value 5"      �� 5#       �� 
TargetType" ��6.   .R�5$   "   �� #��z��6)   ._�5%   &   �� 5&   #   5'      5)      -   5        5+      ��5.      �� 5/       �� DataType$ ListBoxItem��6   .R�50      � $
��1200��6   $	��170��51      $��3,0,3,0q�52       � Cursor$
 Hand��53      ��55      �� 56      " �6$   .�57   "   ��  � �� �#adadad6?    �� Triggers 58   "   P� 59   &    P� Property �@J�IsMouseOver	 P� Value$
	 True��6E   . �5:   *   ��  � ��
 �����6G   5;   '   5=      
 � ColumnDefinitions
 5@      �� 5A      $	��200 �6/   �� 5B      .+�5E      �� $	��150��5F       $	��150��5G       $
��Left=�5H       $��Center=�5I       $��30,5,5,5q�5J       ��5E       �� *cover+5J       �� 5L      $
��Wrap=�5M   $   $��30(�5N   $   $��/Files/Fonts/INTER/#Inter)�5O   $   $
��Bold"�5P   $   $
��Left=�5Q   $   $	��Top=�5R   $   $	��100��5S   $   $��1��5T   $   $��5q�5U   $   ��5L   $   �� *title+5U   $   �� 5W      $
��Wrap=�5X   $   $��20(�5Y   $   $��SemiBold"�5Z   $   $��/Files/Fonts/INTER/#Inter)�5[   $   $
��Left=�5\   $   $��Bottom=�5]   $   $��1��5^   $   $��40��5_   $   $��5q�5`   $   ��5W   $   �� *
sale_price+5`   $   �� 5b      $
��Wrap=�5c   $   $��20(�5d   $   $��Medium"�5e   $   $��/Files/Fonts/INTER/#Inter)�5f   $   $
��Left=�5g   $   $��Center=�5h   $   $��1��5i   $   $��40��5j   $   $��5q�5k   $   ��5b   $   �� *author+5k   $   5l      5m      5o      5p      5q      