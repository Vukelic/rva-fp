   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	       Client.View.AddEditWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	   $��335.5��5      $	��598��6)     � 
ResizeMode$  NoResize=�65    � Title$ AddEditWindow��6K    � WindowStartupLocation$ CenterOwner=�6a   $��Segoe Print)�6�   $��10(�6�    � Icon$$ /Images/settings_backgound.jpg��6�   .��5      � $��0,0,0,35q�6   .+�5	   
   �� $$��/Images/settings_backgound.jpg��6   $
��Fill=�68   $��	0,0,0,-37q�6G   �� 5
   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $��Username��6c   $
��Left=�6v   $��
247,19,0,0q�6�   $	��Top=�6�   $��24��6�   $��66��6�    J� RenderTransformOrigin$ 0.439,0.333&�6�   �� 5   
   $��26��6   $
��Left=�6   $��10(�69   $��Segoe Print)�6G   $��318,19,0,229q�6`    �� TextWrapping$
 Wrap=�6v   $	��120��6�   ��6�   �� *NewMyUser.Username+ �� UpdateSourceTrigger$ PropertyChanged=�{�6�   �� *Add+�� 5   
   $��Password��6   $��10(�6#   $��Segoe Print)�61   $
��Left=�6J   $��
247,64,0,0q�6e   $	��Top=�6y   $ 1.533,-1.115&�6�   $��66��6�   $��25��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��22��6U   $��
318,64,0,0q�6a   $
 Wrap=�6u   $	��Top=�6�   $	��120��6�   ��6�   �� *NewMyUser.Password+$ PropertyChanged=�6�   �� 5   
   $
��Name��6   $��10(�6   $��Segoe Print)�6-   $
��Left=�6F   $��247,104,0,0q�6a   $	��Top=�6v   $ 1.533,-1.115&�6�   $��66��6�   $��25��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��22��6U   $��318,104,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   $ 0.517,1.909&�6�   ��6�   �� *NewMyUser.Name+$ PropertyChanged=�6�   �� 5   
   $��LastName��6   $��10(�6#   $��Segoe Print)�61   $
��Left=�6J   $��247,146,0,0q�6e   $	��Top=�6z   $ 1.533,-1.115&�6�   $��66��6�   $��25��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��22��6U   $��318,149,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   $ 0.517,1.909&�6�   ��6�   �� *NewMyUser.Lastname+$ PropertyChanged=�6�   �� 5   
   $
��Role��6   $��10(�6   $��Segoe Print)�6-   $
��Left=�6F   $��247,191,0,0q�6a   $	��Top=�6v   $ 1.533,-1.115&�6�   $��66��6�   $��25��6�   �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    �� 	IsDefault . $
��Left=�6�   $��392,245,0,-19q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *ExitCommand+��5      �� 5      $��/Images/exit_pic.jpg��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��318,245,0,-19q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *SaveUserCommand+��5      �� 5      $��/Images/save_pic.png��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5       �� 5!   
   $
��Left=�6   $��318,192,0,0q�6.   $	��Top=�6C   $	��120��6[   ��5"      �� *UserTypesList+ �� SelectedItem 5#      �� *NewMyUser.TypeUser+$ PropertyChanged=�	 �� SelectedValue	 6d   �� *
TypeUser+{�6�   �� *Edit+�� 5$   
   
���  ��$
��Left=�6i   $��
454,64,0,0q�6�   $	��Top=�6�   $��28��6�   $	��118��6�   ��6"   �� *LabelPassword+$ PropertyChanged=�6�   �� 5%   
   
���  ��$
��Left=�6i   $��
454,19,0,0q�6�   $	��Top=�6�   $��28��6�   $	��118��6�   ��6"   �� *LabelUsername+$ PropertyChanged=�6�   �� 5&   
   
���  ��$
��Left=�6e   $��454,104,0,0q�6�   $	��Top=�6�   $��28��6�   $	��118��6�   ��6"   �� *	LabelName+$ PropertyChanged=�6�   �� 5'   
   
���  ��$
��Left=�6i   $��454,149,0,0q�6�   $	��Top=�6�   $��28��6�   $	��118��6�   ��6"   �� *LabelLastname+$ PropertyChanged=�6�   �� 5(   
   
���  ��$
��Left=�6d   $��454,191,0,0q�6   $	��Top=�6�   $��28��6�   $	��118��6�   ��6!   �� *	LabelType+$ PropertyChanged=�6�   5)      5*      