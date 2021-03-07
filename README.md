# EHI ContactInverory
The application preservs Contact information in system, allows users to manipulate it.

## Project Hirarchy

EHI.ContactsInvetory   
------>	EHI.ContactsInvetcry.API  
-------------->	Controllers  
------>	EHI.ContactsInvetory.BusinessLayer  
-------------->	Interfaces  
-------------->	Implementation  
------>	EHI.ContactsInvetory.DataAccess  
-------------->	Interfaces  
-------------->	Implementation  
------>	EHI.ContactsInvetory.Dto   
------>	EHI.ContactsInvetory.Tests   
------>	EHI.ContactsInvetory.Web  
-------------->	Controllers  
-------------->	Views  
-------------->	Models  

## Deployment

1. Give appropriate database connection string in EHI.ContactsInvetcry.API project appConfig.json file  
2. While publish, ensure Execute Code First Migrations is checked  

## WIP

1. Authentication and Authorization 
2. 100% Unit test coverage  

## Authors

* **Chandrashekhar Todkar** - *Initial work* 