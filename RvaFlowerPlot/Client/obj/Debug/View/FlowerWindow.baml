   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	       Client.View.FlowerWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	   $	��316��5      $	��342��6'     � 
ResizeMode$  NoResize=�63    � Title$ FlowerTypeWindow��6I    � WindowStartupLocation$ CenterOwner=�6b   $��Segoe Print)�6�   $��10(�6�    � Icon$# /Images/flower_background.jpg��6�   .��5      � $��0,0,0,35q�6   .+�5	   
   �� $#��/Images/flower_background.jpg��6   $
��Fill=�67   $��	0,0,0,-37q�6F   �� 5
   
   $
��Name��6   $��10(�6   $��Segoe Print)�6-   $
��Left=�6F   $��	19,19,0,0q�6a   $	��Top=�6t    J� RenderTransformOrigin$ 1.533,-1.115&�6�   $��62��6�   $��28��6�   �� 5   
   -   5        $��Label1��5      
���  ��$��10(�6o   $��Segoe Print)�6}   $
��Left=�6�   $��	91,64,0,0q�6�   $	��Top=�6�   $ 1.533,-1.115&�6�   $	��172��6  $��28��6  ��6   �� *Label1+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5   
   
������ $
��Left=�6+   $��10(�6F   $��Segoe Print)�6T   $��86,19,0,195q�6m    �� TextWrapping$
 Wrap=�6�   $	��120��6�   $��28��6�   $ 0.458,0.357&�6�   ��6�   �� *MyFlower.FlowerName+$ PropertyChanged=�6�   �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    �� 	IsDefault . $
��Left=�6�   $��160,107,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *ExitCommand+��5      �� 5      $��/Images/exit_pic.jpg��6   $��46��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��
86,107,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *SaveFlowerCommand+��5      �� 5      $��/Images/save_pic.png��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5      �� 5   
   $
��Left=�6\   $��
454,64,0,0q�6w   $	��Top=�6�   $��22��6�   $��80��6�   ��6   ��  �� Path$ LabelPassword�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6X   $��454,107,0,0q�6s   $	��Top=�6�   $��22��6�   $��80��6�   ��6   �� $ 	LabelName�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6\   $��454,137,0,0q�6w   $	��Top=�6�   $��22��6�   $��80��6�   ��6   �� $ LabelLastname�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6X   $��454,174,0,0q�6s   $	��Top=�6�   $��24��6�   $��80��6�   ��6   �� $ 	LabelType�$ PropertyChanged=�6�   5      5      