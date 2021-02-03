# Welcome
I made this API when i started learning .NET Core, it's a simple CRUD about cat names and it could be useful if you want to pick a name for your new cat!


# How to use

If you want to check the list of names just go to: https://name-your-cat.herokuapp.com/api/cat/ and you will be able to see the list there. 
Also, you can sort by female or males names writing F or M in the URL bar.

However if you want to add more or edit / delete some you will need postman or a similar software.


## Add more names
|                |||
|----------------|-------------------------------|-
|POST|`https://name-your-cat.herokuapp.com/api/Cat/`        

Example for a female cat
    
	{
		"name": "Sombra",
		"gender": "F"
	}

Example for a male cat

	{
		"name": "Leo",
		"gender": "M"
	}


## Edit one

|                |||
|----------------|-------------------------------|-
|PUT|`https://name-your-cat.herokuapp.com/api/Cat/`        

	{
		"id": "6019e215911f713662177a49",
		"name": "Luna"
	}

## Delete

|                |||
|----------------|-------------------------------|-
|DELETE|`https://name-your-cat.herokuapp.com/api/Cat/`        

	{
		"id": "6019e215911f713662177a49",
	}
