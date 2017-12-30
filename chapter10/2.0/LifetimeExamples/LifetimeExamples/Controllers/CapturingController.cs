using LifetimeExamples.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifetimeExamples.Controllers
{
    public class CapturingController : Controller
    {
        private readonly CapturingRepository _capturingRepo;
        private readonly ScopedDataContext _scopedDataContext;

        public CapturingController(
            CapturingRepository capturingRepo,
            ScopedDataContext scopedDataContext
            )
        {
            _capturingRepo = capturingRepo;
            _scopedDataContext = scopedDataContext;
        }
        
        public IActionResult Captured()
        {
            var viewModel = new RowCountViewModel
            {
                DataContextCount = _scopedDataContext.RowCount,
                RepositoryCount = _capturingRepo.RowCount,
            };

            return View("Views/RowCount/Index.cshtml", viewModel);
        }
    }
}
