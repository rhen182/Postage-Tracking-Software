   M S B A M L   `   `   `  ����M  IWGUCapstoneProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WGUCapstoneProject.AppViewsWGUCapstoneProject.AppViews  5   	   3    -WGUCapstoneProject.AppViews.ViewPostageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:WGUCapstoneProject.AppViews     5   	     � Title$  ViewPostageWindow��5   	   $	��450��6#   $
��auto��60    � SizeToContent$ WidthAndHeight=�6=    � WindowStartupLocation$ CenterScreen=�6\   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��5 �6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��mailDataGrid��5         AutoGenerateColumns$ false��6#   $��1��6?   $��1��6O   $��3��5      $��3��6"      AreRowDetailsFrozen$
 True��66      CanUserAddRows$ False��6Q      HeadersVisibility$ Column=�5      	   CanUserDeleteRows$	 False��60   
   CanUserResizeRows$
 False��6J      CanUserReorderColumns$ False��6d      SelectionMode$ Single=�5          AlternatingRowBackground
 �����   
IsReadOnly$
 True��6Q   $��3q�6c      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Mail ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *MailId+  5#      $
 Case��6%    63   �� *
CaseName+  5$      $ 	Last Name��6%    68   �� *
LastName+  5%      $ Organization��6%    6;   �� *OrganizationName+  5&      $
 Cost��6%    63   �� *Cost+  5'      $ Postage Type��6%    6;   �� *PostageTypeName+  5(      $ 	Date Sent��6%    68   �� *
DateSent+5*      �� 5,   
   -   5         ��Name$ btnAdd��5.      $��1��5-      $��1��6   $��Add Postage��5/      $��3q�51      52      �� 53   
   -   5        $ 	btnModify��55      $��2��54      $��1��6   $��Modify Postage��56      $��3q�57      59      �� 5:   
   -   5        $ btnGetReport��5;   z   $��3��6   $��1��6   $��2��6*   $��Postage Report��6;   $��3q�6T   5<      �� 5>   
   -   5        $ btnDeleteOne��5@      $��1��5?      $��2��6   $��Delete Postage��5A      $��3q�5C      5D      �� 5E   
   -   5        $ btnDeleteAll��5G      $��2��5F      $��2��6   $��Delete All Postage��5H      $��3q�5J      $y�Visible=�5K      5L      5M      5N      