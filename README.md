# Dotnet Shop
This is a pet project for learning new technologies, using a microservices architecture to enable experimentation with various tools and frameworks.

## Project anatomy

#### Catalog service: 
* ASP.NET Core Minimal APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Use ADO.NET to access SQL Server
* Use Repository Pattern and Procedure on SQL Server
* Local port: http 5001, https 5051
* Docker port: http 6001, https 6061

#### Shopping Cart service: 
* ASP.NET Core REST APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Using Redis as a Distributed Cache
* Implements Proxy, Decorator and Cache-aside patterns
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Consume Discount Grpc Service for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using MassTransit and RabbitMQ
* Local port: http 5002, https 5052
* Docker port: http 6002, https 6062

### Discount service:
* ASP.NET Grpc Server application
* Build a Highly Performant inter-service gRPC Communication with Shopping Cart microservice
* Exposing Grpc Services with creating Protobuf messages
* Using Entity Framework Core ORM for data access
* SQLite database connection and containerization
* Local port: http 5003, https 5053
* Docker port: http 6003, https 6063

### Ordering service
* Implementing DDD, CQRS, and Clean Architecture with using Best Practices
* Developing CQRS with using MediatR
* Consuming RabbitMQ BasketCheckout event queue with using MassTransit-RabbitMQ Configuration
* SqlServer database connection and containerization
* Using Entity Framework Core ORM and auto migrate to SqlServer when application startup

### Identity service
* Using JWT Bearer Authentication
* Using Identity Framework Core
* SqlServer database connection and containerization

#### Common (Cross-cutting concerns)
* Logging
* Global Exception Handling
* Health Checks
* FluentValidation
