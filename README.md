# GraphQL with Postman

Juan Fonseca 2024

Notes and exercises for Postman's Pooja Mistry's GraphQL training [1].

## History
* Facebook developed GraphQL in 2012.

## Benefits [2]
* Avoids data under and over-fetching by letting the consumers specify what information they want to receive.
* Minimizes the impact of changes on the API as consumers can (i) specify the schema of the query, and (ii) perform all operations using the same endpoint.

## Characteristics
* GraphQL operations [1]:
    * Queries: fetch data (like GET).
    * Mutations: create or update data (like POST, PUT, or DELETE).
    * Subscriptions: bi-directional communication (streaming, "real-time" communication).
 * The queries in GraphQL are composed of the following elements [3, 4]:
    * Fields (data objects)
    * Argument: arguments send to fields (for filtering).
    * Alias: to differentiate two result fields with the same type.
    * Fragment: nested list of objects re-usable in queries or mutations.
    * Operation name: the name of the queries or mutations.
    * Variables
 
## Inspection
Postman retrieves the full query schema from a GraphQL service to let the users choose what they want to use.

## Query examples
Taking as an example the [Star Wars's Apollo API](https://studio.apollographql.com/public/star-wars-swapi/variant/current/home), we can retrieve all movie titles using a wide-open query:

Query:
```
query Query {
  allFilms {
    films {
      id 
      title
      director
      releaseDate
    }
  }
}
```

Response fragment:
```
{
    "data": {
        "allFilms": {
            "films": [
                {
                    "id": "ZmlsbXM6NQ==",
                    "title": "Attack of the Clones",
                    "director": "George Lucas",
                    "releaseDate": "2002-05-16"
                },
```

Then, retrieve all characters in a movie by specifying the ID of the movie:

Query:
```
{
    film(id: "ZmlsbXM6NQ==") {
        characterConnection {
            characters {
                id
                name
                homeworld {
                    name
                }
            }
        }
    }
}
```

Response fragment:
```
{
    "data": {
        "film": {
            "characterConnection": {
                "characters": [
                    {
                        "id": "cGVvcGxlOjI=",
                        "name": "C-3PO",
                        "homeworld": {
                            "name": "Tatooine"
                        }
                    },`
```

**Note:** 'characters' object isn't the same as 'person', and 'films' isn't the same as 'film' (not nice).

## References
1. Pooja Mistry. Postman. GraphQL in Postman. URL: https://youtube.com/playlist?list=PLM-7VG-sgbtBbxlhXae-NegYvDD5uqFyC&si=_KpbbJ1bB_YAKrcy (last consulted on 09/10/2024).
2. Testing and Developing GraphQL APIs | Postman Intergalactic. URL: https://youtu.be/VRn2Nl8RXNw?si=2Lb0bxIwpp3jOrmM (last consulted on 09/11/2024).
3. Yudhajit Adhikary. GraphQl: The Big Picture. Medium. URL: https://yudhajitadhikary.medium.com/graphql-the-big-picture-f61bac8b72f8 (last consulted on 09/13/2024).
4. GraphQL. Queries and Mutations. https://graphql.org/learn/queries/ (last consulted on 09/13/2024).
