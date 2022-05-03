# TrendAPI
This is an API for movie and series that are trending.
This API has 3 tables: Trend, Movie, and Series.
This is one-to-many relationship.

Three Endpoints:
- api/trend
- api/movie
- api/movie/{MovieId}

There is 3 available HTTP request
GET, PUT, POST
GET api/trend 
- This will return all the trendid along with the genre of the movie

PUT api/movie/{id}
- This will updating an existing item based on the movieid given

POST api/movie
- This will add an entry to the movie table based on the response body given.

examples request body 
POST api/movie
```
{
    "movieName": "example movie6",
    "movieYear": 2005
}
```
