   M S B A M L   `   `   `  ����N  JProyectoIPO_Lab2324, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProyectoIPO_Lab2324ProyectoIPO_Lab2324  5   	   (    "ProyectoIPO_Lab2324.AddAlbumWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ProyectoIPO_Lab2324     5   	      AddAlbum  � Title#  �   5   	   $	��720��6,   $
��1000��69    � Icon$! /Resources/program_icon.ico��6F    � 
ResizeMode$ NoResize=�6i    � WindowStartupLocation$ CenterScreen=�6   .��5	      � .+�5
   
   �� $��20q�6   .+�5      �� $��Nombre del Álbum:*��6   $
��Bold"�61   �� 5      -   5         ��Name$ txtAlbumName��5      �� 5      $��Nombre del Artista:*��6   $
��Bold"�63   �� 5      -   5        $ txtArtistName��5      �� 5      $��Año de Lanzamiento:��6   $
��Bold"�62   �� 5      -   5        $ txtReleaseYear��5      �� 5      $��	Género:*��6   $
��Bold"�6'   �� 5      -   5        $ txtGenre��5      �� 5      $��Sello Discográfico:��6   $
��Bold"�62   �� 5      -   5        $ txtRecordLabel��5      �� 5      $��	Formato:*��6   $
��Bold"�6(   �� 5      -   5        $ 	txtFormat��5      �� 5      $��País:��6   $
��Bold"�6$   �� 5      -   5        $ 
txtCountry��5      �� 5!      $��Likes:��6   $
��Bold"�6%   �� 5"      -   5        $ txtLikes��5"      �� 5$      $��Puntuación:��6   $
��Bold"�6*   �� 5%      -	   5        $ txtPuntuation��5%      �� 5'      $��PVP:*��6   $
��Bold"�6$   �� 5(      -
   5        $ txtPvp��5(      �� 5*      $��Stock:*��6   $
��Bold"�6&   �� 5+      -   5        $ txtStock��5+      �� 5-      $��Cover (URI):*��6   $
��Bold"�6,   �� 5.       �� Orientation$ 
Horizontal=�6   .+�5/      �� -   5        $ txtCover��5/      �� 50      -   5        $��Seleccionar Imagen��50      $��5,0,0,0q�6S   51      �� 55      -   5        $��Agregar��55      $��Center=�6<   $��
10,20,10,0q�6Y   56      57      58      