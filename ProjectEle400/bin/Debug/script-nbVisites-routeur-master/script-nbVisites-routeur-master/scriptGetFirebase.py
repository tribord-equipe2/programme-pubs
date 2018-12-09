import firebase_admin
from firebase_admin import credentials
from firebase_admin import db
from collections import Counter
import re
import sys

routeur = str()
routeur = sys.argv[1]

#initialiser la base de donee

idBanc = "Routeur1"

cred = credentials.Certificate("cle_db.json")

firebase_admin.initialize_app(cred,{ "databaseURL" : "https://routeur-18013.firebaseio.com/"})

ref = db.reference("/Bancs/" + idBanc)

#extraction des données de tout les bancs
dataBancs = db.reference("/Bancs").get()

#contientlesentrees "arrive" dans la db
macList = list()
#contient les entrees depart
macListDepart = list()

#dataBancs dict
for i in dataBancs.keys():
	#dict
	banc = dataBancs[i]
	for j in banc.keys():
		donee = banc[j]
		if donee["type"] == "ajout":
			macList += [donee["adresse"]]

macList = Counter(macList)

macListBanc = list()

if routeur not in dataBancs:
	sys.stdout.write("reference invalide")
	sys.stdout.flush()
	sys.exit()

try:
	macListBanc = db.reference("/presence/" + routeur).get()["adresses"]
except:
	sys.stdout.write("Aucune connection")
	sys.stdout.flush()
	sys.exit()
	
macList = Counter(macList)

mac = str()

for i,j in macList.most_common(len(macList)):
	if i in macListBanc:
		mac = f"{i} {j}"
		break
		
sys.stdout.write(mac)
sys.stdout.flush()
sys.exit()
