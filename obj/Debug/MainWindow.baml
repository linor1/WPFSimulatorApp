   M S B A M L   `   `   `  ����M  IFlightSimulatorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FlightSimulatorApp.ViewsFlightSimulatorApp.Views  5   	   #    FlightSimulatorApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8views&clr-namespace:FlightSimulatorApp.Views     5   	     � Title$  
MainWindow��5   	   $	��900��6   $��1080.8��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��40 �6   6*   �� 5      $	��600 �6   6+   �� 5      $��* �6   6)   .+�5   
   �� $��Flight Simulator��6   $��4��6,   $��Center=�6@   $��Center=�6]   $��20(�6x   6�   "   FlightSimulatorApp.Views.Map  5   
   $��2��6   $��0��6!   $��2��61   $��2��6E   �� 5   
   -   5         ��Name$ ConnectButton��5      $��1��6(   $��0��65   $��Right=�6E   $��10q�6a   ��6m   �� *ConnectCommand+.��6�   	Connect6�   �� 5   
   -   5        $ SettingsButton��5      $��1��6)   $��1��66   $
��Left=�6F   $��10q�6a   ��6m   �� *SettingsCommand+.��6�   
Settings6�   '   !FlightSimulatorApp.Views.Joystick  5   
   $��2��6   $��2��6&   $��1��66   $��2��6G   6_   (   "FlightSimulatorApp.Views.DashBoard  5   
   $��3��6   $��2��6'   $��1��67   $��2��6H   6`   5       57      