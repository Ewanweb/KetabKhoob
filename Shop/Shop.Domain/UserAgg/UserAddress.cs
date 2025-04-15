using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string name, string family, string nationalcode)
    {
        Guard(shire, city, postalCode, postalAddress, phoneNumber, name, family, nationalcode);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        Nationalcode = nationalcode;
        ActiveAddress = false;
    }

    private UserAddress()
    {
        
    }
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



    public void Edit(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber,
        string name, string family, string nationalcode)
    {
        Guard(shire, city, postalCode, postalAddress, phoneNumber, name, family, nationalcode);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        Nationalcode = nationalcode;
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }

    public void Guard(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber,
        string name, string family, string nationalcode)
    {
        if (phoneNumber is null)
            throw new NullOrEmptyDomainDataException("شماره موبایل خالی است");

        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        NullOrEmptyDomainDataException.CheckString(family, nameof(family));
        NullOrEmptyDomainDataException.CheckString(nationalcode, nameof(nationalcode));

        if (!IranianNationalIdChecker.IsValid(nationalcode))
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
    }
}