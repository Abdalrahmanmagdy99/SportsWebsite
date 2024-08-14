# Sports Website

Welcome to the Sports Website repository. This README provides information on the prerequisites, steps to run the website, and important notes to ensure a smooth setup and operation.

## Prerequisites

Before running the website, ensure you have the following installed on your system:

- Visual Studio 2022
- SQL Server Local Db
- .Net 7 SDK / Runtime

## Steps To Run The Website

Follow these steps to get the website up and running:

1. **Clone The Repository**:  
   Clone the repository 

2. **Update the Database**:  
   Open the Package Manager Console in Visual Studio, set the Domain Layer as the default project, and run the following command:  

3. **Run The API Project**:  
Start the API project by setting it as the startup project and running it.

4. **Run The Web Project**:  
Similarly, start the Web project by setting it as the startup project and running it.

5. **Modify the Program.cs**:  
After the first run, navigate to the `Program.cs` file in the Presentation Layer and comment out the `PopulateData();` function call located at line 34.

6. **Login**:  
Use the following credentials to log in:
- **Username**: Admin@gmail.com
- **Password**: Admin123!

## Important Notes

- **Database Update**: Ensure you run the `Update-Database` command before launching the application.
- **Project Order**: Always run the API project before starting the Web project.
- **Post-First Run**: Remember to comment out the `PopulateData();` function after the first run.
- **Login Requirement**: You must be logged in to perform Add, Update, and Delete operations.
- **Logo Format**: Ensure the logo file is in `.png` format.


