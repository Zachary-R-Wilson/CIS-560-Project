# Timeblock Planner
A web application demonstrating proficiency with databases.


## Description 
Welcome to our Time Block Planner! This is a useful time management tool allowing users to create various personal and professional metrics, goals, and timeblocks which you can align with your busy schedule, due dates, or personal goals. The application tracks your progress and stores all upcoming goals or timeblocks and their respective dates. The Time Block Planner takes the stress and burden of time management and organization off your back allowing you to be your most productive self! 


## Instructions 

In order to run this application for testing purposes on a local machine please ensure you follow the following steps in order to successfully connecct your local database to the front end of the application. 

### Steps :
1.) Ensure that all instances of the 'connectionString' variable are altered in alignment with the following format : 
      
            @"Server=(localdb)\[Local_Database_Server_Name];Database=[Local_Database_Name];Integrated Security=SSPI;"

            
2.) Ensure all Server declaration statements in the solution are altered in alignment with the following format :
      
            $Server = "(localdb)\[Local_Database_Server_Name]"

3.) Ensure that the RebuildDatabase.ps1, located in the SolutionItems folder, is run through the PowerShell prompt and indicates completion of scripts without errors.
Help : In the case the PowerShell prompt indicated an error running the script "...not digitally signed", run the following command to resolve the error and complete the rebuild : 

            Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
