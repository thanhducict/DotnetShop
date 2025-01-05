using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Categories.CreateCategory
{
    public record CreateCategoryCommand(string CategoryName) : ICommand<CreateCategoryResult>;

    public record CreateCategoryResult(Guid? CategoryId);

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
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
                CategoryGuid = Guid.NewGuid(),
                CategoryName = command.CategoryName
            };

            var result = await categoryRepository.CreateCategory(category, cancellationToken);

            return new CreateCategoryResult(result);
        }
    }
}
