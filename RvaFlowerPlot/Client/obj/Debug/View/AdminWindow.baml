   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	       Client.View.AdminWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	   $��306.5��5      $	��562��6(     � 
ResizeMode$  NoResize=�64    � Title$ AdminWindow��6J    � WindowStartupLocation$ CenterOwner=�6^   $��Segoe Print)�6�   $��10(�6�    � Icon$" /Images/admin_bsckground.jpg��6�   .��5      � $��0,0,0,35q�6   .+�5	   
   �� $"��/Images/admin_bsckground.jpg��6   $
��Fill=�66   $��	0,0,0,-37q�6E   �� 5
   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    �� 	IsDefault . $
��Left=�6�   $��194,220,0,-24q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *AddUserCommand+��5      �� 5      $��/Images/add_user.png��6   $��36��66   $
��Fill=�6A    J� RenderTransformOrigin$ 0.531,0.538&�6P   $��33��6t   6�   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��271,220,0,-24q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *EditUserCommand+��5      �� 5      $��/Images/edit_user.jpg��6   $��36��67   $
��Fill=�6B   $ 0.531,0.538&�6Q   $��36��6u   6�   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��346,220,0,-24q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *DeleteUserCommand+��5      �� 5      $��/Images/delete_user.jpg��6   $��36��69   $
��Fill=�6D   $ 0.531,0.538&�6S   $��36��6w   6�   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��	491,5,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *ExitCommand+��5      �� 5      $��/Images/exit1_icon.png��6   $��36��68   $
��Fill=�6C   $ 0.531,0.538&�6R   $��36��6v   6�   5      &   System.Windows.Controls.DataGrid  5   
   $
��Left=�6   $	��159��6.   $��	10,56,0,0q�6;   $	��Top=�6N   $	��536��6f      AutoGenerateColumns .     
IsReadOnly . ��5      �� *	MyUsers+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� SelectedItem	 5       �� *SelectedUser+
   Columns
 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *
Username+  5#      $
 Name��6%   $ * 63    6=   �� *Name+  5$      $ Lastname��6%   $ * 67    6A   �� *
Lastname+  5%      $
 Role��6%   $ * 63    6=   �� *
TypeUser+5'      5(      5)      