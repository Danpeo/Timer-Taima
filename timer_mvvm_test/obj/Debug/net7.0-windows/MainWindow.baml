   M S B A M L   `   `   `  ����J  Ftimer_mvvm_test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:timer_mvvm_testtimer_mvvm_test  5   	        timer_mvvm_test.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [Hardcodet.NotifyIcon.Wpf, Version=1.1.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar  5   	   1timerMvvmTestclr-namespace:timer_mvvm_test  5   	   -   5          � Title$  タイマー��5   	   $	��450��6   $	��800��6#    � Icon$! /Images/timer-icon copy.png��5   "   ���	#FFFF70DF � 	Resources 5         WindowBackgroundBrush �� EndPoint �� 
StartPoint � Color � Offset  ButtonBackgroundBrush  TextForegroundBrush �� Color  LabelForegroundBrush  TextBoxBackgroundBrush  TextBoxForegroundBrush��%�  &	        &	 �     &	     &	 A    &	 d    &	 �    �� 5	   
   $ 0.5,1&�6<   $ 0.5,0&�6M   .��5
      � $ 	#FF3A1640��6   � 5      $ 	#FFA97878��6   $ 1Q�6-   5      �� 5   
   $ 0.5,1&�6<   $ 0.5,0&�6M   .��5      � $ 	#FFE258C9��6   � 5      $ 	#FFDCA9EC��6   $ 1Q�6-   5      �� 5   
   $ 	#FF36C7D2��66   �� 5   
   $ 	#FF2EADC5��67   �� 5   
   $ 	#FF484848��69   �� 5   
   $ 	#FFF54FE0��69   5      ��5      �� 5   
   $ 0.5,1&�6   $ 0.5,0&�6/   .��5      � $ 	#FFC302FF��6   � 5      $ 	#FFE1C4EA��6   $ 1Q�6-   5      ��5      �� 5   
    �� ResourceKey$ WindowBackgroundBrush��6   	 � DataContext	 5      $   timer_mvvm_test.TimerViewModel  5    
   .��5"      � .+�5#   
   3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -   5        
  Name$
 taskbarIcon��5#         ToolTipText$ タイマー��5$      $y�	Collapsed=�5%      5(      �� 5)   
   -   5         ��Name$ TimeHoursTextBlock��5)      $��Center=�60   $��-175,80,0,0q�6M   $
��Wrap=�6b   $	��Top=�6v   $��72(�5*      $��MS UI Gothic)�6"   #��[ 6<   ��5+      �� *Hours+ �� StringFormat$ {0:00}:��5-      �� 5.   
   -   5        $ TimeMinutesTextBlock��5.      $��Center=�62   $��0,80,0,0q�6O   $
��Wrap=�6a   $	��Top=�6u   $��72(�5/      $��MS UI Gothic)�6"   #��[ 6<   ��50      �� *	Minutes+$ {0:00}:��51   l   �� 52   
   -   5        $ TimeSecondsTextBlock��52      $��Center=�62   $��
160,80,0,0q�6O   $
��Wrap=�6c   $	��Top=�6w   $��72(�53      $��MS UI Gothic)�6"   #��[ 6<   ��54      �� *	Seconds+$ {0:00}��56      �� 57   
   $��Center=�6    �� TextAlignment$ Center=�6/   $��160,180,0,0q�6F    �� TextWrapping$
 Wrap=�6[   $	��Top=�59      $��40��6*   #��[ 65   #��[ 5:      ��58      �� *	Seconds+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5:      �� 5;   
   $��Center=�6   $ Center=�6/   $��-10,180,0,0q�6F   $
 Wrap=�6[   $	��Top=�5=      $��40��6*   #��[ 65   #��[ 5>      ��5<      �� *	Minutes+$ TwoWay=�$ PropertyChanged=�5>      �� 5?   
   $��Center=�6   $ Center=�6/   $��-180,180,0,0q�6F   $
 Wrap=�6\   $	��Top=�5A      $��40��6*   #��[ 65   #��[ 5B      ��5@      �� *Hours+$ TwoWay=�$ PropertyChanged=�5B      �� 5C   
   $��H��6   $��Center=�6   $��-180,200,0,0q�69   $	��Top=�6O   #��[ 5D      $��30(�6C   $��41��6Q   �� 5E   
   $��M��6   $��Center=�6   $��-10,200,0,0q�69   $	��Top=�6N   #��[ 5F      $��30(�6C   $��42��6Q   �� 5G   
   $��S��6   $��Center=�6   $��160,200,0,0q�69   $	��Top=�6N   #��[ 5H      $��30(�6C   $��42��6Q   �� 5I   
   -   5         ��Name$ ToggleTimerButton��5I      $��Center=�5J   8   $��-100,255,0,0q�6U   $	��Top=�5K      $��62��6)   $��27��64   
������� �� 	IsDefault$
 True��6S   ��5I   ,   �� *CurrentToggleButtonContent+��5J      �� *StartPauseCommand+��5L      �� 5M      $ ButtonBackgroundBrush��6!   5O      �� 5P   
   $��Reset��6   $��Center=�6B   $��
70,255,0,0q�6_   $	��Top=�5Q      $��27��6)   $��59��65   
���������5P   !   �� *ResetCommand+��5R      �� 5S      $ ButtonBackgroundBrush��6!   5U      �� 5V   
   $��Center=�6   $��-10,150,0,0q�61   $
��Wrap=�6F   $	��Top=�6y   ��6Z   �� *TickUntilTime+��5W      �� 5X      $ 0.5,1&�6&   $ 0.5,0&�67   .��5Y      � $ 	#FFE460C7��6#   � 5Z      $ 	#FFFFF7FD��6#   $ 1Q�65   5[      5]      �� 5^   
   $��Center=�6   $��-10,300,0,0q�61   $
��Wrap=�6F   $	��Top=�6x   $��48(�6�   ���	#FF2EADC5��6Z   �� *TimeIsUpText+6�   5_      5`      