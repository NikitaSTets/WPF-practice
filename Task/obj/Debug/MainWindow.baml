   M S B A M L   `   `   `  ����?  ;Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TaskITaskI  5   	       TaskI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:TaskI     5   	     � Title$  List of students��5   	   $	��350��6"   $��521.297��6/   .��5	      � 
�������$��	0,0,260,0q�6!   $
��auto��64    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��40* �6   �� 5      $	��33* �6   �� 5      $	��37* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5         
IsReadOnly .     AutoGenerateColumns .     HorizontalGridLinesBrush
 �����   RowBackground
 �����   AlternatingRowBackground
 �����$��	-3,0,0,-4q�5   @   $��3��6S   $��2��6g   	 J� RenderTransformOrigin$	 0.5,0.5&�6x   $	��320��6�   $��Bottom=�6�   z�5      V� 5      .~�5      �� �� 5      �� 5      
 �� Angle$
 0.341Q�6&   T� 5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6'      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5#      `� 5$       �� StringFormat$ {0}  {1}��6'   .1�5%      ��  �� Path$
 Name�6&   �� 5&      $ LastName�6&   5'      5)      5  /System.Windows.Controls.DataGridHyperlinkColumn  5*      $ Возраст��6*   $ 80 6X    6;   �� $	 Age�6X     5+      $ Пол��6%   $ 80 6R    62   �� $ Gender�6R   5.      � 5/   
   $	��316��6   $��95,5,-262,-1q�6   $	��Top=�62   $��2��6J   $��1��6Z    50      �� 51      $	��19* �6    �� 52      $	��60* �6    .+�55      �� -   5         ��Name$ button��55      $	��Add��6%   $
��Left=�63   $��
30,134,0,0q�6N   $	��Top=�6b   $��75��6z   $��1��6�   6�   �� 57      -   5         ��Name$ studentFirstNameTextBox��57      $
��Left=�67   $��23��6R   $��	30,29,0,0q�6^    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 59      -   5        $ studentLastNameTextBox��59      $
��Left=�66   $��23��6Q   $��
30,0,0,217q�6]   $��1��6q   $
 Wrap=�6~   $��Bottom=�6�   $	��120��6�   �� 5;      -   5        $ studentAgeTextBox��5;      $
��Left=�61   $��23��6L   $��	30,46,0,0q�6X   $��1��6k   $
 Wrap=�6x   $	��Top=�6�   $	��120��6�   �� 5=      -   5         ��Name$ firstNameLabel��5=      $��First name:��6,   $
��Left=�6B   $��30,3,0,0q�6]   $	��Top=�6o   �� 5?      -   5        $ lastNameLabel��5?      $��	Last name��6+   $
��Left=�6?   $��	30,52,0,0q�6Z   $	��Top=�6m   �� 5A      -   5        $ AgeLabel��5A      $	��Age��6&   $
��Left=�64   $��	30,23,0,0q�6O   $��1��6b   $	��Top=�6o   	� 5C      -	   5         	�Name$ manRadioButton��5C       d� 	IsChecked$
 TrueY�62   $	��Man��6C   $
��Left=�6Q   $��	30,83,0,0q�6l   $��1��6   $	��Top=�6�   	� 5D      -
   5        $ womanRadioButton��5D      $��Women��64   $
��Left=�6D   $��
136,86,0,0q�6_   $��1��6s   $	��Top=�6�   �� 5F      -   5        $ 	deleteBtn��5F      $��Delete��6(   $
��Left=�69   $��136,134,0,0q�6T   $��1��6i   $	��Top=�6v   $��65��6�   $	 1.246,0.727&�6�   6�   �� 5H      -   5        $ 
errorLabel��5H      $�� ��6(   $
��Left=�63   $��
10,177,0,0q�6N   $��1��6b   $	��Top=�6o   $	��242��6�   5J      �� 5L   
   -   5        $ labelListEmpty��5L      $y�Hidden=�6(   $��List is empty��6<   $
��Left=�6T   $��0,5,0,0q�6o   $��2��6�   $	��Top=�6�   $	 
0.5,-0.885&�6�   $��3��6�   $	��243��6�   5M      5N      