   M S B A M L   `   `   `  ����>  :PMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PMS.Views	PMS.Views  5      /clr-namespace:PMS.ViewModelsPMS.ViewModels  5          PMS.Views.PatientDataView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:PMS.Views     5      3
viewModelsclr-namespace:PMS.ViewModels     5        � 	Resources  5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle  DatePickerStyle(  "System.Windows.Controls.DatePicker��%  &	        &	 L     &	 �     �� 5      " ��6   .�5      ��  � ��$ Center=�6,   5      �� 5      " ��6!   .�5      ��  � ��$ Center=�6,   5      �� 5      "  6$   .�5      ��  � ��$ Center=�6,   5      5       � DataContext 5      )   #PMS.ViewModels.PatientDataViewModel  5      .��5       �  � RowDefinitions 5"      �� 5#      $
��Auto �6   �� 5$      $��* �6   .+�5'      �� $��Patient Details��6   $
��Bold"�6'   $��18(�69   $��0��6G   � 5)      $��1��6    � ColumnDefinitions 5+      �� 5,   
   $
��Auto �6   �� 5-   
   $��* �6    50      �� 51   
   $
��Auto �6   �� 52   
   $
��Auto �6   �� 53   
   $
��Auto �6   �� 54   
   $
��Auto �6   �� 55   
   $
��Auto �6   �� 56   
   $
��Auto �6   �� 57   
   $
��Auto �6   �� 58   
   $
��Auto �6   �� 59   
   $
��Auto �6   �� 5:   
   $
��Auto �6   �� 5;   
   $
��Auto �6   �� 5<   
   $
��Auto �6   �� 5=   
   $
��Auto �6   .+�5@      �� $��First Name:��6   $��0��6%   $��0��62   #��[  6B   �� 5A      $��0��6X   $��1��6e   #��[ 6u   ��6   �� *Patient.FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6u   �� 5C      $��
Last Name:��6   $��1��6$   $��0��61   #��[  6A   �� 5D      $��1��6W   $��1��6d   #��[ 6t   ��6   �� *Patient.LastName+$ PropertyChanged=�6t   �� 5F      $��Email:��6   $��2��6    $��0��6-   #��[  6=   �� 5G      $��2��6T   $��1��6a   #��[ 6q   ��6   �� *Patient.Email+$ PropertyChanged=�6q   �� 5I      $��Contact:��6   $��3��6"   $��0��6/   #��[  6?   �� 5J      $��3��6V   $��1��6c   #��[ 6s   ��6   �� *Patient.Contact+$ PropertyChanged=�6s   �� 5L      $��Date of Birth:��6   $��4��6(   $��0��65   #��[  6E     5M      $��4��6e   $��1��6r   #��[ 6�      SelectedDate 6   �� *Patient.DateOfBirth+$ PropertyChanged=�6�   �� 5O      $
��Age:��6   $��5��6   $��0��6+   #��[  6;   �� 5P      $��5��6/   $��1��6<   #��[  6L   ��6   �� *Patient.Age+6L   �� 5R      $��Gender:��6   $��6��6!   $��0��6.   #��[  6>   �� 5S      $��6��6U   $��1��6b   #��[ 6r   ��6   �� *Patient.Gender+$ PropertyChanged=�6r   �� 5U      $��Address:��6   $��7��6"   $��0��6/   #��[  6?   �� 5V      $��7��6V   $��1��6c   #��[ 6s   ��6   �� *Patient.Address+$ PropertyChanged=�6s   �� 5X      $��Medical History:��6   $��8��6*   $��0��67   #��[  6G   �� 5Y      $��8��6]   $��1��6j   #��[ 6z   ��6   �� *Patient.MedicalHistory+$ PropertyChanged=�6z   �� 5[      $��Emergency Contact:��6   $��9��6,   $��0��69   #��[  6I   �� 5\      $��9��6_   $��1��6l   #��[ 6|   ��6   �� *Patient.EmergencyContact+$ PropertyChanged=�6|   �� 5^      $��Blood Group:��6   $��10��6&   $��0��64   #��[  6D   �� 5_      $��10��6Y   $��1��6g   #��[ 6w   ��6   �� *Patient.BloodGroup+$ PropertyChanged=�6w   �� 5a      $��
Allergies:��6   $��11��6$   $��0��62   #��[  6B   �� 5b      $��11��6X   $��1��6f   #��[ 6v   ��6   �� *Patient.Allergies+$ PropertyChanged=�6v   �� 5d      $��Notes:��6   $��12��6    $��0��6.   #��[  6>   �� 5e      $��12��6T   $��1��6b   #��[ 6r   ��6   �� *Patient.Notes+$ PropertyChanged=�6r   5f      5h      5j      