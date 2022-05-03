CREATE DATABASE TrendMovieService;


USE TrendMovieService;

CREATE TABLE Trend(
	TrendId INT NOT NULL AUTO_INCREMENT,
    Genre VARCHAR(255) NOT NULL,
    PRIMARY KEY (TrendId)

);
    


CREATE TABLE Movie(
	MovieId INT NOT NULL AUTO_INCREMENT,
    MovieName VARCHAR(255) NOT NULL,
    MovieYear INT NOT NULL,
    PRIMARY KEY (MovieId)
);

CREATE TABLE Series(
	SeriesId INT NOT NULL AUTO_INCREMENT,
    SeriesName VARCHAR(255) NOT NULL,
    SeriesYear INT NOT NULL,
    PRIMARY KEY (SeriesId)
);

ALTER TABLE Trend ADD COLUMN MovieId INT;
ALTER TABLE Trend ADD COLUMN SeriesId INT;

ALTER TABLE Trend ADD FOREIGN KEY (MovieId) REFERENCES Movie(MovieId);
ALTER TABLE Trend ADD FOREIGN KEY (SeriesId) REFERENCES Series(SeriesId);

ALTER TABLE Trend ADD CONSTRAINT FK_TrendMovie FOREIGN KEY (MovieId) REFERENCES Movie(MovieId);
ALTER TABLE Trend ADD CONSTRAINT FK_TrendSeries FOREIGN KEY (SeriesId) REFERENCES Series(SeriesId);

ALTER TABLE Trend DROP CONSTRAINT FK_TrendMovie;
ALTER TABLE Trend DROP CONSTRAINT FK_TrendSeries;


ALTER TABLE Movie ADD CONSTRAINT CHK_year CHECK (MovieYear >= 2000);
ALTER TABLE Series ADD CONSTRAINT CHK_Seriesyear CHECK (SeriesYear >= 2000);


INSERT INTO Movie (MovieName, MovieYear) VALUES ("example movie2", 2002);
INSERT INTO Series (SeriesName, SeriesYear) VALUES ("example series", 2012);



INSERT INTO Trend (Genre, MovieId) VALUES ("Horror", 1);
INSERT INTO Trend (Genre, SeriesId) VALUES ("Comedy", 1);

SELECT * FROM Trend;
SELECT * FROM Movie;
SELECT * FROM Series;



