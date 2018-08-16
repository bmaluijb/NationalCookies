# NationalCookies

![enter image description here](https://www.pluralsight.com/content/dam/pluralsight/newsroom/brand-assets/logos/pluralsight-logo-vrt-color-2.png)  

Hi! 

Welcome to the GitHub repository of the nationalcookies application.
This app is the demo app for the Pluralsight course [Microsoft Azure Developer: Implementing Azure Cache](https://app.pluralsight.com/profile/author/barry-luijbregts).

You can download a copy and follow along in the course.

You can see the end result running live here: [https://www.nationalcookies.nl/](https://www.nationalcookies.nl/)

The solution consists of:

 - Website (InternationalCookies)
	 - ASP.NET Core 2.1	 
 - Database project (NationalCookies.Data)
	 - For the database schema and seed script	 
 - ARM templates 
	 - For the creation of resources like the Web App, Azure SQL database and Redis cache for each region
		 - (InternationalCookies.Deploy-Region)
	 - For the creation of the Logic App
		 - (InternationalCookies.Deploy-Global)
		 
		 
		 
[![Deploy to Azure](https://azuredeploy.net/deploybutton.svg)](https://azuredeploy.net/)
