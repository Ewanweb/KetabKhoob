using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.CheackOut
{
    public class CheckOutOrderCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Nationalcode { get; private set; }
        public Order Order { get; private set; }

        public CheckOutOrderCommand(long userId, string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalcode, Order order)
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
            Order = order;
        }
    }


    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public CheckOutOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentOrder(request.UserId);

            if (currentOrder is null)
                return OperationResult.NotFound();

            var address = new OrderAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.Nationalcode);

            currentOrder.CheckOut(address);

            await _repository.Save();

            return OperationResult.Success();
        }
    }

    public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.Family)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(r => r.City)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(r => r.PostalAddress)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(r => r.PostalCode)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(r => r.Shire)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("ادرس"));

            RuleFor(r => r.Nationalcode)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("کدملی"))
                .MaximumLength(10).WithMessage("کدملی نا معتبر است")
                .MinimumLength(10).WithMessage("کدملی نا معتبر است")
                .ValidNationalId();

            RuleFor(r => r.PhoneNumber)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("شماره موبایل"))
                .MaximumLength(11)
                .MinimumLength(11).WithMessage("شماره موبایل نا معتبر است");
        }
    }
}
