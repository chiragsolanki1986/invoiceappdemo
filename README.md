# Invoice App

The solution is based on the below stack
<ul>
  <li>.NET Core Web Api</li>
  <li>.NET Core MVC</li>
  <li>SQL Server - using code first approach</li>
 </ul>
 
 The proposed soluton has two projects, one for the UI and the other API services. The SQL scripts are also attached for the refernce under DBScripts folder.
 
 The data access layer has been built using repository pattern to ensure an additional layer of abstraction.
 
 ## Information on Domain Entities
 The domain entities consists of the below
 <ul>
 	<li>Company</li>
	<li>Invoice - many-to-one relation ship with Company</li>
	<li>CustomerDetails - one to one relationship with invoice. However this can be updated to be many-to-one relation with Company</li>
	<li>ShippingDetails - one-to-one relationship with invoice</li>
	<li>InvoiceLineItem - many-to-one relationship with invoice</li>
 </ul>
 
 The application is built with limited functionality as asked in the requirements. Edit and Delete functionality is not provided to limit the scope.
 
 Note: Once the solutioln is cloned/downloaded, kindly restore the nuget packages.
