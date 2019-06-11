
# Boards API [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 
A Reddit style forum engine written with .NET Core.

---

## Quick Setup

```bash
git clone https://github.com/m0wo/boards-api.git
cd boards-api/Boards.API
dotnet run
```

## Project Details

### Motivation

Boards API is a relatively simple implementation of a message board system. Users can register an account, log in/expire sessions, and create various forum entities (Board, Post, Reply).

The aim of the project is to develop a backend which I can extend and add new features to over time. The project will follow best practice when it comes to clean code. 

Elements of domain-driven design are used for the project architecture. For instance, a service layer is used, alongside repositories and a unit of work. Within the API controllers, resource objects are used with AutoMapper for data transfer.

### Tooling Used

- **.NET Core 2.2**
- **EF Core**
- **AutoMapper**
- **SQLite**

### Auth

The API uses JWT for account management. Any requests to secured routes *must* be made with a Bearer token in the authorization header.

### API Usage

A list of endpoints for the API can be found [here](ENDPOINTS.md).

### Folder Structure

```
boards-api/
    Boards.API/
        Controllers/                # Controller classes
        Domain/                     # Domain area
                Models/             # Domain models
                Repositories/       # Repository interfaces
                Security/           # Security interfaces/domain models
                Services/           # Service interfaces
                    Communication/  # Service response models
                Extensions/         # Extension methods
                Mapping/            # AutoMapper profiles
                Persistence/        # Database
                    Contexts/       # EF Core DB contexts
                    Repositories/   # Repository classes
                Resources/          # DTOs for Web API
                Security/           # Security classes
                    Hashing/        # Hashing / checking tokens
                    Tokens/         # Token config / handlers
                Services/           # Service classes
    Boards.Tests/
        Services/                   # Service Tests
```

## Todos

- [ ] Write more tests.
- [ ] Move refresh tokens out of in-memory storage to a db table or Redis.
- [ ] Move JWT auth configs to User Secrets.
- [ ] Various edits to better conform to JSON API spec.
- [ ] Pagination / Filtering queries on list actions.
- [ ] Improve routing.
- [ ] URL slugs for titles containing spaces.
- [ ] Use board name as a primary key?
- [ ] Add user account roles.
- [ ] Be more n-tier (Split into class libs?).
- [ ] Base classes should be more generic.


## Contributing

Please feel free to fork, comment, critique, or submit a pull request.

## Author

- [Alex Errington](https://www.errington.tech)

## License

This project is open source and available under the [MIT License](LICENSE).
