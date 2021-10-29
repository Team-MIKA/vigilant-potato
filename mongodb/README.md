
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