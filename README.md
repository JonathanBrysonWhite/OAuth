# OAuth
OAuth2 Implementation 

# Development
```
 docker pull postgres
 docker run --name postgres -e POSTGRES_PASSWORD=password -d postgres
 psql "user=postgres password=password"
 CREATE ROLE authuser WITH LOGIN PASSWORD 'password';
 ALTER ROLE authuser CREATEDB;
 ALTER ROLE authuser WITH Superuser;
 create database authdb;
 GRANT CONNECT ON DATABASE authdb TO authuser;
```
# Documentation
https://cheatsheetseries.owasp.org/cheatsheets/Authentication_Cheat_Sheet.html

# todo
1. Create DAL 
2. Create database w/ scripts
3. Add JWT middleware
3. b. Add Basic auth middleware - allow interop depending on env variable 
4. Add client id & client secret - research
5. Add optional configurable email / phone num requirements w/ challenge
6. Authenticator app integration

