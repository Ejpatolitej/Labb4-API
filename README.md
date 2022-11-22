# Labb4-API

GET ALL
https://localhost:7234/api/Person

GET Interest for Person
https://localhost:7234/api/Person/1/interest

GET Links for Person
https://localhost:7234/api/Person/1/link

PUT add interest to Person
https://localhost:7234/api/Interest/1
{
  "interestID": 1,
  "interestTitle": "Horses",
  "interestDescript": "I Love Horses",
  "personID": 2
}

POST add links for Person and Interest
https://localhost:7234/api/Website/4/add
{ 
  "webpageLink": "www.minecraft.not",
  "interestID": 2, 
  "person": {FirstName: "Jack",
             LastName: "Niklasson", 
             Phone: "0722211144"
		}, 
"personID": 1
}
