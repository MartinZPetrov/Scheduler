   M S B A M L   `   `   `  ����   	Scheduler    Scheduler.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  	Scheduler��$	��450��$	��525�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � DataContext �� *Main+   Locator �� Source# [   � 	Resources   FadeUIMessage �� 
TargetName �� TargetProperty W� From		 W� To
 g� Duration��%]   &	       �� .��W� $ 	UIMessage��$ (TextBlock.Opacity)�$ 1X�$	 0X�$
 0:0:6D�.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $
��Left=�.@��� $
��Home��$��10(�.���� -    ��Name$ 	ribbonBar��
������ $��12(�$
��Bold"���.  ���� *Views+ �� Mode$ TwoWay=����� .R���  �� Orientation$ 
Horizontal=����� .R��� $��0q�$��20��$	��100��  LightBrightGradientBrush#��[   DarkDullBrush#��[ ���� *
Navigate+$ TwoWay=�.����  �� TextAlignment$ Center=����� *ViewDisplay+�� $
��Edit��$��10(�.���� 
������ $��12(�$
��Bold"���.  ���� *
Commands+$ TwoWay=����� .R��� $ 
Horizontal=����� .R���   ActionButton#��[ $��0q�$��0q�$��0q����� *Send+.���� ���� *Icon+ � ToolTip �� ���� *CommandDisplay+�� -    ��Name$ 	UIMessage��$�� ��$��Right=�$	��Top=�$��0,0,8,0q�  DarkBrightBrush#��[  � -     �Name$ 	EditFrame��$��1��$��Center=�$��Center=�  � NavigationUIVisibility$ Hidden=�