   M S B A M L   `   `   `  ����>  :PMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PMS.Views	PMS.Views  5      /clr-namespace:PMS.ViewModelsPMS.ViewModels  5      /clr-namespace:PMS.ConvertersPMS.Converters  5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
          PMS.Views.PatientDataView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:PMS.Views     5      3
viewModelsclr-namespace:PMS.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -
convertersclr-namespace:PMS.Converters  5	      0sys&clr-namespace:System;assembly=mscorlib  5
        � 	Resources  5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle  DatePickerStyle(  "System.Windows.Controls.DatePicker  IconButtonStyle'  !MaterialDesignThemes.Wpf.PackIcon   MaterialDesignIconForeground   BooleanToVisibilityConverter8   2PMS.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter��%
  &	        &	 L     &	 �     &	 H    '  X    &	 �    &	 �    �� 5   
   " ��6#   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6%   .�5      ��  � ��$ Center=�62   �� 5       � {� 6*   �� *	IsEditing+5      �� 5   
   "  6(   .�5      ��  � ��$ Center=�62   �� 5       � {� 6*   �� *	IsEditing+5      �� 5    
   " ��6(   .�5!      ��  � ��
 ���� 6+   �� 5"       � ��
 ���� 6,   �� 5#       � ��$ 4q�6(   �� 5$       � ��$ Center=�64   �� 5%       � ��$ Center=�62   �� 5&       �@�Cursor$
 Hand��6'   5'      �� 5(   
   "  6   .�5)      ��  � ��# �  6+   5*      �� 5+   
   6'     5,   
   69   5-      .��5/      �  � RowDefinitions 50   
   �� 51      $
��Auto �6   �� 52      $��* �6   .+�56   
   ]� $��0��6   $
��True��6!   .+�57      �� $��Patient Details��6   $
��Bold"�58      $��18(�59      $��Center=�5:      $
��Left=�5;      �� 5<       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Right=�6N   .+�5>           Kind$	 Eye=�6*   $��20��65   $��20��6@    � ToolTip$ 	View Mode��5?      y�5@      �� *	IsEditing+ �� 	Converter# [   5B      $ Pencil=�6*   $��20��68   $��20��6C   $ 	Edit Mode��5C      y�5D      �� *	IsEditing+# [ 5E      5F      � 5H   
   $��1��6   $	��Top=�6   	 � ColumnDefinitions	 5I      �� 5J      $
��Auto �6#   �� 5K      $��* �6#    5N      �� 5O      $
��Auto �6    �� 5P      $
��Auto �6    �� 5Q      $
��Auto �6    �� 5R      $
��Auto �6    �� 5S      $
��Auto �6    �� 5T      $
��Auto �6    �� 5U      $
��Auto �6    �� 5V      $
��Auto �6    �� 5W      $
��Auto �6    �� 5X      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5Z      $
��Auto �6    �� 5[      $
��Auto �6    �� 5\      $��* �6    .+�5_      �� $��First Name:��6   $��0��6+   $��0��68   #��[  6H   �� 5`      $��0��6^   $��1��6k   #��[ 6{   ��6   �� *Patient.FirstName+
 �� UpdateSourceTrigger$
 PropertyChanged=�6{   �� 5b      $��
Last Name:��6   $��1��6*   $��0��67   #��[  6G   �� 5c      $��1��6]   $��1��6j   #��[ 6z   ��6   �� *Patient.LastName+$
 PropertyChanged=�6z   �� 5e      $��Email:��6   $��2��6&   $��0��63   #��[  6C   �� 5f      $��2��6Z   $��1��6g   #��[ 6w   ��6   �� *Patient.Email+$
 PropertyChanged=�6w   �� 5h      $��Contact:��6   $��3��6(   $��0��65   #��[  6E   �� 5i      $��3��6\   $��1��6i   #��[ 6y   ��6   �� *Patient.Contact+$
 PropertyChanged=�6y   �� 5k      $��Date of Birth:��6   $��4��6.   $��0��6;   #��[  6K     5l       �� Today   DisplayDateEnd# Z 5m      $��4��5n      $��1��6&   #��[ 5o         SelectedDate 5l      �� *Patient.DateOfBirth+$
 PropertyChanged=�5o      �� 5q      $
��Age:��6   $��5��6$   $��0��61   #��[  6A   �� 5r      $��5��65   $��1��6B   #��[  6R   ��6   �� *Patient.Age+6R   �� 5t      $��Gender:��6   $��6��6'   $��0��64   #��[  6D   �� 5u      $��6��6[   $��1��6h   #��[ 6x   ��6   �� *Patient.Gender+$
 PropertyChanged=�6x   �� 5w      $��Address:��6   $��7��6(   $��0��65   #��[  6E   �� 5x      $��7��6\   $��1��6i   #��[ 6y   ��6   �� *Patient.Address+$
 PropertyChanged=�6y   �� 5z      $��Medical History:��6   $��8��60   $��0��6=   #��[  6M   �� 5{      $��8��6c   $��1��6p   #��[ 6�   ��6   �� *Patient.MedicalHistory+$
 PropertyChanged=�6�   �� 5}      $��Emergency Contact:��6   $��9��62   $��0��6?   #��[  6O   �� 5~      $��9��6e   $��1��6r   #��[ 6�   ��6   �� *Patient.EmergencyContact+$
 PropertyChanged=�6�   �� 5�      $��Blood Group:��6   $��10��6,   $��0��6:   #��[  6J   �� 5�      $��10��6_   $��1��6m   #��[ 6}   ��6   �� *Patient.BloodGroup+$
 PropertyChanged=�6}   �� 5�      $��
Allergies:��6   $��11��6*   $��0��68   #��[  6H   �� 5�      $��11��6^   $��1��6l   #��[ 6|   ��6   �� *Patient.Allergies+$
 PropertyChanged=�6|   �� 5�      $��Notes:��6   $��12��6&   $��0��64   #��[  6D   �� 5�      $��12��6Z   $��1��6h   #��[ 6x   ��6   �� *Patient.Notes+$
 PropertyChanged=�6x   �� 5�      $��13��6   $��2��6#   $��_Save��5�      $��Right=�5�      $	��100��5�      y�5�      �� *	IsEditing+# [ ��5�      �� *SaveCommand+5�      5�      5�      