
import sqlite3
import random
from pathlib import Path
from entities import Person, Unit
import messages_pb2


db_path = '/'.join([str(Path(__file__).parent), '..', 'db', 'database.sqlite'])
db = sqlite3.connect(db_path, check_same_thread=False)


class Storage:
    @staticmethod
    def get_random_person(gender: bool) -> messages_pb2.Person:
        gender_sql = str(int(gender))
        person_data = db.execute('SELECT surname.name, name.name, second_name.name FROM surname, name, second_name WHERE surname.gender = ? AND name.gender = ? AND second_name.gender = ? ORDER BY RANDOM() LIMIT 1', (gender_sql, gender_sql, gender_sql)).fetchone()
        person = messages_pb2.Person()
        person.surname = person_data[0]
        person.name = person_data[1]
        person.second_name = person_data[2]
        return person

    @staticmethod
    def add_unit(unit: messages_pb2.Unit, unit_type: str):
        name = unit.name
        if unit.gender == True:
            gender = '1'
        else:
            gender = '0'

        db.execute('INSERT INTO ' + unit_type + ' (name, gender, added_by_user) VALUES (?,?,1)', (name, gender))
        db.commit()        