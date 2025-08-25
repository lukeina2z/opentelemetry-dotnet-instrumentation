
Import-Module "$PSScriptRoot\OpenTelemetry.DotNet.Auto.psm1" -Force

$env:OTEL_DOTNET_AUTO_INSTALL_DIR = "D:\opentelemetry-dotnet-instrumentation-windows"

# MyFunctionFromFoo -Param1 "value"

Write-Host "Testing Get-Current-InstallDir..."

$installLoc = Get-OpenTelemetryInstallDirectory

Write-Host "Install directory: $installLoc"

Write-Host "Done."
