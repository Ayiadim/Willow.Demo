-- Tools used --

Microsoft SQL LocalDB
Entity Framework
AutoMapper
MediatR

-- IMPORTANT --

You will need to have Microsoft SQL LocalDB installed, open a powershell window at the root of this folder and run the following commands:

cd src/LanternPay.Data
dotnet ef --startup-project ../LanternPay.Web/ database update

This will create the DB For the project.

After that just run the following command at the root of this folder: dotnet run

-- Functionality Missing --

Business rules
Domain events and their handlers
Exception handling
Unit tests
Nested queries

-- Improvements --

Docker
DDD refactor
Add Serilog
Domain objects should not also serve as data access objects

-- Remarks --

This was fun to work on, I'm very new to DDD but unfortunately I ran out of time
to refactor, rethink my DDD approach and implement business rules.

Total Time Taken: 6 hrs

-- References --

https://aka.ms/microservicesebook