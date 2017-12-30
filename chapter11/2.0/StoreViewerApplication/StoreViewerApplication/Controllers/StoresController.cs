using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace StoreViewerApplication.Controllers
{
    public class StoresController
    {
        private readonly List<Store> _stores;

        public StoresController(IOptions<List<Store>> storeOptions)
        {
            _stores = storeOptions.Value;
        }

        public List<Store> Index()
        {
            return _stores;
        }
    }
}
