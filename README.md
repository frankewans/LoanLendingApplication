Loan Lending Application

For writing and reporting of loans

How to setup and run the project

Download the project from github - https://github.com/frankewans/LoanLendingApplication

Open in Visual Studio (preferrably 2022)

Build the project


Project Design
--------------

Built using .Net6

The design pattern is Domain Driven Design and Test Driven Design

UI is ASP.Net core razor view

Adheres to the principles of OOP - Classes, Interfaces, Inheritance, encapsulation, abstraction etc.

The code was KISS, DRY, YAGNI and adhered to the SOLID principle


Project Structure
-----------------

The Solution is divided into 3-tiers

1. LoanLendingApp.Core

This is the Business Logic layer of the application. There are 4 folders which are used to seperate the different objects and functionalities

2. LoanLendingApp.Tests

Because the application is built using Test Driven Design, I created this test project using xUnit to make sure all cases are tested and assertained

3. LoanLending.App (main application)

This is a console application to consume the business logic. This is also the end-user application
