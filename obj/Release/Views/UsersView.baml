   M S B A M L   `   `   `  ����   	Scheduler    Scheduler.Views.UsersView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � DataContext  �� *Users+   Locator �� Source# [  .���  � RowDefinitions �� $
��Auto ��� $��* � � ColumnDefinitions .+��� $
��Left=�.@��� $
��Edit��.���  �� �� �� �� �� �� �� �� �� ��  �� $
��Auto ��� $��* �.+��� $��Right=�$��4q�$��First Name:���� $��1��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$��4q�$	��Top=�$	��240������ *0.WorkAliasCollection.View.CurrentItem.FirstName+ �� Mode$ TwoWay=��� $��Right=�$��1��$��4q�$��Surname:���� $
��Left=�$��1��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *.,WorkAliasCollection.View.CurrentItem.SurName+$ TwoWay=��� $��Right=�$��2��$��4q�$��
Last Name:���� $��Right=�$��2��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ */-WorkAliasCollection.View.CurrentItem.LastName+$ TwoWay=��� $��Right=�$��3��$��4q�$��E-Mail:���� -   $��Right=�$��3��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *+)WorkAliasCollection.View.CurrentItem.Mail+$ TwoWay=��� $��Right=�$��4��$��4q�$��Phone Number:���� $��Right=�$��4��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *20WorkAliasCollection.View.CurrentItem.PhoneNumber+$ TwoWay=��� $��Right=�$��5��$��4q�$��City:���� $��Right=�$��5��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *+)WorkAliasCollection.View.CurrentItem.City+$ TwoWay=��� $��Right=�$��6��$��4q�$��	Manager: ���� $��Center=�$��6��$��1��$��4q�$��Center=�$	��240�� d� 	IsChecked �� *0.WorkAliasCollection.View.CurrentItem.IsManager+$ TwoWay=��� $��Right=�$��7��$��4q�$��Active: ���� $��Center=�$��7��$��1��$��4q�$��Center=�$	��240�� �� */-WorkAliasCollection.View.CurrentItem.IsActive+$ TwoWay=��� $��Right=�$��8��$��4q�$��User Level: ��%  Xceed.Wpf.Toolkit.IntegerUpDown  $
��Left=�$��8��$��1��$��50��$��4q�$��Center=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *0.WorkAliasCollection.View.CurrentItem.UserLevel+�� $��Right=�$��9��$��4q�$��	Password:���� $��Right=�$��9��$��1��$��23��$
 Wrap=�$��4q�$	��Top=�$	��240������ *
Password+$ TwoWay=��� $
��List��.��� $	��262��$	��400��
�������.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .  
�������	   HeadersVisibility$	 Column=�
   SelectionMode$
 Single=�   CanUserResizeColumns .     CanUserAddRows .   J� 	AllowDrop .     CanUserDeleteRows .  ���� *WorkAliasCollection.Source+ �� SelectedItem �� *SelectedUser+$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    Header$ 	Firs Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	FirstName+$ TwoWay=�   . $	 100 $ 	Last Name�� �� *
LastName+$ TwoWay=�   . $	 133 $
 Mail�� �� *Mail+$ TwoWay=�   . $ 
User Level�� �� *	UserLevel+$ TwoWay=�