# Certificate Authentication Project Notes

## 项目概述
- **cert_auth_server**: Web API 服务器，配置证书认证
- **cert_auth_client**: 控制台应用，用于测试 Web API

## 实现计划

### 第一阶段：配置证书认证服务器
1. ✅ 在 `cert_auth_server` 中配置证书认证中间件
2. 🔄 创建测试控制器
3. ⏳ 配置 HTTPS 和证书验证

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

### 🔄 下一步：创建测试控制器
需要创建一个简单的 API 控制器来测试证书认证是否工作

## 关于手动验证证书的讨论
- 用户提到工作中有人使用 `appsettings.json` 中的 `TrustedCertificates` 数组
- 重写证书认证的 `Validated` 事件进行手动验证
- 需要复刻这个实现来调试 401 问题
- 后续讨论这种做法的最佳实践
