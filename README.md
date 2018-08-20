# NationalCookies

![enter image description here](https://www.pluralsight.com/content/dam/pluralsight/newsroom/brand-assets/logos/pluralsight-logo-vrt-color-2.png)  

Hi! 

Welcome to the GitHub repository of the nationalcookies application.
This app is the demo app for the Pluralsight course [Microsoft Azure Developer: Implementing Azure Cache](https://app.pluralsight.com/profile/author/barry-luijbregts).

You can download a copy of the code and follow along in the course.

You can see the end result running live here: [https://www.nationalcookies.nl/](https://www.nationalcookies.nl/)

The solution consists of:

 - NationalCookies.MVC
	 - This is the website for the Nationalcookies cookie store
	 - Technology: ASP.NET Core MVC 2.1	 
 - NationalCookies.Forms
	 - This is the website for the Nationalcookies cookie store ,based on ASP.NET Forms
	 - Technology: ASP.NET Forms 4.7	 	 
 - NationalCookies.Database
	 - This contains the database schema and seed script
	 - Technology: Visual Studio Database project
 - NationalCookies.Data
	 - This is a class library that contains classes to connect to the database and work with cookies and orders
	 - Technology: 
	 	- Class library (.NET Standard 2.0)
		- Entity Framework Core 2.1
		
This is a very simple solution that consists out of a website (either NationalCookies.MVC or NationalCookies.Forms) that connects to a database and later on in the course, also connects to Azure Redis Cache:


![Image of Nationalcookies solution](https://dnz.blob.core.windows.net/cdn/Nationalcookies%20solution.png)


Follow the steps below to get this code working:

### Step 1: Create a database
The website needs a database to get information about cookies and read and write order information. The database that we are using is a SQL Server database. This can be one that you install locally or an Azure SQL database that you run in Azure. 

In any case, make sure that you have a SQL Server running that you can access.

### Step 2: Change the connection strings
In order for the website to connect to the database, we need to enter the connection string to the database.
We do that in these two places:

-  NationalCookies.MVC / appsettings.json
	- Fill in the CookieDBConnection setting with the value of the connectionstring to your SQL Server
-  NationalCookies.Forms / Web.config
	- Fill in the CookieDBConnection setting with the value of the connectionstring to your SQL Server	

### Step 3: Deploy the database schema and seed script
Now that we have a database and that we website can connect to it, we need to make sure that there are tables and data in the database.

You can do that with the NationalCookies.Database project:
1. In Visual Studio, you can right-click on the NationalCookies.Database project and click Publish. The screen in the image below opens:

![Image of Nationalcookies solution](https://dnz.blob.core.windows.net/cdn/Publish%20database%20screen.png)

2. Click the Edit button to set the connection to your SQL Server database
3. Click Publish

That's it! Now, you can run either the NationalCookies.MVC or NationalCookies.Forms project and follow along with the course. 

Thanks for watching and let me know if you have any questions!
