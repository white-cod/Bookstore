   M S B A M L   `   `   `  ����H  DBookStoreTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BookStoreTestBookStoreTest  5   	   !    BookStoreTest.AddBookWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BookStoreTest     5   	     � Title$  Add Book��5   	   $	��600��6   $	��650��6'    � 
ResizeMode$ NoResize=�63   .��5	      � .+�5
   
   �� -   5         ��Name$ highlightingTextBox1��5
      $
��Left=�60   $	��Top=�6K   $��
294,65,0,0q�6c   $	��330��6w   $	��340��6�    �� TextWrapping$
 Wrap=�6�   ${�False��6�    �� 
IsReadOnly$
 True��6�   �� 5   
   $��Add Your Book��6   $
��Bold"�6)   $��16(�6;   $��0,10,0,0q�6I   $��23��6[   $	��Top=�6g   $��Center=�6   $	��118��6�   �� 5   
   $��
304,71,0,0q�6   $	��333��6)   $	��Top=�66   $
��Left=�6N   $	��310��6i   .+�5      �� $��Title:��6   �� 5      -   5        $ titleTextBox��5      $��0,0,0,10q�6,   �� 5      $��
Publisher:��6   �� 5      -   5        $ publisherTextBox��5      $��0,0,0,10q�60   �� 5      $��Pages:��6   �� 5      -   5        $ pagesTextBox��5      $��0,0,0,10q�6,   �� 5      $��Genre:��6   �� 5      -   5        $ genreTextBox��5      $��0,0,0,10q�6,   �� 5      $��Cost Price:��6   �� 5      -   5        $ costPriceTextBox��5      $��0,0,0,10q�60   �� 5      $��Sale Price:��6   �� 5      -   5        $ salePriceTextBox��5      $��0,0,0,10q�60   5!      �� 5#   
   -   5        $ highlightingTextBox4��5#      $
��Left=�60   $	��Top=�6K   $��8,65,0,0q�6c   $	��270��6u   $	��400��6�   $
 Wrap=�6�   $
 True��6�   ${�False��6�   �� 5$   
   -	   5         ��Name$ 
coverImage��5$      $
��Fill=�6$   $	��350��63   $	��Top=�6@   $
��Left=�6X   $	��250��6s   $��0��6   $��	18,81,0,0q�6�   �� 5%   
   -
   5        $��Change��5%      $��/Files/Fonts/INTER/#Inter)�6"   $��
18,440,0,0q�6i   $	��Top=�6}   $
��Left=�6�   $��20��6�   $��60��6�    J� RenderTransformOrigin$ 0.452,-0.646&�6�   �� 5&   
   -   5        $ coverPathTextBox��5&      $
 True��6,   $��
83,440,0,0q�6>   $��20��6R   $	��Top=�6^   $
��Left=�6v   $	��187��6�   �� 5(   
   -   5        $ bookSummaryPathTextBox��5(      $
 True��62   $��414,440,0,0q�6D   $��24��6Y   $	��Top=�6e   $
��Left=�6}   $	��210��6�   �� 5)   
   -   5        $��Select Description��5)      $��294,440,0,0q�6P   $��24��6e   $	��Top=�6q   $
��Left=�6�   $	��115��6�   �� 5+   
   -   5         ��Name$ addBookButton��5+   6   $��Add Book��6   ${�False��6$   
������$	��100��6�   $��30��6�   $��419,513,0,0q�6�   $	��Top=�6�   $
��Left=�6�   �� 5,   
   -   5        $ CancelButton��5,   "   $��Cancel��6   
���z���$	��100��6l   $��30��6x   $��524,513,0,0q�6�   $	��Top=�6�   $
��Left=�6�   5-      5.      