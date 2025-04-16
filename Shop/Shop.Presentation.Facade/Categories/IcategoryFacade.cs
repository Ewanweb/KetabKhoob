using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GeList;
using Shop.Query.Categories.GetById;

namespace Shop.Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Edit(EditCommentCommand command);
    Task<OperationResult> Create(CreateCategoryCommand command);

    Task<CategoryDto> GetCategoryById(long id);
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId);
    Task<List<CategoryDto>> GetCategoriesByList();
}