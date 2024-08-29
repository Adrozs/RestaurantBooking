# RestaurantBooking
A ASP.NET backend system with a database that handles restaurant reservations, customer information and ordering of dishes. The system allows for handling of tables and reservations along with making orders from a updatable menu through a web API.
The system supports CRUD operations for all key entities (customer, table, dish and reservation) that allow for an easy and effective way to add, modify and remove components as needed. 

It's built with repository and service pattern using a layered architecture. Making use of dependency injection to allow for separation of concerns, reusability and testability.


## Table of Contents
- [ER-Diagram](#er-diagram)
- [Endpoints](#endpoints)
  - [Customers](#customer)
  - [Tables](#table)
  - [Reservations](#reservation)
  - [Dishes](#dish)
 

# ER-Diagram 
![Er-diagram](https://github.com/Adrozs/RestaurantBooking/blob/master/erdiagram.png)

# Endpoints

## Customer
#### `POST /api/Customer/CreateCustomer`
- **Purpose**: Create a customer to assign reservations and orders to with basic info of name and phone number
- **Request Body**:
  ```json
  {
    "name": "Anders Andersson",
    "phoneNumber": "070123456789"
  }

#### `GET /api/Customer/GetAllCustomers`
- **Purpose**: Retrieve a list of all customers currently in the system
- **Response**:
  ```json
  {
    "id": 1,
    "name": "Anders Andersson",
    "phoneNumber": "070123456789"
  }

#### `GET /api/Customer/GetCustomerById/{id}`
- **Purpose**: Retrieve a specific customer
- **Response**:
  ```json
  {
    "name": "Anders Andersson",
    "phoneNumber": "070123456789"
  }

#### `POST /api/Customer/UpdateCustomer`
- **Purpose**: Change a specific customers information 
- **Request Body**:
  ```json
  {
    "id": 1,
    "name": "Sven Svensson",
    "phoneNumber": "079876543210"
  }

#### `DELETE /api/Customer/DeleteCustomer/2`
- **Purpose**: Delete a specific customers from the system
  

## Dish
#### `POST /api/Customer/CreateDish`
- **Purpose**: Create a dish to be ordered
- **Request Body**:
  ```json
  {
    "name": "Mom's Spaghetti",
    "price": 20,
    "isAvailable": true
  }

#### `GET /api/Customer/GetAllDishes`
- **Purpose**: Retrieve a list of all customers currently in the system
- **Response**:
  ```json
  {
    "name": "Mom's Spaghetti",
    "price": 20,
    "isAvailable": true
  },
  {
    "name": "Köttbullar och potatismos",
    "price": 50,
    "isAvailable": true
  },
  {
    "name": "Soup",
    "price": 10,
    "isAvailable": false
  }

#### `GET /api/Customer/GetAvailableDishes`
- **Purpose**: Retrieve a list of all dishes available in the system
- **Response**:
  ```json
  {
    "name": "Mom's Spaghetti",
    "price": 20,
    "isAvailable": true
  },
  {
    "name": "Köttbullar och potatismos",
    "price": 50,
    "isAvailable": true
  }

#### `GET /api/Customer/GetDishById`
- **Purpose**: Retrieve a specific dish
- **Request Body**:
  ```json
  {
    "name": "Köttbullar och potatismos",
    "price": 50,
    "isAvailable": true
  }

#### `POST /api/Customer/UpdateDishes`
- **Purpose**: Change a specific dish's information 
- **Request Body**:
  ```json
  {
    "name": "Köttbullar och potatismos",
    "price": 50,
    "isAvailable": true
  }

#### `DELETE /api/Customer/DeleteDish/4`
- **Purpose**: Delete a specific dish from the system 

## Reservation
#### `POST /api/Customer/CreateReservation`
- **Purpose**: Create a reservation for a customer, a table and a time. (If duration is left empty a standard time of 120 minutes will be set by default)
- **Request Body**:
  ```json
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 120, 
    "guests": 4,
    "tableId": 3,
    "customerId": 2
  }

#### `GET /api/Customer/GetAllReservations`
- **Purpose**: Retrieve a list of all reservations
- **Response**:
  ```json
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 120, 
    "guests": 4,
    "tableId": 3,
    "customerId": 2
  },
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 120, 
    "guests": 25,
    "tableId": 8,
    "customerId": 4
  },
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 200, 
    "guests": 1,
    "tableId": 2,
    "customerId": 42
  }

#### `GET /api/Customer/GetActiveReservations`
- **Purpose**: Retrieve a list of all future and todays reservations
- **Response**:
  ```json
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 120, 
    "guests": 25,
    "tableId": 8,
    "customerId": 4
  },
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 200, 
    "guests": 1,
    "tableId": 2,
    "customerId": 42
  }

#### `GET /api/Customer/GetReservationById`
- **Purpose**: Retrieve a specific reservation and all its details
- **Request Body**:
  ```json
  {
  "reservationTime": "2024-08-28T12:54:58.803",
  "reservationDurationMinutes": 120,
  "guests": 2,
  "totalBill": 45,
  "orderedDishes": [
    {
      "dishId": 3,
      "dishName": "Soup",
      "price": 5,
      "specialInstructions": "string"
    },
    {
      "dishId": 2,
      "dishName": "Meatballs",
      "price": 20,
      "specialInstructions": "extra spicy"
    }
  ],
  "tableId": 4,
  "customerId": 2
}

#### `POST /api/Customer/UpdateReservation`
- **Purpose**: Change a specific reservations information 
- **Request Body**:
  ```json
  {
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 200, 
    "guests": 87,
    "tableId": 2,
    "customerId": 42
  }

#### `DELETE /api/Customer/DeleteReservation/1`
- **Purpose**: Delete a specific reservation from the system 

## Table
#### `POST /api/Customer/CreateTable`
- **Purpose**: Create/Add a new table to be reserved
- **Request Body**:
  ```json
  {
    "tableNumber": 37,
    "seats": 4
  }

#### `GET /api/Customer/GetAllTables`
- **Purpose**: Retrieve a list of all tables
- **Response**:
  ```json
  {
    "id": 2,
    "tableNumber": 8,
    "seats": 2,
    "isReserved": false,
    "reservedUntil": "2024-08-10T16:07:13.908Z"
  },
  {
    "id": 5,
    "tableNumber": 37,
    "seats": 9,
    "isReserved": true,
    "reservedUntil": "2024-08-28T16:07:13.908Z"
  },
  {
    "id": 6,
    "tableNumber": 4,
    "seats": 4,
    "isReserved": true,
    "reservedUntil": "2024-08-28T18:07:13.908Z"
  }

#### `GET /api/Customer/GetAvailableTables`
- **Purpose**: Retrieve a list of all tables available to be reserved
- **Response**:
  ```json
  {
    "id": 4,
    "tableNumber": 11,
    "seats": 4,
    "isReserved": false
  },
  {
  "id": 7,
  "tableNumber": 22,
  "seats": 9,
  "isReserved": true
  }

 #### `GET /api/Customer/GetTableById`
- **Purpose**: Retrieve a specific table
- **Request Body**:
  ```json
  {
    "tableNumber": 11,
    "seats": 4,
    "isReserved": false
  }

#### `POST /api/Customer/UpdateTable`
- **Purpose**: Change a specific dish's information 
- **Request Body**:
  ```json
  {
   "id": 3,
  "tableNumber": 22,
  "seats": 27,
  "reservedUntil": "2024-08-28T16:09:44.434Z"
  }

#### `DELETE /api/Customer/DeleteTable/2`
- **Purpose**: Delete a specific table from the system 
