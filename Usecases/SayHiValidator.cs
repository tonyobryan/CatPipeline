using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatPipeline.Usecases
{
    public class SayHiValidator : AbstractValidator<SayHiHandeler.Request>
    {
        public SayHiValidator()
        {
            List<string> knownDogs = new() {"fido", "rex", "dogo", "dog", "steve"};

            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x=>x.Message)
                .Must(x => !knownDogs.Contains(x))
                .WithMessage(x => $"Cat {x} is a known covert dog operative!");
        }
    }
}
