   M S B A M L   `   `   `  ����B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter6WPFTest.UI.Chapter6  5      'clr-namespace:WPFTest.UI
WPFTest.UI  5      *    $WPFTest.UI.Chapter6.RoomTypeListPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFTest.UI.Chapter6     5      )baseclr-namespace:WPFTest.UI     5         WPFTest.UI.ChildPage    Loaded$  ChildPage_Loaded_1��5
       N� Title$ 房型列表��6   .��5      � $��Stretch=�6   $��0q�6*   $��Stretch=�65    � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      $��* �6   6+   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   .+�5   
   �� -   5         ��Name$ label1��5      $��0��6    $��0��6-   $��房型列表��6=   $��Stretch=�6M   $��Center=�6k   $
��Left=�6�   $��0,0,0,0q�6�   �� 5$   
   -   5         ��Name$
 show��5$      $��0��6   $��5��6,   $��显示房号��6=   $��Center=�6L   $��Center=�6j   $��80��6�   $��30��6�   6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ dataGrid��5'      $��Center=�6%   $��Center=�6I   $��1��6k   $��6��6x   $��Stretch=�6�   $��0q�6�   $��Stretch=�6�      EnableRowVirtualization .     
IsReadOnly . 	 �� AlternationCount$	 2��5(      
   AutoGenerateColumns
 .     CanUserResizeColumns .     CanUserResizeRows .     SelectionMode$ Single=�6y      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ 房型编号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *type+  5-      $ 房型名称��6%   $ * 63    6=   �� *description+  5/      $ 房型特征��6%   $ * 63    6=   �� *	remarks+  50      $ 房型价格��6%   $ * 63    6=   �� *price+54      �� 56   
   -   5        $ label2��56      $��2��6    $��0��6-   $��房号列表��6=   $��Stretch=�6M   $��Center=�6k   $
��Left=�6�   $��0,0,0,0q�6�     57   
   -   5        $ 	dataGrid2��57      $��Center=�6&   $��Center=�6J   $��3��6l   $��6��6y   $��Stretch=�6�   $��0q�6�   $��Stretch=�6�    .   . $	 2��58      
 .   .   .  $ Single=�6y    5:        5<      $ 房型编号��6%   $ * 63    6=   �� *	type.type+  5>      $ 房号��6%   $ * 61    6;   �� *
roomNumber+  5?      $ 所在地址��6%   $ * 63    6=   �� *
location+  5@      $ 说明��6%   $ * 61    6;   �� *
comments+  5A      $ 房价��6%   $ * 61    6;   �� *price+5D      5E      5F      