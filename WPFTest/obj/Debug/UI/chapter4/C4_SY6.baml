   M S B A M L   `   `   `  ����B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter4WPFTest.UI.Chapter4  5      'clr-namespace:WPFTest.UI
WPFTest.UI  5           WPFTest.UI.Chapter4.C4_SY6   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFTest.UI.Chapter4     5      )baseclr-namespace:WPFTest.UI     5         WPFTest.UI.ChildPage    Loaded$  ChildPage_Loaded��5
       N� Title$! 实验：进程管道通信��6   4  .System.Windows.Automation.AutomationProperties   IsColumnHeader .  N� WindowTitle$  ��6^   .��5      � $��Stretch=�6   $��0q�6*   $��Stretch=�65    � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��180 �6   6-   �� 5      $��* �6   6+   �� 5      $	��180 �6   6-   .+�5   
   �� -   5         ��Name$ label1��5      $��0��6    $��0��6-   $��管道客户端��6=   $��Stretch=�6O   $��Center=�6m   $
��Left=�6�   $��24��6�   �� 5   
   -   5         ��Name$ textBox1��5      $��0��6%   $��1��62   $��Stretch=�6C   $��30��6a    �� TextWrapping$
 Wrap=�6n   $�� ��6�   $��Center=�6�   �� 5   
   -   5        	 ��Name$
	 btn1��5      $��0��6   $��2��6,   $��发送内容��6=   $��Center=�6L   $��Center=�6j   $	��150��6�   $��30��6�   6�   �� 5   
   -   5        $ label2��5      $��1��6    $��0��6-   $��管道服务器��6=   $��Stretch=�6O   $��Center=�6m   $
��Left=�6�   $��24��6�   �� 5   
   -   5        
 ��Name$
 listBox1��5      $��1��6%   $��1��62   $��2��6B   $��1��6S   $��Stretch=�6g   $��Stretch=�6�   � 5   
   $��2��6   $��2��6    5       �� 5!      $��30 �6    6.   �� 5"      $��30 �6    6.   �� 5#      $��30 �6    6.   �� 5$      $��30 �6    6.   �� 5%      $��30 �6    6.   �� 5&      $��30 �6    6.   �� 5'      $��30 �6    6.   �� 5(      $��30 �6    6.   �� 5)      $��30 �6    6.   �� 5*      $��30 �6    6.   �� 5+      $��* �6    6-   5.      50      51      