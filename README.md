# TrendAPI
This is an API for movie and series that are trending.
This API has 2 tables: Trend and Movie. 
This is one-to-many relationship.

Three Endpoints:
- api/trend
- api/movie
- api/movie/{MovieId}

There is 3 available HTTP request
GET, PUT, POST

GET (This will return all values within the parameter)
- api/trend
- api/trend/{trendId}
- api/movie
- api/movie/{movieId}


PUT (This will updating an existing item based on the id given within the scope of the constraint, in my case movies >= 2000)
- api/trend/{trendId}
- api/movie/{movieId}

POST (This will add an entry to the table based on the response body given)
- api/trend

sample request body

PUT api/movie/1
```
{
       
}
```

POST api/movie
```
{
        
        
}
```
