   M S B A M L   `   `   `  ����   Football Manager    Football_Manager.OknoMecz   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -   .��]� $��5q�.+�� $��Bottom=�  � ColumnDefinitions  �� �� .+��� -   $��powrot��$��1��$��10q�$��30��{�.  .��Dalej�� -   $��bTimer��$��0��$��10q�$��30��.��
Przyspiesz� $	��Top=� � ShowGridLines .   � RowDefinitions �� �� ��   �� �� $
��auto ��� .+��� -   $��lGospodarzNazwa��$��0��$��0��$
��Left=�.��	gospodarz�� -   $��lGole��$��0��$��1��$��Center=�.��Gole�� -   $��
lGoscNazwa��$��0��$��2��$��Right=�.��gosc�� $��1��$��1��$��Center=�.��Posiadanie pilki�� $��2��$��1��$��Center=�.��Skutecznosc ataku�� -   $��rPosiadaniePilkiGospodarz��$��1��$��0��$��20��$	��100��$
��Left=����� .���  � Color$ 
LightGreen�� � Offset$ 1Q�� $ Green��$ 0Q��� -   $��rPosiadaniePilkiGosc��$��1��$��2��$��20��$	��100��$��Right=����� .��� $ 
LightGreen��$ 0Q�� $ Green��$ 1Q��� -	   $ ��rSkutecznoscAtakuGospodarz��$��2��$��0��$��20��$��0��$
��Left=����� .��� $ 
LightGreen��$ 1Q�� $ Green��$ 0Q��� -
   $��rSkutecznoscAtakuGosc��$��2��$��2��$��20��$��0��$��Right=����� .��� $ 
LightGreen��$ 0Q�� $ Green��$ 1Q��� -   $��lPosiadaniePilkiGospodarz��$��1��$��0��
�������$
��Left=�.��50%�� -   $��lPosiadaniePilkiGosc��$��1��$��2��
�������$��Right=�.��50%�� -   $ ��lSkutecznoscAtakuGospodarz��$��2��$��0��
�������$
��Left=�.��0�� -   $��lSkutecznoscAtakuGosc��$��2��$��2��
�������$��Right=�.��0� $	��Top=�.+��� .��	Minuta:�� -   $��lMinuta��.��20�� .��|�� .��Piłkę posiada:�� -   $��lPilkePosiada���� -   $��lRelacja��$	��Top=� �� View �� .P���  �� Width$ 30��$	��Min�� �� DisplayMemberBinding �� *minuta+�� $	 700��$��	Komentarz�� �� CellTemplate �� .R��� $
��Wrap=����� 	 �� Path$	 	komentarz�