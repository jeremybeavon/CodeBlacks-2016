Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory("$PSScriptRoot\MSBuild.Extension.Pack.1.8.0.zip", "$PSScriptRoot\packages")