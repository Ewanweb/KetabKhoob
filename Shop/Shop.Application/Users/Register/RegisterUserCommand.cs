using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.Register
{
    public record RegisterUserCommand(PhoneNumber PhoneNumber, string Password) : IBaseCommand;
}
