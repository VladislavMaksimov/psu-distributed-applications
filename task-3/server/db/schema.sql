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
values ('��������', 1, 0),
('�������', 1, 0),
('���������', 1, 0),
('�������', 1, 0),
('������', 1, 0),
('������', 1, 0),
('�������', 1, 0),
('����', 1, 0),
('������', 1, 0),
('�������', 1, 0),
('���', 1, 0),
('���������', 1, 0);

insert into surname (name, gender, added_by_user)
values ('���������', 0, 0),
('��������', 0, 0),
('����������', 0, 0),
('��������', 0, 0),
('�������', 0, 0),
('�������', 0, 0),
('��������', 0, 0),
('����������', 0, 0),
('�������', 0, 0),
('��������', 0, 0),
('��������', 0, 0),
('����������', 0, 0);

insert into name (name, gender, added_by_user)
values ('���������', 1, 0),
('������', 1, 0),
('����', 1, 0),
('������', 1, 0),
('����', 1, 0),
('�������', 1, 0),
('�������', 1, 0),
('����', 1, 0),
('�����', 1, 0),
('�������', 1, 0),
('���������', 1, 0),
('�������', 1, 0);

insert into name (name, gender, added_by_user)
values ('�����', 0, 0),
('�����', 0, 0),
('����', 0, 0),
('�����', 0, 0),
('���������', 0, 0),
('��������', 0, 0),
('������', 0, 0),
('��������', 0, 0),
('��������', 0, 0),
('�����', 0, 0),
('�������', 0, 0),
('�����', 0, 0);

insert into second_name (name, gender, added_by_user)
values ('�������������', 1, 0),
('����������', 1, 0),
('��������', 1, 0),
('���������', 1, 0),
('��������', 1, 0),
('����������', 1, 0),
('�������������', 1, 0),
('��������', 1, 0),
('��������', 1, 0),
('����������', 1, 0),
('���������', 1, 0),
('����������', 1, 0);

insert into second_name (name, gender, added_by_user)
values ('�������������', 0, 0),
('����������', 0, 0),
('��������', 0, 0),
('���������', 0, 0),
('��������', 0, 0),
('����������', 0, 0),
('�������������', 0, 0),
('��������', 0, 0),
('��������', 0, 0),
('����������', 0, 0),
('���������', 0, 0),
('����������', 0, 0);