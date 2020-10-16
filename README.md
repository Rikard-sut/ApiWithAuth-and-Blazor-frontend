# ApiWithAuth-and-Blazor-frontend
A webapi project with authentication where you can create account with either user role or admin role. and a frontend in Blazor web assembly to use the api.


1.Righ click solution and set both projects as startup projects. 
2. Click Webapiwithauths properties and set port number to a different port than the Blazorapp's portnumber.
3.In webapiwithauth's appsettings.jspo, set validaudience to the portnumber of Blazorapp and validissuer to the portnumber of Webapiwithauth.
4. In blazorapp's program.cs file change the api link in the httpclient to the url of webapiwithauth. (find it in the projects properties)
