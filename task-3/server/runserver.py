from flask import Flask, session, render_template, redirect, request, url_for, jsonify
from entities import Person, Unit
from storage import Storage
from flask_cors import CORS, cross_origin
import messages_pb2

app = Flask(__name__)
CORS(app)

@app.route('/random/male', methods=['GET'])
def get_random_male(): 
    return Storage.get_random_person(True).SerializeToString()

@app.route('/random/female', methods=['GET'])
def get_random_female(): 
    return Storage.get_random_person(False).SerializeToString()

@app.route('/new/surname', methods=['POST'])
@cross_origin(origin='*',headers=['Content-Type', 'Access-Control-Allow-Origin'])
def post_surname():
    surname = messages_pb2.Unit()
    surname.ParseFromString(request.data)
    Storage.add_unit(surname, 'surname')
    return jsonify({'data': surname.name})
    
@app.route('/new/name', methods=['POST'])
@cross_origin(origin='*',headers=['Content-Type', 'Access-Control-Allow-Origin'])
def post_name():
    name = messages_pb2.Unit()
    name.ParseFromString(request.data)
    Storage.add_unit(name, 'name')
    return jsonify({'data': name.name})

@app.route('/new/second_name', methods=['POST'])
@cross_origin(origin='*',headers=['Content-Type', 'Access-Control-Allow-Origin'])
def post_second_name():
    second_name = messages_pb2.Unit()
    second_name.ParseFromString(request.data)
    Storage.add_unit(second_name, 'second_name')
    return jsonify({'data': second_name.name})

app.run(port=8080, host='localhost', debug=True)