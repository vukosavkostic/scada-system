   M S B A M L   `   `   `  ����C  ?ScadaGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ScadaGUIScadaGUI  5   	       ScadaGUI.AddAlarmWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ScadaGUI     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
�������  MaterialDesignFont#���  5   	    � Title$ AddAlarm��5   	   $	��325��6   $	��500��6'   $	��325��63   $	��500��6C   $	��325��6R   $	��500��6b   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��59* �6   �� 5      $
��227* �6    � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      .+�5   
   #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5      $��32q�5      $��0��5       $��2��6   $��
0,0,0,33.2q�60   $��2��6D   � 5!   
   -   5        $��MainAlarmGrid��5!   j   $��0��6   ���#efeff1$��2��61   $��
0,0,0,33.2q�6E   $��2��6Y    5"      �� 5#      $��* �6#   �� 5$      $��3* �6#    5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      .+�5/      �� $��0��6   $��0��6!   $��Alarm Name:��61   $��SemiBold"�6G   $��Center=�6]   $
��Left=�6x   $��12(�6�   $��5q�6�   �� 50      -   5        $��alarmTypeLab��50   �   $��0��6   $��1��6!   $��Required Field!��61   $��Bottom=�6K   $��Center=�6f   
���  ��$��12(�6�   $��0,0,0,10q�6�   $y�Hidden=�6�   �� 52      $��1��6   $��0��6!   $��Alarm Type:��61   $��SemiBold"�6G   $��Center=�6]   $
��Left=�6x   $��12(�6�   $��5q�6�   �� 53      -   5        $��alarmNameLab��53   �   $��1��6   $��1��6!   $��Required Field!��61   $��Bottom=�6K   $��Center=�6f   
���  ��$��12(�6�   $��0,0,0,10q�6�   $y�Hidden=�6�   �� 55      $��2��6   $��0��6!   $��Analog Input:��61   $��SemiBold"�6I   $��Center=�6_   $
��Left=�6z   $��12(�6�   $��5q�6�   �� 56      -   5        $��analogInputLab��56   �   $��2��6   $��1��6!   $��Required Field!��61   $��Bottom=�6K   $��Center=�6f   
���  ��$��12(�6�   $��
0,0,200,15q�6�   $y�Hidden=�6�   �� 58      $��3��6   $��0��6!   $��Limit Value:��61   $��SemiBold"�6H   $��Center=�6_   $
��Left=�6z   $��12(�6�   $��5q�6�   �� 59      -   5        $��alarmAddresLab��59   �   $��3��6   $��1��6!   $��Required Field!��61   $��Bottom=�6K   $��Center=�6f   
���  ��$��12(�6�   $��
0,0,200,15q�6�   $y�Hidden=�6�   �� 5;      $��4��6   $��0��6!   $��Alarm Message:��61   $��SemiBold"�6J   $��Center=�6`   $
��Left=�6{   $��12(�6�   $��5q�6�   �� 5<      -   5        $��alarmMessageLab��5<   �   $��4��6   $��1��6!   $��Required Field!��61   $��Bottom=�6K   $��Center=�6f   
���  ��$��12(�6�   $��
0,0,200,15q�6�   $y�Hidden=�6�   �� 5>      -   5        $��	alarmName��5>   L   $��0��6   $��1��6#   $
��Left=�6]   $��10q�6x   $��12(�6�   $	��350��6�   ��63   ��  �� Path$ Id�6�   �� 5?      -   5        $��	alarmType��5?   4   $��1��6   $��1��6$   $��12(�6E   $��10q�6T   $
��Left=�6`   $	��200��6{   �� 5@      -	   5        $��analogInput��5@   ]   $��2��6   $��1��6$   $��12(�6p   $��10q�6   $
��Left=�6�   $	��200��6�    �� Text 64   �� $ AnalogInputTagName�6�   �� 5A      -
   5        $��alarmLimitValue��5A   T   $��3��6   $��1��6#   $��12(�6k   $��10q�6z   $
��Left=�6�   $	��200��6�   ��63   �� $ 
LimitValue�6�   �� 5B      -   5        $��aiDesc��5F      $��4��5C      $��1��5D       �� TextWrapping$
 Wrap=�5G      $��Stretch=�5H      $	��350��5I      	 �� AcceptsReturn	 . "
 �� VerticalScrollBarVisibility$

 Auto=�5K       �� 	IsEnabled . $��35��5M      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Message��5N      $
��Left=�5O      $��10q�5P      $��12(�5Q      ��5E      �� $ AlarmMessage�5Q      5T      �� 5V   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   $��0,0.4,0,0.2q�6O   .+�5W      �� -   5        $��Confirm��5W      $��10, 10, 10, 0q�6B   $	��120��6Y   $��20��6e   $��12(�6q   $��Center=�6   �� 5X      -   5        $��Cancel��5X      $��
10,10,10,0q�6@   $	��120��6T   $��20��6`   $��12(�6l   $��Center=�6z   5[      5^      5_      