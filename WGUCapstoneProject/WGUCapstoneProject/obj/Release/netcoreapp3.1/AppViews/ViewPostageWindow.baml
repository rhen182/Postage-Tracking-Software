   M S B A M L   `   `   `  ���� M  IWGUCapstoneProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WGUCapstoneProject.AppViewsWGUCapstoneProject.AppViews  3    -WGUCapstoneProject.AppViews.ViewPostageWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:WGUCapstoneProject.AppViews       � Title$  ViewPostageWindow��$	��450��$
��auto�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $��5 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��5 � � RowDefinitions �� $��5 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��5 �.+�&   System.Windows.Controls.DataGrid  -   $��mailDataGrid��   AutoGenerateColumns$ false��$��1��$��1��$��3��$��3��   AreRowDetailsFrozen$
 True��   CanUserAddRows$ False��   HeadersVisibility$ Column=�	   CanUserDeleteRows$	 False��
   CanUserResizeRows$
 False��   CanUserReorderColumns$ False��   SelectionMode$ Single=�   AlternatingRowBackground
 �����   
IsReadOnly$
 True��$��3q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mail ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MailId+  $
 Case�� �� *
CaseName+  $ 	Last Name�� �� *
LastName+  $ Organization�� �� *OrganizationName+  $
 Cost�� �� *Cost+  $ Postage Type�� �� *PostageTypeName+  $ 	Date Sent�� �� *
DateSent+�� -    ��Name$ btnAdd��$��1��$��1��$��Add Postage��$��3q��� -   $ 	btnModify��$��2��$��1��$��Modify Postage��$��3q��� -   $ btnGetReport��$��3��$��1��$��2��$��Postage Report��$��3q��� -   $ btnDeleteOne��$��1��$��2��$��Delete Postage��$��3q��� -   $ btnDeleteAll��$��2��$��2��$��Delete All Postage��$��3q�$y�Visible=�