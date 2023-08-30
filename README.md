# InternalInstalledBase

## Missing Implementations

The project is currently missing the linking between the Product and Property page.
The Product page still requires a field named "Show Properties" or similar, which will open a window in which the user
can link the product to an existing property. The user also will have to enter which properties shall be choosen from the existing **Options**. On the Property there is a **isMultipleChoice** field which should be checked because it decides if a user can only select one field or multiple.

Everything else should be correctly implemented.

## Setup
To run the programm a database connection is required to a MySQL server.
### f.e. create a docker-container 

```shell
docker pull mysql:latest

docker run --name IIB -p 7400:3306 -e MYSQL_ROOT_PASSWORD=yourRootPassword -e MYSQL_DATABASE=IIB -e MYSQL_USER=user -e MYSQL_PASSWORD=yourPassword -d mysql:latest

```

The config should then be put in *src/DapperExtension/dbconfig.yml*
**Note** The file is only in this directoy because the project isnt finished. When compiling to a binary the dbconfig should be in the same directory as the binary.

For the recently created docker-container the config will look like the following:

`````yml
server: localhost
port: 7400
database: IIB
user: user
password: yourPassword 
`````
**Note** The dbconfig.yml is loaded relatively to the *src/WpfApplication* directory because the application assumes it is started with *dotnet run* in this directory.
When refractoring or compiling this into an executable this should be respected.

## Run the application

The application is started with `dotnet run` inside of the **src/WpfApplication** directory
