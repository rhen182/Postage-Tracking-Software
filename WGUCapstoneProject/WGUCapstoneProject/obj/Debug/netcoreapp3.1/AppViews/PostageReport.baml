   M S B A M L   `   `   `  ����M  IWGUCapstoneProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WGUCapstoneProject.PlaygroundViews"WGUCapstoneProject.PlaygroundViews  5   	   6    0WGUCapstoneProject.PlaygroundViews.PostageReport   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:WGUCapstoneProject.PlaygroundViews     5   	     � Title$  PostageReport��5   	   $	��450��6   $	��800��6,    � SizeToContent$ WidthAndHeight=�68    � WindowStartupLocation$ CenterScreen=�6W   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��5 �6   .+�5!   
   �� -   5         ��Name$ 	cmbMonths��5"      $��1��6    $��1��60   $��3q�6=   $��75��6g    �� 
IsEditable$
 True��6u    �� 
IsReadOnly$
 True��6�    �� Text$ Select Month��6�   ��6H   �� *months+5#      �� 5$   
   -   5        $ cmbYears��5%      $��2��6   $��1��6/   $��3q�6<   $��75��6e   $
 True��6s   $
 True��6�   $
 Year��6�   ��6G   �� *years+5&      �� 5'   
   -   5        $ cmbCase��5(      $��3��6   $��1��6.   $��3q�6;   	 �� DisplayMemberPath$	 CaseName��6d   $��75��6�   $
 True��6�   $
 True��6�   $ 	Case Name��6�   ��6F   �� *cases+5)      �� 5*   
   -   5        
 ��Name$
 btnLoad��5+      $��4��6   $��1��6.   $��1��6?   $��Load Report��6L   $��3q�6b   $��75��6�   5,      �� 5-   
   -   5         ��Name$ 
txtCsvName��5-      $��2��6&   $��2��63   $��1��6G   $��3q�6W   $ ��Enter Exported Report Name��6b    �� TextAlignment$ Center=�6�   6�   �� 50   
   -   5        $
 btnExportToCsv��51      $��3��6%   $��2��65   $��Export to CSV��6B   $��3q�6Z   $��75��6�   52      �� 53   
   -   5        $
 	btnCancel��54      $��4��6    $��2��60   $��1��6=   $��3q�6Q   $
��Back��6t   $��75��6�   55      &   System.Windows.Controls.DataGrid  56   
   -   5        $��postageDataGrid��56         AutoGenerateColumns$ false��6*   $��1��6F   $��3��6V   $��4��6c      AreRowDetailsFrozen$
 True��6w      CanUserAddRows$ False��6�      HeadersVisibility$ Column=�6�      CanUserDeleteRows$ False��6�      CanUserResizeRows$ False��6�      CanUserReorderColumns$ False��6�      SelectionMode$ Extended=�6     AlternatingRowBackground
 �����   
IsReadOnly$
 True��6T  $��3q�6f     Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Mail ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *MailId+  59      $
 Case��6%    63   �� *
CaseName+  5:      $ 	Last Name��6%    68   �� *
LastName+  5;      $ Organization��6%    6;   �� *OrganizationName+  5<      $
 Cost��6%    63   �� *Cost+  5=      $ Postage Type��6%    6;   �� *PostageTypeName+  5>      $ 	Date Sent��6%    68   �� *
DateSent+5@        5A   
   -	   5        $��postageTotalGrid��5A      $ false��6+   $��1��6G   $��4��6W   $��2��6d   $
 True��6x   $ False��6�   $ Column=�6�   $ False��6�   $ False��6�   $ False��6�   $ Extended=�6  
 �����$
 True��6U  $��3q�6g   5B        5C      $
 Case��6%    63   �� *Case+  5D      $ 
Month Sent��6%    69   �� *	MonthSent+  5E      $ 	Year Sent��6%    68   �� *
YearSent+  5F      $ 
Total Cost��6%    69   �� *Total+5H      5I      5J      