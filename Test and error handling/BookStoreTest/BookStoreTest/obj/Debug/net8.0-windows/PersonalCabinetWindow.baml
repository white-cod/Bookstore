   M S B A M L   `   `   `  ����H  DBookStoreTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BookStoreTestBookStoreTest  5   	   )    #BookStoreTest.PersonalCabinetWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BookStoreTest     5   	     � Title$  PersonalCabinetWindow��5   	   $	��450��6'   $	��800��64    � 
ResizeMode$ NoResize=�6@   .��5	      � .+�5
   
   �� $'��!Welcome to Your Personal Cabinet!��6   $��16(�6<   $
��Bold"�6J   $��0,10,0,0q�6\   $��32��6n   $	��Top=�6z   $��Center=�6�   $	��280��6�   �� 5   
   -   5         ��Name$ avatarImage��5      $
��Fill=�6%   $��
20,0,0,165q�64   $	��210��6H   $��Bottom=�6U   $
��Left=�6p   $	��210��6�   5      �� 5   
   -   5        $��Change��5      $��
20,0,0,132q�6C   $��28��6W   $��Bottom=�6c   $
��Left=�6~   $��79��6�   �� 5   
   $��Account name: ��6   $��260,0,438,346q�6*   $
��Wrap=�6A   $��Bottom=�6U   �� 5   
   -   5         ��Name$ usernameTextBox��5       �� 
IsReadOnly$
 True��6+   $��347,0,0,344q�6=   $��18��6R   $��Bottom=�6^   $
��Left=�6y   $	��320��6�   �� 5   
   $��Email:��6   $��260,0,0,305q�6"   $
��Left=�67   $��35��6R   $��18��6]   $��Bottom=�6i   �� 5   
   -   5        $ editEmailTextBox��5      $��300,0,0,305q�6N   $
��Left=�6c   $	��320��6~   $��18��6�   $��Bottom=�6�   �� 5   
   $��	Nickname:��6   $��18��6%   $��260,0,0,265q�61   $��Bottom=�6F   $
��Left=�6a   $��61��6|   �� 5   
   -   5        $ editNicknameTextBox��5      $��326,0,0,265q�6Q   $
��Left=�6f   $	��320��6�   $��18��6�   $��Bottom=�6�   �� 5   
   $��Name:��6   $��18��6!   $��260,0,0,225q�6-   $��Bottom=�6B   $
��Left=�6]   $��40��6x   �� 5   
   -   5        $ editNameTextBox��5      $��305,0,0,225q�6M   $
��Left=�6b   $	��320��6}   $��18��6�   $��Bottom=�6�   �� 5   
   $��Date of Birth:��6   $��18��6*   $��260,0,0,185q�66   $��Bottom=�6K   $
��Left=�6f   $��74��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ editDateOfBirthDatePicker��5      $��25��68   $��	0,0,0,181q�6D   $��Bottom=�6W   $��Center=�6r   $	��120��6�   �� 5!   
   -   5         ��Name$ 
SaveButton��5!       $
��Save��6   ${�False��6M   $��
611,0,0,10q�6_   $
��Left=�6s   $��80��6�   $��26��6�   $��Bottom=�6�   �� 5"   
   -	   5        $��Cancel��5"      $��
696,0,0,10q�6A   $��26��6U   $��Bottom=�6a   $
��Left=�6|   $��80��6�   5$      5%      