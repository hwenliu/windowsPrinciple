   M S B A M L   `   `   `  ���� B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter2WPFTest.UI.Chapter2  'clr-namespace:WPFTest.UI
WPFTest.UI       WPFTest.UI.Chapter2.C2_SY2   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WPFTest.UI.Chapter2     )baseclr-namespace:WPFTest.UI       N� Title$  实验：调用c++dll��.��� $��Stretch=�$��0q�$��Stretch=� � RowDefinitions �� $��40 ��� $��40 ��� $��40 ��� $��* � � ColumnDefinitions �� $	��120 ��� $	��300 ��� �� $	��120 �.+��� -    ��Name$ label1��$��0��$��0��$��求和��$��Stretch=�$��Center=�$
��Left=�$	��0,8q�$��24���� -    ��Name$ textBox1��$��0��$��1��$��1��$
��Left=�$��30��$	��120�� �� TextWrapping$
 Wrap=�$�� ��$��Center=�$	��0,5q��� -   $ label2��$��0��$��1��$��+��$
��Left=�$��30��$��30��$��Center=�$
��Left=�$��	120,5,0,5q��� -   $ textBox2��$��0��$��1��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=�$��	160,5,0,5q��� -   $ label3��$��0��$��2��$��=��$
��Left=�$��30��$	��120��$��Center=�$
��Left=��� -   $ textBox3��$��0��$��2��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=�$��	120,0,0,0q��� -    ��Name$
 btn1��$��0��$��3��$��求和��$��Center=�$��Center=�$	��100��$��30��$
��10,5q��� -   $ label5��$��1��$��0��$��	求乘积��$��Stretch=�$��Center=�$
��Left=�$	��0,8q�$��24���� -	   $ textBox5��$��1��$��1��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=�$	��0,5q��� -
   $ label6��$��1��$��1��$��*��$
��Left=�$��30��$��30��$��Center=�$
��Left=�$��	120,5,0,5q��� -   $ textBox6��$��1��$��1��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=�$��	160,5,0,5q��� -   $ label7��$��1��$��2��$��=��$
��Left=�$��30��$	��120��$��Center=�$
��Left=��� -   $ textBox7��$��1��$��2��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=�$��	120,0,0,0q��� -   $
 btn2��$��1��$��3��$��	求乘积��$��Center=�$��Center=�$	��100��$��30��$
��10,5q�