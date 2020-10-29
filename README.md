# ApiWithAuth-and-Blazor-frontend
A webapi project with authentication where you can create account with either user role or admin role. and a frontend in Blazor web assembly to use the api.

For convinience while developing the blazor app and the backend are in the same solution. For real purposes separate the frontend entirely from the solution.


1.Righ click solution and set both projects as startup projects. 
2. Click Webapiwithauths properties and set port number to a different port than the Blazorapp's portnumber.
3.In webapiwithauth's appsettings.json, set validaudience to the portnumber of Blazorapp and validissuer to the portnumber of Webapiwithauth.
4. In blazorapp's program.cs file change the api link in the httpclient to the url of webapiwithauth. (find it in the projects properties)



Bugs to fix: Sometimes after closing the browser while being logged in you cannot get your days or tasks upon opening the browser again, you have to log out and log in again
then it works. 
