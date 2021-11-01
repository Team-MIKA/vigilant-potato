# vigilant-potato
This is the repository for group MIKA's P7 project

# GraphQL:
- https://chillicream.com/docs/hotchocolate
- https://chillicream.com/docs/hotchocolate/fetching-data
- https://dianper.medium.com/building-graphql-api-in-net-core-hotchocolate-mongodb-docker-part-1-d00a20eb0ff0


## Banana Cake Pop example: (Please check MongoDB README for database example content)
{
  books(
    where: {
      bookName: { eq: "Clean Code" }
  }){
    id
    author
    bookName
    price
  }
}