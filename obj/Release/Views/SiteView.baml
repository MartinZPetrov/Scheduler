   M S B A M L   `   `   `  ���� D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Scheduler.ViewModelScheduler.ViewModel      Scheduler.Views.SiteView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  1	ViewModel!clr-namespace:Scheduler.ViewModel    � DataContext  �� *Sites+   Locator �� Source# [  .��� -    �Name$ 
LayoutRoot�� � RowDefinitions �� $
��Auto ��� $��* �.+��� $
��Left=�.@��� -    ��Name$ tiEdit��$
��Edit��.���  �� �� �� �� �� ��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��Right=�$��4q�$��Name:���� $��1��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$��4q�$	��Top=�$	��240������ *+)WorkAliasCollection.View.CurrentItem.Name+ �� Mode$ TwoWay=��� $��Right=�$��1��$��4q�$��Address:���� $
��Left=�$��1��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *.,WorkAliasCollection.View.CurrentItem.Address+$ TwoWay=��� $��Right=�$��2��$��4q�$��City:���� $��Right=�$��2��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *+)WorkAliasCollection.View.CurrentItem.City+$ TwoWay=��� $��Right=�$��4��$��4q�$��Phone Number:���� $��Right=�$��4��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *,*WorkAliasCollection.View.CurrentItem.Phone+$ TwoWay=��� $
��List��.��� -   $ 
grdContent��$	��152��$	��345��
�������.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .  
�������	   HeadersVisibility$	 Column=�
   SelectionMode$
 Single=�   CanUserResizeColumns .     CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .  ���� *WorkAliasCollection.Source+ �� SelectedItem �� *SelectedSite+$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 345    Header$
 Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+$ TwoWay=��� -   $ 
employeePL��$��	Employees��$y�Hidden=�.���� .+��� -    ��Name$ 	listView1��$	��152��$
��Left=�$	��Top=�$	��345������ *EmployeesCollection+ �� View �� .P���  �� CellTemplate �� .R���  d� 	IsChecked ��  �� RelativeSource ��  �� AncestorType" �� �� Path$ 
IsSelected��� $��
First Name�� �� DisplayMemberBinding �� *	FirstName+�� $��	Last Name�� �� *
LastName+�� $��Active�� �� .R���  �� *
IsActive+�� $��80��$��40��$
��Left=�
�������$��Accept������ *SelectedEmployeesCommand+� $
��Auto��$	��345��
�������$��4�� �� �� .+�  -     Name$ 
dgEmployee�� .  
�������$	��200��   
IsReadOnly . $	 Column=�$
 Single=� .   .   .   .  $��-2,0,2,0q����� *SelectedEmployeesCollection+ �� *DgSelectedEmployee+$ TwoWay=�    . $	 150 $ Employee First Name�� �� *	FirstName+$ TwoWay=�   . $	 200 $ Employee Last Name�� �� *
LastName+$ TwoWay=��� 
������ $��1��$��12(�$
��Bold"���.  ���� *
Commands+$ TwoWay=����� .R��� $��RightToLeft=� �� Orientation$ 
Horizontal=����� .R���   ActionButton#��[ $��0q�$��0q�$��0q����� *Send+  � ToolTip  �� ���� *CommandDisplay+.���� ���� *Icon+