# OAuth Provider Project (Code-First, Multi-Tenant Capable)

## 📌 Overview

This project is a standards-compliant OAuth2 provider with optional OpenID Connect (OIDC) support, built using a **code-first** approach in C#. It is designed to operate in **single-tenant** or **multi-tenant** mode, with the flexibility to support modern OAuth flows such as **Authorization Code Flow** (with PKCE) and **Client Credentials Flow**.

It is intended for use in secure, production-grade environments with extensibility, tenant isolation, and testability in mind.

---

## 🧠 Key Concepts & Functionality

### 🔐 OAuth2 Flows

#### Authorization Code Flow (with PKCE)
- Used by public clients (e.g. SPAs, mobile apps).
- Involves redirecting the user to log in, exchanging a code for tokens.

#### Client Credentials Flow
- Used by server-to-server (machine-to-machine) apps.
- No user interaction required.

### 🧱 Domain Entities

- **Tenant**: Optional; used in multi-tenant mode to isolate clients, users, and scopes.
- **Client**: Registered application that can request tokens.
- **User**: End-user authenticating via OAuth.
- **Scope**: A named permission (`read:profile`, etc.).
- **AuthorizationCode**: Used temporarily in Authorization Code Flow.
- **AccessToken / RefreshToken**: Issued to clients after successful authentication.
- **Consent**: Records user consent for a client’s requested scopes.

### 🌐 OAuth Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/authorize` | GET | Initiates Authorization Code Flow |
| `/token` | POST | Exchanges code or credentials for token |
| `/revoke` | POST | Revokes a token |
| `/introspect` | POST | Verifies token validity and metadata |
| `/userinfo` | GET | (OIDC) Returns user claims |
| `/.well-known/openid-configuration` | GET | OIDC metadata discovery |
| `/.well-known/jwks.json` | GET | Returns JSON Web Key Set for JWT signature verification |

---

## ✅ Project TODO

### 📁 Project Setup
- [ ] Scaffold project and setup solution structure
- [ ] Set up Entity Framework Core (Code-First)
- [ ] Set up initial migration and database context

### 🧩 Domain Model
- [ ] Define `Tenant` entity (optional, depending on mode)
- [ ] Define `Client` entity (with allowed grant types, secrets, redirect URIs)
- [ ] Define `User` entity
- [ ] Define `Scope` entity
- [ ] Define `AuthorizationCode` entity
- [ ] Define `AccessToken` / `RefreshToken` entities
- [ ] Define `Consent` entity

### 🔧 Configuration
- [ ] Add support for single-tenant vs multi-tenant mode
- [ ] Add tenant resolution middleware (query param / subdomain / client metadata)

### 🔐 OAuth Logic
- [ ] Implement `/authorize` endpoint
- [ ] Implement login + consent UI (or endpoint logic)
- [ ] Implement `/token` endpoint
  - [ ] Support `authorization_code` grant (with PKCE)
  - [ ] Support `client_credentials` grant
- [ ] Implement `/revoke` endpoint
- [ ] Implement `/introspect` endpoint
- [ ] Implement `/userinfo` endpoint (for OIDC)

### 🔑 OIDC Support
- [ ] Implement `/.well-known/openid-configuration` endpoint
- [ ] Implement `/.well-known/jwks.json` endpoint
- [ ] Add support for signing and validating JWTs

### 🧪 Testing
- [ ] Set up unit test project
- [ ] Write tests for:
  - [ ] Authorization Code flow
  - [ ] Client Credentials flow
  - [ ] Token issuance and validation
  - [ ] Multi-tenant isolation

### ⚙️ Admin / Management
- [ ] Admin API for:
  - [ ] Managing Clients
  - [ ] Managing Tenants
  - [ ] Managing Users (optional)
  - [ ] Managing Scopes
- [ ] Seed default data (admin user, default tenant, test client)

### 🧱 Infrastructure (optional)
- [ ] Add HTTPS support
- [ ] Add rate limiting middleware
- [ ] Add logging / audit trails
- [ ] Add health check endpoint (`/healthz`)

---

## 📘 Notes

- You can toggle multi-tenant mode via app settings or environment variables.
- Consider using JWT access tokens signed with RS256.
- For better scalability, refresh tokens should be stored securely and revocable.

---

## ✨ Coming Soon

- Support for passwordless or external identity providers (OIDC Federation)
- Per-tenant branding and theming
- Hosted login/consent UI (or allow plug-in via templates)

