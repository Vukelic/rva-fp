   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	        Client.View.SoilTypeWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	   $��332.5��5      $	��411��6(     � 
ResizeMode$  NoResize=�64    � Title$ SoilTypeWindow��6J    � WindowStartupLocation$ CenterOwner=�6a   $��Segoe Print)�6�   $��10(�6�    � Icon$ /Images/soil_pic.jpg��6�   .��5      � $��0,0,0,35q�6   .+�5	   
   �� $��/Images/soil_pic.jpg��6   $
��Fill=�6.   $��	0,0,0,-34q�6=   $	��302��6P   $	��Top=�6]   �� 5
   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $��ClayPercent��6c   $
��Left=�6y   $��	10,17,0,0q�6�   $	��Top=�6�   $��24��6�   $��83��6�    J� RenderTransformOrigin$ 0.439,0.333&�6�   �� 5   
   $��22��6   $
��Left=�6   $��10(�69   $��Segoe Print)�6G   $��125,17,0,215q�6`    �� TextWrapping$
 Wrap=�6v   $	��120��6�   ��6�   �� *MySoilType.ClayPercent+ �� UpdateSourceTrigger$ PropertyChanged=�{�6�   �� *Add+�� 5   
   $��SandPercent��6   $��10(�6&   $��Segoe Print)�64   $
��Left=�6M   $��	11,61,0,0q�6h   $	��Top=�6{   $ 1.533,-1.115&�6�   $��82��6�   $��25��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��22��6U   $��
125,64,0,0q�6a   $
 Wrap=�6u   $	��Top=�6�   $	��120��6�   ��6�   �� *MySoilType.SandPercent+$ PropertyChanged=�6�   �� 5   
   $��SiltPercent��6   $��10(�6&   $��Segoe Print)�64   $
��Left=�6M   $��
10,111,0,0q�6h   $	��Top=�6|   $ 1.533,-1.115&�6�   $��83��6�   $��25��6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��22��6U   $��125,114,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   $ 0.517,1.909&�6�   ��6�   �� *MySoilType.SiltPercent+$ PropertyChanged=�6�   �� 5   
   $
��Name��6   $��10(�6   $��Segoe Print)�6-   $
��Left=�6F   $��
11,162,0,0q�6a   $	��Top=�6u   $ 1.533,-1.115&�6�   $��83��6�   $��24��6�   �� 5   
   $��24��6   $
��Left=�6   $��10(�69   $��Segoe Print)�6G   $��125,164,0,70q�6`   $
 Wrap=�6v   $	��120��6�   ��6�   �� *MySoilType.SoilName+$ PropertyChanged=�6�   �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    �� 	IsDefault . $
��Left=�6�   $��199,210,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *ExitCommand+��5      �� 5      $��/Images/exit_pic.jpg��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5      �� 5   
   $��10(�6   
������ 
������ $��Segoe Print)�6R    . $
��Left=�6�   $��125,210,0,0q�6�   $	��Top=�6�   $��46��6�   $��46��6�   ��6k   �� *SaveSoilCommand+��5      �� 5      $��/Images/save_pic.png��6   $��36��66   $
��Fill=�6A   $ 0.531,0.538&�6P   $��36��6t   6�   5      �� 5   
   -   5        $��label1��5   "   
���  ��$
��Left=�6q   $��
266,18,0,0q�6�   $	��Top=�6�   $	��111��6�   $	��120��6�   ��61   �� *Label1+$ PropertyChanged=�6�   �� 5    
   
���  ��$
��Left=�6e   $��266,169,0,0q�6�   $	��Top=�6�   $	��120��6�   $��24��6�   ��6"   �� *	LabelName+$ PropertyChanged=�6�   5!      5"      