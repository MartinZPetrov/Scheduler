   M S B A M L   `   `   `  ����D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Scheduler	Scheduler  5	          Scheduler.Views.WorkView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Scheduler     5	        � DataContext  5      �� *Work+   Locator �� Source# [   � 	Resources 5      )   #Scheduler.ByteArrayToImageConverter  ByteArrayToImageConverter��%   &	         5   
   6*   5      .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Work Start:��6   60   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *	WorkDay+ �� Mode$ TwoWay=�5      �� 5      -   5         ��Name$ lvWorkStartTime��5      $��Stretch=�60   $	��Top=�6N   $��20��6f   $
��1000��6r   ��5      �� *	WorkStart+��5      �� 5      .R�5      A� 	 A� Columns$	 3��6&   $��Stretch=�63   5      ��5       �� 5!      .R�5"      �� $��75,0,0,0q�6%   $��Center=�67   $��Center=�6U   ��6p   �� *	WorkStart+6�   5#      5%      �� 5'      -   5        $ lvWorkImages��5'      $��Stretch=�6-   $	��Top=�6K   $	��200��6c   $
��1000��6p   ��5(      �� *WorkStartImages+��5)      �� 5*      .R�5+      A� $	 3��6&   $��Stretch=�63   5,      ��5.      �� 5/      .R�50      �� ��6    �� *Image+
 �� 	Converter#
 [ 6q   51      53      �� 55      
�������$��5q�61   ._�56      �� $	��200��6   $	��230��6*   ��57      �� 58      .R�59   "   ��  ��Name$ imgEmp��6(   $��10��6�   ��68   �� *PictureStartTaken+#
 [ $ TwoWay=�6�   5:      5<      5=      �� 5>      -   5         ��Name$ btnPicStart��5>      $	��100��6.   $��25��6:   
�������$��
Work Start��6p   6�   �� 5@      $��Work End��6   6)   �� 5A      -   5        $ lvWorkEndTime��5A      $��Stretch=�6.   $	��Top=�6L   $��20��6d   $
��1000��6p   ��5B      �� *	WorkEnd+��5C      �� 5D      .R�5E      A� $	 3��6&   $��Stretch=�63   5F      ��5H      �� 5I      .R�5K      �� $��75,0,0,0q�6%   $��Center=�67   $��Center=�6U   ��6p   �� *	WorkEnd+6�   5L      5N      �� 5P      -   5        $ lvWorkEndImages��5P      $��Stretch=�60   $	��Top=�6N   $	��200��6f   $
��1000��6s   ��5Q      �� *WorkEndImages+��5R      �� 5S      .R�5T      A� $	 3��6&   $��Stretch=�63   5U      ��5W      �� 5X      .R�5Y      �� ��6    �� *Image+#
 [ 6q   5Z      5\      �� 5^      
�������$��5q�6-   ._�5_      �� $	��200��6   $	��230��6&   ��5`      �� 5a      .R�5b      �� $ imgEmp��6$   $��10��6�   ��64   �� *PictureEndTaken+#
 [ $ TwoWay=�6�   5c      5e      5f      �� 5g      -   5        $ 	btnPicEnd��5g      $	��100��6)   $��25��65   
�������$��Work Emd��6n   6�   5h      5i      5j      