   M S B A M L   `   `   `  ���� D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Scheduler	Scheduler       Scheduler.Views.GroupsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:Scheduler     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � DataContext  �� *Groups+   Locator �� Source# [  .��� -    �Name$ 
LayoutRoot�� � RowDefinitions �� $
��Auto ��� $��* �.+��� $
��Left=�.@��� -    ��Name$ tiEdit��$
��Edit��.��� $	��345�� �� �� �� �� ��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��Right=�$��4q�$��Description:���� $
��Left=�$��1��$��23�� �� TextWrapping$
 Wrap=�$��4q�$	��Top=�$	��240������ *20WorkAliasCollection.View.CurrentItem.Description+ �� Mode$ TwoWay=��� $��Right=�$��0��$��1��$��4q�$��Color:��#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ ClrPcker_Background��$��4q�$��1��$	��200��$
��Left=�$��1���� $
��List��.��� -   $ 
grdContent��$	��152��$	��345��
������� �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  	   AutoGenerateColumns	 .  
�������
   HeadersVisibility$
 Column=�   SelectionMode$ Single=�   CanUserResizeColumns .     CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .  ���� *WorkAliasCollection.Source+ �� SelectedItem �� *SelectedGroup+$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 300    Header$ Description��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Description+$ TwoWay=�  $ Color��$ 45  .    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value �� *Color+$ TwoWay=��� -   $ 
employeePL��$��	Employees��$y�Hidden=�.���� .+��� -    ��Name$ 	listView1��$	��152��$
��Left=�$	��Top=�$	��345������ *EmployeesCollection+ �� View �� .P���  �� CellTemplate �� .R���  d� 	IsChecked ��  �� RelativeSource ��  �� AncestorType" ��  �� Path$  
IsSelected��� $��
First Name��! �� DisplayMemberBinding! �� *	FirstName+�� $��	Last Name��! �� *
LastName+�� $��Active�� �� .R���  �� *
IsActive+�� $��80��$��40��$
��Left=�
�������$��Accept������ *SelectedEmployeesCommand+� $
��Auto��$	��345��
�������$��4�� �� �� .+�  -   "  Name$" 
dgEmployee��	 .  
�������$	��200��#   
IsReadOnly# . $
 Column=�$ Single=� .   .   .   .  $��-2,0,2,0q����� *SelectedEmployeesCollection+ �� *DgSelectedEmployee+$ TwoWay=�    . $	 150 $ 
First Name�� �� *	FirstName+$ TwoWay=�   . $	 200 $ 	Last Name�� �� *
LastName+$ TwoWay=��� 
������ $��1��$��12(�$
��Bold"���.  ���� *
Commands+$ TwoWay=����� .R��� $��RightToLeft=�$ �� Orientation$$ 
Horizontal=����� .R���   ActionButton#��[ $��0q�$��0q�$��0q����� *Send+% � ToolTip% �� ���� *CommandDisplay+.���� ���� *Icon+