using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITodoRepository todoRepository, ILogger<HomeController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var items = _todoRepository.GetAll().Result;

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
        }

        public async Task<IActionResult> AddItem(TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _todoRepository.Add(item);


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _todoRepository.Remove(id);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var item = await _todoRepository.Find(id);

            if (item != null)
            {
                return View(item);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SaveEdit(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                await _todoRepository.Update(item);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", item);
        }
    }
}
