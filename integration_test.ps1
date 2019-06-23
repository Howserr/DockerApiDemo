[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

docker-compose up -d
Write-Host "Waiting for application to deploy and warm up"
Start-Sleep 10
Try {
    Invoke-RestMethod -Uri https://localhost:44339/api/customers
} 
Catch {
    $_.Exception | Format-List -Force
}
Finally {
    docker-compose down
}