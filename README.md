Project structure:
GICApplication/
│
├── GICApplication.Application/   (Application Layer - Services & Interfaces)
│   ├── Interfaces/
│   │   └── IAccountService.cs
│   └── Services/
│       └── AccountService.cs
│
├── GICApplication.Domain/        (Domain Layer - Core Business Logic)
│   ├── Entities/
│   │   ├── Account.cs
│   │   └── Transaction.cs
│   └── Enums/
│       └── TransactionType.cs
│
└── GICApplication.ConsoleApp/    (Presentation Layer - Console Application)
    └── Program.cs

===================Load and Run the project======================
01)Open Project Folder in Visual Studio Code
  Launch Visual Studio Code:
  Open Your Project:
  Click on File in the top menu.
  Select Open Folder... from the dropdown menu.
  Navigate to the root folder of the solution.
02)Restore Dependencies
  Open the Terminal:
  In the top menu, click on Terminal.
  Select New Terminal from the dropdown. A terminal window will appear at the bottom.
  Restore Dependencies:
  In the terminal, enter the following command and press Enter:
  bash>>> dotnet restore
  This command downloads and installs any necessary packages defined in your project.
03) Build the Solution
  Build the Project:
  In the same terminal window, run the following command:
  bashbash>>> dotnet build
  Ensure that the build completes successfully.
04) Run the Console Application
Navigate to the Console Application:
bash>>>dotnet run --project GICApplication.ConsoleApp
