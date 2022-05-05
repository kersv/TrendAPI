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

GET Response Example

GET api/trend/1
```
{
       "statusCode": 200,
       "statusDescription": "Successful",
       "trendList": [
        {
              "trendId": 1,
              "genre": "Thriller",
              "movie": {
                  "movieId": 1,
                  "movieName": "Squid Game",
                  "movieYear": 2021
              }
           }
        ]
}
```

PUT Request Example
PUT api/movie/1
```
{
       "movieId": 1,
       "movieName": "Squid Game season 2",
       "movieYear": 2025
}
      
```


POST Request Example
POST api/trend
```


```
