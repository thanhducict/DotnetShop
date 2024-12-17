# Dotnet Shop
This is a pet project to learn technologies. The microservices architecture is used so a lot of technologies can be experimented.

## Project anatomy

#### Catalog service: 
* ASP.NET Core Minimal APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Use Marten library for .NET Transactional Document DB on PostgreSQL

#### Shopping Cart service: 
* ASP.NET Core REST APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Using Redis as a Distributed Cache
* Implements Proxy, Decorator and Cache-aside patterns
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Consume Discount Grpc Service for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using MassTransit and RabbitMQ

### Discount service:
* ASP.NET Grpc Server application
* Build a Highly Performant inter-service gRPC Communication with Shopping Cart microservice
* Exposing Grpc Services with creating Protobuf messages
* SQLite Data Provider for data access and ensure high performance
* SQLite database connection and containerization

### Ordering service
* Implementing DDD, CQRS, and Clean Architecture with using Best Practices
* Developing CQRS with using MediatR
* Consuming RabbitMQ BasketCheckout event queue with using MassTransit-RabbitMQ Configuration
* SqlServer database connection and containerization
* Using Entity Framework Core ORM and auto migrate to SqlServer when application startup

#### Inventory service:
* ASP.NET Core REST APIs
* [Undetermined] Architecture
* Use Repository Pattern, Unit of Work and Procedure on SQL Server

#### Common (Cross-cutting concerns)
* Logging
* Global Exception Handling
* Health Checks
* FluentValidation

## License
This repository is licensed under the MIT license.
