### HairSalon.Solution

_By Jeremy Banka_

## Technologies Used

- 🎵 C# / .NET 5 Framework
- 🎛️ ASP.NET Core Server
- 🧮 MySQL Database
- 🔁 Entity Framework Core
- 🪒 Razor Templating
- 💅 SCSS to CSS via Ritwick's Live Sass Compiler
- 🛠️ Tooling: Omnisharp
- 🅰️ Fonts: Verdana & Charter by Matthew Carter

## Description

This website is an exercise in using Microsoft's Entity Framework Core to abstract the process of reading from and writing to a MySQL database.

## Setup/Installation Requirements

- Get the source code: `$ git clone https://github.com/jeremybanka/HairSalon.Solution`
- Set up a compatible database. There are two ways of going about this. I recommend the first.
  1. **Import my configuration**
     - Find `jeremy_banka.sql` in the root folder.
     - In MySQL Workbench, find the 'Administration' tab in the upper left of the application.
     - Under that tab, click 'Data Import/Restore'.
     - Select the radio option 'Import from Self-Contained File' and browse to the `.sql` file located earlier.
     - If you want a few example entries in the database pre-made, pick 'Dump Structure and Data' in the dropdown near the bottom. If you want to see the empty-state first, select 'Dump Structure Only'.
     - Click 'Start Import'.
     - Once complete, go back to the 'Schemas' tab next to administration and refresh using the tiny 🔁 button.
     - The app won't do this for you.
     - Why would it?
  2. **Set it up yourself**
     - If you picked this option, I'm gonna assume you know what you're doing.
     - Make a new schema `hair_salon`.
     - Add two tables `clients`, `stylists`.
     - In `clients` add three columns
       - `ClientId`: `VARCHAR(36)` with `PK` (primary key) and `NN` (not null) options picked.
       - `Name`: `VARCHAR(45)`
       - `StylistId`: `VARCHAR(36)` these aren't `INT`s because I'm using `System.Guid`.
     - In `stylists` add two columns
       - `StylistId`: `VARCHAR(36)` with `PK` (primary key) and `NN` (not null) options picked.
       - `Name`: `VARCHAR(45)`
- Add `appsettings.json` in `HairSalon/` and paste in the following text:

  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=hair_salon;uid=root;pwd=************;"
    }
  }
  ```

  except, instead of `************` put your password for MySQL.

- Compile and run the WebApp as you save changes: `$ dotnet watch run` in `HairSalon/` (This command will also install necessary dependencies.)

## Known Bugs

- none identified

## License

Gnu Public License ^3.0

## Contact Information

hello at jeremybanka dot com
