# M-Files Template for Visual Studio - VAF App With Nested UI Extensibility App
Visual Studio template for a server app using the Vault Application Framework that contains a nested UI Extensibility app

The sample as-is will create a VAF app with an Extension Method and a UI Extensibility app with a custom right-click action. When clicked the action will show a message.

## Installing the Template
- Download Zip of the GitHub project
- Unzip
- Create Zip of the folder "VAF App With Nested UIX App"
- Put Zip in (user)/Documents/Visual Studio (version)/Templates/Project Templates/Visual C#/M-Files (Don't Unzip)
- In Visual Studio click New-Project and find the new template and create the project
- Right click the project
- Click Manage NuGet Packages
- Click Restore where it says "Some NuGet packages are missing from this solution"

## Installing your app to M-Files
- Open Post Build Command Line
- Change where it says "VaultNameHere" to the name of your vault
- Build Solution (F7)

## Pre and Post build commands explanation
### Pre-Build
```
powershell.exe "Compress-Archive -Path '$(ProjectDir)\Nested UIX App' -DestinationPath '$(TargetDir)\Nested UIX App.zip' -Force"
```
Runs a powershell command to create a zip of the nested UI Extensibility app and place it in the debug folder

### Post-Build
```
start "Installing Vault Application" /D "$(TargetDir)" "MFVaultApplicationInstaller.exe" "VaultNameHere"
```
Installs the app

## To-Do
- Figure out how to automatically get the NuGet packages
