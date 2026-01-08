
using FluentValidation.Results;
using FluentValidationDemo.Model;
using FluentValidationDemo.Validators;


User user = new User
{
    Id = 1,
    Name = "John Doe",
    Age = 11
};

var validator = new UserValidator();
ValidationResult validationResult = validator.Validate(user);

if(validationResult.IsValid)
{
    Console.WriteLine("User is valid.");
}
else
{
    Console.WriteLine("User is not valid:");
    foreach (var error in validationResult.Errors)
    {
        Console.WriteLine($"- {error.ErrorMessage}");
    }
}
