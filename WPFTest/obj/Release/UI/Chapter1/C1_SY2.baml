   M S B A M L   `   `   `  ���� B  >WPFTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFTest.UI.Chapter1WPFTest.UI.Chapter1  'clr-namespace:WPFTest.UI
WPFTest.UI       WPFTest.UI.Chapter1.C1_SY2   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WPFTest.UI.Chapter1     )baseclr-namespace:WPFTest.UI       N� Title$  文件合并��.��� $��Stretch=�$��0q�$��Stretch=� � RowDefinitions �� $��30 ��� $��30 ��� $��* ��� $��30 ��� $��30 ��� $��* ��� $��30 ��� $��30 � � ColumnDefinitions �� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 ��� $��* ��� $	��120 �.+��� -    ��Name$
 btn1��$��0��$��0��$��选择文件目录��$��Center=�$��Center=�$��Center=��� -    ��Name$ label1��$��0��$��1��$��4��$��Stretch=�$��Center=�$
��Left=��� -   $ label2��$��1��$��0��$��文件名字符��$��Center=�$��Center=�$
��Left=��� -    ��Name$ textBox��$��1��$��1��$��3��$��Stretch=�$��30��$��10,6,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=��� -   $
 btn2��$��1��$��4��$��查找所有文件��$��Center=�$��Center=�$	��100��$��30���� -    ��Name$ listBox��$��2��$��0��$��5��$��Stretch=�$��	10,10,0,0q�$��Stretch=��� -   $
 btn3��$��4��$��0��$��添加到目标集中��$��Center=�$��Center=�$	��100��$��30���� -   $
 btn4��$��4��$��1��$��清空目标集��$��Center=�$��Center=�$	��100��$��30���� -	   $ listBox2��$��5��$��0��$��5��$��Stretch=�$��10,0,0,5q�$��Stretch=�� $��5��$��5�� �� $��30 ��� $��30 ��� $��30 ��� $��* �.+��� -
   $
 btn5��$��0��$��0��$��上移��$��Center=�$��Center=�$	��100��$��30���� -   $
 btn6��$��1��$��0��$��下移��$��Center=�$��Center=�$	��100��$��30���� -   $
 btn7��$��2��$��0��$��打开选中文件��$��Center=�$��Center=�$	��100��$��30���� -   $
 btn8��$��6��$��0��$��目标文件名��$��Center=�$��Center=�$	��100��$��30���� -   $ label3��$��6��$��1��$��4��$��Stretch=�$��Center=�$
��Left=�$��0,0,0,0q��� -   $
 btn9��$��6��$��5��$��合并文件��$��Center=�$��Center=�$	��100��$��30���� -    ��Name$ 	checkBox1��$��7��$��0��$!��文件合并时添加换行��$��Stretch=�$��Center=�$
��Left=��� -   $ 	checkBox2��$��7��$��1��$$��文件合并时添加文件名��$��Stretch=�$��Center=�$
��Left=��� -   $ 	checkBox3��$��7��$��2��$��打开合并后的文件��$��Stretch=�$��Center=�$
��Left=�