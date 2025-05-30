﻿using Common.Domain;

namespace Shop.Domain.OrderAgg;

public class OrderAddress : BaseEntity
{
    public OrderAddress(string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalcode)
    {
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        Nationalcode = nationalcode;
    }


    public long OrderId { get; internal set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Nationalcode { get; private set; }
    public Order Order { get; private set; }
}