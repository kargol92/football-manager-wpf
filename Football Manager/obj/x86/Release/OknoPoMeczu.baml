   M S B A M L   `   `   `  ����   Football Manager"    Football_Manager.OknoPoMeczu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -   .��]� $��5q�.+��� -   $��powrot��$��Bottom=�$��10q�$��30��.��Powrot� $	��Top=�  � ShowGridLines  .   � RowDefinitions �� �� �� �� �� �� �� �� �� ��  � ColumnDefinitions �� �� �� .+��� -   $��rPosiadaniePilkiGospodarz��$��1��$��0��$��20��$	��100��$
��Left=����� .���  � Color$ 
LightGreen�� � Offset$ 1Q�� $ Green��$ 0Q��� -   $��rPosiadaniePilkiGosc��$��1��$��2��$��20��$	��100��$��Right=����� .��� $ 
LightGreen��$ 0Q�� $ Green��$ 1Q��� -   $ ��rSkutecznoscAtakuGospodarz��$��2��$��0��$��20��$��0��$
��Left=����� .��� $ 
LightGreen��$ 1Q�� $ Green��$ 0Q��� -   $��rSkutecznoscAtakuGosc��$��2��$��2��$��20��$��0��$��Right=����� .��� $ 
LightGreen��$ 0Q�� $ Green��$ 1Q��� -   $��lGospodarzNazwa��$��0��$��0��$
��Left=�.��	gospodarz�� -   $��lGole��$��0��$��1��$��Center=�.��Gole�� -	   $��
lGoscNazwa��$��0��$��2��$��Right=�.��gosc�� $��1��$��1��$��Center=�.��Posiadanie pilki�� -
   $��lPosiadaniePilkiGospodarz��$��1��$��0��
�������$
��Left=�.��50�� -   $��lPosiadaniePilkiGosc��$��1��$��2��
�������$��Right=�.��50�� $��2��$��1��$��Center=�.��Skutecznosc ataku�� -   $ ��lSkutecznoscAtakuGospodarz��$��2��$��0��
�������$
��Left=�.��50�� -   $��lSkutecznoscAtakuGosc��$��2��$��2��
�������$��Right=�.��50�� -   $��lGospodarzIloscAkcji��$��3��$��0��$
��Left=��� $��3��$��1��$��Center=�.��Ilosc akcji�� -   $��lGoscIloscAkcji��$��3��$��2��$��Right=��� $��4��$��1��$��Center=�.��
Formacja�� -   $��lFormacjaGospodarz��$��4��$��0��$
��Left=��� -   $��lFormacjaGosc��$��4��$��2��$��Right=��� $��5��$��1��$��Center=�.��
Ustawienie�� -   $��lUstawienieGospodarz��$��5��$��0��$
��Left=��� -   $��lUstawienieGosc��$��5��$��2��$��Right=��� $��6��$��1��$��Center=�.��
Pressing�� -   $��lPressingGospodarz��$��6��$��0��$
��Left=��� -   $��lPressingGosc��$��6��$��2��$��Right=��� $��7��$��1��$��Center=�.��	Agresja�� -   $��lAgresjaGospodarz��$��7��$��0��$
��Left=��� -   $��lAgresjaGosc��$��7��$��2��$��Right=��� $��8��$��1��$��Center=�.��	Kapitan�� -   $��lKapitanGospodarz��$��8��$��0��$
��Left=��� -   $��lKapitanGosc��$��8��$��2��$��Right=��� $��9��$��1��$��Center=�.��Stałe fragmenty gry�� -   $��lStaleFragmentyGospodarz��$��9��$��0��$
��Left=��� -   $��lStaleFragmentyGosc��$��9��$��2��$��Right=�� $	��Top=� �� �� .+��� -   $��lGospodarzGole��$��0�� �� View �� .P���  �� Width$ 30��$��Minuta�� �� DisplayMemberBinding �� *minuta+�� $ 70��$��Imię�� �� *pilkarz.imie+�� $	 120��$��Nazwisko�� �� *pilkarz.nazwisko+�� $��	Zdarzenie�� �� *rodzaj+�� -   $��	lGoscGole��$��1�� �� .P��� $ 30��$��Minuta�� �� *minuta+�� $ 70��$��Imię�� �� *pilkarz.imie+�� $	 120��$��Nazwisko�� �� *pilkarz.nazwisko+�� $��	Zdarzenie�� �� *rodzaj+