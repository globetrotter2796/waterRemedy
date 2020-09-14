﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterRemedy.Utility;
using System.Net.Http;
using Newtonsoft.Json;
using WaterRemedy.Models;
using System.Collections;

namespace WaterRemedy.Controllers
{
    public class HomeController : Controller
    {
        private waterremedyModelContainer db = new waterremedyModelContainer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeIndex()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult homePage() {

            return View();
        }

        // testing
        [HttpGet]
        public ActionResult GetAustralianWaterUsage()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(StaticFilePath.LocalFilePath);
                var fileInfo = directoryInfo.GetFiles().FirstOrDefault(x => x.Name.Equals("Aus_Water_Usage.csv"));
                if (fileInfo == null) return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = "No Data" }), "application/json");

                var process = new ImportCSV($@"{fileInfo.DirectoryName}\", fileInfo.Name);
                var data = process.ReadCsvFileToTable();

                return Content(JsonConvert.SerializeObject(new { isSuccess = true, Data = data }), "application/json");                
            }
            catch (Exception e)
            {
                return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = e.Message }), "application/json");
            }
        }

        [HttpGet]
        public ActionResult GetWaterChemical()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(StaticFilePath.LocalFilePath);
                var fileInfo = directoryInfo.GetFiles().FirstOrDefault(x => x.Name.Equals("Melbourne_water_chemical.csv"));
                if (fileInfo == null) return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = "No Data" }), "application/json");

                var process = new ImportCSV($@"{fileInfo.DirectoryName}\", fileInfo.Name);
                var data = process.ReadCsvFileToTable();

                return Content(JsonConvert.SerializeObject(new { isSuccess = true, Data = data }), "application/json");
            }
            catch (Exception e)
            {
                return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = e.Message }), "application/json");
            }
        }

        [HttpGet]
        public ActionResult GetVicWaterUsage()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(StaticFilePath.LocalFilePath);
                var fileInfo = directoryInfo.GetFiles().FirstOrDefault(x => x.Name.Equals("Victoria_Water_usage.csv"));
                if (fileInfo == null) return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = "No Data" }), "application/json");

                var process = new ImportCSV($@"{fileInfo.DirectoryName}\", fileInfo.Name);
                var data = process.ReadCsvFileToTable();

                return Content(JsonConvert.SerializeObject(new { isSuccess = true, Data = data }), "application/json");
            }
            catch (Exception e)
            {
                return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = e.Message }), "application/json");
            }
        }

        [HttpGet]
        public ActionResult GetVicWaterUsagePc()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(StaticFilePath.LocalFilePath);
                var fileInfo = directoryInfo.GetFiles().FirstOrDefault(x => x.Name.Equals("Aus_Water_Usage_pc.csv"));
                if (fileInfo == null) return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = "No Data" }), "application/json");

                var process = new ImportCSV($@"{fileInfo.DirectoryName}\", fileInfo.Name);
                var data = process.ReadCsvFileToTable();

                return Content(JsonConvert.SerializeObject(new { isSuccess = true, Data = data }), "application/json");
            }
            catch (Exception e)
            {
                return Content(JsonConvert.SerializeObject(new { isSuccess = false, Message = e.Message }), "application/json");
            }
        }

        public ActionResult chemicalView()
        {
            return View();
        }

        public ActionResult AusWaterUsage()
        {
            return View();
        }

        public ActionResult PercentageOfUsage()
        {
            return View();
        }
        public ActionResult MelWaterUsage()
        {
            return View();
        }

        public ActionResult Instruction()
        {
            return View();
        }

        public ActionResult HomeMap()
        {
            return View();
        }

        public ActionResult StatisticsForWaterUsageAndChemicals()
        {
            return View();
        }

        public ActionResult WaterQualityAndPollution()
        {
            return View();
        }

        public ActionResult GrowthOfUsage()
        {
            return View();
        }

        public ActionResult DIYDetergent()
        {
            return View();
        }
        public ActionResult RoofWater()
        {
            DateTime dt = DateTime.Now;
            var currentMonth = dt.ToString("MMMM");
            var rainfallList = db.RainfallSet.ToList();
            var currentMonthRainfall = 0.0;
            var currentMonthIndoor = 0.0;
            var yearRainfall = 0.0;
            List<Double> water = new List<Double>();


            foreach (var item in rainfallList) {
                if (item.month.Equals(currentMonth)) {
                    currentMonthRainfall = item.storage_month;
                    currentMonthIndoor = item.indoor_req;
                }
            }
            foreach (var a in rainfallList) {
                yearRainfall += a.storage_month;
                water.Add(a.storage_month);
            }
            ViewBag.currentMonthWater = currentMonthRainfall;
            ViewBag.currentMonthIndoorReq = currentMonthIndoor;
            ViewBag.list = yearRainfall;
            ViewBag.rlist = water;
            return View(db.RainfallSet.ToList());
        }

        public ActionResult AboutWater()
        {
            return View();
        }

        public ActionResult CatchmentInDanger()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LockPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitLockCode(string lockCode)
        {
            var baseLockCode = Encryption.GetLockCode();

            if (lockCode.Equals(baseLockCode)) return Content("/Home/HomeIndex", "text/plain");

            return Content("/Home/LockPage", "text/plain");                    
        }
    }
}