# OAuth
OAuth2 Implementation 

# Development
> docker pull postgres
> docker run --name postgres -e POSTGRES_PASSWORD=password -d postgres
> psql "user=postgres password=password"
> CREATE ROLE authuser WITH LOGIN PASSWORD 'password';
> ALTER ROLE authuser CREATEDB;
> ALTER ROLE authuser WITH Superuser;
> create database authdb;
> GRANT CONNECT ON DATABASE authdb TO authuser;
> ctrl+c
> dotnet tool install --global --version 6.0.1 dotnet-ef
add your db connection string to appsettings.json, then...
> dotnet ef migrations add "initial_migrations"
> dotnet ef database update
# Documentation
https://cheatsheetseries.owasp.org/cheatsheets/Authentication_Cheat_Sheet.html

# todo
1. Create DAL 
2. Create database w/ scripts
3. Add JWT middleware
4. 

