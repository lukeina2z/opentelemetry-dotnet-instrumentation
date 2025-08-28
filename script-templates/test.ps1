
Import-Module "$PSScriptRoot\OpenTelemetry.DotNet.Auto.psm1" -Force

Write-Host "Run OTel PowerShell Script..."

# Install-OpenTelemetryCore -InstallDir "D:\otel-dotnet-profiler-installRoot" # -LocalPath "d:\"

$env:OTEL_DOTNET_AUTO_INSTALL_DIR = "D:/Users/lukezha/github/otel-dotnet/opentelemetry-dotnet-instrumentation/bin/tracer-home"


# Register-OpenTelemetryForWindowsService -WindowsServiceName "W3Svc" -OTelServiceName "otel-w3svc-svc-test"
# UnRegister-OpenTelemetryForWindowsService -WindowsServiceName "W3Svc"

Register-OpenTelemetryForCurrentSession -OTelServiceName "xxyy-OTel-Dotnet-Bar"

Write-Host "End"

cmd /c set ASPNET
cmd /c set CORECLR_
cmd /c set COR_
cmd /c set DOTNET_
cmd /c set OTEL_




