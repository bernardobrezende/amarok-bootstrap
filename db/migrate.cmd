@echo off

set connectionString=%1
set migratePath="..\packages\FluentMigrator.1.1.1.0\tools\Migrate.exe"
set migrationsPath=..\src\Amarok.Database.Migrations\bin\Debug\Amarok.Database.Migrations.dll

@echo Calling Fluent Migrator...

%migratePath% /connection %connectionString% /db sqlserver /profile=Development /target %migrationsPath%

@echo End!