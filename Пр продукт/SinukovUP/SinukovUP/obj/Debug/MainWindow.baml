   M S B A M L   `   `   `  ����D  @SinukovUP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SinukovUP	SinukovUP  5          SinukovUP.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SinukovUP     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��300��5	      $	��600��5
       � AllowsTransparency .   � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   � -   5           MainWindowPlace_sytle#��[  5   -   .+�5      ��   mainWindowStackPanal_style#��[ 6   .+�5      ��   TitleWindowText_style#��[ 6   $��РЕГИСТРАЦИЯ��6K   �� 5        normalHelpText_style#��[ 6   $��ФИО��6J   �� 5      -   5         ��Name$ fioInput��5       �� 	MaxLength$ 50��5        usualyTextInpyt_style#��[ 5      �� 5      #��[ 6   $��Телефон��6J   �� 5      -   5        $ 
phoneInput��5      $ 11��5       #��[ 5!      �� 5#      #��[ 6   $��
Логин��6J   �� 5$      -   5        $ 
loginInput��5%      $ 30��5&      #��[ 5'      �� 5)      #��[ 6   $��Пароль��6J   �� 5*      -   5        $ passwordInput��5+      $ 15��5,      #��[ 5-      �� 5/      #��[ 6   $��Роль��6J   �� 50      -   5         ��Name$ 
roleSelect��50        comboBoxRole_style#��[ 6/   .@�51      �� $��Оператор��6    �� 52      $��Мастер��6    �� 53      $��Менеджер��6    �� 54      $��Заказчик��6    55      �� 58      -   5        $��Создать��5:        RegAuthBtn_style#��[ 5;      5<      5=      � 5>   
   -   5         �Name$ SettingsPlace��5?        setingsPlace_style#��[ 5@      $y�Hidden=�5A      .+�5B      �� $��Center=�6   #��[ 64   .+�5C      �� -	   5        $��
Войти��5C        settingsBtn_style#��[ 6)   6T   �� 5D      -
   5        $!��Закрыть сессию��5F      #��[ 5G      �� 5H      -   5        $��Обратно��5H      #��[ 6+   6V   5I      5J      � 5K   
    	 BottomWindowPlace_style#��[	 6   .+�5L      �� $��Center=�6   	 �� Orientation$	 
Horizontal=�66   .+�5M      �� -   5          
 settingsSmallBottomBtn_style#��[
 5M   3   ��5N      �� 5O      
 �� ImageSource$
 icon/menu.png��6%   5Q      5R      5T      5U      5V      