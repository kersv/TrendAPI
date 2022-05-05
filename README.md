# TrendAPI
This is an API for movies that are trending.
This API has 2 tables: Trend and Movie. 

Four Endpoints:
- api/trend
- api/trend/{TrendId}
- api/movie
- api/movie/{MovieId}

There is 3 available HTTP request
GET, PUT, POST

GET (This will return all values within the parameter)
- api/trend
- api/trend/{TrendId}
- api/movie
- api/movie/{MovieId}


PUT (This will updating an existing item based on the id given within the scope of the constraint, in my case movies >= 2000)
- api/trend/{TrendId}
- api/movie/{MovieId}

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
