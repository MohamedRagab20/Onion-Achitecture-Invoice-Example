using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Invoice.Web.Models;
using Invoice.Service;
using Invoice.Data.Models;

namespace Invoice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService itemService;
        private readonly IUnitService unitService;
        private readonly IStoreService storeService;
        private readonly IInvoiceService invoiceService;

        public HomeController(ILogger<HomeController> logger,
            IItemService itemService,
            IUnitService unitService, IStoreService storeService, IInvoiceService invoiceService)
        {
            _logger = logger;
            this.itemService = itemService;
            this.unitService = unitService;
            this.storeService = storeService;
            this.invoiceService = invoiceService;
        }

        public IActionResult Index()
        {
            return View(invoiceService.GetInvoices().ToList());
        }

        public IActionResult AddInvoice()
        {
            List<Stores> stores = storeService.GetStores().ToList();

            return View(stores);
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            List<Items> items = itemService.GetItems().ToList();

            return Ok(items);
        }

        [HttpGet]
        public IActionResult GetUnits()
        {
            List<Units> units = unitService.GetUnits().ToList();

            return Ok(units);
        }

        [HttpPost]
        public IActionResult SaveInvoice([FromBody]InvoiceViewModel[] invoice)
        {
            try
            {
                for (int i = 0; i < invoice.Length; i++)
                {
                    Invoice.Data.Models.Invoice invoiceData = new Invoice.Data.Models.Invoice()
                    {
                        InvoiceDate = DateTime.Now,
                        InvoiceNo = Convert.ToInt32(invoice[i].InvoiceNo),
                        Net = Convert.ToInt32(invoice[i].Net),
                        StoreId = Convert.ToInt32(invoice[i].StoreId),
                        Taxes = Convert.ToDecimal(invoice[i].Taxes),
                        Total = Convert.ToDecimal(invoice[i].Total)
                    };

                    foreach (InvoiceDetailViewModel invDetail in invoice[i].invoiceDetails)
                    {
                        InvoiceDetails detail = new InvoiceDetails()
                        {
                            InvoiceId = invoiceData.Id,
                            ItemId = Convert.ToInt32(invDetail.ItemId),
                            Net = Convert.ToInt32(invDetail.Net),
                            Price = Convert.ToInt32(invDetail.Price),
                            Qty = Convert.ToInt32(invDetail.Qty),
                            Total = Convert.ToDecimal(invDetail.Total),
                            UnitId = Convert.ToInt32(invDetail.UnitId),
                            Discount = Convert.ToInt32(invDetail.Discount)
                        };

                        invoiceData.InvoiceDetails.Add(detail);
                    }

                    invoiceService.InsertInvoice(invoiceData);
                }

                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}
