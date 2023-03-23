# Calculator API
This is a simple calculator API built with .NET Core Web API, which supports basic arithmetic operations (+, -, *, /) and JWT authentication for secure access. The API also uses FluentValidation for input validation and Serilog for logging HTTP requests and responses to a file.

### Getting Started

####Prerequisites
To build and run the API, you need the following installed on your machine:



- .NET 7 SDK

####Installing
- Clone the repository to your local machine.

- Open a command prompt or terminal window and navigate to the root directory of the project.

- Run the following command to build the project:
    `dotnet build`
- Run the following command to start the API:
`dotnet run`

The API should now be running and listening for requests.

###Usage

####Authentication
The API uses JWT authentication for secure access.

- To register a user, you need to send a POST request to the /api/auth/register endpoint with a username and password.

- Then To authenticate, you need to send a POST request to the /api/auth/login endpoint with a valid username and password. The endpoint returns a JWT token that you need to include in the other API requests related to calculator API.


####Calculation
 To perform a calculation, send a POST request to the **/**{**arithmatic operation**} endpoint with the two operands and operator in the request body. You need to include the JWT token obtained from the authentication request in the **Authorization** header.

#####Request
    POST /api/calculate HTTP/1.1
    Content-Type: application/json
    Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
    
    {
      "leftoperand": 10,
      "rightoperand": 5
    }

#####Response
    HTTP/1.1 200 OK
    Content-Type: application/json
    
    {
      "result": 15
    }


Repeat the same for the other endpoints as well

Thank you.

Copyrights @Benuka Withanage
benuka02@gmail.com
