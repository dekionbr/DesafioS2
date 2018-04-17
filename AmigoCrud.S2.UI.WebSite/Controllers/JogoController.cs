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
    [Authorize]
    public class JogoController : BaseController
    {
        private readonly IJogoAppService _appService;
        private readonly IAmigoAppService _amigoAppService;

        public JogoController(IJogoAppService appService,
                              IAmigoAppService amigoAppService,
                              INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _appService = appService;
            _amigoAppService = amigoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("jogo-management/list-all")]
        public IActionResult Index()
        {
            return View(_appService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("jogo-management/details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _appService.GetById(id.Value);

            viewModel.Amigos = _amigoAppService.GetAll();

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("jogo-management/new")]
        public IActionResult Create()
        {
            var viewModel = new JogoViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("jogo-management/new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JogoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            _appService.Register(viewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Jogo Incluido!";

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("jogo-management/edit/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _appService.GetById(id.Value);

            viewModel.Amigos = _amigoAppService.GetAll();

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("jogo-management/edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(JogoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            _appService.Update(viewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Jogo Salvo!";

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("jogo-management/remove/{id:guid}")]
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
        [Route("jogo-management/remove/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _appService.Remove(id);

            if (!IsValidOperation()) return View(_appService.GetById(id));

            ViewBag.Sucesso = "Jogo Removido!";
            return RedirectToAction("Index");
        }
    }
}