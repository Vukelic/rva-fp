   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   $	��320��5      $	��562��6'     � 
ResizeMode$  NoResize=�63    � Title$ 	LoginForm��6I    � WindowStartupLocation$ CenterOwner=�6[   $��Segoe Print)�6   $��10(�6�    � Icon$ /Images/background_2.jpg��6�   ��5      �� 5	   
   .��5      � $��0,0,2,-4q�6    � ColumnDefinitions 5   
   �� 5      $	��11* �6   �� 5      $	��37* �6   �� 5      $	��38* �6   �� 5      $
��469* �6   .+�5   
   �� $��0,2,0,0q�6   $��/Images/background_2.jpg��6"   $
��Fill=�6D    J� RenderTransformOrigin$ 0.5,0.5&�6S   $��4��6s   �� 5   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $��Username��6c   $
��Left=�6v   $��229.5,119,0,0q�6�   $	��Top=�6�   $��24��6�   $��66��6�   $ 0.439,0.333&�6�   $��3��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��24��6T   $��317.5,119,0,0q�6`    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��120��6�   $��3��6�   ��6�   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Password��6   $��10(�6#   $��Segoe Print)�61   $
��Left=�6J   $��229.5,158,0,0q�6e   $	��Top=�6|   $ 1.533,-1.115&�6�   $��66��6�   $��25��6�   $��3��6�   G� 5   
   -   5        $��PasswordBox1��5      $
��Left=�6*   $��10(�6E   $��Segoe Print)�6S   $��22��6m   $��317.5,161,0,0q�6y   $	��Top=�6�   $	��120��6�   $��3��6�   �� 5   
   $��10(�6   $��Segoe Print)�6   
������ 
������  �� 	IsDefault . $
��Left=�6�   $��334,203,0,0q�6�   $	��Top=�6�   $��76��6�   $��3��6�   $��34��6   ��6k   �� *LoginCommand+��5      �� 5      $��/Images/registration.JPG��6   $��71��6:   $��26��6F   $
��Fill=�6R   6c   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��
378,10,0,0q�6�   $	��Top=�6�   $��70��6�   $��3��6�   $��43��6�   ��6k   �� *ExitCommand+��5      �� 5      $��/Images/exit_icon.jpg��6   $��68��67   $��43��6C   $
��Fill=�6O   6`   5       5#      5$      