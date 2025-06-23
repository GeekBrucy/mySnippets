# Certificate Authentication Project Notes

## 项目概述
- **cert_auth_server**: Web API 服务器，配置证书认证
- **cert_auth_client**: 控制台应用，用于测试 Web API

## 实现计划

### 第一阶段：配置证书认证服务器
1. ✅ 在 `cert_auth_server` 中配置证书认证中间件
2. ✅ 创建测试控制器
3. ✅ 配置 HTTPS 和证书验证

### 第二阶段：创建测试客户端
1. ⏳ 在 `cert_auth_client` 中实现证书客户端
2. ⏳ 配置客户端证书
3. ⏳ 实现 API 调用测试

## 重要概念
- **客户端证书认证**: 服务器验证客户端提供的证书
- **双向 TLS (mTLS)**: 客户端和服务器都使用证书进行身份验证
- **证书链**: 验证证书的有效性和信任关系

## 技术要点
- ASP.NET Core 证书认证中间件
- HttpClient 配置客户端证书
- 开发证书生成和管理

## 实现进度

### ✅ 第一步完成：基础证书认证配置
- 添加了 `Microsoft.AspNetCore.Authentication.Certificate` 命名空间
- 配置了 `CertificateAuthenticationDefaults.AuthenticationScheme`
- 添加了 `UseAuthentication()` 中间件

### ✅ 第二步完成：创建测试控制器
- 创建了 `CertificateTestController` 控制器
- 包含两个端点：
  - `/certificate-test/no-cert` - 不需要认证
  - `/certificate-test/cert` - 需要认证，返回证书信息
- 在认证端点中返回客户端证书的详细信息：
  - Subject（主题）
  - Issuer（颁发者）
  - Thumbprint（指纹）
  - 有效期（NotBefore, NotAfter）
  - SerialNumber（序列号）
  - UserClaims（用户声明）

### ✅ 第三步完成：配置 HTTPS 和证书验证
- 修复了证书认证配置，添加了完整的 `.AddCertificate()` 配置
- 配置了证书验证选项：
  - `AllowedCertificateTypes = CertificateTypes.All`
  - `ValidateCertificateUse = true`
  - `ValidateValidityPeriod = true`
  - `RevocationMode = NoCheck` (开发环境)
- 添加了 `AddAuthorization()` 服务

## 关于手动验证证书的讨论
- 用户提到工作中有人使用 `appsettings.json` 中的 `TrustedCertificates` 数组
- 重写证书认证的 `Validated` 事件进行手动验证
- 需要复刻这个实现来调试 401 问题
- 后续讨论这种做法的最佳实践

## 关键代码片段
```csharp
// 获取客户端证书
var certificate = HttpContext.Connection.ClientCertificate;

// 获取用户声明
var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

// 证书认证配置
builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate(options =>
    {
        options.AllowedCertificateTypes = CertificateTypes.All;
        options.ValidateCertificateUse = true;
        options.ValidateValidityPeriod = true;
        options.RevocationMode = X509RevocationMode.NoCheck;
    });
```

## 问题修复记录
- **问题**: 服务器启动失败，endpoint 不工作
- **原因**: 证书认证配置不完整，缺少 `.AddCertificate()` 和 `AddAuthorization()`
- **解决**: 添加了完整的证书认证配置和授权服务
