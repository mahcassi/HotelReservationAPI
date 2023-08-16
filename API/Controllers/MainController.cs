using Domain.Interfaces;
using Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Controllers
{
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool OperationIsValid()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid())
            {
                return Ok(new { success = true, data = result });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(m => m.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifierErrorModel(modelState);

            return CustomResponse();
        }

        protected void NotifierErrorModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifierError(errorMsg);
            }
        }

        protected void NotifierError(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

    }
}
