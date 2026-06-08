
  # **ATM Console App**

An Automated Teller Machine (ATM) is an electronic banking device that allows customers to perform basic financial transactions. 

## **Description**
A console-based ATM banking application built with C# that enables customer registration, account number generation, deposits, withdrawals, balance inquiries, PIN management.

### **Table of Contents** 
     1. [Program.cs](#Program.)
     2. [Customer.cs](#Customer)
     3. [Generate.cs](#Generate)
     4. [Services.cs](#Service)
     5. [Validation.cs](#Validation)
     6. [Deposit.cs](#Deposit)

### **Program**

Program.cs is the main entry point of the ATM Console Application. It handles application startup, user interaction, menu navigation, and the execution of banking operations by connecting the various modules of the system, including customer validation, account generation and  deposits.

### **Customer** 
The Customer class represents the customer entity within the application. It stores and manages customer information and account details.
   ###### **Properties Include:** 
         1. Customer Name
         2. Account Number
         3. PIN
         4. Email
         5. amount 
         6. Phone Number

### **Generate**
The Generate branch is responsible for generating unique account numbers for newly registered customers.

This module automates the account creation process and ensures proper customer identification.

##### **Responsibilities:**
     1. Generate unique account numbers.
     2. Ensure no duplicate account numbers exist.
     3. Assign account numbers during customer registration.

### **Service**
The Services branch contains all banking operations available to customers after successful authentication.

This branch serves as the main transaction center of the application.
 ##### **Available Services:**
     1. Deposit Funds
     2. Check Account Balance
     3. Withdraw Funds
     4. Change PIN
     5. Update Phone Number

 ### **Validation**
 The Validation branch is responsible for verifying and validating customer information during account registration and login processes. It ensures that all customer details meet the required standards before an account is created or accessed.
##### **Responsibilities:**
     1. Validate customer registration details.
     2. Verify PIN and account credentials.
     3. Prevent invalid or duplicate customer records.
     4. Handle input errors and exceptions.

### **Deposit**
The Deposit branch manages all deposit-related transactions for customers. It handles both initial deposits during account creation and subsequent deposits made by customers.

##### **Responsibilities:**
     1. Process customer deposits.
     2. Update account balances.
     3. Validate deposit amounts.
     4. Record successful deposit transactions.


 
  












     
     





