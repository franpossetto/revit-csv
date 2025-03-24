#define MyAppName "RevitCSV"
#define MyAppVersion "1.0.0"
#define MyAppExeName "RevitCSV.exe"

[Setup]
AppId= 29EB0FF1-635A-4B8D-803D-1DB35438EF79
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
OutputBaseFilename= RevitCSV
OutputDir=/output
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DefaultDirName={autopf}\RevitCSV

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; General Files
Source: "..\RevitCSV\Ribbon\PackageContents.xml"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle"; Flags: ignoreversion

; 2023 Files
Source: "..\RevitCSV\bin\Release\RevitCSV.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2023"; Flags: ignoreversion
Source: "..\RevitCSV\RevitCSV.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2023"; Flags: ignoreversion
