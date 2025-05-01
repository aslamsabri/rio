
# Coding Exercise Projects

This solution contains three related .NET projects showcasing API development, custom logic implementation (without using sorting functions), and client simulation through parallel requests.

---

## 🗂 Project Structure

```
/ATMCashier/                → Console app for ATM cash combination logic  
/Ria.Customer.API/          → ASP.NET Core Web API to manage customers  
/Ria.Customer.Simulator/    → .NET 8 Console App to simulate API POST/GET requests  
```

---

## ⚙️ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code
- Git (optional)

---

## 1. ATMCashier Project

### Purpose:
Calculates all possible combinations of given denominations (10, 50, 100 EUR) to pay a specified amount. The combination logic is implemented manually without any built-in sorting.

### ▶ How to Run:

1. Navigate to the project folder:
    ```bash
    cd ATMCashier
    ```

2. Run the application:
    ```bash
    dotnet run
    ```

---

## 👤 2. Ria.Customer.API (REST API)

### Purpose:
Web API to manage customer data with custom business rules:
- Validates fields: all fields must be present, age > 18, unique ID
- Inserts each customer in correct alphabetical position (last name > first name) **without using Sort/OrderBy**
- Persists customer data to a file (`customers.json`) that survives restarts

### ▶ How to Run:

1. Navigate to the API folder:
    ```bash
    cd Ria.Customer.API
    ```

2. Run the API:
    ```bash
    dotnet run
    ```

3. Use the endpoints:
    - `POST /customers` → add customers (JSON array)
    - `GET /customers`  → retrieve the customer list

### Notes:
- File path: `/Data/customers.json`
- File is auto-created and updated after successful POSTs

---

## 🤖 3. Ria.Customer.Simulator

### Purpose:
Simulates multiple concurrent `POST` and `GET` requests to the Customer API. Designed to test the API under random input conditions.

### 🔧 Configuration:

1. Open `appsettings.json` and update the base URL to match the API port (shown in terminal output after running API).

```json
{
  "CustomerSimulator": {
    "BaseUrl": "http://localhost:<your-port>/customers",
    "StartingId": 1,
    "FirstNames": [ "Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos" ],
    "LastNames": [ "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane" ]
  }
}
```

2. Ensure `appsettings.json` is set to **Copy to Output Directory → Copy if newer**

### ▶ How to Run:

1. Navigate to the simulator project:
    ```bash
    cd Ria.Customer.Simulator
    ```

2. Run the simulator:
    ```bash
    dotnet run
    ```

### Simulator Behavior:
- Sends 5 parallel POST and GET requests
- Each POST includes at least 2 randomized customers
- IDs are sequential and names are randomly picked from the configured lists
- Respects API validation rules

---

## Reviewer Notes
- The simulator can be modified to increase load or frequency
- To reset the API, delete `customers.json` while API is stopped

---

## Questions?

Feel free to reach out or open an issue if you need help running any part of the solution.
