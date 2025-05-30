﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Nationalcode { get; private set; }
        public bool ActiveAddress { get; private set; }

        public AddUserAddressCommand(long userId, string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string name, string family, string nationalcode, bool activeAddress)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            Nationalcode = nationalcode;
            ActiveAddress = activeAddress;
        }
    }
}
