   M S B A M L   `   `   `  ����D  @SinukovUP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SinukovUP	SinukovUP  5          SinukovUP.SignInWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SinukovUP     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  SignInWindow��5      $	��300��5	      $	��600��5
       � AllowsTransparency .   � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   � -   5           MainWindowPlace_sytle#��[  5   -   .+�5      ��   mainWindowStackPanal_style#��[ 6   .+�5      ��   TitleWindowText_style#��[ 6   $��АВТОРИЗАЦИЯ��6K   �� 5        normalHelpText_style#��[ 6   $��
Логин��6J   �� 5      -   5         ��Name$ 
loginInput��5       �� 	MaxLength$ 30��5        usualyTextInpyt_style#��[ 5      �� 5      #��[ 6   $��Пароль��6J   �� 5      -   5        $ passwordInput��5       $ 15��5!      #��[ 5"      �� 5$      #��[ 6   $��Роль��6J   �� 5%      -   5         ��Name$ 
roleSelect��5%        comboBoxRole_style#��[ 6/   .@�5&      �� $��Оператор��6    �� 5'      $��Мастер��6    �� 5(      $��Менеджер��6    �� 5)      $��Заказчик��6    5*      �� 5-      -   5        $��
Войти��5/        RegAuthBtn_style#��[ 50      51      52      � 53   
   -   5         �Name$ SettingsPlace��54        setingsPlace_style#��[ 55      $y�Hidden=�56      .+�57      �� $��Center=�6   #��[ 64   .+�58      �� -   5        $��Регистрация��5:        settingsBtn_style#��[ 5;      �� 5<      -   5        $!��Закрыть сессию��5>      #��[ 5?      �� 5@      -	   5        $��Обратно��5B      #��[ 5C      5D      5E      � 5F   
    	 BottomWindowPlace_style#��[	 6   .+�5G      �� $��Center=�6   	 �� Orientation$	 
Horizontal=�66   .+�5H      �� -
   5          
 settingsSmallBottomBtn_style#��[
 5H   3   ��5I      �� 5J      
 �� ImageSource$
 icon/menu.png��6%   5L      5M      5O      5P      5Q      