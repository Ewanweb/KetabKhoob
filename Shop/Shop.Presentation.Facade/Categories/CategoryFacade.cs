﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GeList;
using Shop.Query.Categories.GetById;
using Shop.Query.Categories.GetByParentId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Categories
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;

        public CategoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> AddChild(AddChildCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CategoryDto> GetCategoryById(long id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(id));
            
        }

        public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId)
        {
            return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
        }

        public async Task<List<CategoryDto>> GetCategoriesByList()
        {
            return await _mediator.Send(new GetCategoryListQuery());
        }
    }
}
