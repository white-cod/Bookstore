   M S B A M L   `   `   `  ����H  DBookStoreTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BookStoreTestBookStoreTest  5   	   )    #BookStoreTest.PersonalCabinetWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BookStoreTest     5   	     � Title$  PersonalCabinetWindow��5   	   $	��450��6'   $	��800��64    � 
ResizeMode$ NoResize=�6@   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��250 �6   �� 5      .+�5   
   �� $'��!Welcome to Your Personal Cabinet!��6   $��16(�6<   $
��Bold"�6J   $��/Files/Fonts/INTER/#Inter)�6\   $��0,10,0,0q�6�   $��32��6�   $	��Top=�6�   $��Center=�6�   $	��280��6�   $��2��6�   �� 5   
   -   5         ��Name$ highlightingTextBox4��5      $
��Left=�60   $��Bottom=�6K   $��	10,0,0,81q�6f   $	��230��6y   $	��268��6�    �� TextWrapping$
 Wrap=�6�    �� 
IsReadOnly$
 True��6�   ${�False��6�   �� 5   
   -   5         ��Name$ avatarImage��5      $
��Fill=�6%   $	��220��64   $��Center=�6A   $��Center=�6\   $	��220��6y   $��0��6�   $��0,0,0,50q�6�   �� 5   
   -   5        $��Change��5      $��/Files/Fonts/INTER/#Inter)�6"   $��
0,0,160,90q�6j   $��Bottom=�6~   $��Center=�6�   $��20��6�   $��60��6�   �� 5   
   -   5        $ highlightingTextBox1��5      $
��Left=�60   $��Bottom=�6K   $��
10,0,0,199q�6f   $	��470��6z   $	��150��6�   $
 Wrap=�6�   ${�False��6�   $
 True��6�   $��1��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��5   	   $	��470��5   	   $	��138��5   	   $	��Top=�5   	   $
��Left=�5   	   $��	10,69,0,0q�6$   .+�5      �� $ Vertical=�6   .+�5      �� $��/Files/Fonts/INTER/#Inter)�6   $��Account name:��6C   $��	10,10,5,0q�6X   �� 5      $��/Files/Fonts/INTER/#Inter)�6   $��Email:��6C   $��	10,10,5,0q�6R   �� 5       $��/Files/Fonts/INTER/#Inter)�6   $��	Nickname:��6C   $��	10,10,5,0q�6T   �� 5!      $��/Files/Fonts/INTER/#Inter)�6   $��Name:��6C   $��	10,10,5,0q�6P   �� 5"      $��/Files/Fonts/INTER/#Inter)�6   $��Date of Birth:��6C   $��	10,10,5,0q�6Y   5#      �� 5%      $ Vertical=�6   .+�5&      �� -   5        $ usernameTextBox��5&      $��/Files/Fonts/INTER/#Inter)�63   $��10,8,0,0q�6Z   $
 True��6l   $	��350��6~   �� 5'      -   5        $ editEmailTextBox��5'      $��/Files/Fonts/INTER/#Inter)�64   $��10,8,0,0q�6}   $	��350��6�   �� 5(      -   5        $ editNicknameTextBox��5(      $��/Files/Fonts/INTER/#Inter)�67   $��10,8,0,0q�6�   $	��350��6�   �� 5)      -   5        $ editNameTextBox��5)      $��/Files/Fonts/INTER/#Inter)�63   $��10,8,0,0q�6|   $	��350��6�   (  "System.Windows.Controls.DatePicker  5*      -	   5          Name$ editDateOfBirthDatePicker��5*      $��/Files/Fonts/INTER/#Inter)�6@   $��10,8,0,0q�6�   $	��350��6�   5+      5-      �� 5/   
   -
   5        	 ��Name$	 instructionsTextBlock��5/      ${�False��63   
���  ��$e��_In order to become an author, you need to provide all the necessary information about yourself!��6V   $
��Wrap=�6�   $
��Left=�6�   $��	10,65,0,0q�6�   $��Center=�6�   $	��460��6  $��1��6&  $��38��66  �� 50   
   -   5        
 ��Name$
 becomeAuthorButton��50      $��/Files/Fonts/INTER/#Inter)�6-   $��Become Author��6T   ${�False��6�   $��1��6�   $��
10,0,0,130q�6�   $
��Left=�6�   $��95��6�   $��20��6�   $��Bottom=�6�   �� 52   
   -   5        $ highlightingTextBox3��52      ${�False��60   $
��Left=�6B   $��Bottom=�6]   $	��800��6x   $��51��6�   $
 Wrap=�6�   $
 True��6�   $��2��6�   �� 53   
   -   5        $
 addBookButton��53      $��/Files/Fonts/INTER/#Inter)�6(   $��Add New Book��6O   $��
155,0,0,10q�6�   $��30��6�   $��Bottom=�6�   $
��Left=�6�   $��90��6�   �� 54   
   -   5        $
 	YourBooks��54   $   $��My Books��6   $��/Files/Fonts/INTER/#Inter)�67   $��	80,0,0,10q�6^   $��30��6q   $��Bottom=�6}   $
��Left=�6�   $��70��6�   6�   �� 55   
   -   5        $
 
SaveButton��55   o   $��1��6   $��/Files/Fonts/INTER/#Inter)�6!   $
��Save��6H   
������${�False��6�   $��Right=�6�   $��	0,0,95,10q�6�   $��80��6�   $��26��6�   $��Bottom=�6�   �� 56   
   -   5        $��1��56      $��/Files/Fonts/INTER/#Inter)�6!   $��Cancel��6H   
���z���$��26��6�   $��Bottom=�6�   $��Right=�6�   $��80��6�   $��10q�6�   �� 57   
   -   5        $
 CartOpen��57   8   $��/Files/Fonts/INTER/#Inter)�6   $��My Cart��6J   
�������$��10,10,170,10q�6~   $��Bottom=�6�   $��60��6�   $��30��6�   6�   �� 59   
   -   5        $
 adminButton��59   H   $��1��6   $��/Files/Fonts/INTER/#Inter)�6!   $��Admin��6]   
�������$��26��6�   $��Bottom=�6�   $��Right=�6�   $��80��6�   $��
0,0,443,12q�6�   5:      5;      