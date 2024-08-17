# Angular 16 CRUD with .NET 7 Web API using Entity Framework Core

## This is my first app with suсh instruments as angular and bootstrap and mssql server. 
Because of I did it on macOs I need to put mssql in a docker container. Here are the steps for this in termiinal:

* Download docker
* Enter command *docker pull mcr.microsoft.com/mssql/server:2019-latest* 
* Once the download is complete, you need to run the downloaded SQL Server image in Docker with command: 
   *docker run --name [type in your desired SQL Server name here] -e ‘ACCEPT_EULA=Y’ -e ‘SA_PASSWORD=[type in your password for your database]’-e ‘MSSQL_PID=[type in your Docker membership type]’ -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest*

	*ACCEPT_EULA=Y* in the above command means you accept the End User License Agreement for Docker.

	I used command *docker run -d --name sql_server_demo -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=mySronggPwd123' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest*

Also there is an analogue of SQL Server Management Studio for macOs  - this is  Azure Data Studio. After Downloaded it from official Microsoft web-page you need to create a New Connection. 

Since SQL Server runs on your own Mac, the server is simply local. The username is SA for System Administrator and the password is the one you entered in the terminal command to start SQL Server with Docker