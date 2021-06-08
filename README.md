# ApiWithAuth-and-Blazor-frontend
A webapi project with authentication where you can create account with either user role or admin role, and set up your todo list for the week. Very basic frontend only to showcase use purposes.

For convinience while developing the blazor app and the api/backend are in the same solution. For real purposes separate the frontend entirely from the solution.


1. Righ click solution and set both projects as startup projects. 
2. Click Webapiwithauths properties and set port number to a different port than the Blazorapp's portnumber.
3. In webapiwithauth's appsettings.json, set validaudience to the portnumber of Blazorapp and validissuer to the portnumber of Webapiwithauth.
4. In blazorapp's program.cs file change the api link in the httpclient to the url of webapiwithauth. (find it in the projects properties)
5. Or just test the API via postman or swagger.



Migrate db's before running the project using packet manager console
1. add-migration initial -Context ApplicationDbContext
2. add-migration initial -Context TodoDbContext
3. update-database -Context ApplicationDbContext
4. update-database -Context TodoDbContext

Now you can test the project.
