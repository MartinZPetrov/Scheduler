   M S B A M L   `   `   `  ����D  @Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Scheduler.HelpersScheduler.Helpers  5      f bMicrosoft.Expression.Framework, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a�fclr-namespace:Microsoft.VisualStudio.PlatformUI.Shell.Controls;assembly=Microsoft.Expression.Framework0Microsoft.VisualStudio.PlatformUI.Shell.Controls 5          Scheduler.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -wclr-namespace:Scheduler.Helpers     5      {Controlsfclr-namespace:Microsoft.VisualStudio.PlatformUI.Shell.Controls;assembly=Microsoft.Expression.Framework     5      
�������  � 	Resources  5       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource��%�  '��       '�� �     �� 5   
   " ��6)    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� *.,(Validation.Errors).CurrentItem.ErrorContent+# Z 5      5      �� 5   
   " ��6*    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� *.,(Validation.Errors).CurrentItem.ErrorContent+# Z 5      5      5      	 � DataContext	 5      �� 5   
   
 �� Path$
 Login�6      Locator �� Source# [  6   .��5"      �  J� RenderTransformOrigin$ 0.627,0.442&�6   $��0,-2,0,2q�6/   .+�5$   
   �� -   5         ��Name$ tbUser��5$      $��User:��6%   $��0��62   $��0��6?   $��Right=�6O   $��Center=�6l   $��0,159,312,325q�6�   $ 1.061,1.946&�6�   �� 5%   
   -   5        $ 
tbPassword��5%      $��Password��6(   $��0��68   $��Right=�6H   $��Center=�6e   $��0,200,312,284q�6�   $ 	0.54,0.75&�6�   �� 5&   
   -   5        $ tbSite��5&      $
��Site��6$   $��0��60   $��Right=�6@   $��Center=�6]   $��0,244,312,240q�6x   $ 0.284,3.712&�6�   �� 5'   
   -   5         ��Name$ cboSite��5'      $��3��6$   
�������
�������$��0��5)   9   $	��200��6F   $��40��6R   $y�Visible=�5*      $��194,235,106,225q�6    �� SelectedItem 5(      �� *CurrentSite+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=� �� ValidatesOnDataErrors . ��5)      �� *SiteCollection+$ TwoWay=�5*      �� 5-   
   -   5         ��Name$ txtuser��5-      $��1��6#   $��0��60   $	��200��6=   $��40��6I   $y�Visible=�6U   $��194,145,106,315q�6j   ��5.      �� *
UserName+$ TwoWay=� . $ 	LostFocus=� . �� 59   
   -   5        $ txtUserPassword��59      $��2��6+   $	��200��68   $��40��5:      $y�Visible=�6   $��194,190,106,270q�6%   ��5;      �� *UserPassword+$ TwoWay=� . $ 	LostFocus=� . �� 5=   
   $��4��6   $��40��6   
�������$��Ok��5?      $��207,294,214,166q�6   $y�Visible=�6*   ��5>      �� *ProceedToLogin+5?   *   �� 5@   
   $��304,306,106,0q�6   $	��Top=�6+   $��90��6C   �� 5A      -   5        .�5A   1   Server Settings6C   5B      5C      5D      