# SFCoreTraining Lab 1

## Pre-requisites
1. Visual Studio 2022 installed on your machine https://visualstudio.microsoft.com/downloads/
2. At least MS SQL Express 2019 installed on your machine, regular SQL Server is fine too. We will be using SQL Express in this training class. https://www.microsoft.com/en-us/sql-server/sql-server-downloads

## Create a Sitefinity CMS Web Application using the .NET Framework 4.8

1. Open Visual Studio 2022.
2. In the toolbar, click File » New Project… The Create a new project window appears.
3. In the All languages dropdown, select C#.
4. In the All platforms dropdown, select Windows.
5. And in the All project types dropdown, select Web.
6. From the list of projects, select ASP.NET Web Application (.NET Framework).
7. In Project name, enter a name of your project.For example, enter SitefinityWebApp
8. Choose a location to store your project.
9. Enter a name for the solution. For example, enter SitefinityWebApp
10. In Framework, select .NET Framework 4.8. **(Very important step)**
11. Click Create.
12. In the window that appears, select Empty and click Create.


## Configure Sitefinity NuGet repository
####  In Visual Studio, perform the following:
1. In the toolbar, click Tools » NuGet Package Manager » Package Manager Settings.
2. In the left pane, expand NuGet Package Manager.
3. Select Package Sources.
4. Add a new source by clicking the plus button.
5. In Name, enter Sitefinity Nuget
6. In Source, enter https://nuget.sitefinity.com/nuget
7. Click OK

## Install Sitefinity CMS
#### In Visual Studio, perform the following:

1. In the toolbar, click Tools » NuGet Package Manager » Package Manager Console.
2. In Package source, select Sitefinity Nuget.
3. In Default project, select the empty project that you have created.
4. Depending on whether you want to install the full Sitefinity CMS package or a light version:
    1. To have all Sitefinity CMS modules installed in your project, install the Telerik.Sitefinity.All package by entering in the console: 
        ```
        Install-Package Telerik.Sitefinity.All
        ```
    1. To have only the core Sitefinity CMS modules installed in your project, install the Progress.Sitefinity package by entering in the console: 
        ```
        Install-Package Progress.Sitefinity
        ```
        #### NOTE: With these commands, you install the latest patch build. If you want to install a specific version, you must use the command followed by -Version and the version number. For example, enter Install-Package Telerik.Sitefinity.All -Version 14.3.8000

5. Wait until Sitefinity CMS is installed on your empty project. 
6. Build your solution
7. Run the Solution in Visual Studio
8. Activate the license by using your company's lic or a trial license. You can get a trial license from https://www.progress.com/sitefinity-cms/try-now/download
9. Go through the process of choosing SQL Express and let it complete the setup until you get to the Dashboard.

## Setup the Sitefinity .NET Core Application

1. Make sure the .NET Core CLI is installed on your machine. You can download it from here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0 if not installed already.
2. Add Sitefinity NuGet source with the following command: 
   ```
   dotnet nuget add source https://nuget.sitefinity.com/nuget
   ```
3. Install the template with the following command:
   ```
   dotnet new -i Progress.Sitefinity.AspNetCore.Templates::*
   ```
4. Create a new Renderer app with the following command:
    ```
    dotnet new sitefinity --project-name "YourProjectName" --sfurl "http://your.sitefinity.url"
    ```
5. Start the renderer using the following command:
    ```
    dotnet run
    ```