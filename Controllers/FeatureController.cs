using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sqlapp.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public FeatureController(IFeatureManager featureMgr)
        {
            _featureManager = featureMgr;
        }

        [FeatureGate(FeatureFlag.Staging)]
        public IActionResult Index()
        {
            return View();
        }
    }

    public enum FeatureFlag
    {
        Staging
    }
}
