# Online Store

## Project Description

A simple WEB II university project built with ASP.NET Core MVC. Visitors can browse products, search and filter them, use a session shopping cart, and place orders. A simple Admin section manages products, categories, and order status.

## Technologies Used

- ASP.NET Core MVC and .NET 8
- Entity Framework Core
- SQLite
- HTML, CSS, JavaScript

## Features

- Product list, search, category filter, and details page
- Session-based shopping cart with quantity controls
- Checkout that saves Orders and OrderItems to SQLite
- Seed data: 3 categories and 9 products
- Admin CRUD for products and categories
- Admin order list, details, and status update

## Database Tables

- Categories
- Products
- Orders
- OrderItems

## How To Run The Project

1. Open the `OnlineStore` folder in Visual Studio Code or File Explorer.
2. Open Terminal in this folder (right-click and choose **Open in Terminal**).
3. Run this command:

```powershell
dotnet restore
```

4. Then run:

```powershell
dotnet build
```

5. Start the website:

```powershell
dotnet run
```

6. Open the address printed in the terminal, normally `http://localhost:xxxx`.
7. The `onlinestore.db` file is created automatically in the project folder at the first start; it includes seed data.
8. Open `/Admin` in the browser for the management pages.
9. Stop the server using `Ctrl + C` in Terminal.

## Project Structure

- `Controllers/` receives requests and selects pages.
- `Models/` contains database classes such as Product and Order.
- `Views/` contains Razor pages shown in the browser.
- `Data/` contains StoreContext and seed data.
- `ViewModels/` contains models made for page display.
- `wwwroot/` contains CSS and static files.
- `Program.cs` configures MVC, SQLite, session, and database creation.

## Simple Project Explanation

A browser request goes to a Controller. The Controller asks `StoreContext` for data. Entity Framework Core converts the C# query into SQLite database commands, then the Controller sends a Model or ViewModel to a Razor View. The View creates HTML for the browser.

`Product` belongs to one `Category`; a Category can have many Products. An Order has many OrderItems, and every OrderItem points to one Product. The cart is kept in Session, so it does not need its own database table. At checkout, its cart items become one Order and multiple OrderItems, then the cart is cleared.

## Verification Results

- `dotnet restore`: Passed during project creation and package installation.
- `dotnet build`: Passed (0 warnings, 0 errors).
- Application startup: Passed (server listened on http://127.0.0.1:5080).
- Home Page, Products Page, Cart, and Admin pages: Passed with local HTTP 200 checks. Checkout flow: Not manually verified.
- Database creation: Passed; SQLite tables and seed data were created at application startup.
