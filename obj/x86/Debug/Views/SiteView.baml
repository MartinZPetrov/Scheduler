   M S B A M L   `   `   `  ����D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Scheduler.ViewModelScheduler.ViewModel  5          Scheduler.Views.SiteView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      1	ViewModel!clr-namespace:Scheduler.ViewModel  5        � DataContext  5	      �� *Sites+   Locator �� Source# [  .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Left=�6   .@�5      �� -   5         ��Name$ tiEdit��5   $   $
��Edit��6   .��5      �  5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5       �� $��Right=�6    $��4q�6<   $��Name:��6G   �� 5!      $��1��6   $
��Left=�5"      $��23��6"    �� TextWrapping$
 Wrap=�6.   $��4q�6B   $	��Top=�5#      $	��240��6   ��5!   .   �� *+)WorkAliasCollection.View.CurrentItem.Name+ �� Mode$ TwoWay=�5#      �� 5%      $��Right=�6    $��1��6<   $��4q�6I   $��Address:��6T   �� 5&      $
��Left=�6   $��1��6:   $��1��6H   $��23��5'      $
 Wrap=�6   $��4q�6'   $	��Top=�5(      $	��240��6   ��5&   X   �� *.,WorkAliasCollection.View.CurrentItem.Address+$ TwoWay=�5(      �� 5*      $��Right=�6    $��2��6<   $��4q�6I   $��City:��6T   �� 5+      $��Right=�6   $��2��6;   $��1��6I   $��23��5,      $
 Wrap=�6   $��4q�6'   $	��Top=�5-      $	��240��6   ��5+   Y   �� *+)WorkAliasCollection.View.CurrentItem.City+$ TwoWay=�5-      �� 50      $��Right=�6    $��4��6<   $��4q�6I   $��Phone Number:��6T   �� 51      $��Right=�6   $��4��6;   $��1��6I   $��23��53      $
 Wrap=�6   $��4q�6'   $	��Top=�54      $	��240��6   ��52      �� *,*WorkAliasCollection.View.CurrentItem.Phone+$ TwoWay=�54      55      56      �� 57      $
��List��6   .��58      � -   5        $ 
grdContent��58   $   $	��152��6   $	��345��68   
�������.+�59      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  
�������	   HeadersVisibility$	 Column=�5;      
   SelectionMode$
 Single=�5=         CanUserResizeColumns .     CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .  ��5:      �� *WorkAliasCollection.Source+ �� SelectedItem 5<      �� *SelectedSite+$ TwoWay=�   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 345 5E   	      Header$
 Name��5F   	   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5D   	   �� *Name+$ TwoWay=�5F   	   5H      5I      5J      �� 5K      -   5        $ 
employeePL��5K      $��	Employees��6*   $y�Hidden=�6=   .��5L      �� .+�5M      �� -   5         ��Name$ 	listView1��5O      $	��152��5M      $
��Left=�5N      $	��Top=�5Q      $	��345��5R      ��5S      �� *EmployeesCollection+ �� View 5V      �� 5W      .P�5X   "   ��  �� CellTemplate 5Y   &   �� 5Z   *   .R�5[   .   ��  d� 	IsChecked 68   ��  �� RelativeSource ��  �� AncestorType" �� �� Path$ 
IsSelected�5\   +   5^   #   �� 5_   "   $��
First Name��6\    �� DisplayMemberBinding 61   �� *	FirstName+6\   �� 5`   "   $��	Last Name��6[    61   �� *
LastName+6[   �� 5a   "   $��Active��61    5b   &   �� 5c   *   .R�5d   .   ��  67   �� *
IsActive+5e   +   5g   #   5h      5j      �� 5k      $��80��6   $��40��6(   $
��Left=�6a   
�������$��Accept��6�   ��64   �� *SelectedEmployeesCommand+6�   5l      5m      5n      � 5o   
   $
��Auto��6   $	��345��6   
�������$��4��6<    5p      �� 5q      �� 5r      .+�5u        -   5          Name$ 
dgEmployee��5w       .  
�������$	��200��5v         
IsReadOnly . $	 Column=�5z      $
 Single=�5{       .   .   .   .  $��-2,0,2,0q�5�      ��5y      �� *SelectedEmployeesCollection+ 5|      �� *DgSelectedEmployee+$ TwoWay=� 5�        5�       . $	 150 5�      $ Employee First Name��5�       5�      �� *	FirstName+$ TwoWay=�5�        5�       . $	 200 5�      $ Employee Last Name��5�       5�      �� *
LastName+$ TwoWay=�5�      5�      �� 5�      
������ $��1��5�      $��12(�5�      $
��Bold"�6   ��.  ��5�      �� *
Commands+$ TwoWay=���5�      �� 5�      .R�5�      �� $��RightToLeft=�6%    �� Orientation$ 
Horizontal=�6A   5�      ��5�      �� 5�      .R�5�      ��   ActionButton#��[ 6!   $��0q�5�      $��0q�5�      $��0q�6   ��5�   G   �� *Send+  � ToolTip  5�      �� 5�   "   ��6,   �� *CommandDisplay+.��5�      �� ��6$   �� *Icon+5�      5�      5�      5�      5�      5�      