   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	   )    #Client.View.AddEditFlowerPlotWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	   $��306.5��5   !   $	��562��60     � 
ResizeMode$  NoResize=�6<    � Title$ AddEditWindow��6R    � WindowStartupLocation$ CenterOwner=�6h   $��Segoe Print)�6�   $��10(�6�    � Icon$ /Images/flowerPlot.JPG��6�   .��5      � $��0,0,0,35q�6   .+�5	   
   �� $��/Images/flowerPlot.JPG��6   $
��Fill=�60   $��	0,0,0,-37q�6?   �� 5
   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $
��Area��6c   $
��Left=�6r   $��	10,19,0,0q�6�   $	��Top=�6�   $��24��6�   $��66��6�    J� RenderTransformOrigin$ 0.439,0.333&�6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��146,19,0,199q�6T    �� TextWrapping$
 Wrap=�6j   $	��120��6�   ��6~   �� *NewFlowerPlot.Area+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��HarvestDate��6   $��10(�6&   $��Segoe Print)�64   $
��Left=�6M   $��	10,61,0,0q�6h   $	��Top=�6{   $ 1.533,-1.115&�6�   $��78��6�   $��25��6�   �� 5   
   $��MoisturePerc��6   $��10(�6'   $��Segoe Print)�65   $
��Left=�6N   $��
10,101,0,0q�6i   $	��Top=�6}   $ 1.533,-1.115&�6�   $��78��6�   $��25��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��22��6U   $��146,104,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   $ 0.517,1.909&�6�   ��6�   �� *NewFlowerPlot.MoisturePerc+$ PropertyChanged=�6�   �� 5   
   $��PlantingDate��6   $��10(�6'   $��Segoe Print)�65   $
��Left=�6N   $��
10,141,0,0q�6i   $	��Top=�6}   $ 1.533,-1.115&�6�   $��78��6�   $��25��6�   �� 5   
   $��Stage��6   $��10(�6    $��Segoe Print)�6.   $
��Left=�6G   $��
10,180,0,0q�6b   $	��Top=�6v   $ 1.533,-1.115&�6�   $��78��6�   $��25��6�   �� 5   
   
������ $
��Left=�6+   $��10(�6F   $��Segoe Print)�6T   $��22��6n   $��146,183,0,0q�6z   $
 Wrap=�6�    �� 
IsReadOnly . $	��Top=�6�   $	��120��6  $ 0.517,1.909&�6#  ��6�   �� *NewFlowerPlot.Stage+$ PropertyChanged=�6#  �� 5   
   $��Kind of flowers��6   $��10(�6*   $��Segoe Print)�68   $
��Left=�6Q   $��
280,18,0,0q�6l   $	��Top=�6�   $ 1.533,-1.115&�6�   $��90��6�   $��25��6�   �� 5   
   -   5        $��ComboBoxFlowers��5      $
��Left=�6*   $��
375,19,0,0q�6E   $	��Top=�6Y   $	��120��6q   ��5      �� *MyFlowertype+ �� SelectedItem 5      �� *NewFlowerPlot.FlowerName+$ PropertyChanged=�	 �� SelectedValue	 6j   �� *
FlowerName+{�6�   �� *IsIdleState+$ PropertyChanged=��� 5   
   $��	Soil type��6   $��10(�6$   $��Segoe Print)�62   $
��Left=�6K   $��
280,63,0,0q�6f   $	��Top=�6z   $ 1.533,-1.115&�6�   $��90��6�   $��25��6�   �� 5   
   $
��Left=�6   $��
375,61,0,0q�6.   $	��Top=�6B   $	��120��6Z   ��5      �� *
MySoiltype+ 5      �� *NewFlowerPlot.SoilName+$ PropertyChanged=�	 6h   �� *
SoilName+{�6�   �� *IsIdleState+�� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R   
 �� 	IsDefault
 . $
��Left=�6�   $��449,104,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *ExitCommand+��5      �� 5      $��/Images/exit_pic.jpg��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5      �� 5    
   $��10(�6   
������ 
������ $��Segoe Print)�6S   
 . $
��Left=�6�   $��375,104,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6l   �� *SaveFlowerPlotCommand+��5!      �� 5"      $��/Images/save_pic.png��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5$      �� 5%   
   $��10(�6   
������ 
������ $��Segoe Print)�6R   
 . $
��Left=�66  $��271,180,0,0q�6Q  $	��Top=�6f  $��31��6~  $��25��6�  ��6k   �� *NextStageCommand+$ PropertyChanged=�y�6�   �� *AddNextStage+$ PropertyChanged=�{�6�   �� *NextStageChanged+��5&      �� 5'      $��/Images/redo_icon.png��6   $��21��67   $
��Fill=�6B   $ 0.531,0.538&�6Q   $��22��6u   6�   5)      (  "System.Windows.Controls.DatePicker  5*   
   $
��Left=�6   $��
146,61,0,0q�60   $	��Top=�6D   $	��120��6\   $��27��6�      SelectedDate 6i   �� *NewFlowerPlot.HarvestDate+$ PropertyChanged=�6�     5+   
   $
��Left=�6   $��146,142,0,0q�60   $	��Top=�6E   $	��120��6]    6j   �� *NewFlowerPlot.PlantingDate+$ PropertyChanged=�5,      5-      