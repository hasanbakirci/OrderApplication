# Order Application

 This project is a simple Order Application
 
 `cd OrderApplication`

 `docker-compose up`
 _____
 `cd OrderApplication/Data`

 `dotnet ef migrations add migrationName`

 `dotnet ef database update`
 ____
 `cd OrderApplication/Microservices/Services/Api`

 `dotnet watch run`
 ____
 `cd OrderApplication/GatewayApi`

 `dotnet run`
 
 ##  Requirements

 - Postgresql
 - .Net 5
 - Docker

 ## 3rd Party Libraries

- EntityFramework
- FluentValidation
- Automapper
- Swagger
- Ocelot

# Endpoints

## Customers
| Method | Endpoint                | Desc                                                     |
| -----------|-------------------------|----------------------------------------------------------|
| GET | /api/Customers| Get customers
| POST | /api/Customers| Create customer 
| DELETE | /api/Customers/{id}| Delete customer  
| GET | /api/Customers/Search/{id}| Get by customer id                            
| PUT | /api/Customers| Update customer       


## Orders
| Method | Endpoint                | Desc                                                     |
| -----------|-------------------------|----------------------------------------------------------|
| GET  | /api/Orders| Get orders
| POST | /api/Orders| Create order 
| DELETE | /api/Orders/{id}| Delete order  
| GET | /api/Orders/Search/{id}| Get by order id                            
| PUT | /api/Orders| Update text
| GET | /api/Orders/SearchCustomerId/{id}| Get by orders for customerId
| PUT | /api/Orders/ChangeStatus| Update status  


## Gateway Api
| Method | Endpoint                |                                                      |
| -----------|-------------------------|----------------------------------------------------------|
| GET POST PUT | /api-customers| 
| GET DELETE | /api-customers/{everything}
| GET POST PUT  | /api-orders|
| GET PUT DELETE | /api-orders/{everything}|
  