   M S B A M L   `   `   `  ����C  ?Fractals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FractalsFractals  5   	       Fractals.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Fractals     5   	     � Title$  Фракталы��5   	   $	��450��6   $	��800��6'    � 
ResizeMode$ CanMinimize=�63   .��5	      � .+�5
   
   �� $	��235��6   
�������$
��Left=�65   .+�5      �� .+�5      �� $%��Выберите фрактал��6   $��35 3 0 0q�64   �� 5      
�������$��1q�61   $��10 1 0 0q�6E   ._�5      �� $��2 2 3 2q�6!   .+�5      	� -   5         	�Name$ curve��5   &    	� 	GroupName$ Fractals��65   $��Кривая Коха��6J   6`   	� 5      -   5        $ carpet��5   &   $ Fractals��66   $'��!Ковер Серпинского��6K   6g   	� 5      -   5        $ triangle��5   &   $ Fractals��68   $3��-Треугольник Серпинского��6M   6o   5      5      �� 5      
�������$��1q�61   $��	10 12 0 5q�6E   ._�5      �� $��2 2 3 5q�6!   $��23��62   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0 4 0 0q�6>   .+�5      �� !Глубина рекурсии6:   �� 5      -   5         ��Name$ 
iterations��5   &   $��32 0 0 0q�6:   $��60��6L   ${�False��6W   6i   5      5      5      �� 5      -   5        $��Информация��5      $��
10 260 0 0q�6.   
�������$��1q�6Z   6n   5      5      �� 5   
   -   5         ��Name$ 
drawCanvas��5      $��	235 0 0 0q�6%   $	��565��68   $	��450��6D   5       5!      5"      