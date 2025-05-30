﻿using Common.Domain.ValueObjects;

namespace Shop.Api.ViewModels.Users
{
    public class AddUserAddressViewModel
    {
        public string Shire { get;  set; }
        public string City { get;  set; }
        public string PostalCode { get;  set; }
        public string PostalAddress { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Name { get;  set; }
        public string Family { get;  set; }
        public string Nationalcode { get;  set; }
        public bool ActiveAddress { get;  set; }
    }

    public class EditUserAddressViewModel
    {
        public string Shire { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Nationalcode { get; set; }
        public bool ActiveAddress { get; set; }
    }
}
