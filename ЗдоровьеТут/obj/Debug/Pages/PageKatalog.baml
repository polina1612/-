   M S B A M L   `   `   `  ����Q  MЗдоровьеТут, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ЗдоровьеТут.PagesЗдоровьеТут.Pages  5      .    (ЗдоровьеТут.Pages.PageKatalog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:ЗдоровьеТут.Pages     5      -   5          N� Title$  PageKatalogAP��5
      .��5      � ��. $��Visible=�5       � ColumnDefinitions 5   
   �� 5      $	��340 �6   �� 5      $	��450 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��265 �6   .+�5   
   �� $��1��6   ���	#FF84E2A8 �� CornerRadius$ 15��68   $��	0,10,0,10q�6J   ._�5      ��  �� Orientation$ Vertical=�6   $��0,0,46,0q�60   .+�5      �� $��Поиск ��6    �� TextAlignment$ Right=�5      $	��220��62   $��Right=�5      $
��10 5q�68   $��14(�6F   ���	#FF007A3D6T   �� 5      -   5         ��Name$ Search��5      $	��220��6*   $��Right=�5      $
��10 0q�66   $��25��5       6&   5"      5$      o� 5%   
   $��1��6   $��40��6    $��47��6,   $��RightToLeft=�67   $
��Left=�6S   $��403,20,10,20q�6�   ��6n   Z� .@�5&      m�  � Cursor$
 Hand��6   $��45(�6%   $
��Bold"�64   $��40��6G   $��47��6T   .@�5'      m� -   5        $
 Hand��5'      $��15(�6)   $��Добавить��67   $��0 0 10 0q�6`   6t   m� 5(      -   5        $
 Hand��5(      $��15(�6)   $ ��Редактировать��67   6i   m� 5)      -   5        $
 Hand��5)      $��15(�6)   $��Сохранить��67   6f   m� 5*      -   5        $
 Hand��5*      $��15(�6)   $��Удалить��67   6c    m� Icon 5+      �� 5,      $ ��/Icons/menu-burger (2).png��6   $��10,-6,-28,-2q�6@   5.      5/      �� 50   
   $��1��6   ���	#FF84E2A8$ 15��65   $��2��6H   ._�51      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 DataGridEmployee��51      $
 Hand��52      
   AutoGenerateColumns
 .  $��Center=�55      $
��1000��56      $	��295��6      RowBackground
 �����   AlternatingRowBackground
 ��������	#FF007A3D$��3q�5:         	RowHeight$ 40Q�5;      $��13(�5<         
IsReadOnly . $	��546��5>      $��	0,10,0,10q�5?      ���	#FF007A3D���	#FFFAFAFA��53      ��    Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Наименование��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Наименование+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  5E      $ Количество��6)    6=   �� *(&Количество_на_складе+$ TwoWay=�$ PropertyChanged=�  5F      $ Цена��6)    67   �� *
Цена+$ TwoWay=�$ PropertyChanged=�5H      5I      5J      5K      