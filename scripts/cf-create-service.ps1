Param(
    [string]$networkAddress = "\\\\localhost\\steeltoe_network_share",
	[string]$username = "shareWriteUser",
	[string]$password = "thisIs1Pass!1234"
	[string]$domain = "replace_me"
)
$ErrorActionPreference = "Stop"

$serviceName = "credhub"
$servicePlan = "default"
$serviceInstanceName = "steeltoe-network-share"

$paramJSON = [string]::Format('{{\"location\":\"{0}\",\"username\":\"{1}\",\"password\":\"{2}\",\"domain\":\"{3}\"}}', $networkAddress, $username, $password, $domain)

#Create the service instance
cf create-service $serviceName $servicePlan $serviceInstanceName -c $paramJSON -t $serviceInstanceName
