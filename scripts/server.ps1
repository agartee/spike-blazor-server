[CmdletBinding(DefaultParameterSetName = 'default')]
param(
  [Parameter(Mandatory = $false, HelpMessage = "Configuration name (e.g. Release, Debug)")]
  [string]$configuration = "Debug"
)

$rootDir = (get-item $PSScriptRoot).Parent.FullName
& "$rootDir\scripts\support\start-server-local.ps1" -configuration "$configuration"
