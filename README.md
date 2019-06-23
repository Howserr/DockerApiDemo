# .NET Core API with SQL Server DB deployed through Docker

## Packaging Instructions:
- To simply build, package and start a container for the API using the script [build_and_package.ps1](./DockerApiDemo/build_and_package.ps1)
- To deploy the API and DB to seperate docker containers, from the DockerApiDemo project folder run "docker-compose up --build"


## API Usage Instructions:
The API has a single restful controller, Customers, which supports the HTTP verbs GET, PUT, PATCH, DELETE.

Examples of these requests for use in Powershell can be seen below. Alternatively, [integration_test.ps1](integration_test.ps1) demonstrates building, deploying and using all endpoints.

### Sample Web Requests:
#### Get All: 
`curl https://localhost:44339/api/customers`

#### Get specific id: 
`curl https://localhost:44339/api/customers/1`

#### Create customer: 
`curl -d '{"firstName": "Alex","lastName": "Albon","email": "a.albon@mclaren.com" "password": "IDriveFast123"}' -H "Content-Type: application/json" -X POST https://localhost:44339/api/customers`

#### Patch customer: 
`curl -d '{"id": 1, firstName": "Alex","lastName": "Albon","email": "a.albon@mclaren.com" "password": "IDriveFast123"}' -H "Content-Type: application/json" -X PATCH https://localhost:44339/api/customers`

#### Delete customer:  
`curl -X DELETE https://localhost:44339/api/customers/1`


## Further Considerations

### Deploying to a Live Environment:
Once the API image has been built it can be published to a registry, allowing the image to be used from a node.
With the image published, the stack can be deployed to any swarm using the docker-compose.yml.
As part of this, security concerns would include moving DB authentication information to secrets.

### Scaling:
Being a RESTful API, state is not a concern for the application tier, as such the data tier is the limitation for concurrency. SQL Server could become a bottleneck at large request volumes due to the limitations with concurrency in SQL Server. A change to PostgresSQL would increase the concurrent performance of the data tier due to it's improved handling of multiple processes reading/writing to shared data. However ultimately Cassandra would provide the most scalable system due to it's distributed design and ability to scale beyond a single node and the sharding of keys across the nodes.

### Exception handling:
Currently the API uses the default framework exception catching for database errors and returns a 500 error to the user. The application will continue to run in this scenario however no persistence of data will be achieved. Any unsaved changes will not be commited. 

A solution to this issue would be to implement a caching tier which will write updates to the DB once it becomes available again. This would also increase the speed of the API by removing the need to hot hit the DB for each request. However this would come at the cost of memory in the application tier, unless the cache is implemented in a seperate caching tier through Redis for example. 
- If caching in the application tier cache updates should be implemented through events in order to ensure each instance of the application across nodes is kept in sync

### User information security:
- Authentication for the API should be used to ensure customer data is not accessed by non-approved API users
- Passwords should not be stored as plain text
- Uniquely indentifying information should not be exposed outside of approved data use applications
