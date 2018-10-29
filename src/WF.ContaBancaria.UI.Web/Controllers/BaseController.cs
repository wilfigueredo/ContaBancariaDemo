using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WF.ContaBancaria.UI.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public void PopularModelComErros(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }
        }
    }
}