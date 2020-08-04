﻿# ContactBook

I used ASp.NET Core 2.1.
```bash
cd ContactBook
dotnet run
```
Should be enough. Once running you can:
1. Check it out in browser at http://localhost:5001/costumers
2. Use the provided Json in Postman
3. 
```bash
cd ContactBookTest
dotnet test
```
It is a relatively standard .NET Core Project. Uses Localdb as a database, generated though Code-First emigrations with entity framework. The tests use an in-memory database.

The tests are just examples. In real-life I would be a bit more thorough with unit testing. I mostly just used Postal for testing the API.
