   M S B A M L   `   `   `  ����   WPF-Number-Guessing-Game,    &WPF_Number_Guessing_Game.Views.Options   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $��640px��$��640px��  N� Title$  Options��.��]� $	��Top=�.+��� $	��Top=�   MyTopBorder#��[  ._��� -    ��Name$ Navbar�� �� Orientation$ 
Horizontal=�.+��� -   $��HomeBtn��  nav-btn#��[ .��Home�� -   $��AboutBtn��#��[ .��About�� $
��Left=� 
 MyBody#��[ ._��  � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $
��50px ��� $
��50px ��� $
��50px ��� $��100px ��� $��* �.+��� -   $��MinRange��$
��auto��$��Right=�$��Bottom=� 	 label#��[ $��0��$��1��.��Minimum Range�� -   $��MinRangeTextbox��$
��Left=�$��Bottom=�  textbox#��[ $��1��$��1���� -   $��MaxRange��$
��auto��$��Right=�$��Bottom=�#��[ $��0��$��2��.��Maximum Range�� -   $��MaxRangeTextbox��$
��Left=�$��Bottom=�#��[ $��1��$��2���� -	   $��SaveOptionsBtn��$��Right=�$��Center=�$��0��$��3��  primary-btn#��[ .��Save