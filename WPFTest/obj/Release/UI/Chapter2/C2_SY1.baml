   M S B A M L   `   `   `  ���� B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter2WPFTest.UI.Chapter2  'clr-namespace:WPFTest.UI
WPFTest.UI       WPFTest.UI.Chapter2.C2_SY1   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WPFTest.UI.Chapter2     )baseclr-namespace:WPFTest.UI       N� Title$  实验：调用托管dll��.��� $��Stretch=�$��0q�$��Stretch=� � RowDefinitions �� $��40 ��� $��40 ��� $��40 ��� $��* � � ColumnDefinitions �� $	��120 ��� $	��240 ��� $��* ��� $	��120 �.+��� -    ��Name$ label1��$��0��$��0��$��	求阶乘��$��Stretch=�$��Center=�$
��Left=�$��0,0,0,0q��� -    ��Name$ textBox1��$��0��$��1��$��1��$
��Left=�$��30��$	��120�� �� TextWrapping$
 Wrap=�$�� ��$��Center=��� -   $ label2��$��0��$��1��$��=��$
��Left=�$��30��$	��120��$��Center=�$
��Left=�$��	120,0,0,0q��� -   $ textBox2��$��0��$��2��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=��� -    ��Name$
 btn1��$��0��$��3��$��调用dll计算��$��Center=�$��Center=�$	��100��$��30���� -   $ label3��$��1��$��0��$��斐波那契数��$��Stretch=�$��Center=�$
��Left=�$��0,0,0,0q��� -   $ textBox3��$��1��$��1��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=��� -   $ label4��$��1��$��1��$��=��$
��Left=�$��30��$	��120��$��Center=�$
��Left=�$��	120,0,0,0q��� -	   $ textBox4��$��1��$��2��$��1��$
��Left=�$��30��$	��120��$
 Wrap=�$�� ��$��Center=��� -
   $
 btn2��$��1��$��3��$��调用dll计算��$��Center=�$��Center=�$	��100��$��30���� -   $ label5��$��2��$��0��$��列举dll中函数��$��Stretch=�$��Center=�$
��Left=�$��0,0,0,0q��� -   $
 btn3��$��2��$��3��$��通过反射机制得到��$��Center=�$��Center=�$	��100��$��30���� -    ��Name$ listBox1��$��3��$��0��$��3��$��Stretch=�$	��300��$��	10,10,0,0q�$	��Top=�