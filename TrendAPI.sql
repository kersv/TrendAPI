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

ALTER TABLE Trend ADD COLUMN MovieId INT;

ALTER TABLE Trend ADD FOREIGN KEY (MovieId) REFERENCES Movie(MovieId);

ALTER TABLE Trend ADD CONSTRAINT FK_TrendMovie FOREIGN KEY (MovieId) REFERENCES Movie(MovieId);

ALTER TABLE Movie ADD CONSTRAINT CHK_year CHECK (MovieYear >= 2000);

ALTER TABLE Trend AUTO_INCREMENT = 1;

INSERT INTO Movie (MovieName, MovieYear) VALUES ("Squid Game", 2021);
INSERT INTO Trend (Genre, MovieId) VALUES ("Thriller", 1);

SELECT * FROM Trend;
SELECT * FROM Movie;


