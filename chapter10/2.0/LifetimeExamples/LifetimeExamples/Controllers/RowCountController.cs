using LifetimeExamples.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifetimeExamples.Controllers
{
    public class RowCountController : Controller
    {
        private readonly ScopedRepository _scopedRepo;
        private readonly SingletonRepository _singletonRepo;
        private readonly TransientRepository _transientRepo;

        private readonly ScopedDataContext _scopedDataContext;
        private readonly SingletonDataContext _singletonDataContext;
        private readonly TransientDataContext _transientDataContext;

        public RowCountController(
            ScopedRepository scopedRepo, 
            SingletonRepository singletonRepo,
            TransientRepository transientRepo,
            ScopedDataContext scopedDataContext,
            SingletonDataContext singletonDataContext,
            TransientDataContext transientDataContext
            )
        {
            _scopedRepo = scopedRepo;
            _singletonRepo = singletonRepo;
            _transientRepo = transientRepo;
            _scopedDataContext = scopedDataContext;
            _singletonDataContext = singletonDataContext;
            _transientDataContext = transientDataContext;
        }

        public IActionResult Transient()
        {
            var viewModel = new RowCountViewModel
            {
                DataContextCount = _transientDataContext.RowCount,
                RepositoryCount = _transientRepo.RowCount,
            };

            return View("Index", viewModel);
        }

        public IActionResult Scoped()
        {
            var viewModel = new RowCountViewModel
            {
                DataContextCount = _scopedDataContext.RowCount,
                RepositoryCount = _scopedRepo.RowCount,
            };

            return View("Index", viewModel);
        }

        public IActionResult Singleton()
        {
            var viewModel = new RowCountViewModel
            {
                DataContextCount = _singletonDataContext.RowCount,
                RepositoryCount = _singletonRepo.RowCount,
            };

            return View("Index", viewModel);
        }
    }
}
