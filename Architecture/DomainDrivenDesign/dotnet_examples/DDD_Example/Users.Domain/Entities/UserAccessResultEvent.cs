using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Users.Domain.Enums;
using Users.Domain.ValueObjects;

namespace Users.Domain.Entities;

public record UserAccessResultEvent(PhoneNumber PhoneNumber, UserAccessResult Result) : INotification;