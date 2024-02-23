using FluentValidation;
using System.Collections.Generic;

namespace CatPipeline.Usecases
{
    public class SayHiValidator : AbstractValidator<SayHiHandler.Request>
    {
        public SayHiValidator()
        {
            List<string> knownDogs = new() {"fido", "rex", "dogo", "dog", "steve"};

            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x=>x.Message)
                .Must(x => !knownDogs.Contains(x))
                .WithMessage(x => $"Cat {x.Message} is a known covert dog operative!");
        }
    }
}
