using Microsoft.AspNetCore.Mvc;
using StrongPointTechAssignment.Domain;
using StrongPointTechAssignment.Domain.Interfaces;
using StrongPointTechAssignment.Domain.Models;
using StrongPointTechAssignment.Web.Models;
using System.Diagnostics;

namespace StrongPointTechAssignment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFormulaCalculatorService _formulaCalculatorService;
        private readonly IFormulaCalculatorHistoryService _formulaCalculatorHistoryService;

        public HomeController(IFormulaCalculatorService formulaCalculatorService, IFormulaCalculatorHistoryService formulaCalculatorHistoryService)
        {
            _formulaCalculatorService = formulaCalculatorService;
            _formulaCalculatorHistoryService = formulaCalculatorHistoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormulaRequestModel fc)
        {
            var resultModel = new KineticEnergyResultModel();
            if (ModelState.IsValid is false)
            {
                return View("Result", resultModel);
            }

            try
            {
                var kineticEnergyFormula = new KineticEnergyFormula(fc.Mass, fc.Velocity);
                resultModel.Result = _formulaCalculatorService.CalculateFormula(kineticEnergyFormula);
                resultModel.ImpactToEarthLevel = KineticEnergyImpactCalculatorHelper.CalculateLevel(resultModel.Result);

                var historicalRecord = new CalculatorHistoryItem(DateTime.UtcNow, kineticEnergyFormula, resultModel.Result);
                _formulaCalculatorHistoryService.AddHistoricalRecord(historicalRecord);
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View("Result", resultModel);
        }

        public IActionResult History()
        {
            var allHistoricalRecords = _formulaCalculatorHistoryService.RetrieveAllHistoryRecords();
            return View(allHistoricalRecords);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}