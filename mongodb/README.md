
## Run 
Run ```docker-compose up``` to run the mongodb.

### Management UI
mongodb://root:example@mongo:27017/
Login with the user provided in the .env file.

### Environments
Look at the .env.template for inspiration on how to configure the image

### Mongo DB terminology

| Sql Terms   | MongoDB Terms                         |
|-------------|---------------------------------------|
| Database    | Database                              |
| Table       | Collection                            |
| Row         | Document (BSON document)              |
| Column      | Field                                 |
| Primary key | In MongoDB it is set to the _id field |

## Resources
* https://hub.docker.com/_/mongo?tab=description
* https://stackoverflow.com/questions/47901561/how-to-run-mongodb-and-mongo-express-with-docker-compose
* https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-5.0&tabs=visual-studio
The following article is used to setup the connection with dotnet and mongodb:
* https://medium.com/@kristaps.strals/docker-mongodb-net-core-a-good-time-e21f1acb4b7b


## Setting up example database 
* Reference: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-5.0&tabs=visual-studio
1. Go to Docker Desktop and open Docker in CLI. 
2. write 'mongosh'
3. write 'use admin'
4. write 'db.auth('MONGO_ROOT_USER', 'MONGO_ROOT_PASSWORD') --> found in .env file
5. write 'use BookstoreDb'
6. write 'db.createCollection('Books')'
7. write 'db.Books.insertMany([{'Name':'Design Patterns','Price':54.93,'Category':'Computers','Author':'Ralph Johnson'}, {'Name':'Clean Code','Price':43.15,'Category':'Computers','Author':'Robert C. Martin'}])'

8. GJ, ur good to go.