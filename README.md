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
        + ldap string : 192.168.0.111 or ebithp3-b4
        + Shared Folders: 192.168.0.111\shared *preferable with the same admin account
        + Admin Account: Administrator
        + Admin Password: 123456
```
These setting can also be set in the `ProgParams.xml`. All except for the password ofcourse.

#### After setting the options ####
Once you're at this point the program should be ready to go, assuming the setting are correct. To pull the Active Directory users from the server goto `"File > Connect to Server"`. 

#### Uploading CSV ####
Use the excel file given to you by the registrar's office. Open it in excel and than save it as a `Comma Seperated Values (.csv)` file. Then goto `"File > Upload CSV"`. 


