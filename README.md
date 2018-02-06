# EmployeeApi
It is a Web API with DDD and TDD to store employees' information.

To start you need to execute the migration (inside the project LuizalabsEmployeeManager.Repositories - update-database command) to create the database or you can execute the SQL script file inside the folder Resources.

There are 3 methods in the endpoit, follow them bellow:

**GET api/Employee?page_size={page_size}&page={page}**	-> Get paginated Employee
page_size - int
page - int

Status code return -> 200 OK


**POST api/Employee**	-> Create new Employee
{
  "Name": "Name",
  "Email": "email@email.com",
  "Department": "Existent department name"
}

Status code return -> 201 Created


**DELETE api/Employee/{id}**	-> Delete an Employee
id - int

Status code return -> 200 OK
