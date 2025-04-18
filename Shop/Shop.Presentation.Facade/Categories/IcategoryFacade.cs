using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Comments.Edit;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GeList;
using Shop.Query.Categories.GetById;

namespace Shop.Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult<long>> Create(CreateCategoryCommand command);
    Task<OperationResult> Remove(long categoryId);

    Task<CategoryDto> GetCategoryById(long id);
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId);
    Task<List<CategoryDto>> GetCategoriesByList();
}