### **Solution Overview**
1. **APIM1 Configuration**: Update APIM1 policies to forward requests to APIM2's endpoint, replacing the backend URL and injecting APIM2's subscription key.
2. **Subscription Key Management**: Store APIM2's subscription key as a **Named Value** in APIM1 for secure access.
3. **Header Preservation**: Ensure critical headers (e.g., JWT) are forwarded, and APIM2's key is added to the request.

### **Step-by-Step Implementation**

#### **1. Configure APIM1 to Forward Requests to APIM2**
Use APIM policies to reroute traffic by updating the backend URL and injecting APIM2's subscription key.

**Example APIM1 Policy**:
```xml
<policies>
  <inbound>
    <!-- Validate APIM1 subscription key (if required) -->
    <validate-jwt header-name="Authorization" failed-validation-httpcode="401" ... />
    
    <!-- Set backend to APIM2's endpoint -->
    <set-backend-service base-url="https://apim2.azure-api.net/new-webapi" />
    
    <!-- Add APIM2's subscription key as a header -->
    <set-header name="Ocp-Apim-Subscription-Key" exists-action="override">
      <value>{{apim2-subscription-key}}</value> <!-- Reference stored Named Value -->
    </set-header>
    
    <!-- Forward original headers (e.g., JWT) -->
    <base />
  </inbound>
  <backend>
    <base />
  </backend>
  <outbound>
    <base />
  </outbound>
</policies>
```

#### **2. Securely Store APIM2's Subscription Key in APIM1**
- **Create a Named Value** in APIM1 (e.g., `apim2-subscription-key`) to securely store APIM2's key.
- Reference it in policies using `{{apim2-subscription-key}}` to avoid hardcoding secrets.

#### **3. Test and Validate**
- **Pre-Cutoff**: Test the policy in APIM1 with a subset of traffic (e.g., using a test API operation) to ensure:
  - Requests are correctly forwarded to APIM2.
  - APIM2 processes requests and writes to the relational database.
  - Headers like JWT are preserved.
- **Post-Cutoff**: Disable the Function App backend to prevent Cosmos writes.

#### **4. Monitor Post-Cutoff**
- Use Azure Monitor/APIM Analytics to ensure no traffic flows to Cosmos.
- Verify APIM2 logs to confirm all data is routed correctly.

---

### **Key Considerations**
- **Request Compatibility**: Ensure the new WebApp API accepts the same request format as the old Function Apps.
- **Security**: Use HTTPS for communication between APIM1 and APIM2. Avoid exposing APIM2's key in logs/traces.
- **Error Handling**: Configure APIM1 to return appropriate errors if APIM2 is unreachable.
- **Header Management**: Use `<set-header>` or `<forward-request>` policies to propagate necessary headers (e.g., `Authorization`).

### **Why This Works**
- **Seamless Transition**: External users continue using APIM1’s URL and keys without changes.
- **Secure Key Handling**: APIM2’s key is stored securely in APIM1 and injected dynamically.
- **Zero Downtime**: APIM1 remains active post-cutoff, rerouting traffic to the modernized backend.

By implementing this, you ensure data stops flowing to Cosmos after the cutoff while maintaining backward compatibility for external users.