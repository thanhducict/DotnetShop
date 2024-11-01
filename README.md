#### Catalog microservice: 
* ASP.NET Core Minimal APIs
* Vertical Slice Architecture
* CQRS implementation using MediatR library
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Cross-cutting concerns Logging, Global Exception Handling and Health Checks

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

### Motivation quote microservice:
* ASP.NET Core APIs
* [Undetermined] Architecture
* Use Repository Pattern, Unit of Work and Procedure on SQL Server
* TODO: gallery to manage images, use vitejs to build an react app, it's an addon in admin UI. Make random combination between an image and a motivation quote, 2 repositories for Images and Quotes then use unit of work for them
