using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password, Gender gender,IUserDomainService userDomainService)
        {
            Guard(phoneNumber, email, userDomainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            AvatarName = "noImage.png";
            IsActive = true;
        }

        private User()
        {
            
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public string AvatarName { get; private set; }
        public bool IsActive { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }

        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IUserDomainService userDomainService)
        {
            Guard(phoneNumber, email, userDomainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomainService)
        {
            if (userDomainService.IsPhoneNumberExist(phoneNumber))
                throw new InvalidOperationException("شماره تلفن قبلاً ثبت شده است.");

            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("رمز عبور نمی‌تواند خالی باشد.");

            return new User("", "", phoneNumber, null, password, Gender.None, userDomainService);
        }

        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = "noImage.png";

            AvatarName = imageName;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void EditAddress(UserAddress address, long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(x => x.Id == addressId);

            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found");
            
            oldAddress.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress,
                address.PhoneNumber, address.Name, address.Family, address.Nationalcode);
        }

        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(x => x.Id == addressId);

            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found");

            Addresses.Remove(oldAddress);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber, string? email, IUserDomainService userDomainService)
        {
            if (phoneNumber is null)
                throw new NullOrEmptyDomainDataException("شماره موبایل خالی است");



            if (email.IsValidEmail())
                throw new InvalidDomainDataException("ایمیل نامعتبر است");


            if (!string.IsNullOrWhiteSpace(email))
                if (email != Email)
                    if (userDomainService.IsEmailExist(email))
                        throw new InvalidDomainDataException("ایمیل تکراری است");


        }
    }
}
