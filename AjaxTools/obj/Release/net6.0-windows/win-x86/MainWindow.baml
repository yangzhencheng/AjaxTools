   M S B A M L   `   `   `  ���� D  @AjaxTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AjaxTools	AjaxTools      AjaxTools.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:AjaxTools       � Title$  Ajax 数据发送��$	��750��$	��950��.��� $��12q� � RowDefinitions �� $��60 ��� $��30 ��� $	��300 ��� $	��300 �.+�� $��0�� � ColumnDefinitions �� $��93 ��� $	��260 ��� $	��120 �.+��� -    ��Name$ combSendMethod��$��0��$��80��$��30��$��0,0,12,0q� �� SelectedIndex$ 0��$��Center=�$��Center=����#AAA.@��� $��30��$��Center=�$��Center=�.��GET�� $��30��$��Center=�$��Center=�.��POST�� $��30��$��Center=�$��Center=�.��PUT�� $��30��$��Center=�$��Center=�.��DELETE�� -    ��Name$ txtUrlAddress��$��1��$��30��$��Center=��� -    ��Name$ btnSendData��$��2��$��16,0,0,0q�$��30��
����=H�
�������.��发送� $��1��.+���  �� Orientation$ 
Horizontal=�.+��� $
��Bold"�$��0,0,0,0q�ContentType：	� -   $��12,0,0,0q� 	� 	GroupName$ SelectContentType��$'��!application/x-www-form-urlencoded��	 d� 	IsChecked$
	 TrueY�	� -   $��12,0,0,0q�$ SelectContentType��$��multipart/form-data��	� -   $��12,0,0,0q�$ SelectContentType��$��application/json��� $��2��.+��� .+��� $
��Bold"�$��30��传输数据：�� -   $ txtSendData��$	��240��
 �� TextWrapping$

 Wrap=� �� AcceptsReturn$
 True��$
��Auto=�
���   �� $��3��$��0,16,0,0q�.+��� .+��� $
��Bold"�$��30��回传数据：�� -   $ txtReceiveData��$	��240�� �� 
IsReadOnly$
 True��$

 Wrap=�$
 True��$
��Auto=�
������