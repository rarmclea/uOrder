   M S B A M L   `   `   `  ����A  =uOrder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:uOrderuOrder  5   	       uOrder.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:uOrder     5   	     � Title$)  #uOrder - Restaurant Ordering System��5   	   $
��1050��65   $
��1950��6C    � WindowStartupLocation$ CenterOwner=�6P   $��Center=�6t   $��Center=�6�    � WindowState$ 	Maximized=�6�   .��5	      � -   5        $��myGrid��5	       � RowDefinitions 5
   
   �� 5      -   5         �Name$ first��5      $	��100 �6)   �� 5      -   5        $ second��5      $	��850 �6+   �� 5      -   5        $ third��5      $
��Auto �6)    � ColumnDefinitions 5   
   �� 5      $
��1950 �6   .+�5   
   �� $��0��6   ���	#FF4F0D0D$��	0,0,0,830q�63   $��2��6F   �� 5   
   -   5         ��Name$ Image6_png3��5      $��0��6%   $��
7,0,1688,0q�62   $	��100��6F   $��uOrderLogo.png��6S   $��Uniform=�6k   �� 5   
   -   5        $
��home��5      $��0��6   $��268,20,1617.4,19.8q�6*   $��0q�6F   .��5      �� -   5        $ Image11_png��5      $��home_icon.png��6)   $��Uniform=�6@   5      �� 5   
   -   5        $
��menu��5      $��0��6   $
��MENU��6*   $��28(�69   $��Heavy"�6G   ���	#FFEEE6E4���	#FF4F0D0D���	#FF4F0D0D$��3q�6�   $��1212,20,565.4,19.8q�6�   6�   �� 5   
   -	   5        $
��help��5      $��0��6   $��352,20,1532.4,19.8q�6*   $��0q�6Y   .��5      �� -
   5        $
 hel3��5      $��question_icon.png��6"   $��Uniform=�6=   5      �� 5   
   -   5        $��receipt��5      $��0��6    $��VIEW RECEIPT��6-   $��28(�6D   $��Heavy"�6R   ���	#FFEEE6E4���	#FF4F0D0D���	#FF4F0D0D$��3q�6�   $��1491,21,188.4,19.8q�6�   6�   �� 5   
   -   5         ��Name$
 call��5      $��436,15,1442.4,16.8q�6   ���	#FF4F0D0D$��5q�6f   .��5      �� -   5        $ Image10_png��5       �� BitmapScalingMode$ HighQuality=�6)   $��Image10.png��6W   $��Uniform=�6l   5      �� 5!   
   -   5        $ 
Image5_png��5!      $��2��6$   $��25,10,1450,27q�61   $��
Image5.png��6H   $��Uniform=�6\   �� 5"   
   $��1��6   ���	#FFC7C2C26!   �� 5#   
   -   5        $��page_viewer��5#   "   $��1��6   $��10q�65   5%      �� 5&   
   -   5        $��enter��5&      $��Button��6   $��3��6/   	 J� Opacity$	 0Q�6T   �� 5'   
   -   5        $��start��5'      $��3��6   
 J� IsHitTestVisible
 .  ���	#FF4F0D0D$y�Visible=�6_   .��5(      �� .+�5)      �� -   5        $ uOrderLogo_png��5)      $��uOrderlogo.png��60   $��Uniform=�6H   $y�Visible=�6Z   $
��2034��6o   $	��778��6|   $��-80,0,-20,0q�6�   �� 5*      $��Swipe to continue >>��6   
�������$��34(�6J   $��Center=�6X   $��Italic$�6|   5+      5,      5-      5.      