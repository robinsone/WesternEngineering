rem chgdisplay.vbs - Changes the display names of all users in a given OU to the 
rem format of Lastname, Firstname.
rem Usage = cscript chgdisplay.vbs "OU=My Ou, DC=My Domain, DC=com"
rem OU must be enclosed in quotes if it contains spaces in the name

Dim strTargetOU

ParseCommandLine()

wscript.echo strTargetOU
wscript.echo
wscript.echo "Changing Display names of users in " & strTargetOU

Set oTargetOU = GetObject("LDAP://" & strTargetOU)

oTargetOU.Filter = Array("user")

For each usr in oTargetOU

	if instr(usr.SamAccountName, "$") = 0 then
		vLast = usr.get("Sn")
		vFirst = usr.get("GivenName")
 		vFullname = vLast + "\, " + vFirst
	    	usr.put "displayName", vFullName 
 	   	usr.setinfo
		wscript.echo usr.displayName
	end if
Next


Sub ParseCommandLine()
  	Dim vArgs

  	set vArgs = WScript.Arguments
  
  	if vArgs.Count <> 1 then 
      		DisplayUsage()
  	Else
     		strTargetOU = vArgs(0)
  	End if
End Sub

Sub DisplayUsage()
	WScript.Echo
 	WScript.Echo "Usage:  cscript.exe " & WScript.ScriptName & " <Target OU to change users display names in>" 
 	WScript.Echo "Example: cscript " & WScript.ScriptName & " " & chr(34) & "OU=MyOU,DC=MyDomain,DC=com" & chr(34)
	WScript.Quit(0)
End Sub