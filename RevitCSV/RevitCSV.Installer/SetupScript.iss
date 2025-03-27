#define MyAppName "RevitCSV"
#define MyAppVersion "1.0.1"
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
Source: "..\RevitCSV.Common\PackageContents.xml"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle"; Flags: ignoreversion


; 2021 Files
Source: "..\RevitCSV.R2021\bin\Release\RevitCSV.R2021.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2021"; Flags: ignoreversion
Source: "..\RevitCSV.Common\bin\Release\RevitCSV.Common.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2021"; Flags: ignoreversion
Source: "..\RevitCSV.R2021\RevitCSV.R2021.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2021"; Flags: ignoreversion

; 2022 Files
Source: "..\RevitCSV.R2022\bin\Release\RevitCSV.R2022.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2022"; Flags: ignoreversion
Source: "..\RevitCSV.Common\bin\Release\RevitCSV.Common.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2022"; Flags: ignoreversion
Source: "..\RevitCSV.R2022\RevitCSV.R2022.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2022"; Flags: ignoreversion

; 2023 Files
Source: "..\RevitCSV.R2023\bin\Release\RevitCSV.R2023.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2023"; Flags: ignoreversion
Source: "..\RevitCSV.Common\bin\Release\RevitCSV.Common.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2023"; Flags: ignoreversion
Source: "..\RevitCSV.R2023\RevitCSV.R2023.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2023"; Flags: ignoreversion

; 2024 Files
Source: "..\RevitCSV.R2024\bin\Release\RevitCSV.R2024.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2024"; Flags: ignoreversion
Source: "..\RevitCSV.Common\bin\Release\RevitCSV.Common.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2024"; Flags: ignoreversion
Source: "..\RevitCSV.R2024\RevitCSV.R2024.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\RevitCSV.bundle\Contents\2024"; Flags: ignoreversion