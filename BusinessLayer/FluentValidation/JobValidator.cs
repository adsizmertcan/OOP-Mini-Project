using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(X => X.JobName).NotEmpty().WithMessage("Meslek Adını Boş Geçemezsiniz");
            RuleFor(X => X.JobName).MinimumLength(3).WithMessage("Meslek Adı En Az 3 Karakter Olmalıdır");
           
        }
    }
}
