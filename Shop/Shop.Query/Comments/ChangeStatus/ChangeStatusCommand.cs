using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeStatusCommand(long Id, CommentStatus Status) : IBaseCommand;
}
