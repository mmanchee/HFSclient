# _Fantasy Football League_

#### _Fantasy Football program API and database to simulate fantasy football games, Created: November 2nd, 2020; Modified: November 5th, 2020_

#### By _**Mike Manchee, Joseph Nilles, Daniel Schaaf & Jeff Dinsmore **_

## Description



<!-- 

 -->
### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
|  1.  ... | ... | ... |


## Setup/Installation Requirements

### Project from GitHub
* Download option
  * Download files from GitHub repository by click Code and Download Zip
  * Extract files into a single directory 
  * Run GitBASH in directory
  * Type "dotnet restore" to get bin and obj files
  * Type "dotnet build" to verify no errors
  * Type "dotnet ef migrations add Initial" to initialize migrations
  * Type "dotnet ef database update" to add the database
  * Type "dotnet run" in GitBash to run the program
  * Have fun with HFS Client<!-- TITLE HERE -->

* Cloning options
  * For cloning please use the following GitHub [tutorial](https://docs.github.com/en/enterprise/2.16/user/github/creating-cloning-and-archiving-repositories/cloning-a-repository)
  * Place files into a single directory 
  * Run GitBASH in directory
  * Type "dotnet restore" to get bin and obj files
  * Type "dotnet build" to verify no errors
  * Type "dotnet ef migrations add Initial" to initialize migrations
  * Type "dotnet ef database update" to add the database
  * Type "dotnet run" in GitBash to run the program
  * Add database per the instructions below.
  * Have fun with HFS Client<!-- TITLE HERE -->

### To Login as Administrator and Change Administrator Credentials
* _To login as the administrator, use the username and password credentials "admin@HFS.local" & "NotSecure123!!"_
* _The admin credentials can be changed to your preferred username and password by going to the SeedData.cs file in the project root directory_
* _Change lines 38 & 47 where the username "admin@pierre.local" is to your preferred username_
* _Change line 48 where the password "Notsecure1" is and change to your preferred password_
* _Save both files_
* _Your admin username and password are now updated_

## Known Bugs

No Known Bugs

## Technologies Used
Project Specifics
* C# API

Main Programs
* MySQL
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
  * [Entity](https://docs.microsoft.com/en-us/ef/core/)
  * [Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-3.1)
  * [MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* CSS
  * [Bootstrap](https://getbootstrap.com/docs/4.5/getting-started/introduction/)
  * [Font Awesome](https://www.w3schools.com/icons/fontawesome_icons_intro.asp)
  * [Postman](https://www.postman.com/)


### Other Links
![GitHub](img/Github.png)
[Mike's GitHub](https://github.com/mmanchee)<br />
[LinkedIn](https://www.linkedin.com/in/mikemanchee/)<br />
[Garrett's GitHub](https://github.com/garrett-brown-dev/)<br />
[LinkedIn](https://www.linkedin.com/in/garrett-brown-d/)

### License

Copyright (c) 2020 **_{Mike Manchee}_**
Licensed under MIT

Co-authored-by: Joseph Nilles <jbnilles24@gmail.com>
Co-authored-by: Jeff Dinsmore <hello@jeffdinsmore.com>
Co-authored-by: Daniel Schaaf <daniel.schaaf@outlook.com>
Co-authored-by: Mike Manchee <mikemanchee@gmail.com>

Merge Branches
type "git fetch mm" mm = to origin
all branches will be pulled down
type "git merge mm/branch" branch = the branch
correct conflicts
add and commit changes
