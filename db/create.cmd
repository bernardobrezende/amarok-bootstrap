@echo off

set serverinstance=%1
set dbname=%2

@echo Creating Database...

sqlcmd -S %1 -Q "if not exists(select * from sys.databases where name = '%2') create database %2"