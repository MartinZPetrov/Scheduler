   M S B A M L   `   `   `  ����D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Scheduler	Scheduler  5      -    'Scheduler.Controls.FavouriteWeekControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Scheduler     5      -   5        $"��favweekcontrfavweekcontrolol��5        � 	Resources  5         MonthButton �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName  	CellStyle*  $System.Windows.Controls.DataGridCell �� Triggers%   Scheduler.ValueToBrushConverter  ValueToBrushConverter'   !Scheduler.BooleanToBrushConverter  BoleanToBrushConverter(   "Scheduler.ScheduleToValueConverter  ScheduleToValueConverter)  #Scheduler.DataToVisibilityConverter  DataToVisibilityConverter��%.  &	        &	 �    &	 �    &	 �    &	 �    &	 �    �� 5   
   " ��6$   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�5      $	 4,2q�5      
�������$ 3��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver	 . . �5    "   �� $
 border��6)    � ��
 �   �6T   5!      5#      5%      5&      �� 5(   
   "  6"   .�5)      ��  � ��
 �   �6+    5*      P� 5+       �@ 
IsSelected	 . . �5,      ��  � �� 63   Z� 5-      5/        51   
   6&     52   
   6(     53   
   6)     54   
   6*   55      .��57      � .+�58   
   �� .+�59      �  � ColumnDefinitions 5:      �� 5;      $
��Auto �6'   �� 5<      $
��Auto �6'    � RowDefinitions 5>      �� 5?      $��* �6$   �� 5@      $
��Auto �6$   .+�5B      9� $��0��6    9� 
IsExpanded 6,   �� *IsExpandedAllFav+�� 5C      -   5        $��3��5C   .   $��20��6>   ��5D      �� 5E      .R�5F      �� $��Right=�6$   $��RightToLeft=�6@   $,��&pack://application:,,,/Icons/close.png��6\   5G      5I      &   System.Windows.Controls.DataGrid  5J      -   5          Name$ 	dgFavWeek��5J      $��1��6.      AutoGenerateColumns .  
�������   
IsReadOnly .    HeadersVisibility$	 All=�5N         CanUserResizeColumns .     CanUserResizeRows .     RowHeaderWidth$ 0Q�5Q      $	��500��5R         SelectionUnit$ FullRow=�5S         SelectionMode$ Extended=�5T         CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .    5Y         Scheduler.BindingProxy 	 proxy   Data��%&   &	         5Z       6;   �� 5[         Columns 5\      0  *System.Windows.Controls.DataGridTextColumn  5^      ,	  &System.Windows.Controls.DataGridColumn 	  
IsReadOnly .  	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 150
 5`   	    	  	CellStyle# [ 5a   !     	  Header$	  Day��5b   	   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5_   	   �� *Day+" �� StringFormat$" {0:dddd dd.MM.yyyy}��5c        5f      $ 50
 5i   	   # [ 5j   !   $  1��5k   	   # 	  
Visibility# 5f   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col1+$ �� 	Converter#$ [ % �� Source#% [ ! 5h   	   �� *Col1+& �� Mode$& TwoWay=�' �� UpdateSourceTrigger$' 	LostFocus=�(   ElementStyle( 5l      �� 5m   "   " ��6(   .�5n   &   ��  � �� 5o   *   `� 5p   .   ) `� 	Converter#) [ 6;   .1�5q   2   �� * �� Path$
* Col1�6:   $& TwoWay=�6F   �� 5r   2   $* 	Group_Ref�6:   5s   /   5u   '   5v   #   5x        5z      $ 50
 5}   	   # [ 5~   !   $  2��5   	   # 5z   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col2+#$ [ #% [ ! 5|   	   �� *Col2+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col2�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5�      $ 50
 5�   	   # [ 5�   !   $  3��5�   	   # 5�   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col3+#$ [ #% [ ! 5�   	   �� *Col3+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col3�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5�      $ 50
 5�   	   # [ 5�   !   $  4��5�   	   # 5�   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col4+#$ [ #% [ ! 5�   	   �� *Col4+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col4�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5�      $ 50
 5�   	   # [ 5�   !   $  5��5�   	   # 5�   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col5+#$ [ #% [ ! 5�   	   �� *Col5+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col5�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5�      $ 50
 5�   	   # [ 5�   !   $  6��5�   	   # 5�   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col6+#$ [ #% [ ! 5�   	   �� *Col6+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col6�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5�      $ 50
 5�   	   # [ 5�   !   $  7��5�   	   # 5�   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col7+#$ [ #% [ ! 5�   	   �� *Col7+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col7�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5�      $ 50
 5�   	   # [ 5�   !   $  8��5�   	   # 5�   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col8+#$ [ #% [ ! 5�   	   �� *Col8+$& TwoWay=�$' 	LostFocus=�( 5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� 5�   *   `� 5�   .   #) [ 6;   .1�5�   2   �� $
* Col8�6:   �� 5�   2   $* 	Group_Ref�6:   5�   /   5�   '   5�   #   5�        5      $ 50
 5  	   # [ 5  !   $  9��5  	   # 5   /   �� *97Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col9+#$ [ #% [ ! 5  	   �� *Col9+$& TwoWay=�$' 	LostFocus=�( 5     �� 5  "   " ��6(   .�5  &   ��  � �� 5	  *   `� 5
  .   #) [ 6;   .1�5  2   �� $
* Col9�6:   �� 5  2   $* 	Group_Ref�6:   5  /   5  '   5  #   5       5     $ 50
 5  	   # [ 5  !   $  10��5  	   # 5  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col10+#$ [ #% [ ! 5  	   �� *Col10+$& TwoWay=�$' 	LostFocus=�( 5     �� 5  "   " ��6(   .�5  &   ��  � �� 5  *   `� 5  .   #) [ 6;   .1�5  2   �� $* Col10�6:   �� 5  2   $* 	Group_Ref�6:   5   /   5"  '   5#  #   5%       5&     $ 50
 5)  	   # [ 5*  !   $  11��5+  	   # 5&  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col11+#$ [ #% [ ! 5(  	   �� *Col11+$& TwoWay=�$' 	LostFocus=�( 5,     �� 5-  "   " ��6(   .�5.  &   ��  � �� 5/  *   `� 50  .   #) [ 6;   .1�51  2   �� $* Col11�6:   �� 52  2   $* 	Group_Ref�6:   53  /   55  '   56  #   58       59     $ 50
 5<  	   # [ 5=  !   $  12��5>  	   # 59  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col12+#$ [ #% [ ! 5;  	   �� *Col12+$& TwoWay=�$' 	LostFocus=�( 5?     �� 5@  "   " ��6(   .�5A  &   ��  � �� 5B  *   `� 5C  .   #) [ 6;   .1�5D  2   �� $* Col12�6:   �� 5E  2   $* 	Group_Ref�6:   5F  /   5H  '   5I  #   5K       5M     $ 50
 5P  	   # [ 5Q  !   $  13��5R  	   # 5M  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col13+#$ [ #% [ ! 5O  	   �� *Col13+$& TwoWay=�$' 	LostFocus=�( 5S     �� 5T  "   " ��6(   .�5U  &   ��  � �� 5V  *   `� 5W  .   #) [ 6;   .1�5X  2   �� $* Col13�6:   �� 5Y  2   $* 	Group_Ref�6:   5Z  /   5\  '   5]  #   5_       5a     $ 50
 5d  	   # [ 5e  !   $  14��5f  	   # 5a  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col14+#$ [ #% [ ! 5c  	   �� *Col14+$& TwoWay=�$' 	LostFocus=�( 5g     �� 5h  "   " ��6(   .�5i  &   ��  � �� 5j  *   `� 5k  .   #) [ 6;   .1�5l  2   �� $* Col14�6:   �� 5m  2   $* 	Group_Ref�6:   5n  /   5p  '   5q  #   5s       5u     $ 50
 5x  	   # [ 5y  !   $  15��5z  	   # 5u  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col15+#$ [ #% [ ! 5w  	   �� *Col15+$& TwoWay=�$' 	LostFocus=�( 5{     �� 5|  "   " ��6(   .�5}  &   ��  � �� 5~  *   `� 5  .   #) [ 6;   .1�5�  2   �� $* Col15�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5�     $ 50
 5�  	   # [ 5�  !   $  16��5�  	   # 5�  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col16+#$ [ #% [ ! 5�  	   �� *Col16+$& TwoWay=�$' 	LostFocus=�( 5�     �� 5�  "   " ��6(   .�5�  &   ��  � �� 5�  *   `� 5�  .   #) [ 6;   .1�5�  2   �� $* Col16�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5�     $ 50
 5�  	   # [ 5�  !   $  17��5�  	   # 5�  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col17+#$ [ #% [ ! 5�  	   �� *Col17+$& TwoWay=�$' 	LostFocus=�( 5�     �� 5�  "   " ��6(   .�5�  &   ��  � �� 5�  *   `� 5�  .   #) [ 6;   .1�5�  2   �� $* Col17�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5�     $ 50
 5�  	   # [ 5�  !   $  18��5�  	   # 5�  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col18+#$ [ #% [ ! 5�  	   �� *Col18+$& TwoWay=�$' 	LostFocus=�( 5�     �� 5�  "   " ��6(   .�5�  &   ��  � �� 5�  *   `� 5�  .   #) [ 6;   .1�5�  2   �� $* Col18�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5�     $ 50
 5�  	   # [ 5�  !   $  19��5�  	   # 5�  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col19+#$ [ #% [ ! 5�  	   �� *Col19+$& TwoWay=�$' 	LostFocus=�( 5�     �� 5�  "   " ��6(   .�5�  &   ��  � �� 5�  *   `� 5�  .   #) [ 6;   .1�5�  2   �� $* Col19�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5�     $ 50
 5�  	   # [ 5�  !   $  20��5�  	   # 5�  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col20+#$ [ #% [ ! 5�  	   �� *Col20+$& TwoWay=�$' 	LostFocus=�( 5�     �� 5�  "   " ��6(   .�5�  &   ��  � �� 5�  *   `� 5�  .   #) [ 6;   .1�5�  2   �� $* Col20�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5�     $ 50
 5�  	   # [ 5�  !   $  21��5�  	   # 5�  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col21+#$ [ #% [ ! 5�  	   �� *Col21+$& TwoWay=�$' 	LostFocus=�( 5�     �� 5�  "   " ��6(   .�5�  &   ��  � �� 5�  *   `� 5�  .   #) [ 6;   .1�5�  2   �� $* Col21�6:   �� 5�  2   $* 	Group_Ref�6:   5�  /   5�  '   5�  #   5�       5     $ 50
 5  	   # [ 5  !   $  22��5  	   # 5  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col22+#$ [ #% [ ! 5  	   �� *Col22+$& TwoWay=�$' 	LostFocus=�( 5     �� 5  "   " ��6(   .�5	  &   ��  � �� 5
  *   `� 5  .   #) [ 6;   .1�5  2   �� $* Col22�6:   �� 5  2   $* 	Group_Ref�6:   5  /   5  '   5  #   5       5     $ 50
 5  	   # [ 5  !   $  23��5  	   # 5  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col23+#$ [ #% [ ! 5  	   �� *Col23+$& TwoWay=�$' 	LostFocus=�( 5     �� 5  "   " ��6(   .�5  &   ��  � �� 5  *   `� 5  .   #) [ 6;   .1�5   2   �� $* Col23�6:   �� 5!  2   $* 	Group_Ref�6:   5"  /   5$  '   5%  #   5'       5)     $ 50
 5,  	   # [ 5-  !   $  24��5.  	   # 5)  /   �� *:8Data.ScheduleDetailsViewSourceFav.View.CurrentItem.Col24+#$ [ #% [ ! 5+  	   �� *Col24+$& TwoWay=�$' 	LostFocus=�( 5/     �� 50  "   " ��6(   .�51  &   ��  � �� 52  *   `� 53  .   #) [ 6;   .1�54  2   �� $* Col24�6:   �� 55  2   $* 	Group_Ref�6:   56  /   58  '   59  #   5;     4  .System.Windows.Controls.DataGridComboBoxColumn  5=     $	 100
 5>  	   +   DisplayMemberPath$+ Description��5?  !   ,   SelectedValuePath$, 	Group_Ref��5@  !   $  Worker��5B  	   -   SelectedValueBinding- 5A  !   �� *	Group_Ref+$& TwoWay=�.   ElementStyle. 5C     �� 5D  "   " ��6(   .�5E  &   ��  � �� 6D   �� $#* DataContext.ScheduleGroupsFav�/ �� RelativeSource/ �� 0 �� AncestorType"0 >�5F  #   1   EditingElementStyle1 5I     �� 5J  "   " ��6(   .�5K  &   ��  � �� 6D   �� $#* DataContext.ScheduleGroupsFav�/ �� "0 >�5L  #   5N     2 � ContextMenu2 5Q     �� 5R     .@�5S     m� -   5        $��Select Week��5S  '   6<   5T     3 �� 
GroupStyle3 5W     (  "System.Windows.Controls.GroupStyle  5X     4   ContainerStyle4 5Y     �� 5Z  "   " ��6(   .�5[  &   ��  � �� 5\  *   �� 5]  .   " ��6>   .R�5^  2   9�  . ��5_  6   ]� 5j  :   .+�5k  >   �� $
��Bold"�6H   $��5,0,0,0q�6�   ��6Z   �� $
* Name�$" {0:dddd dd.MM.yyyy}��6�   5l  ;   ��5n  6   �� 5o  :   5q  3   5r  /   5t  '   5u  #   5w     5y     5z     5{     5|     5}     