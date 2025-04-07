using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _repository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository)
    {
        _repository = repository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);

        if (inventory is null)
            return OperationResult.NotFound();

        if (inventory.Count < request.Count)
            OperationResult.Error("تعداد محصولات درخواستی بیشتر از تعداد محصولات موجود میباشد!");

        var order = await _repository.GetCurrentOrder(request.UserId);

        order ??= new Order(request.UserId);


        order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));

        if (ItemCountBiggerThanInventoryCount(inventory, order))
            OperationResult.Error("تعداد محصولات درخواستی بیشتر از تعداد محصولات موجود میباشد!");


        await _repository.Save();

        return OperationResult.Success();
    }

    private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItem = order.Items.First(x => x.InventoryId == inventory.Id);

        if (orderItem.Count > inventory.Count)
            return true;

        return false;
    }
}