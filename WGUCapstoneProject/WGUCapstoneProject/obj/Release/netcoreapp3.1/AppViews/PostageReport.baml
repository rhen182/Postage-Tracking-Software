   M S B A M L   `   `   `  ���� M  IWGUCapstoneProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WGUCapstoneProject.PlaygroundViews"WGUCapstoneProject.PlaygroundViews  6    0WGUCapstoneProject.PlaygroundViews.PostageReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Blocal0clr-namespace:WGUCapstoneProject.PlaygroundViews       � Title$  PostageReport��$	��450��$	��800�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $��5 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��5 � � RowDefinitions �� $��5 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��5 �.+��� -    ��Name$ 	cmbMonths��$��1��$��1��$��3q�$��75�� �� 
IsEditable$
 True�� �� 
IsReadOnly$
 True�� �� Text$ Select Month������ *months+�� -   $ cmbYears��$��2��$��1��$��3q�$��75��$
 True��$
 True��$
 Year������ *years+�� -   $ cmbCase��$��3��$��1��$��3q�	 �� DisplayMemberPath$	 CaseName��$��75��$
 True��$
 True��$ 	Case Name������ *cases+�� -   
 ��Name$
 btnLoad��$��4��$��1��$��1��$��Load Report��$��3q�$��75���� -    ��Name$ 
txtCsvName��$��2��$��2��$��1��$��3q�$ ��Enter Exported Report Name�� �� TextAlignment$ Center=��� -   $
 btnExportToCsv��$��3��$��2��$��Export to CSV��$��3q�$��75���� -   $
 	btnCancel��$��4��$��2��$��1��$��3q�$
��Back��$��75��&   System.Windows.Controls.DataGrid  -   $��postageDataGrid��   AutoGenerateColumns$ false��$��1��$��3��$��4��   AreRowDetailsFrozen$
 True��   CanUserAddRows$ False��   HeadersVisibility$ Column=�   CanUserDeleteRows$ False��   CanUserResizeRows$ False��   CanUserReorderColumns$ False��   SelectionMode$ Extended=�   AlternatingRowBackground
 �����   
IsReadOnly$
 True��$��3q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mail ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MailId+  $
 Case�� �� *
CaseName+  $ 	Last Name�� �� *
LastName+  $ Organization�� �� *OrganizationName+  $
 Cost�� �� *Cost+  $ Postage Type�� �� *PostageTypeName+  $ 	Date Sent�� �� *
DateSent+  -	   $��postageTotalGrid��$ false��$��1��$��4��$��2��$
 True��$ False��$ Column=�$ False��$ False��$ False��$ Extended=�
 �����$
 True��$��3q�   $
 Case�� �� *Case+  $ 
Month Sent�� �� *	MonthSent+  $ 	Year Sent�� �� *
YearSent+  $ 
Total Cost�� �� *Total+