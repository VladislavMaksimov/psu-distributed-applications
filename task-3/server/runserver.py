from flask import Flask, session, render_template, redirect, request, url_for, jsonify
from entities import Person, Unit
from storage import Storage
from flask_cors import CORS, cross_origin

app = Flask(__name__)
CORS(app)

@app.route('/random/male', methods=['GET'])
def get_random_male(): 
    return jsonify(Storage.get_random_person(True).serialize())

@app.route('/random/female', methods=['GET'])
def get_random_female(): 
    return jsonify(Storage.get_random_person(False).serialize())

@app.route('/new/surname', methods=['POST'])
@cross_origin(origin='*',headers=['Content-Type', 'Access-Control-Allow-Origin'])
def post_surname():
    json_data = request.json
    Storage.add_unit(Unit(json_data['name'], bool(json_data['gender']), 'surname'))
    return jsonify({'data': json_data['name']})
    
@app.route('/new/name', methods=['POST'])
@cross_origin(origin='*',headers=['Content-Type', 'Access-Control-Allow-Origin'])
def post_name():
    json_data = request.json
    Storage.add_unit(Unit(json_data['name'], bool(json_data['gender']), 'name'))
    return jsonify({'data': json_data['name']})

@app.route('/new/second_name', methods=['POST'])
@cross_origin(origin='*',headers=['Content-Type', 'Access-Control-Allow-Origin'])
def post_second_name():
    json_data = request.json
    Storage.add_unit(Unit(json_data['name'], bool(json_data['gender']), 'second_name'))
    return jsonify({'data': json_data['name']})

app.run(port=8080, host='0.0.0.0', debug=True)