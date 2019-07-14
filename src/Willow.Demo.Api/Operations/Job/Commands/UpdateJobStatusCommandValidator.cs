namespace Willow.Demo.Api.Operations.Job.Commands
{
    using FluentValidation;

    public class UpdateJobStatusCommandValidator : AbstractValidator<UpdateJobStatusCommand>
    {
        public UpdateJobStatusCommandValidator()
        {
            RuleFor(c => c.Job)
                .NotNull();
            RuleFor(c => c.Job.Id)
                .NotEmpty();
            RuleFor(c => c.Job.Status)
                .NotEmpty();
        }
    }
}

