IF (DB_ID(N'CatalogDb') IS NOT NULL)
    BEGIN
        USE Master
        ALTER DATABASE CatalogDb SET single_user WITH ROLLBACK IMMEDIATE
        DROP DATABASE CatalogDb
    END
GO

CREATE DATABASE CatalogDb
GO

USE CatalogDb
GO

CREATE TABLE dbo.Category (
    CategoryId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    CategoryName NVARCHAR(50) NOT NULL
)

CREATE TABLE dbo.Product (
    ProductId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    ShortDescription NVARCHAR(500),
    LongDescription NVARCHAR(MAX),
    ImageUrls NVARCHAR(MAX),
    ImageThumbnailUrl NVARCHAR(1000),
    Price DECIMAL(30, 5),
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT Fk_CategoryProduct FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
)
GO

INSERT INTO dbo.Category (CategoryId, CategoryName) VALUES ('791a4219-b883-4c7b-93bf-bf977a25fdb6', 'Shirt')
INSERT INTO dbo.Category (CategoryId, CategoryName) VALUES ('1d097e4a-6950-4eb9-b4ba-1ff8c3315c98', 'Cup')
INSERT INTO dbo.Category (CategoryId, CategoryName) VALUES ('18b4cb49-bdee-4387-9935-df3215e0a0bf', 'Badge')
GO

