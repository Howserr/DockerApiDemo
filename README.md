# .NET Core API with SQL Server DB deployed through Docker

## Packaging instructions:
- To simply build, package and start a container for the API using the script "build_and_package.ps1"
- To deploy the API and DB to seperate docker containers, from the DockerApiDemo project folder run "docker-compose up --build"


## API Usage instructions:
The API has a single restful controller, Customers, which supports the HTTP verbs GET, PUT, PATCH, DELETE.

Examples of these requests for use in Powershell can be seen below. Alternatively, "integration_test.ps1" demonstrates building, deploying and using all endpoints.

### Sample web requests:
#### Get All: 
curl https://localhost:44339/api/customers

#### Get specific id: 
curl https://localhost:44339/api/customers/1

#### Create customer: 
curl -d '{"firstName": "Alex","lastName": "Albon","email": "a.albon@mclaren.com" "password": "IDriveFast123"}' -H "Content-Type: application/json" -X POST https://localhost:44339/api/customers

####Patch customer: 
curl -d '{"id": 1, firstName": "Alex","lastName": "Albon","email": "a.albon@mclaren.com" "password": "IDriveFast123"}' -H "Content-Type: application/json" -X PATCH https://localhost:44339/api/customers

#### Delete customer:  
curl -X DELETE https://localhost:44339/api/customers/1 