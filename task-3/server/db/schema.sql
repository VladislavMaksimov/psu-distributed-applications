create table surname
(
	id integer not null	primary key autoincrement,
	name text not null,
	gender integer not null,
	added_by_user integer
);

create table name
(
	id integer not null	primary key autoincrement,
	name text not null,
	gender integer not null,
	added_by_user integer
);

create table second_name
(
	id integer not null	primary key autoincrement,
	name text not null,
	gender integer not null,
	added_by_user integer
);

insert into surname (name, gender, added_by_user)
values ('Максимов', 1, 0),
('Парыгин', 1, 0),
('Сибиряков', 1, 0),
('Вотяков', 1, 0),
('Иванов', 1, 0),
('Петров', 1, 0),
('Сидоров', 1, 0),
('Шпак', 1, 0),
('Бобров', 1, 0),
('Кельсин', 1, 0),
('Кук', 1, 0),
('Соломонов', 1, 0);

insert into surname (name, gender, added_by_user)
values ('Максимова', 0, 0),
('Парыгина', 0, 0),
('Сибирякова', 0, 0),
('Вотякова', 0, 0),
('Иванова', 0, 0),
('Петрова', 0, 0),
('Сидорова', 0, 0),
('Акименкова', 0, 0),
('Боброва', 0, 0),
('Кельсина', 0, 0),
('Сохорова', 0, 0),
('Соломонова', 0, 0);

insert into name (name, gender, added_by_user)
values ('Владислав', 1, 0),
('Матвей', 1, 0),
('Семён', 1, 0),
('Сергей', 1, 0),
('Глеб', 1, 0),
('Дмитрий', 1, 0),
('Виталий', 1, 0),
('Егор', 1, 0),
('Павел', 1, 0),
('Валерий', 1, 0),
('Александр', 1, 0),
('Алексей', 1, 0);

insert into name (name, gender, added_by_user)
values ('Ирина', 0, 0),
('Алина', 0, 0),
('Анна', 0, 0),
('Дарья', 0, 0),
('Анастасия', 0, 0),
('Анжелика', 0, 0),
('Любовь', 0, 0),
('Виктория', 0, 0),
('Вероника', 0, 0),
('Алиса', 0, 0),
('Валерия', 0, 0),
('Елена', 0, 0);

insert into second_name (name, gender, added_by_user)
values ('Александрович', 1, 0),
('Алексеевич', 1, 0),
('Семёнович', 1, 0),
('Сергеевич', 1, 0),
('Глебович', 1, 0),
('Дмитриевич', 1, 0),
('Владиславович', 1, 0),
('Егорович', 1, 0),
('Павлович', 1, 0),
('Валерьевич', 1, 0),
('Матвеевич', 1, 0),
('Витальевич', 1, 0);

insert into second_name (name, gender, added_by_user)
values ('Александровна', 0, 0),
('Алексеевна', 0, 0),
('Семёновна', 0, 0),
('Сергеевна', 0, 0),
('Глебовна', 0, 0),
('Дмитриевна', 0, 0),
('Владиславовна', 0, 0),
('Егоровна', 0, 0),
('Павловна', 0, 0),
('Валерьевна', 0, 0),
('Матвеевна', 0, 0),
('Витальевна', 0, 0);