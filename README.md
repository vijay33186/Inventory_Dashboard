
# Inventory Management System

## Overview

This project is a simple Inventory Management module built using ASP.NET Core MVC.
It allows users to manage inventory items with basic CRUD operations, search, sorting, pagination, and dashboard statistics.

## Features

* User login with session handling
* Add, edit, view, and delete inventory items
* Dashboard summary (Total Items, Total Quantity, Total Value)
* Search inventory items
* Sorting by price and quantity
* Pagination for large datasets
* Low stock alert banner
* Chart visualization of inventory quantity

## Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* PostgreSQL
* Bootstrap 5
* Chart.js

## Project Structure

Controllers – Handles request/response logic
Models – Database entities
Views – Razor UI pages
wwwroot – Static files (CSS, JS)

## Database Setup

1. Install PostgreSQL
2. Create a new database named **Inventory**
3. Run the SQL script below to create the table

```sql
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL
);

INSERT INTO Users (Username, Password)
VALUES ('admin', 'admin123');

```


```sql

CREATE TABLE Inventory (
    Id SERIAL PRIMARY KEY,
    Itemname VARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);


INSERT INTO Inventory (Itemname, Quantity, Price) VALUES
('Laptop', 5, 50000),
('Keyboard', 20, 1500),
('Mouse', 15, 800);
```

## Configuration

Update the connection string in **appsettings.json**.

```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=Inventory;Username=postgres;Password=Vijay1805"
}
```

## How to Run the Project

1. Clone the repository
2. Open the solution in Visual Studio
3. Configure the PostgreSQL connection string
4. Build and run the project
5. Access the application from the browser

## Notes

This project was created as a technical task demonstration for an ASP.NET Core full-stack developer role.
