   M S B A M L   `   `   `  ���� B  >Tzolkin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TzolkinTzolkin      Tzolkin.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Tzolkin       � Title$-  'Цолькин | Планировщик��$��438.494��$��714.347�� � 
ResizeMode$ CanMinimize=�.��� -   ���	#FF2D2D30 � ColumnDefinitions �� $
��589* ��� $
��203* �.+��� $��День��
�������$
��Left=�$��	26,20,0,0q�$	��Top=�$
��Bold"��� $��
Месяц��
�������$
��Left=�$��	26,51,0,0q�$	��Top=�$
��Bold"��� $��Год��
�������$
��Left=�$��	26,82,0,0q�$	��Top=�$
��Bold"��� -    ��Name$ inputDay��
������$
��Left=�$��25��$��	97,22,0,0q� �� TextWrapping$
 Wrap=�$��23��$	��Top=�$��53�� J� RenderTransformOrigin$ 1.124,0.397&����	#FF575757$
��Bold"��� -   $ 
inputMonth��
������$
��Left=�$��25��$��	97,54,0,0q�$
 Wrap=�$��01��$	��Top=�$��53��$ 1.124,0.397&����	#FF575757$
��Bold"��� -   $ 	inputYear��
������$
��Left=�$��25��$��	97,84,0,0q�$
 Wrap=�$
��2010��$	��Top=�$��53��$ 1.124,0.397&����	#FF575757$
��Bold"��� -   $"��КОНВЕРТИРОВАТЬ��$
��Left=�$��
26,120,0,0q�$	��Top=�$	��124��$��32�����	#FFEE8732�� -    ��Name$ InfoKIN��
�������$��Кин 1, ИМИШ 1��$
��Left=�$��
26,189,0,0q�$	��Top=�$��46��$	��150��$
��Bold"�$��14(��� -    ��Name$ InfoImageTone��$
��Left=�$��37��$��
57,225,0,0q�$3��-pack://siteoforigin:,,,/Resources/tones/1.gif��$	��Top=�$��69���� -   $ 	InfoImage��$
��Left=�$	��118��$��
26,267,0,0q�$	��Top=�$	��124��$1��+pack://siteoforigin:,,,/Resources/sym/1.png�� J� OpacityMask �	#FFFFFBFB�� -	   	 ��Name$	 scrollViewer��$
��Left=�$	��352��$��
198,33,0,0q�$	��Top=�$	��490��$
��Auto=�$��2��.���� -
   
 ��Name$
 	textBlock��$
��Left=�
�������$
��Wrap=�$�� ��$	��Top=�$
��1200��$	��470��$
��Bold"��� -   $��Справка��$
��Left=�$��
26,157,0,0q�$	��Top=�$	��124�����	#FFB2B2B2