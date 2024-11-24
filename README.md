#### Catalog microservice: 
* ASP.NET Core Minimal APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Use Marten library for .NET Transactional Document DB on PostgreSQL

#### Cart microservice: 
* ASP.NET Core REST APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Using Redis as a Distributed Cache
* Implements Proxy, Decorator and Cache-aside patterns
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Consume Discount Grpc Service for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using MassTransit and RabbitMQ
* TODO: https://github.com/jeangatto/ASP.NET-Core-Vertical-Slice-Architecture/blob/main/src/Blog.PublicAPI/Features/Users/UsersController.cs

#### Inventory microservice:
* ASP.NET Core REST APIs
* [Undetermined] Architecture
* Use Repository Pattern, Unit of Work and Procedure on SQL Server

#### Common (Cross-cutting concerns)
* Logging
* Global Exception Handling
* Health Checks
* FluentValidation

