   M S B A M L   `   `   `  ����B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter2WPFTest.UI.Chapter2  5      'clr-namespace:WPFTest.UI
WPFTest.UI  5           WPFTest.UI.Chapter2.C2_SY1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFTest.UI.Chapter2     5      )baseclr-namespace:WPFTest.UI     5        N� Title$  实验：调用托管dll��5
      .��5      � $��Stretch=�6   $��0q�6*   $��Stretch=�65    � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��* �6   6)   �� 5      $��40 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��120 �6   6-   �� 5      $	��240 �6   6-   �� 5      $��* �6   6+   �� 5      $	��120 �6   6-   .+�5   
   �� -   5         ��Name$ label1��5      $��0��6    $��0��6-   $��	求阶乘��6=   $��Stretch=�6M   $��Center=�6k   $
��Left=�6�   $��0,0,0,0q�6�   �� 5   
   -   5         ��Name$ textBox1��5      $��0��6%   $��1��62   $��1��6B   $
��Left=�6V   $��30��6q   $	��120��6~    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $��Center=�6�   �� 5   
   -   5        $ label2��5      $��0��6    $��1��6-   $��=��6=   $
��Left=�6K   $��30��6f   $	��120��6s   $��Center=�6   $
��Left=�6�   $��	120,0,0,0q�6�   �� 5    
   -   5        $ textBox2��5       $��0��6%   $��2��62   $��1��6B   $
��Left=�6V   $��30��6q   $	��120��6~   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   �� 5!   
   -   5         ��Name$
 btn1��5!      $��0��6   $��3��6,   $��调用dll计算��6<   $��Center=�6Q   $��Center=�6o   $	��100��6�   $��30��6�   6�   �� 5#   
   -   5        $ label3��5#      $��1��6    $��0��6-   $��斐波那契数��6=   $��Stretch=�6O   $��Center=�6m   $
��Left=�6�   $��0,0,0,0q�6�   �� 5$   
   -   5        $ textBox3��5$      $��1��6%   $��1��62   $��1��6B   $
��Left=�6V   $��30��6q   $	��120��6~   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   �� 5%   
   -   5        $ label4��5%      $��1��6    $��1��6-   $��=��6=   $
��Left=�6K   $��30��6f   $	��120��6s   $��Center=�6   $
��Left=�6�   $��	120,0,0,0q�6�   �� 5&   
   -	   5        $ textBox4��5&      $��1��6%   $��2��62   $��1��6B   $
��Left=�6V   $��30��6q   $	��120��6~   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   �� 5'   
   -
   5        $
 btn2��5'      $��1��6   $��3��6,   $��调用dll计算��6<   $��Center=�6Q   $��Center=�6o   $	��100��6�   $��30��6�   6�   �� 5)   
   -   5        $ label11��5)      $��2��6!   $��0��6.   $��给某某打招呼��6>   $��Stretch=�6Q   $��Center=�6o   $
��Left=�6�   $��0,0,0,0q�6�   �� 5*   
   -   5        $ 	textBox11��5*      $��2��6&   $��1��63   $��1��6C   $
��Left=�6W   $��30��6r   $	��120��6   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   �� 5+   
   -   5        $ label12��5+      $��2��6!   $��1��6.   $��=��6>   $
��Left=�6L   $��30��6g   $	��120��6t   $��Center=�6�   $
��Left=�6�   $��	120,0,0,0q�6�   �� 5,   
   -   5        $ 	textBox12��5,      $��2��6&   $��2��63   $��1��6C   $
��Left=�6W   $��30��6r   $	��120��6   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   �� 5-   
   -   5        $ btn11��5-      $��2��6    $��3��6-   $��调用dll计算��6=   $��Center=�6R   $��Center=�6p   $	��100��6�   $��30��6�   6�   �� 50   
   -   5        $ label5��50      $��3��6    $��0��6-   $��列举dll中函数��6=   $��Stretch=�6R   $��Center=�6p   $
��Left=�6�   $��0,0,0,0q�6�   �� 51   
   -   5        $
 btn3��51      $��3��6   $��3��6,   $��通过反射机制得到��6<   $��Center=�6R   $��Center=�6p   $	��100��6�   $��30��6�   6�   �� 53   
   -   5         ��Name$ listBox1��53      $��4��6%   $��0��62   $��3��6B   $��Stretch=�6V   $	��300��6t   $��	10,10,0,0q�6�   $	��Top=�6�   �� 55   
   -   5        $ label21��55      $��5��6!   $��0��6.   $��减法��6>   $��Stretch=�6M   $��Center=�6k   $
��Left=�6�   $��0,0,0,0q�6�   �� 56   
   -   5        $ 	textBox21��56      $��5��6&   $��1��63   $��1��6C   $
��Left=�6W   $��30��6r   $��87��6   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��0,5q�6�   �� 57   
   -   5        $ label22��57      $��5��6!   $��1��6.   $��-��6>   $��Stretch=�6L   $��Center=�6j   $
��Left=�6�   $��
89,6,122,9q�6�    J� RenderTransformOrigin$ 
-0.724,0.6&�6�   �� 58   
   -   5        $ 	textBox22��58      $��5��6&   $��1��63   $
��Left=�6C   $��30��6^   $��72��6k   $
 Wrap=�6v   $�� ��6�   $��Center=�6�   $��	123,4,0,6q�6�   $ 1.191,0.633&�6�   �� 5:   
   -   5        $ label23��5:      $��5��6!   $��1��6.   $��=��6>   $
��Left=�6L   $��30��6g   $��45��6t   $��Center=�6   $
��Left=�6�   $��	195,5,0,5q�6�   $ 0.675,0.467&�6�   �� 5;   
   -   5        $ 	textBox23��5;      $��5��6&   $��2��63   $��1��6C   $
��Left=�6W   $��30��6r   $	��430��6   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��0,5q�6�   �� 5<   
   -   5        $ btn21��5<      $��5��6    $��3��6-   $��调用dll计算��6=   $��Center=�6R   $��Center=�6p   $	��100��6�   $��30��6�   6�   5>      5?      