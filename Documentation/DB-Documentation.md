# Database Documentation

## Table of Contents
[Prerequisites](#prerequisites)
[Database SetUp](#database-setup)
[Adding migrations after initial setup](#adding-migrations-after-initial-setup)
[Order of migrations](#order-of-migrations)
[Getting card and set data](#getting-card-and-set-data)


## Prerequisites

- Visual Studio installed with ASP.NET Core 3.1
- MS SQL Server installed and running.
- Either Visual studio or MS SQL Server Manager to look at the 

## Configure and set up database

##### IMPORTANT - These instructions are only to be run the first time. To re-run these instructions, the database must be deleted.

1. Launch Visual Studio.
2. Go to the appsettings.json file and change the connection string server value to your local computers name.
    * `"DefaultConnection": "Server=<Insert your database/computer name here>;Database=BurnBuilder;Trusted_Connection=True;`MultipleActiveResultSets=true"
3. Open the Package Manager Console in Visual Studio.
4. Once it's loaded type Update-Database and press enter. You will see the following messages in the console.

```
PM> Update-Database
Build started...
Build succeeded.
Done.
PM> 
```

5. Check the database is correct in either Visual Studio or MS SQL Server Manager.

At this point you should be set up and ready to launch the app with an empty database. 

Also note, this will fully update your database to the latest migration in the schema. 

## Adding migrations after initial setup

After you have the database set up and have been working with it there are two ways you can get an updated database schema.

1. Delete the database and start over. (Ouch!)
2. Perform the update migrations one at a time from where your database is to current. This does require that you know which migration you are currently on. Migrations done out of order could potentially error or break the database. Broken database is only fixed by deleting the database and starting again with the initial set up.

## Order of migrations

1. InitialCustomTableCreation
2. 


## Getting card and set data

