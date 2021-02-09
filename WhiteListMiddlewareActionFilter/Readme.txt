Article: https://docs.microsoft.com/en-us/aspnet/core/security/ip-safelist?view=aspnetcore-2.2

This article shows three ways to implement an IP address safelist
(also known as an allow list/whitelist ) in an ASP.NET Core app. An accompanying 
sample app demonstrates all three approaches. You can use:

 1.   Middleware to check the remote IP address of every request.
 2.   MVC action filters to check the remote IP address of requests for specific controllers or action methods.
 3.   Razor Pages filters to check the remote IP address of requests for Razor pages.
