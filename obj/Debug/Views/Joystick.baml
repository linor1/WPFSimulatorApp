   M S B A M L   `   `   `  ����M  IFlightSimulatorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FlightSimulatorApp.ViewsFlightSimulatorApp.Views  5      '    !FlightSimulatorApp.Views.Joystick   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:FlightSimulatorApp.Views     5      .��5
      � 
�������  � ColumnDefinitions  5   
   �� 5      $��80 �6   6,   �� 5      $��* �6   6+   �� 5      $��80 �6   6,    � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      $��* �6   6)   �� 5      $��30 �6   6*   .+�5   
   �� -   5         ��Name$
 Base��5   &   
�������$	��340��64   $	��340��6@   $��1��6M   $��1��6Z   $��1��6j   .+�5      A� $
��Left=�6   $	��340��61   $	��Top=�6>   $	��340��6V   ��5      
� 5      .��5      �  � Color$ 	#FF2C2A2A��6'    � Offset$ 1Q�69   � 5      $ 	#FF3A3737��6'   5      5      A� 5      $
��Left=�6   $	��170��61   $	��Top=�6>   $	��170��6V    �� Left$ 84��6b   
 �� Top$ 84��6s   ��5       
� 5!      .��5"      � $ 	#FF0E0E0E��6'   $ 1Q�69   � 5#      $ 	#FF1D1D1D��6'   � 5$      $ 	#FF323030��6'   $ 0.453Q�69   5%      5'      F� 5)      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Y   $��18.375��6t    �� Stretch$
 Fill=�6�    � UseLayoutRounding .  $	��Top=�6�   $��42.75��6�   $ 147.875��6�   $ 37.625��6�   F� 5*      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Y   $��18.375��6t   $
 Fill=�6�    .  $	��Top=�6�   $��42.75��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   $ 147.875��6�   $ 284.125��6	  z�5+      �� 5,      
 �� ScaleY$
 -1Q�6%   5.      F� 5/      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Y   $��18.375��6t   $
 Fill=�6�    .  $	��Top=�6�   $��42.75��6�   $	 0.5,0.5&�6�   $ 270.875��6�   $ 162.125��6	  z�50      V� 51      .~�52      �� $
 -1Q�6)    �� ScaleX$ -1Q�65   �� 53       �� Angle$	 -90Q�6*   54      56      F� 57      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Z   $��18.375��6u   $
 Fill=�6�    .  $	��Top=�6�   $��42.75��6�   $	 0.5,0.5&�6�   $ 24.375��6�   $ 163.625��6	  z�58      V� 59      .~�5:      �� $ 90Q�6*   �� 5;      $ -1Q�6)   5<      5>      �� 5@      -   5        $
 Knob��5@      $	��Top=�6$   $
��Left=�6<   $��0��6W   $��0��6a   $	 0.5,0.5&�6l   $	 125��6�   $	 125��6�   .+�5A      ��  �� Orientation$ Vertical=�6   $��91��64   5H      A� 5I      -   5         A�Name$ Shadow��5I      $
��Left=�6*   $��88��6E   $	��Top=�6Q   $��86��6i   ���	#52131212$ 22��6�   $ 18��6�   A� 5J      -   5        $ KnobBase��5J      $
��Left=�6,   $��90��6G   $	��Top=�6S   $��90��6k   $	 0.5,0.5&�6v   $ 1��6�   ��5K      
� 5L      .��5M      � $ 	#FF8A8A8A��6+   � 5N      $ 	#FF979797��6+   $ 1Q�6=   5O      5Q      A� 5R      $
��Left=�6   $��74.313��65   $	��Top=�6E   $��82.189��6]   $	 0.5,0.5&�6l    .  $ 0.613��6�   $ 1.692��6�   ��5S      
� 5T      .��5U      � $ 	#C0828080��6+   $ 0.797Q�6=   � 5V      $ 	#FD000000��6+   5W      z�5Y      V� 5Z      .~�5[      �� $ -28.434Q�6.   �� 5\       �� AngleX$ -2.144Q�6,   T� 5]       T� X$ -1.199Q�61    T� Y$ 0.649Q�6<   5^      5`      A� 5a      $
��Left=�6   $��75.491��65   $	��Top=�6F   $��70.887��6^   $	 0.5,0.5&�6m    .  $ 12.396��6�   $ 5.057��6�   ��5b      �� 5c       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5d      � $ 	#00858585��6+   $ 0Q�6=   � 5e      $ 	#1AFFFFFF��6+   $ 1Q�6=   � 5f      $ 	#3FC2C2C2��6+   $ 0.349Q�6=   5g      z�5i      V� 5j      .~�5k      ��  �� CenterX$ 3Q�6,    �� CenterY$ -4Q�68   �� 5l      $ -.7628Q�6.   5m      5o      �� 5p      -   5         ��Name$ Ellipse_button��5p      $ 5��61   $ 1��6A   ��5q      �� 5r      .R�5s      A� $
��Left=�6&   $��72.722��6A   $	��Top=�6Q   $��72.936��6i   $	 0.5,0.5&�6x    .  $ 0.631��6�   $ 4.896��6�   ��5t   "   
� 5u   &   .��5v   *   � $ 	#9A909090��67   $ 1Q�6I   � 5w   *   $
 Gray��67   5x   '   z�5z   "   �� 5{   &   $ -31.733Q�66   6H   5}      5~      5�      A� 5�      $
��Left=�6   $��37��65   $	��Top=�6A   $��39��6Y   $	 0.5,0.5&�6d    .  $ 14.001��6�   $ 11.001��6�   z�5�      �� 5�      $ -8Q�6(   67   ��5�      
� 5�      .��5�      � $ 	#FF898989��6+   $ 0Q�6=   � 5�      $ 	#38777777��6+   $ 1Q�6=   � 5�      $ 	#55676767��6+   $ 0.672Q�6=   5�      5�      F� 5�      �����fÔ �ҵ �`�� 0j� ѐ�� �� Ѵ� ؍�<7�  �7�J#� ��=�v�j X:�0�f H���t ��� �"��  � � �7 �Ŕ ��l �ڙ �b�W �� Ѡ6G ��� QR B h��|?�0@���@ 0ѶeC  �8�    p�3�N�  �R� (� �@&& �� �<5R�` ј�BR�` Ѹ�J �� Ѱ�<�Ŕ �$�hL� �d�� @]� �@� �ǆ ��� ��j �+?    �+?:O0 �h6��- �d�� �6 �TE� �I �D� v�[ ��8� ��a �@�� �|: Ѩ!� ��$ �Tv� � ��n��j0@�� 	���	#99EEEEEE$
��Left=�6�  $��20.833��6�  $
 Fill=�6�   .  $	��Top=�6�  $��21.667��6�  $ 18.166��6  $ 15.917��6  z�5�      T� 5�      -   5        knobPosition��5�   )    � 	Resources 5�       g�Name   
CenterKnob �� 
TargetName �� TargetProperty	 W� To g� Duration W� EasingFunction-  'System.Windows.Media.Animation.BackEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode��%d  &	        �� 5�      $ 
centerKnob��64   -   5        .��5�      W� $ knobPosition��6*   $ X�5�      $ 0X�6<   $ 0:0:0.2D�6C    5�        5�   "   $ 	EaseInOut=�6+   5�      W� 5�      $ knobPosition��6*   $ Y�6O   $ 0X�6m   $ 0:0:0.2D�6t    5�        5�   "   $ 	EaseInOut=�6+   5�      5�      5�      5�      5�      �� 5�   
   $��20(�6   $
��Bold"�6"   $��Center=�64   $��Center=�6O   $��0��6l   $��0��6y   ��6�   �� *
Throttle+�� 5�   
   $��20(�6   $
��Bold"�6"   $��Center=�64   $��Center=�6O   $��0��6m   $��1��6z   ← rudder →6�   � 5�   
   $��0��6   $��2��6   $��2��6,   $��1��6=     5�      �� 5�      $
��Auto �6#   62   �� 5�      $
��Auto �6#   62    5�      �� 5�      $
��Auto �6    $��56��6.   6?   �� 5�      $
��Auto �6    $	��3.2��6.   6@   .+�5�      �� $��20(�6   $
��Bold"�6&   $��0��6P   $��0��6`   $��1��6m   $��2��6�   ��68   �� *Rudder+6�   �� 5�      $��20(�6   $
��Bold"�6&   $��1��6R   $��0.4,39,-0.4,-2.2q�6b   $��2��6|   ��68   �� *
Elevator+ � LayoutTransform 5�      �� 5�      $ 90Q�6&   5�      5�      �� 5�   
   $��2��6   $��1��6"   $��2��62   .+�5�      �� $��20(�6   $
��Bold"�6&   $��Center=�68   $��Center=�5�      �� 65   $�← aileron →��69   6O   5�      � 5�   
   $��0��6   $��0��6   $��0,0,0,0q�6,   $��2��6=     5�      �� 5�      $��* �6#   6/   �� 5�      $��* �6#   6/   .+�5�      �� $��20(�6   $
��Bold"�6&   $��← throttle →��68   $��0��5�      $��1��6(   $��2��65   $��1��6F   $��1,150q�6Z   $��Stretch=�6i   $	 0.533,0.272&�6�    5�      �� 5�      $ 90Q�6&   5�      �� 5�      -   5          �� Orientation$  
Horizontal=�5�   /   $��Bottom=�5�      ! �� IsSnapToTickEnabled! . " � Minimum$" -1Q�5�      # � Maximum$# 1Q�6   $ �� TickPlacement$
$ Both=�6*   % �� TickFrequency$
% 0.01Q�6@   & �� AutoToolTipPlacement$& BottomRight=�5�      $	 0.493,1.306&�68   $��42��6\   $��1��5�   ;   $��100,10,-300,0q�6K   $��2��6b   $��2��6o   ' � Value' 5�      �� *	Aileron+5�   o   �� 5�      -	   5        $	��300��5�   0   $��Right=�6<   $��1��6X   $��1��6h   ! . $" -1Q�5�      $# 1Q�6   $
$ Both=�6*   $
% 0.01Q�6@   $& BottomRight=�5�      ( �� IsDirectionReversed( . ' 5�      �� *
Throttle+ 5�      �� 5�      $ 90Q�6&   5�      5�      �� 5�   
   $��20(�6   $
��Bold"�6"   $��← elevator →��64   $��1��6H   $��2��6U   $��Center=�5�      $��Center=�61   $��2��6L    5�      �� 5�      $ 90Q�6"   5�      �� 5�   
   $��2��6-   $��3��6:   $��20(�6J   $
��Bold"�6X   $��Center=�6j   $��Center=�5�      ��5�      �� *	Aileron+5�   0   5�      5�      