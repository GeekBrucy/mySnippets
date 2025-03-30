using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OAuthClient
{
    public class TokenManage
    {
        private readonly string _dbPath;

        public TokenManage(IWebHostEnvironment env)
        {
            _dbPath = Path.Combine(env.ContentRootPath, "token_database");
        }

        public Dictionary<string, TokenInfo> Record => File.Exists(_dbPath)
            ? JsonSerializer.Deserialize<Dictionary<string, TokenInfo>>(File.ReadAllText(_dbPath))
            : new Dictionary<string, TokenInfo>();

        public TokenInfo Get(string key)
        {
            return Record[key];
        }
        public void Save(string key, TokenInfo tokenInfo)
        {
            var db = Record;
            if (db.ContainsKey(key))
            {
                db[key] = tokenInfo;
            }
            else
            {
                db.Add(key, tokenInfo);
            }
            File.WriteAllText(_dbPath, JsonSerializer.Serialize(db));
        }

        public record TokenInfo(string AccessToken, string RefreshToken, DateTime Expires);
    }
}