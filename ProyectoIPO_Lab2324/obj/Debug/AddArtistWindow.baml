   M S B A M L   `   `   `  ����N  JProyectoIPO_Lab2324, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProyectoIPO_Lab2324ProyectoIPO_Lab2324  5   	   )    #ProyectoIPO_Lab2324.AddArtistWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ProyectoIPO_Lab2324     5   	      	AddArtist  � Title#  �   5   	   $	��600��6-   $
��1000��6:   .��5	      � .+�5
   
   �� $��20q�6   .+�5      ��   lb_artisticName#���  6   $
��Bold"�6@   �� 5      -   5         ��Name$ txtArtisticName��5      �� 5        lb_realName#���  6   $
��Bold"�6<   �� 5      -   5        $ txtRealName��5      �� 5        lb_birthday#���  6   $
��Bold"�6<   �� 5      -   5        $ txtBirthday��5      �� 5        lb_description#���  6   $
��Bold"�6?   �� 5      -   5        $ txtDescription��5      �� 5        lb_genre#���  6   $
��Bold"�69   �� 5      -   5        $ txtGenre��5      �� 5        lb_artistInstagram#���  6   $
��Bold"�6C   �� 5      -   5        $ txtInstagram��5      �� 5        lb_artist_X_Twitter#���  6   $
��Bold"�6D   �� 5      -   5        $ txtX_Twitter��5      �� 5!        lb_likes#���  6   $
��Bold"�69   �� 5"      -   5        $ txtLikes��5"      �� 5$       	 lb_image#��� 	 6   $
��Bold"�69   �� 5%       �� Orientation$ 
Horizontal=�6   .+�5&      �� -	   5        $ txtImage��5&      �� 5'      -
   5        $��Seleccionar Imagen��5'      $��5,0,0,0q�66   6G   5(      �� 5*      -   5         
 btn_add#��� 
 5*      $��Center=�69   $��
10,20,10,0q�6V   6j   5+      �� 5/   
   -   5         ��Name$ combobox_language��5/      $��20,512,839,20q�6.   $��3��6E   $��Berlin Sans FB)�50   I   $��25(�6e    �� SelectedIndex$ 0��51      $��Center=�6%   $��Center=�6I    J� Opacity$	 0.6Q�6k   .@�52      �� -   5         ��Name$ cbItem1��52      $��ES��6,   �� 53      -   5        $ cbItem2��53      $��EN��6,   54      56      57      