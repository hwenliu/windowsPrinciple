   M S B A M L   `   `   `  ����B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFTest.UI.IndexWPFTest.UI.Index  5      'clr-namespace:WPFTest.UI
WPFTest.UI  5      !    WPFTest.UI.Index.JzListPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:WPFTest.UI.Index     5      )baseclr-namespace:WPFTest.UI     5        N� Title$  
JzListPage��5
      .��5      � $��Stretch=�6   $��0q�6*   $��Stretch=�65    � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      $��* �6   6+   �� 5      $��80 �6   6,   �� 5      $��80 �6   6,   �� 5      $��80 �6   6,   .+�5   
   �� -   5         ��Name$ label1��5      $��0��6    $��0��6-   $#��在建：xx台，在役:xx台��6=   $��Stretch=�6Y   $��Center=�6w   $
��Left=�6�   $��0,0,0,0q�6�   �� 5   
   -   5         ��Name$	 new��5      $��0��6   $��2��6+   $��新建��6;   $��Center=�6H   $��Center=�6f   $��60��6�   $��30��6�   �� 5   
   -   5        $
 edit��5      $��0��6   $��3��6,   $��修改��6=   $��Center=�6J   $��Center=�6h   $��60��6�   $��30��6�   �� 5   
   -   5        $	 del��5      $��0��6   $��4��6+   $��删除��6<   $��Center=�6I   $��Center=�6g   $��60��6�   $��30��6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGrid��5!      $��Center=�6%   $��Center=�6I   $��1��6k   $��5��6x   $��Stretch=�6�   $��0q�6�   $��Stretch=�6�      EnableRowVirtualization .     
IsReadOnly . 5#      5$      5%      