   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$  Task Manager��5   
   $	��450��6   $	��600��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ processListView��5      ��6,   �� *	Processes+ �� View 5      �� 5      .P�5      �� $��
Process ID��6%    �� Width$ 80��6]    �� DisplayMemberBinding 69   �� *Id+6]   �� 5      $
��Name��6%   $	 200��6Y    63   �� *Name+6Y   �� 5      $	��CPU��6%   $	 200��6\    62   �� *
CpuUsage+6\   �� 5      $��Memory (MB)��6%   $	 100��6g    6:   �� *MemoryUsage+6g   5      5      �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   $��10q�69   .+�5      �� -   5         ��Name$ selectedProcessTextBlock��5      5      �� 5   
   -   5         ��Name$ 
killButton��5      $
��Kill��6%   $��1��64   $��80��6A   $��30��6L   $��10q�6X   5      5      5      