WesternEngineering
==================

### Disclaimer ###
This program is still in BETA. Please report back any issues you find using this GitHub repository. 

### Install Instructions ###
1. Download the entire [.zip folder](https://github.com/robinsone/WesternEngineering/archive/master.zip). 
2. Run the .exe file found at ".../SeedingProgramV2/SeedingProgramV2/bin/Debug/SeedingProgramV2.exe"
  - Feel free to make a shortcut to your desktop while in this folder 

### Usage ###
#### Initial Setup ####
When you start the program, you'll want to enter the options to find your Active Directory Server. This can be found on the toolbar, Tools > Options. 

```
    - example settings:
        + ldap string : 192.168.0.111 or ServerName
        + Shared Folders: 192.168.0.111\shared *preferable with the same admin account
        + Admin Account: Administrator
        + Admin Password: 123456
```
These setting can also be set in the `ProgParams.xml`. All except for the password ofcourse.

#### After setting the options ####
Once you're at this point the program should be ready to go, assuming the setting are correct. To pull the Active Directory users from the server goto `"File > Connect to Server"`. 

#### Uploading CSV ####
Use the excel file given to you by the registrar's office. Open it in excel and than save it as a `Comma Seperated Values (.csv)` file. Then goto `"File > Upload CSV"`. 

#### Instructions By Lyle ####
- DOWNLOAD THE LATEST .ZIP FROM GITHUB
- Make sure Options are set to ScreenShot
- File -> Connect to Server
- File -> Upload .CSV
  - Student#, GRAD/UGRAD, LastName, FirstName, MiddleName, Username
- Select Group from drop down and click Apply, You can verify this step by looking at the H: DRIVE Path in the grid
- Select Users to import
- Action -> Add Selected Users
  - You should see the grey rows become purple, this will indicate user was added. 
  
Notes: It's a good idea to add one user to test and make sure everything is working as expected





