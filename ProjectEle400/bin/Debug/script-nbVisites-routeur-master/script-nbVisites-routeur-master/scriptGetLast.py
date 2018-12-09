import firebase_admin
from firebase_admin import credentials
from firebase_admin import db
from collections import Counter
import re
import sys

routeur = str()
routeur = sys.argv[1]

#initialiser la base de donee


cred = credentials.Certificate("cle_db.json")

firebase_admin.initialize_app(cred,{ "databaseURL" : "https://routeur-18013.firebaseio.com/"})

ref = db.reference("/Bancs/" + routeur)

#extraction des données de tout les bancs
dataBancs = db.reference("/Bancs").get()

#contientlesentrees "arrive" dans la db
macList = list()

#dataBancs dict
for i in dataBancs.keys():
	#dict
	banc = dataBancs[i]
	for j in banc.keys():
		donee = banc[j]
		if donee["type"] == "ajout":
			macList += [donee["adresse"]]
#Les nombres de visites sont dans macList
macList = Counter(macList)

if routeur not in dataBancs:
	sys.stdout.write("reference invalide")
	sys.stdout.flush()
	sys.exit()

adresse = str()
banc = dataBancs[routeur]
for i in banc.keys():
	if banc[i]["type"] == "ajout":
		adresse = ["adresse"]
		
mac = f"{adresse} {macList[adresse]}"
sys.stdout.write(mac)
sys.stdout.flush()
sys.exit()
