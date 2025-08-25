
Import-Module "$PSScriptRoot\OpenTelemetry.DotNet.Auto.psm1" -Force

# MyFunctionFromFoo -Param1 "value"

Write-Host "Testing Install-OpenTelemetryCore..."

# Install-OpenTelemetryCore -InstallDir "D:\otel-dotnet-profiler-installRoot" # -LocalPath "d:\"
$env:OTEL_DOTNET_AUTO_INSTALL_DIR = "D:\otel-dotnet-profiler-installRoot"

# Set up your Windows Service instrumentation
Register-OpenTelemetryForWindowsService -WindowsServiceName "W3Svc" -OTelServiceName "otel-w3svc-svc-test"

UnRegister-OpenTelemetryForWindowsService -WindowsServiceName "W3Svc"

Write-Host "Done."
