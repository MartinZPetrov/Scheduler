   M S B A M L   `   `   `  ����D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Scheduler	Scheduler  5           Scheduler.Views.GroupsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Scheduler     5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � DataContext  5	      �� *Groups+   Locator �� Source# [  .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Left=�6   .@�5      �� -   5         ��Name$ tiEdit��5   $   $
��Edit��6   .��5      � $	��345��6    5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5!      �� $��Right=�6    $��4q�6<   $��Description:��6G   �� 5"      $
��Left=�6   $��1��6:   $��23��5#       �� TextWrapping$
 Wrap=�6   $��4q�6'   $	��Top=�5$      $	��240��6   ��5"   J   �� *20WorkAliasCollection.View.CurrentItem.Description+ �� Mode$ TwoWay=�5$      �� 5&      $��Right=�6    $��0��6<   $��1��6L   $��4q�6Z   $��Color:��6e   #  Xceed.Wpf.Toolkit.ColorPicker  5'      -   5          Name$ ClrPcker_Background��5'   '   $��4q�6D   $��1��6O   $	��200��6\   $
��Left=�6h   $��1��5(   i   5*      5+      �� 5,      $
��List��6   .��5-      � -   5        $ 
grdContent��5-   $   $	��152��6   $	��345��68   
������� 5.      �� 5/      $��* �6+   �� 50      $
��Auto �6,   .+�52      &   System.Windows.Controls.DataGrid  	   AutoGenerateColumns	 .  
�������
   HeadersVisibility$
 Column=�54         SelectionMode$ Single=�56         CanUserResizeColumns .     CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .  ��53      �� *WorkAliasCollection.Source+ �� SelectedItem 55      �� *SelectedGroup+$ TwoWay=�   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 5>   	      Header$ Description��5?   	   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5=   	   �� *Description+$ TwoWay=�5?   	     5A      $ Color��61   $ 45 6@    .    	CellStyle 5B   "   �� 5C   &    �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6,   .�5D   *   ��  �� Property � �� �� Value 6G   �� *Color+$ TwoWay=�5E   '   5G      5I      5K      5L      �� 5M      -   5        $ 
employeePL��5M      $��	Employees��6*   $y�Hidden=�6=   .��5N      �� .+�5O      �� -   5         ��Name$ 	listView1��5Q      $	��152��5O      $
��Left=�5P      $	��Top=�5S      $	��345��5T      ��5U      �� *EmployeesCollection+ �� View 5X      �� 5Y      .P�5Z   "   ��  �� CellTemplate 5[   &   �� 5\   *   .R�5]   .   ��  d� 	IsChecked 68   ��  �� RelativeSource ��  �� AncestorType" ��  �� Path$  
IsSelected�5^   +   5`   #   �� 5a   "   $��
First Name��6\   ! �� DisplayMemberBinding! 61   �� *	FirstName+6\   �� 5b   "   $��	Last Name��6[   ! 61   �� *
LastName+6[   �� 5c   "   $��Active��61    5d   &   �� 5e   *   .R�5f   .   ��  67   �� *
IsActive+5g   +   5i   #   5j      5l      �� 5m      $��80��6   $��40��6(   $
��Left=�6a   
�������$��Accept��6�   ��64   �� *SelectedEmployeesCommand+6�   5n      5o      5p      � 5r   
   $
��Auto��6   $	��345��6   
�������$��4��6<    5s      �� 5t      �� 5u      .+�5x        -   5        "  Name$" 
dgEmployee��5z      	 .  
�������$	��200��5y      #   
IsReadOnly# . $
 Column=�5}      $ Single=�5~       .   .   .   .  $��-2,0,2,0q�5�      ��5|      �� *SelectedEmployeesCollection+ 5      �� *DgSelectedEmployee+$ TwoWay=� 5�        5�       . $	 150 5�      $ 
First Name��5�       5�      �� *	FirstName+$ TwoWay=�5�        5�       . $	 200 5�      $ 	Last Name��5�       5�      �� *
LastName+$ TwoWay=�5�      5�      �� 5�      
������ $��1��5�      $��12(�5�      $
��Bold"�6   ��.  ��5�      �� *
Commands+$ TwoWay=���5�      �� 5�      .R�5�      �� $��RightToLeft=�6%   $ �� Orientation$$ 
Horizontal=�6A   5�      ��5�      �� 5�      .R�5�      ��   ActionButton#��[ 6!   $��0q�5�      $��0q�5�      $��0q�6   ��5�   G   �� *Send+% � ToolTip% 5�      �� 5�   "   ��6,   �� *CommandDisplay+.��5�      �� ��6$   �� *Icon+5�      5�      5�      5�      5�      5�      