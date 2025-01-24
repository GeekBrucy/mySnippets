```sh
az vmss create 
  --name <vmss name>
  --resource-group <resource group name>
  --image Ubuntu2204 
  --vm-sku Standard_B1ls 
  --storage-sku StandardSSD_LRS 
  --authentication-type SSH 
  --instance-count 2 
  --upgrade-policy-mode manual 
  --single-placement-group false 
  --platform-fault-domain-count 1 
  --load-balancer "" 
  --disable-overprovision
  --orchestration-mode Uniform
  --generate-ssh-keys
  --vnet-name vnet-vmss-poc
  --subnet default
```