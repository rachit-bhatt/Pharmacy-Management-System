   M S B A M L   `   `   `  ����>  :PMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PMSPMS  5   	   %clr-namespace:PMS.Views	PMS.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	       PMS.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:PMS     5   	   (viewclr-namespace:PMS.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3System&clr-namespace:System;assembly=mscorlib  5	   	     � Title$	  PMS��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	      BackgroundBrush#���   5   	     ForegroundBrush#���  5   	    � 	Resources 5        IconButtonWidth  IconButtonHeight  	IconWidth  
IconHeight  SunnyIconColor  NightIconColor  SunnyIconBrush �� Color 	 NightIconBrush��%.  &	       &	      &	 4     &	 N     &	 h     &	 �     &	 �     7  &		 �     7  X�5   
   30Q�64   X�5   
   30Q�65   X�5   
   24Q�6.   X�5   
   24Q�6/   ��5   
   #FFA500��60   ��5   
   #333333��60   �� 5   
   8   61   �� 5   
   8   61   5      .��5!      � .+�5#   
      PMS.Views.Dashboard  �� 5%   
   .+�5&      d� -   5         d�Name$ ThemeToggleButton��5&      
 �� Top$ 0��5'       �� Right$ 0��5(      #��[ 5)      #��[ 5*       � ToolTip$ Toggle Theme��5+      ��5,      �� 5-      	 �� 
TargetType"	 d�6   .�5.      �� 
 �� Property
 � �� �� Value 50      '  !MaterialDesignThemes.Wpf.PackIcon  51   "      Kind$ WeatherSunny=�6:   #��[ 52   6   #��[ 53   6   #��[ 54   6   56       �� Triggers 57      P� 58       P� Property �@d�	IsChecked P� Value$
 TrueY�6;   . �59   "   �� 
 � �� 5;   &     5<   *   $ WeatherNight=�6B   #��[ 5=   >   #��[ 5>   >   #��[	 5?   >   5A   #   5B      5D      5F      5G      5I      5K      