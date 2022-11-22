# Labb4-API

GET ALL
https://localhost:7234/api/Person

GET Interest for Person
https://localhost:7234/api/Interest/1

GET Links for Person
https://localhost:7234/api/Website/2

PUT add interest to Person
https://localhost:7234/api/Interest/1/update
{ InterestID = 4, InterestTitle = "Crabs", InterestDescript = "Crab people", PersonID = 1 }

POST add links for Person and Interest
https://localhost:7234/api/Website/4/add
{ "WebpageLink": "www.hats.tk", "Interest": null, "Persons": { "FirstName": "Emma", "LastName": "Whiteside", "Phone": "0700021212", "Interest": null }, "PersonID": 2 }
