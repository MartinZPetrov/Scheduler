   M S B A M L   `   `   `  ���� D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scheduler.ControlsScheduler.Controls  %clr-namespace:Scheduler	Scheduler  "    Scheduler.Views.ScheduleView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  +ctrl clr-namespace:Scheduler.Controls  #localclr-namespace:Scheduler    � DataContext  �� *	Schedules+   Locator �� Source# [   � 	Resources   GroupHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Path �� StringFormat  MonthButton	 �� Padding
 �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  	CellStyle*  $System.Windows.Controls.DataGridCell �� Triggers%   Scheduler.ValueToBrushConverter  ValueToBrushConverter'   !Scheduler.BooleanToBrushConverter  BoleanToBrushConverter��%)  &	       &	 v     &	 �    &	 �    &	 �    �� " ��.���  � �� �� " ��.R��� 
����ح�.+��� ���� $
 Name�$ {0:dddd dd.MM.yyyy}���� �� " ��.���  �@�OverridesDefaultStyle . ��  � ��$ 5q���  � �� �� " ��.R��� $��border��$��1q�$		 4,2q�
�������$
 3��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � ��
 �   ��� "  .���  � ��
 �   � P�  �@ 
IsSelected . . ���  � �� Z�     .��� -    �Name$ 
LayoutRoot�� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $
��Left=�$��1��$��1��.@��� -    ��Name$ tiEdit��$
��View��.���  �� �� �� �� �� �� ��  �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Right=�$��4q�$��Year:��%  Xceed.Wpf.Toolkit.IntegerUpDown  -   $
��Left=�$��1��$��4q�$��Center=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *CurrentSelectedYear+ �� Mode$ TwoWay=��� $��Right=�$��4q�$��1��$��Start Time:��&   Xceed.Wpf.Toolkit.DateTimeUpDown  $��1��$��1��   Format$ Custom=�   FormatString$ HH��$��4q��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *	StartTime+�� $��Right=�$��4q�$��2��$��	End Time:��  $��2��$��1��$ Custom=�$ HH��$��4q� �� *	EndTime+�� -   $��3��#��[ $��70��$��50��$��5q�$��January������ *AcceptedSchedules[0]+ �� 	Converter# [ ���� *CreateSheduleJan+ � ToolTip _� .���� .+���  �� Orientation$ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[0]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[0]+�� $��3��#��[ $��1��$��70��$��50��$��5q�$��February������ *AcceptedSchedules[1]+# [ ���� *CreateSheduleFeb+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[1]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[1]+�� $��3��#��[ $��2��$��70��$��50��$��5q�$��March������ *AcceptedSchedules[2]+# [ ���� *CreateSheduleMar+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[2]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[2]+�� $��3��#��[ $��3��$��70��$��50��$��5q�$��April������ *AcceptedSchedules[3]+# [ ���� *CreateSheduleApr+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[3]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[3]+�� $��4��#��[ $��0��$��70��$��50��$��5q�$	��May������ *AcceptedSchedules[4]+# [ ���� *CreateSheduleMay+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[4]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[4]+�� $��4��#��[ $��1��$��70��$��50��$��5q�$
��June������ *AcceptedSchedules[5]+# [ ���� *CreateSheduleJun+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[5]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[5]+�� $��4��#��[ $��2��$��70��$��50��$��5q�$
��July������ *AcceptedSchedules[6]+# [ ���� *CreateSheduleJul+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[6]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[6]+�� $��4��#��[ $��3��$��70��$��50��$��5q�$��August������ *AcceptedSchedules[7]+# [ ���� *CreateSheduleAug+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[7]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[7]+�� $��5��#��[ $��0��$��70��$��50��$��5q�$��	September������ *AcceptedSchedules[8]+# [ ���� *CreateSheduleSep+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[8]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[8]+�� $��5��#��[ $��1��$��70��$��50��$��5q�$��October������ *AcceptedSchedules[9]+# [ ���� *CreateSheduleOct+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[9]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[9]+�� $��5��#��[ $��2��$��70��$��50��$��5q�$��November������ *AcceptedSchedules[10]+# [ ���� *CreateSheduleNov+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[10]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[10]+�� $��5��#��[ $��3��$��70��$��50��$��5q�$��December������ *AcceptedSchedules[11]+# [ ���� *CreateSheduleDec+ _� .���� .+��� $ 
Horizontal=�.+��� $
��Bold"�Start Time:�� ���� *StartTimeText[11]+�� $ 
Horizontal=�.+��� $
��Bold"�	End Time:�� ���� *EndTimeText[11]+� $��0��$��0�� K� ZIndex$
 1000��.+�(   "Scheduler.Controls.ScheduleControl  -     Name$ ctrlScheduleJan��   MonthSchedule$ 1��$y�	Collapsed=�� $��1��$��0��$
 1000��.+�  -   $ ctrlScheduleFeb��$ 2��$y�	Collapsed=�� $��2��$��0��$
 1000��.+�  -   $ ctrlScheduleMarch��$ 3��$y�	Collapsed=�� $��0��$��0��$
 1000��.+�  -   $ ctrlScheduleApr��$ 4��$y�	Collapsed=�� $��1��$��1��$
 1000��.+�  -	   $ ctrlScheduleMay��$ 5��$y�	Collapsed=�� $��2��$��1��$
 1000��.+�  -
   $ ctrlScheduleJun��$ 6��$y�	Collapsed=�� $��0��$��1��$
 1000��.+�  -   $ ctrlScheduleJul��$ 7��$y�	Collapsed=�� $��1��$��1��$
 1000��.+�  -   $ ctrlScheduleAug��$ 8��$y�	Collapsed=�� $��2��$��2��$
 1000��.+�  -   $ ctrlScheduleSep��$ 9��$y�	Collapsed=�� $��0��$��2��$
 1000��.+�  -   $ ctrlScheduleOct��$ 10��$y�	Collapsed=�� $��1��$��2��$
 1000��.+�  -   $ ctrlScheduleNov��$ 11��$y�	Collapsed=�� $��2��$��2��$
 1000��.+�  -   $ ctrlScheduleDec��$ 12��$y�	Collapsed=�