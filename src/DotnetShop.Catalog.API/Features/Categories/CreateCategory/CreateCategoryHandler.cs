using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Categories.CreateCategory
{
    public record CreateCategoryCommand(Guid CategoryId, string CategoryName) : ICommand<CreateCategoryResult>;

    public record CreateCategoryResult(bool IsSuccess);

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("GUID is required");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("CategoryName is required");
        }
    }

    internal class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<CreateCategoryCommandHandler> logger)
        : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        public async Task<CreateCategoryResult> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("CreateCategoryCommandHandler.Handle called with {@Query}", command);
            var category = new Category
            {
                CategoryId = command.CategoryId,
                CategoryName = command.CategoryName
            };

            var result = await categoryRepository.CreateCategory(category);

            return new CreateCategoryResult(result);
        }
    }
}
