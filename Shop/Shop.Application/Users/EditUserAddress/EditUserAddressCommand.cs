using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Users.EditUserAddress
{
    public class EditUserAddressCommand : IBaseCommand
    {
        public long Id { get; set; }
        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Nationalcode { get; private set; }
        public bool ActiveAddress { get; private set; }
    }
}
