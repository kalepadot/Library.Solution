# _Library Administration Page_

#### By _**K. Wicz, Steph Podolak, and Jeremy Kale Padot**_


## Description

_An MVC web application to to catalog a library's books and let patrons check them out._

## Program User Stories

| Specification | Example Input | Example Output |
| ------------- |:-------------:| -------------------:|
| Librarian user can create, read, update, delete, and list books in a catalog inventory.| New book including title, and author is entered | Book and details available to view and edit in library |
| Librarian user can search for a book by author or title | Librarian inputs title | Book is displayed with author details  |
| Librarian user can enter multiple authors for a book | Librarian edits book to add additional authors | Multiple authors displayed with book details |
| Patron user can checkout a book from library database | Patron checks out 1 book  | Number of copies for that specific book decreases by 1|
| Patron user can check how many copies of a particular book are available | Patron searches for book | Book details displays number of copies available|
| Patron user can see a history of all books they've checked out | Patron logs into account | Patron can view entire checkout history |
| Patron user can check when a book they've checked out is due | Patron clicks on checkout item | Due date is displayed |
| Librarian user can see a list of all overdue books | Librarian views overdue library books| Overdue books are displayed | 


## Setup/Installation Requirements

### 1.  Install .NET Core

#### on macOS:
* [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download a .NET Core SDK from Microsoft Corp.

#### on Windows:
* [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp.

#### Install dotnet script
Enter the command ``dotnet tool install -g dotnet-script`` in Terminal (macOS) or PowerShell (Windows).

### 2. Clone this repository

Enter the following commands in Terminal (macOS) or PowerShell (Windows):
```sh
cd desktop
git clone https://github.com/kwicz/Library.Solution
cd Library.Solution
```
### 3. Install all necessary packages and make sure the project will build
In your terminal, type the following commands to make sure all necessary packages are included in the project and to launch in your browser:
```sh
cd Library
dotnet restore
dotnet build
```

### 4. Create the database and tables
Enter the following to build your database and tables for the program:
```sh
dotnet ef migrations add Initial
dotnet ef database update
```

### 5. Launch the project in your browser
In your terminal, type:
```sh
dotnet watch run
```
Then hold ```command``` while clicking the link in your local terminal to your local address, which should be:
```sh
http://127.0.0.1:5000
```

Eureka! The project is now ready to use.

## Known Bugs

_No known bugs at this time._

## Support and contact details

_Have a bug or an issue with this application? [Open a new issue](https://github.com/kwicz/Library.solution/issues) here on GitHub._

## Technologies Used
* _C#_
* _.NET Core 2.2_
* _ASP.NET Core MVC_
* _MySQL_
* _EF Core 2.2.6_
* _ASP.NET Core Identity_
* _Razor 2.2.0_
* _Material Design Lite_

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2020 **_K Wicz_**
