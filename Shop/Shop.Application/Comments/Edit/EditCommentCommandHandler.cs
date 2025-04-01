﻿using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandHandler : IBaseCommandHandler<ChangeStatusCommand>
{
    private readonly ICommentRepository _repository;

    public EditCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.Id);

        if (comment == null || comment.UserId != request.UserId)
            return OperationResult.NotFound();

        comment.Edit(request.Text);
        await _repository.Save();

        return OperationResult.Success();
    }
}