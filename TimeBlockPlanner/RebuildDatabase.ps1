Param(
   [string] $Server = "(localdb)\reaganlocal",
   [string] $Database = "rphazell"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name SqlServer;

# Install the SQL Server Module
# Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

<#
   If on your local machine, you can drop and re-create the database.
#>
& ".\Scripts\DropDatabase.ps1" -Database $Database
& ".\Scripts\CreateDatabase.ps1" -Database $Database

<#
   If on the department's server, you don't have permissions to drop or create databases.
   In this case, maintain a script to drop all tables.
#>
#Write-Host "Dropping tables..."
#Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "PersonData\Sql\Tables\DropTables.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Schemas\User.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Tables\User.User.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Tables\User.TimeBlock.sql"

Write-Host "Stored procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Procedures\User.CreateUser.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Procedures\User.GetUserByEmail.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Procedures\User.GetUserById.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Procedures\User.SaveUserTimeBlock.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Procedures\User.RetrieveTimeBlockForUser.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "UserData\Sql\Procedures\User.RetrieveUser.sql"



Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive
