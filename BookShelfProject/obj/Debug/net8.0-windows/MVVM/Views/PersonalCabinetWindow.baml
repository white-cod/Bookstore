   M S B A M L   `   `   `  ����K  GBookShelfProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BookShelfProject.MVVM.ViewsBookShelfProject.MVVM.Views  5   	   S.clr-namespace:BookShelfProject.Core.Converters BookShelfProject.Core.Converters  5   	   7    1BookShelfProject.MVVM.Views.PersonalCabinetWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:BookShelfProject.MVVM.Views     5   	   E
converters.clr-namespace:BookShelfProject.Core.Converters     5   	   -   5          � Title$  PersonalCabinetWindow��5	   	   $	��450��6'   $	��800��64    � 
ResizeMode$ NoResize=�5
   	   $��/Files/Fonts/INTER/#Inter)�5   	   ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@�WindowStyle �� Value$
 None=�6,   �� 5       �@�AllowsTransparency$
 True��63   �� 5       � ��
 �����6+   �� 5       � ��$ 2q�60   �� 5       � ��
 �   �6,   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5"   
   �� $'��!Welcome to Your Personal Cabinet!��6   $��16(�5#      $
��Bold"�6   $��0,10,0,0q�5$      $��32��6"   $	��Top=�5%      $��Center=�5&      $	��280��5'      $��2��5(      �� 5*   
   $��0,0,0,50q�6   $	��250��5+      $	��200��5,      $��Center=�5-      $��Center=�5.      
���   �$��1q�50      ._�51      �� -   5         ��Name$ AvatarImage��51      $
��Fill=�52      ��53      �� *
AvatarPath+54      �� 57   
   $��Change��6   $��	15,0,0,20q�58      $��20��59      $��Bottom=�5:      $
��Left=�5;      $��75��5<      ��5=      �� *_ChangeAvatarCommand+�� 5?   
    �� Orientation$ 
Horizontal=�6   $��1��5@      $	��500��5A      $	��120��5B      $	��Top=�5C      $��Center=�5D      $��10,60,10,10q�5E      .+�5G      �� $ Vertical=�6   .+�5H      �� $��Account name:��6   $��	10,10,5,0q�5I      �� 5J      $��Name: ��6   $��	10,10,5,0q�5K      �� 5L      $��Email:��6   $��	10,10,5,0q�5M      �� 5N      $��Date of Birth:��6   $��	10,10,5,0q�5O      5P      �� 5R      $ Vertical=�6   .+�5S      �� $��10,8,0,0q�6   	 �� 
IsReadOnly$	 False��5T      $	��350��5U      ��5V      �� *
Username+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5X      $��10,8,0,0q�6   $	 False��5Y      $	��350��5Z      ��5[      �� *Name+$
 TwoWay=�$ PropertyChanged=��� 5\      $��10,8,0,0q�6   $	��350��5]      ��5^      �� *Email+$
 TwoWay=�$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  5_      $��10,8,0,0q�6   $	��350��5`         SelectedDate 5a      �� *	BirthDate+$
 TwoWay=�$ PropertyChanged=�5b      5c      �� 5e   
   $��Become author��6   $��2��5f      $��Center=�5h      $
��Left=�5i      $	��130��5j      $��35��5k      $��14(�5l      $��SemiBold"�5m      $��30,10,30,10q�5n      {�5g      �� *IsAuthorStatusAvailable+��5o      ��  �� Path$ _BecomeAuthorCommand�5p      �� 5r   
   $��Logout��6   $��1��5s      $��Center=�5t      $��Right=�5u      $��0,0,65,0q�5v      $��80��5w      $��35��5x      $��16(�5y      $��SemiBold"�5z      ��5{      �� $ _LogoutCommand��� 5}   
   $e��_In order to become an author, you need to provide all the necessary information about yourself!��6   $
��Wrap=�5~      $��1��5      $��0��5�      $��Center=�5�      $��Center=�5�      $	��480��5�      $��10,100,10,10q�5�      
���  ����5�      �� 5�      " ��6   .�5�      ��  � y�$ 	Collapsed=�63    �� Triggers 5�      �� 5�       �� Binding 6&   �� *IsCurrentUserAuthor+ �� Value	 False6N   .a�5�      ��  � y�$ Visible=�6;   5�      5�      5�      �� 5�   
   $��1��6   $��1��5�      $
��Save��5�      $��Right=�5�      $��Center=�5�      $��10,0,110,10q�5�      $��80��5�      $��26��5�      {�5�      �� *AreFieldsFilled+��5�      �� *_SaveProfileChangesCommand+�� 5�   
   $��1��6   $��1��5�      $��Back to shop��5�      $��26��5�      $��Right=�5�      $��Center=�5�      $��90��5�      $��
10,0,10,10q�5�      
���z�����5�      �� $ _OpenShopWindowCommand�5�      �� 5�   
   $��0��6   $��1��5�      $��My Cart��5�      $
��Left=�5�      $��Center=�5�      $��	15,0,0,10q�5�      $��30��5�      $��60��5�      
���������5�      �� $ _OpenCartCommand�5�      �� 5�   
   $��1��6   $��1��5�      $��Center=�5�      $
��Left=�5�      $	��100��5�      $��30��5�      $��
Admin menu��5�      ���#fc0303$��SemiBold"�5�      $��	10,0,0,10q�5�      ��5�      �� $ _OpenAdminWindowCommand���5�      �� 5�      " ��6   .�5�      ��  � y�$ 	Collapsed=�63    5�      �� 5�       6&   �� $/ )_CurrentUserDataStore.CurrentUser.IsAdmin� True6i   .a�5�      ��  � y�$ Visible=�6;   5�      5�      5�      �� 5�   
   $��0��6   $��1��5�      $��Add book��5�      $��0,0,8,10q�5�      $��70��5�      $��30��5�      $��Center=�5�      $��Center=�5�      {�5�      �� $ IsCurrentUserAuthor���5�      �� *_OpenAddBookWindowCommand+5�      �� 5�   
   $��0��6   $��1��5�      $��My books��5�      $��	0,0,15,10q�5�      $��70��5�      $��30��5�      $��Center=�5�      $��Right=�5�      {�5�      �� $ IsCurrentUserAuthor���5�      �� $" _OpenUsersBooksWindowCommand�5�      5�      5�      