CREATE TABLE artists (
  id SERIAL PRIMARY KEY,
  surname varchar,
  name varchar,
  second_name varchar,
  id_country int,
  id_period int
);

CREATE TABLE countries (
  id int PRIMARY KEY,
  name varchar
);

CREATE TABLE periods (
  id int PRIMARY KEY,
  name varchar
);

CREATE TABLE pictures (
  id int PRIMARY KEY,
  name varchar,
  id_artist int
);

CREATE TABLE artists_expo (
  id_artist int,
  id_expo int
);

CREATE TABLE expositions (
  id int PRIMARY KEY,
  name varchar
);

ALTER TABLE artists ADD FOREIGN KEY (id_country) REFERENCES countries (id);

ALTER TABLE artists ADD FOREIGN KEY (id_period) REFERENCES periods (id);

ALTER TABLE pictures ADD FOREIGN KEY (id_artist) REFERENCES artists (id);

ALTER TABLE artists_expo ADD FOREIGN KEY (id_artist) REFERENCES artists (id);

ALTER TABLE artists_expo ADD FOREIGN KEY (id_expo) REFERENCES expositions (id);
