   M S B A M L   `   `   `  ����  	Scheduler    Scheduler.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	Scheduler��5   	   $	��450��6   $	��525��6(    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � DataContext 5   	   �� *Main+   Locator �� Source# [   � 	Resources 5	        FadeUIMessage �� 
TargetName �� TargetProperty W� From		 W� To
 g� Duration��%�   &	       �� 5
   
   .��5      W� $ 	UIMessage��5      $ (TextBlock.Opacity)�5      $ 1X�5      $	 0X�6   $
 0:0:6D�6!   5      5      .��5      �� $
��Auto=�6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Left=�6   .@�5      �� $
��Home��6   $��10(�6$   .��5      �� -   5         ��Name$ 	ribbonBar��5      
������ $��12(�6s   $
��Bold"�6�   ��.  ��6.   �� *Views+ �� Mode$ TwoWay=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   6D   5      ��5!      �� 5"      .R�5$      �� $��0q�5%   )   $��20��6=   $	��100��6I     LightBrightGradientBrush#��[ 5&   )     DarkDullBrush#��[ 5'   )   ��5$   %   �� *
Navigate+$ TwoWay=�.��5)   "   ��  �� TextAlignment$ Center=�5*   ,   ��5)   ,   �� *ViewDisplay+5*   ,   5+      5,      5.      5/      �� 50      $
��Edit��6   $��10(�6%   .��51      �� 
������ $��12(�6c   $
��Bold"�6q   ��.  ��6   �� *
Commands+$ TwoWay=���53      �� 54      .R�55      �� $ 
Horizontal=�6)   56      ��58      �� 59      .R�5:      ��   ActionButton#��[ 6%   $��0q�5;   )   $��0q�5<   )   $��0q�64   ��5:   K   �� *Send+.��5=   "   �� ��6(   �� *Icon+ � ToolTip 5>      �� 5?   &   ��60   �� *CommandDisplay+5A      5B      5D      5E      5F      �� 5G   
   -   5         ��Name$ 	UIMessage��5G      $�� ��6'   $��Right=�6/   $	��Top=�6K   $��0,0,8,0q�6c     DarkBrightBrush#��[ 6t    � 5H   
   -   5          �Name$ 	EditFrame��5H      $��1��6#   $��Center=�60   $��Center=�6K     � NavigationUIVisibility$ Hidden=�6h   6�   5J      5K      5L      