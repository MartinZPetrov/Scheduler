   M S B A M L   `   `   `  ���� D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scheduler.ControlsScheduler.Controls  %clr-namespace:Scheduler	Scheduler  (    "Scheduler.Controls.ScheduleControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1ctrl clr-namespace:Scheduler.Controls     )localclr-namespace:Scheduler       � 	Resources     GroupHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Path �� StringFormat  MonthButton �� Padding �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName  	CellStyle*  $System.Windows.Controls.DataGridCell �� Triggers   Scheduler.ADPs%   Scheduler.ValueToBrushConverter  ValueToBrushConverter'   !Scheduler.BooleanToBrushConverter  BoleanToBrushConverter(   "Scheduler.ScheduleToValueConverter  ScheduleToValueConverter��%�  &	        &	 v     &	 �    &	 ?    &	 D    &	 I    �� " ��.���  � �� �� " ��.R��� 
����ح�.+��� ���� $
 Name�$ {0:dddd dd.MM.yyyy}���� �� " ��.���  �@�OverridesDefaultStyle . ��  � ��$ 5q���  � �� �� " ��.R��� $��border��$��1q�$	 4,2q�
�������$ 3��#��z��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border�� � ��
 �   ��� "  .���  � ��
 �   � P� 
 �@ 
IsSelected . . ���  �@ IsCellSelected . P� 
 �@ 
IsSelected .  . ���  �@ IsCellSelected .        .��� .+��� .+��  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�9� $��0�� 9� 
IsExpanded �� *IsExpandedAll+�� 
�������$��1������ *AcceptSchedule+.��Accept Schedule�� 
�������$��2���� $��Center=�$��Center=�$��2������ $ Caption� �� Mode$ TwoWay=� �� RelativeSource ��  �� AncestorType" >��� -   $��3��$��20������ .R��� $��Right=�$��RightToLeft=�$,��&pack://application:,,,/Icons/close.png����  �� Orientation$ 
Horizontal=�.+�&   System.Windows.Controls.DataGrid  -     Name$ dgSchedules��$��1��   AutoGenerateColumns .  
�������   HeadersVisibility$	 All=�   CanUserResizeColumns .     CanUserResizeRows .     RowHeaderWidth$ 0Q�$	��500��   SelectionUnit$
 Cell=�   SelectionMode$ Extended=�   CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .   �� SelectedItem �� *DgSelectedScheduleDetail+$ TwoWay=�  �� UpdateSourceTrigger$  Default=����� )  #System.Windows.Controls.DataGridRow"   P� 
 �@ IsCellSelected . . ���  � ��$ 2q���  � ��
 � � �!   Columns! 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn" 	  
IsReadOnly" . # 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	# 150
 $ 	  	CellStyle#$ [ % 	  Header$	% Day��1  +System.Windows.Controls.DataGridBoundColumn&   Binding& �� *Day+$ {0:dddd dd.MM.yyyy}��  ' 	  
Visibility$' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col1+$ TwoWay=�$  	LostFocus=�(   ElementStyle( �� " ��.���  � �� `� ) `� 	Converter#) [ .1��� $
 Col1�$ TwoWay=��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col2+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col2��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col3+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col3��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col4+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col4��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col5+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col5��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col6+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col6��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col7+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col7��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col8+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col8��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col9+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $
 Col9��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col10+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col10��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col11+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col11��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col12+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col12��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col13+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col13��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col14+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col14��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col15+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col15��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col16+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col16��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col17+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col17��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col18+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col18��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col19+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col19��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col20+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col20��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col21+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col21��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col22+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col22��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col23+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col23��� $ 	Group_Ref�  $' 	Collapsed=�$# 50
 #$ [ $	% Day��& �� *Col24+$ TwoWay=�$  	LostFocus=�( �� " ��.���  � �� `� #) [ .1��� $ Col24��� $ 	Group_Ref�4  .System.Windows.Controls.DataGridComboBoxColumn  $	# 100
 *   DisplayMemberPath$* Description��+   SelectedValuePath$+ 	Group_Ref��$% Worker��,   SelectedValueBinding, �� *	Group_Ref+$ TwoWay=�-   ElementStyle- �� " ��.���  � �� �� $  DataContext.ScheduleGroups� �� " >�.   EditingElementStyle. �� " ��.���  � �� �� $  DataContext.ScheduleGroups� �� " >�/ J� InputBindings/ d� 0 d� Gesture$0 LeftDoubleClicka�1 �� Command1 �� $" DataContext.EmployeePickList� �� " >�2 � ContextMenu2 �� .@�m� -   $��Delete��m� -   $��Insert��m� -   $
��Copy��m� -   $��Paste��m� -   ���� *
CopyText+$ TwoWay=�m� -   ���� *	PasteText+$ TwoWay=�m� -	   $��	Copy week��m� -
   $��	Past week��3 �� 
GroupStyle3 (  "System.Windows.Controls.GroupStyle  4   ContainerStyle4 �� " ��.���  � �� �� " ��.R�9�  . ��]� .+��� $
��Bold"�$��5,0,0,0q����� $
 Name�$ {0:dddd dd.MM.yyyy}������ � .+�!   Scheduler.Controls.PickList  -   5  Name$5 empPL��$y�	Collapsed=�