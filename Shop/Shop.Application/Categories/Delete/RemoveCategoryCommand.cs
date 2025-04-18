using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Categories.Delete
{
    public record RemoveCategoryCommand(long CategoryId) : IBaseCommand;
}
