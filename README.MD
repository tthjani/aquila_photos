# Aquila Photos
Repository of a website to an imaginary Photo Studio.

## Tools
There's a `tools` folder in the repository root, which contains different tools running/maintaining the application. The tools are as follows:

### CreateMigration.cmd
Using this Command Prompt file we can easily create EF Migrations without knowing the exact command. It has two parameters:

 - Migration name
	 - The name of the migration which will be added to the migration file.
 - Connection String
	 - The connection string to the database we want to run the migrations against.

Usage:
Open a command prompt window and run the CreateMigration.cmd file.
Example:

`.\CreateMigration.cmd "MigrationName" "Server="localhost;Database=aquila_photos_db;Integrated Security=True;`