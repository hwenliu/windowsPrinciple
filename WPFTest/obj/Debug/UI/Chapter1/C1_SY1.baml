   M S B A M L   `   `   `  ����B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter1WPFTest.UI.Chapter1  5      'clr-namespace:WPFTest.UI
WPFTest.UI  5           WPFTest.UI.Chapter1.C1_SY1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFTest.UI.Chapter1     5      )baseclr-namespace:WPFTest.UI     5        N� Title$  实验：汉字处理��5
      .��5      � $��Stretch=�6   $��0q�6*   $��Stretch=�65    � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��120 �6   6-   �� 5      $��* �6   6+   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   .+�5   
   �� -   5         ��Name$ label1��5      $��0��6    $��0��6-   $��输入汉字��6=   $��Stretch=�6N   $��Center=�6l   $
��Left=�6�   $��0,0,0,0q�6�   �� 5   
   -   5         ��Name$
 btn1��5      $��0��6   $��2��6,   $��获得拼音��6<   $��Center=�6N   $��Center=�6l   $	��100��6�   $��30��6�   6�   �� 5   
   -   5        $
 btn2��5      $��0��6   $��3��6,   $��简体->繁体��6=   $��Center=�6N   $��Center=�6l   $	��100��6�   $��30��6�   6�   �� 5   
   -   5        $
 btn3��5      $��0��6   $��4��6,   $��繁体->简体��6=   $��Center=�6N   $��Center=�6l   $	��100��6�   $��30��6�   6�   �� 5    
   -   5        $
 btn4��5       $��0��6   $��5��6,   $��文本->发音��6=   $��Center=�6N   $��Center=�6l   $	��100��6�   $��30��6�   6�   �� 5"   
   -   5         ��Name$ textBox��5"      $��1��6$   $��0��61   $��2��6A   $��Stretch=�6U   $��30��6s   $��10,6,0,0q�6    �� TextWrapping$
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   �� 5#   
   -   5         ��Name$ listBox��5#      $��2��6$   $��0��61   $��2��6A   $��Stretch=�6U   $	��300��6s   $��	10,10,0,0q�6�   $	��Top=�6�   5%      5&      