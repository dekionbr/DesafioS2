using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmigoCrud.S2.Application.Interfaces;
using AmigoCrud.S2.Application.ViewModels;
using AmigoCrud.S2.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmigoCrud.S2.UI.WebSite.Controllers
{
    public class AmigoController : BaseController
    {
        private readonly IAmigoAppService _appService;
        private readonly IJogoAppService _jogoAppService;

        public AmigoController(IAmigoAppService appService,
                               IJogoAppService jogoAppService,
                               INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _appService = appService;
            _jogoAppService = jogoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("amigo-management/list-all")]
        public IActionResult Index()
        {
            return View(_appService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("amigo-management/details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = _appService.GetById(id.Value);

            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("amigo-management/new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("amigo-management/new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AmigoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            _appService.Register(viewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Jogo Incluido!";

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("amigo-management/edit/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _appService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("amigo-management/edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AmigoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            _appService.Update(viewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Jogo Salvo!";

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("amigo-management/remove/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _appService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [AllowAnonymous]
        [Route("amigo-management/remove/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _appService.Remove(id);

            if (!IsValidOperation()) return View(_appService.GetById(id));

            ViewBag.Sucesso = "Jogo Removido!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("amigo-management/list-jogos/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var jogos = _jogoAppService.GetByAmigoId(id);
            return Json(jogos);
        }
    }
}