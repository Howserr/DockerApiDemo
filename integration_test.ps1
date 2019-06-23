Write-Host "Starting integration test"
Write-Host "Building images and starting containers"
docker-compose up -d --build --force-recreate --quiet-pull
Write-Host "Waiting for application to start and warm up"
Start-Sleep 10

Try {
    # Get initial state of customers for comparison at end. Also provides test of get all
    $initalCustomers = Invoke-RestMethod -Uri https://localhost:44339/api/customers -Method Get

    Write-Host "========================================="
    Write-Host "Testing customer creation:"
    $newCustomer = @{
        firstName='Integration'
        lastName='Test'
        email='i.test@test.com'
        password='Testing123'
    }
    Write-Host "Sending POST to customers root"
    $createdCustomer = Invoke-RestMethod -Uri https://localhost:44339/api/customers -Body (ConvertTo-Json $newCustomer) -Method Post -ContentType 'application/json'

    Write-Host "========================================="
    Write-Host "Testing customer retrieval:"
    $createdCustomerUri = 'https://localhost:44339/api/customers/' + $createdCustomer.id
    Write-Host "Sending GET to customers/{id}"
    $fetchedCustomer = Invoke-RestMethod -Uri $createdCustomerUri -Method Get

    If($createdCustomer.id -ne $fetchedCustomer.id -Or $createdCustomer.firstName -ne $fetchedCustomer.firstName -Or $createdCustomer.lastName -ne $fetchedCustomer.lastName-Or $createdCustomer.email -ne $fetchedCustomer.email-Or $createdCustomer.password -ne $fetchedCustomer.password) {
        throw "Retrieved customer different to the expected customer that was previously created."
    }

    Write-Host "========================================="
    Write-Host "Testing customer update:"
    $createdCustomer.firstName = 'Updated-Integration'
    $createdCustomer.lastName = "Updated-Test"
    $createdCustomer.email = 'u.update@test.com'
    $createdCustomer.password = "NewPassword123"

    Write-Host "Sending PATCH to customers root"
    $updatedCustomer = Invoke-RestMethod -Uri https://localhost:44339/api/customers -Body (ConvertTo-Json $createdCustomer) -Method Patch -ContentType 'application/json'

    If($createdCustomer.id -ne $updatedCustomer.id -Or $createdCustomer.firstName -ne $updatedCustomer.firstName -Or $createdCustomer.lastName -ne $updatedCustomer.lastName-Or $createdCustomer.email -ne $updatedCustomer.email-Or $createdCustomer.password -ne $updatedCustomer.password) {
        throw "Updated customer not updated correctly as expected."
    }

    Write-Host "========================================="
    Write-Host "Testing customer deletion:"
    Write-Host "Sending DELETE to customers/{id}"
    Invoke-RestMethod -Uri $createdCustomerUri -Method Delete

    Write-Host "========================================="
    Write-Host "Checking customers is in expected state:"
    Write-Host "Sending GET to customers root"
    $finalCustomers = Invoke-RestMethod -Uri https://localhost:44339/api/customers -Method Get

    if ($initalCustomers.count -ne $finalCustomers.count){
        throw "Incorrect number of customers returned after testing."
    }

    Write-Host "========================================="
    Write-Host "Integration test successful. All tests passed"
} 
Catch {
    Write-Host "========================================="
    $_.Exception | Format-List -Force
    Write-Host "========================================="
    Write-Host "Integration test failed"
}
Finally {

    Write-Host "========================================="
    Write-Host "Stopping and removing containers"
    docker-compose down
    Write-Host "Docker containers stopped and removed." 
}
Write-Host "========================================="
Write-Host "Integration test complete"