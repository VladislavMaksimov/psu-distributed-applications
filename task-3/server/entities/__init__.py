class Person:
    def __init__(self, surname: str, name: str, second_name: str):
        self.surname = surname
        self.name = name
        self.second_name = second_name

    def serialize(self):
        data = {
            'name': self.name,
            'surname': self.surname,
            'second_name': self.second_name
        }
        return data

class Unit:
    def __init__(self, name: str, gender: bool, unit_type: str):
        self.name = name
        self.gender = gender
        self.unit_type = unit_type