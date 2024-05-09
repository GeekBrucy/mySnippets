using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_fluent_validation.Dtos;

public record AddNewUserRequest(string UserName, string Email, string Password, string ConfirmPassword);
