   M S B A M L   `   `   `  ���� M  IWGUCapstoneProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WGUCapstoneProject.AppViewsWGUCapstoneProject.AppViews  5    /WGUCapstoneProject.AppViews.ModifyPostageWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:WGUCapstoneProject.AppViews       � Title$  ModifyPostageWindow��$	��450��$
��auto�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=�.���  � ColumnDefinitions �� $��5 ��� $
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
��auto ��� $��5 �.+��� $��Modify Postage��$��1��$��1��$��5��$��Center=��� $��2��$��1��$
��Case��$��3q�$��Center=�$��Center=��� -    ��Name$ cmbCase��$��2��$��2��$��2��$	��150��$��3q� �� DisplayMemberPath$ CaseName��-  'System.Windows.Input.KeyboardNavigation   TabIndex$ 0������ *
caseList+�� -    ��Name$ txtNewCaseName��$	��150��$��2��$��2��$��2��$y�Hidden=�$ 0���� $��2��$��4��$��Address Line 1��$��3q��� -   $ txtAddress1��$��2��$��5��$	��150��$��3q�$ 6���� $��3��$��1��$��	Recipient��$��3q��� -   $ txtNewRecipientFirstName��$��3��$��2��$��First��$��3,3,3,0q�$��75��$ 1��$��18��$	��Top=��� -   $ txtNewRecipientLastName��$��3��$��3��$
��Last��$��3q�$��75��$ 2���� $��3��$��4��$��Address Line 2��$��3q��� -   $ txtAddress2��$��3��$��5��$	��150��$��3q�$ 7���� $��4��$��1��$��Organization��$��3q��� -   $ cmbOrganization��$��4��$��2��$��2��$	��150��$��3q�$ OrganizationName��$ 3������ *organizations+�� -   $ txtNewOrganizationName��$	��150��$��4��$��2��$��2��$y�Hidden=�$ 3���� $��4��$��4��$
��City��$��3q�$��Center=�$��Center=��� -	   $ txtCity��$��4��$��5��$	��150��$��3q�$ 8���� $��5��$��1��$
��Cost��$��3q�$��Center=�$��Center=��� -
   $ txtCost��$��5��$��2��$��2��$	��150��$��3q�$ 4���� $��5��$��4��$��State��$��3q�$��Center=�$��Center=��� -   $ txtState��$��5��$��5��$	��150��$��3q�$ 9���� $��6��$��1��$��Postage Type��$��3q��� -   $ cmbPostageType��$��6��$��2��$��2��$	��150��$��3q�$ PostageTypeName��$ 5������ *postageTypes+�� -   $ txtNewPostageTypeName��$	��150��$��6��$��2��$��2��$��3q�$y�	Collapsed=�$ 5���� $��6��$��4��$��Zip Code��$��3q�$��Center=�$��Center=��� -   $ txtZip��$��6��$��5��$	��150��$��3q�$ 10���� -   	 ��Name$	 	btnCancel��$��1��$��3��$��7��$��Cancel��$��3q�$ 12���� -   $	 	btnModify��$��4��$��3��$��7��$��2��$��Confirm��$��3q�$ 11��