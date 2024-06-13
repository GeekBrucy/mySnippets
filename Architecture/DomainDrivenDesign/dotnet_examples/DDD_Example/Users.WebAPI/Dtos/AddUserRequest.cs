using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.ValueObjects;

namespace Users.WebAPI.Dtos;

public record AddUserRequest(PhoneNumber PhoneNumber, string password);