# bus-tickets-semos

ASP.NET Core web application intended for online booking and purchasing bus tickets throughout the country.

## Installation and setup

For this web application to work properly, you need to install the following programs:
- Visual Studio 2019
- SQL Server 2019 & SQL Server Management Studio 18

## After successful installation of the programs, you need to enable SQL Server Authentication:
- Open Sql Server Management Studio
  - Login with Windows Authentication
  - Under the Object Explorer, right click the first row that contains your server name (ex. DESKTOP-8BR4ALU (SQL Server 15.0.20))
  - Click Properties
    - Click Security
    - Under Server Authentication, uncheck the Windows Authentication mode and check the SQL Server and Windows Authentication mode
    - Click Ok
  - Restart your SQL Server Management Studio
- Next, enable the login for the user sa
    - Under the Object Explorer, expand Security
     - Expand Logins
      - Right click on the user sa
        - Click on Properties
        - Change the password to 12345
        - Uncheck Specify old password policy & Enforce password policy
     - On the left hand side, click on Status
        - Under Login, uncheck Disabled and check Enabled
        - Click Ok
     - Restart your SQL Server Management Studio
  - Run your SQL Server Management Studio
  - Under Authentication, choose SQL Server Authentication
  - Login :
      - Username : sa
      - Password: 12345
  - Click Connect and you are good to go!
  
## After successful login with SQL Server Authentication, you need to restore the database BusesDB
  - Under the Object Explorer, right click Databases
    - Click Restore Database
    - Under Source, uncheck the Database and check the Device
    - Click on the 3 dots
    - Click add and navigate to the folder that contains your project bus-tickets-semos
    - Locate the file BusesDB.bak and click OK
    - Check if the database BusesDB is restored under Databases
    
## After successful restore of the database, you need to change the connection string in the project
- Open the project in Visual Studio 2019
- Expand Libraries
  - Expand API
  - Double click on appsettings.json and the following code will be there: 
  ```"ConnectionStrings": {
    "DefaultConnection": "Server="DESKTOP-8BR4ALU";Database=BusesDB;User Id=sa;password=12345;Trusted_Connection=False;MultipleActiveResultSets=True;"
  }
  ```
  - You need to change the Server="DESKTOP-8BR4ALU" with your server's name
    - Open SQL Server Management Studio and Copy your Server Name
  - Paste your server's name at "Server="".
  - Hit Save All and you are good to go!
  
  
  

