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

- **Response**:
  - 200 OK: Customer created successfully.
  - 400: Failed create customer: {reason}


#### `GET /api/Customer/GetAllCustomers`
- **Purpose**: Retrieve a list of all customers currently in the system
- **Response**:
  - 200 OK:
  ```json
  {
    "id": 1,
    "name": "Anders Andersson",
    "phoneNumber": "070123456789"
  }
  ```
  - 404 Not found: No customers found.
  

#### `GET /api/Customer/GetCustomerById/{id}`
- **Purpose**: Retrieve a specific customer
- **Response**:
  
  - 200 OK:
  ```json
  {
    "name": "Anders Andersson",
    "phoneNumber": "070123456789"
  }
  ```
  - 404 Not found: No matching customer found.


#### `POST /api/Customer/UpdateCustomer`
- **Purpose**: Change a specific customers information 
- **Request Body**:
  ```json
  {
    "id": 1,
    "name": "Sven Svensson",
    "phoneNumber": "079876543210"
  }

- **Response**:
  - 200 OK: Customer updated successfully.
  - 400: Failed to update customer. {reason}


#### `DELETE /api/Customer/DeleteCustomer/{id}`
- **Purpose**: Delete a specific customers from the system

- **Response**:
  - 200 OK: Customer deleted successfully.
  - 400: Failed to delete customer. {reason}

  

## Dish
#### `POST /api/Dish/CreateDish`
- **Purpose**: Create a dish to be ordered
- **Request Body**:
  ```json
  {
    "name": "Mom's Spaghetti",
    "price": 20,
    "isAvailable": true
  }

- **Response**:
  - 200 OK: Dish created successfully.
  - 400: Failed to create dish. {reason}


#### `GET /api/Dish/GetAllDishes`
- **Purpose**: Retrieve a list of all customers currently in the system
- **Response**:
  - 200 OK: 
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
  ```
  - 404 Not found: No dishes were found.


#### `GET /api/Dish/GetAvailableDishes`
- **Purpose**: Retrieve a list of all dishes available in the system
- **Response**:
  - 200 OK: 
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
  ```
  - 404 Not found: No available dishes found.
  

#### `GET /api/Dish/GetDishById/{id}`
- **Purpose**: Retrieve a specific dish
- **Request Body**:
- **Response**:
  - 200 OK: 
  ```json
  {
    "name": "Köttbullar och potatismos",
    "price": 50,
    "isAvailable": true
  }
  ```
  - 404 Not found: No matching dish was found.


#### `POST /api/Dish/UpdateDishes`
- **Purpose**: Change a specific dish's information 
- **Request Body**:
  ```json
  {
    "name": "Köttbullar och potatismos",
    "price": 50,
    "isAvailable": true
  }
  
- **Response**:
  - 200 OK: Dish successfully updated.
  - 400: Failed to update dish. {reason}


#### `DELETE /api/Dish/DeleteDish/4`
- **Purpose**: Delete a specific dish from the system
- **Response**:
  - 200 OK: Dish deleted updated.
  - 400: Failed to delete dish. {reason}



## Reservation

#### `POST /api/Reservation/OrderDish`
- **Purpose**: Order a dish (with optional special instructions) which adds the dish to the reservation along with cost to the total bill  
- **Request Body**:
  ```json
  {
    "dishId": 0,
    "reservationId": 0,
    "specialInstructions": "string"
  }

- **Response**:
  - 200 OK: Dish successfully ordered and added to reservation.
  - 400: Failed order dish: {reason}
    

#### `POST /api/Reservation/CreateReservation`
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

- **Response**:
  - 200 OK: Successfully created reservation.
  - 400: Failed create reservation: {reason}
  - 400: No matching customer found.
  - 400: No matching table found.
  - 400: Table is not available at the requested time.
  - 400: Selected table has too few seats for the number of guests. Seats: YY. Guests: ZZ.

#### `GET /api/Reservation/GetAllReservations`
- **Purpose**: Retrieve a list of all reservations
- **Response**:
  - 200 OK: Successfully created reservation.
  ```json
  {
    "id": 8,
    "reservationTime": "2024-08-31T11:17:47.819",
    "reservationDurationMinutes": 60,
    "guests": 2,
    "customerName": "Sven Svensson",
    "totalBill": 0,
    "tableId": 8,
    "customerId": 6
  },
  {
    "id": 8,
    "reservationTime": "2024-08-31T11:17:47.819",
    "reservationDurationMinutes": 120,
    "guests": 2,
    "customerName": "Anders Andersson",
    "totalBill": 85,
    "tableId": 3,
    "customerId": 4
  }
  ```
  - 400: Failed create reservation: {reason}

#### `GET /api/Reservation/GetActiveReservations`
- **Purpose**: Retrieve a list of all future and todays reservations
- **Response**:
  - 200 OK:
  ```json
  {
    "id": 8,
    "reservationTime": "2024-08-31T11:17:47.819",
    "reservationDurationMinutes": 60,
    "guests": 2,
    "customerName": "Anders Andersson",
    "totalBill": 0,
    "tableId": 8,
    "customerId": 6
  }
  ```
  - 404 Not found: No reservations were found.

#### `GET /api/Reservation/GetReservationById/{id}`
- **Purpose**: Retrieve a specific reservation and all its details
- **Response**:
  - 200 OK:
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
  ```  
  - 404 Not found: No active reservations were found.


#### `POST /api/Reservation/UpdateReservation`
- **Purpose**: Change a specific reservations information 
- **Request Body**:
  ```json
  {
    "id": 2,
    "reservationTime": "2024-08-28T16:00:35.510Z",
    "reservationDurationMinutes": 200, 
    "guests": 87,
    "totalBill": 0,
    "tableId": 2,
    "customerId": 42
  }
  
- **Response**:
  - 200 OK: Reservation successfully updated.
  - 400: Failed to update reservation: {reason}

#### `DELETE /api/Reservation/DeleteReservation/{id}`
- **Purpose**: Delete a specific reservation from the system 
- **Response**:
  - 200 OK: Reservation successfully deleted.
  - 400: Failed to delete reservation: {reason}


## Table
#### `POST /api/Table/CreateTable`
- **Purpose**: Create/Add a new table to be reserved
- **Request Body**:
  ```json
  {
    "tableNumber": 37,
    "seats": 4
  }
- **Response**:
  - 200 OK: Table successfully created.
  - 400: Failed to create table: {reason}

#### `GET /api/Table/GetAllTables`
- **Purpose**: Retrieve a list of all tables
- **Response**:
  -  200 OK:
  ```json
  {
    "id": 9,
    "tableNumber": 77,
    "seats": 6,
    "reservedUntil": "0001-01-01T00:00:00"
  },
  {
    "id": 10,
    "tableNumber": 3,
    "seats": 6,
    "reservedUntil": "0001-01-01T00:00:00"
  }
   ```
  - 404 Not found: No tables were found

#### `GET /api/Table/GetAvailableTables`
- **Purpose**: Retrieve a list of all tables available to be reserved
- **Response**:
  ```json
  {
    "id": 8,
    "tableNumber": 11,
    "seats": 2,
    "reservedUntil": "2024-08-31T12:17:47.819"
  },
  {
    "id": 9,
    "tableNumber": 77,
    "seats": 6,
    "reservedUntil": "0001-01-01T00:00:00"
  }
  ```
  - 404 Not found: No available tables were found

 #### `GET /api/Table/GetTableById`
- **Purpose**: Retrieve a specific table
- **Request Body**:
  ```json
  {
    "id": 1,
    "tableNumber": 3,
    "seats": 2,
    "reservedUntil": "2024-08-31T12:46:11.791Z"
  }
  ```
  - 404 Not found: No matching table were found

#### `POST /api/Table/UpdateTable`
- **Purpose**: Change a specific dish's information 
- **Request Body**:
  ```json
  {
   "id": 3,
  "tableNumber": 22,
  "seats": 27,
  "reservedUntil": "2024-08-28T16:09:44.434Z"
  }
- **Response**:
  - 200 OK: Table successfully updated.
  - 400: Failed to update table: {reason}

#### `DELETE /api/Customer/DeleteTable/2`
- **Purpose**: Delete a specific table from the system
- **Response**:
  - 200 OK: Table successfully deleted.
  - 400: Failed to delete table: {reason}
