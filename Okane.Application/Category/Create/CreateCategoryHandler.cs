﻿using FluentValidation;
// Check
namespace Okane.Application.Category.Create
{
    public class CreateCategoryHandler
    {
        private readonly IValidator<CreateCategoryRequest> _validator;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(IValidator<CreateCategoryRequest> validator,
            ICategoryRepository categoryRepository)
        {
            _validator = validator;
            _categoryRepository = categoryRepository;
        }

        public ICategoryResponse Handle(CreateCategoryRequest createCategoryRequest)
        {
            var validation = _validator.Validate(createCategoryRequest);

            if (!validation.IsValid)
                return ValidationErrorsCategoryResponse.From(validation);

            var category = createCategoryRequest.ToCategory();
            _categoryRepository.Add(category);

            return category.ToCategoryResponse();
        }
    }
}