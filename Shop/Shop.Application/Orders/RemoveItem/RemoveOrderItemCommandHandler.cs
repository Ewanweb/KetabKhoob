using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem;

public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
{
    private readonly IOrderRepository _repository;

    public RemoveOrderItemCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _repository.GetCurrentOrder(request.UserId);

        if (currentOrder is null)
            return OperationResult.NotFound();
            
        currentOrder.RemodeItem(request.ItemId);

        await _repository.Save();

        return OperationResult.Success();
    }
}