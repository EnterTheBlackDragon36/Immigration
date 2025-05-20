using Immigration.Interfaces;
using Immigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Immigration.Controllers
{
    [ApiController]
    public class ImmigrationController : Controller
    {
        private readonly ImmigrantContext _context;
        private readonly IImmigration _iImmigration;
        public ImmigrationController(IImmigration immigration, ImmigrantContext context)
        {            
            _context = context;
            _iImmigration = immigration;
        }
        [HttpGet]
        [Route("api/Immigration/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Immigration/GetGlobalCityById/{id}")]
        public ActionResult GetGlobalCityById(int id)
        {
            var _globalCity = _context.GlobalCities.Where(c => c.Id == id).FirstOrDefault();
            if (_globalCity != null)
            {
                var globalCity = JsonConvert.SerializeObject(_globalCity);
                return Ok(globalCity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetGlobalCityByCountryCode/{countryCode}")]
        public ActionResult GetGlobalCityByCountryCode(string countryCode)
        {
            var _globalCity = _context.GlobalCities.Where(c => c.CountryCode == countryCode).FirstOrDefault();
            if (_globalCity != null)
            {
                var globalCity = JsonConvert.SerializeObject(_globalCity);
                return Ok(globalCity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetGlobalCityByCityAbbrCode/{cityCode}")]
        public ActionResult GetGlobalCityByCityAbbrCode(string cityCode)
        {
            var _globalCity = _context.GlobalCities.Where(c => c.CityAbbrCode == cityCode).FirstOrDefault();
            if (_globalCity != null)
            {
                var globalCity = JsonConvert.SerializeObject(_globalCity);
                return Ok(globalCity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetGlobalCountryById/{id}")]
        public ActionResult GetGlobalCountryById(int id)
        {
            var _globalCountry = _context.GlobalCountries.Where(c => c.Id == id).FirstOrDefault();
            if (_globalCountry != null)
            {
                var globalCountry = JsonConvert.SerializeObject(_globalCountry);
                return Ok(globalCountry);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetGlobalCountryByCountryCode/{countryCode}")]
        public ActionResult GetGlobalCountryByCountryCode(string countryCode)
        {
            var _globalCountry = _context.GlobalCountries.Where(c => c.CountryCode == countryCode).FirstOrDefault();
            if (_globalCountry != null)
            {
                var globalCountry = JsonConvert.SerializeObject(_globalCountry);
                return Ok(globalCountry);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetGlobalCountryById/{country}")]
        public ActionResult GetGlobalCountryById(string country)
        {
            var _globalCountry = _context.GlobalCountries.Where(c => c.Country.ToUpper() == country.ToUpper()).FirstOrDefault();
            if (_globalCountry != null)
            {
                var globalCountry = JsonConvert.SerializeObject(_globalCountry);
                return Ok(globalCountry);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetImmigrationKeyById/{id}")]
        public ActionResult GetImmigrationKeyById(int id)
        {
            var _immigrant = _context.ImmigrationKeys.Where(c => c.Id == id).FirstOrDefault();
            if (_immigrant != null)
            {
                var immigrant = JsonConvert.SerializeObject(_immigrant);
                return Ok(immigrant);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetShipVesselById/{id}")]
        public ActionResult GetShipVesselById(int id)
        {
            var _ship = _context.ShipVessels.Where(s => s.Id == id).FirstOrDefault();
            if (_ship != null)
            {
                var ship = JsonConvert.SerializeObject(_ship);
                return Ok(ship);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Immigration/GetTravelById/{id}")]
        public ActionResult GetTravelById(int id)
        {
            var _travel = _context.Travels.Where(t => t.Id == id).FirstOrDefault();
            if (_travel != null)
            {
                var travel = JsonConvert.SerializeObject(_travel);
                return Ok(travel);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        [Route("api/Immigration/EditImmigrationKeyById/{id}")]
        public ActionResult EditImmigrationKeyById([FromBody] JsonElement iKey, int id)
        {
            if (!String.IsNullOrEmpty(iKey.ToString()))
            {
                var _iKey = _context.ImmigrationKeys.Where(k => k.Id == id).FirstOrDefault();
                var iKeyDS = JsonConvert.DeserializeObject<ImmigrationKey>(iKey.ToString());
                if (_iKey != null)
                {
                    _iKey.OccupationKey = iKeyDS.OccupationKey;
                    _iKey.VesselKey = iKeyDS.VesselKey;
                    _iKey.OriginCountryKey = iKeyDS.OriginCountryKey;
                    _iKey.OriginCityKey = iKeyDS.OriginCityKey;
                    _iKey.SettlementStateKey = iKeyDS.SettlementStateKey;
                    _iKey.SettlementCityKey = iKeyDS.SettlementCityKey;
                    _context.Update(_iKey);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Immigration/EditImmigrationKeyByPersonId/{id}")]
        public ActionResult EditImmigrationKeyByPersonId([FromBody] JsonElement iKey, int personId)
        {
            if (!String.IsNullOrEmpty(iKey.ToString()))
            {
                var _iKey = _context.ImmigrationKeys.Where(k => k.PersonKey == personId).FirstOrDefault();
                var iKeyDS = JsonConvert.DeserializeObject<ImmigrationKey>(iKey.ToString());
                if (_iKey != null)
                {
                    _iKey.OccupationKey = iKeyDS.OccupationKey;
                    _iKey.VesselKey = iKeyDS.VesselKey;
                    _iKey.OriginCountryKey = iKeyDS.OriginCountryKey;
                    _iKey.OriginCityKey = iKeyDS.OriginCityKey;
                    _iKey.SettlementStateKey = iKeyDS.SettlementStateKey;
                    _iKey.SettlementCityKey = iKeyDS.SettlementCityKey;
                    _context.Update(_iKey);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Immigration/EditShipVesselById{id}")]
        public ActionResult EditShipVesselById()
        {
            return Ok();
        }

        [HttpPut]
        [Route("api/Immigration/EditTravelById/{id}")]
        public ActionResult EditTravelById([FromBody] JsonElement travel, int id)
        {
            if (!String.IsNullOrEmpty(travel.ToString()))
            {
                var _travel = _context.Travels.Where(t => t.Id == id).FirstOrDefault();
                var travelDS = JsonConvert.DeserializeObject<Travel>(travel.ToString());
                if (_travel != null)
                {
                    _travel.City = travelDS.City;
                    _travel.CountryCode = travelDS.CountryCode;
                    _travel.CityAbbrCode = travelDS.CityAbbrCode;
                    _travel.Country = travelDS.Country;
                    _travel.Departure = travelDS.Departure;
                    _travel.Arrival = travelDS.Arrival;
                    _travel.Profession  = travelDS.Profession;
                    _travel.Vessel = travelDS.Vessel;
                    _travel.AmountOfMoney = travelDS.AmountOfMoney;
                    _travel.Relatives = travelDS.Relatives;
                    _context.Update(_travel);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpPut]
        [Route("api/Immigration/EditTravelByPersonId/{id}")]
        public ActionResult EditTravelByPersonId([FromBody] JsonElement travel, int personId)
        {
            if (!String.IsNullOrEmpty(travel.ToString()))
            {
                var _travel = _context.Travels.Where(t => t.PersonId == personId).FirstOrDefault();
                var travelDS = JsonConvert.DeserializeObject<Travel>(travel.ToString());
                if (_travel != null)
                {
                    _travel.City = travelDS.City;
                    _travel.CountryCode = travelDS.CountryCode;
                    _travel.CityAbbrCode = travelDS.CityAbbrCode;
                    _travel.Country = travelDS.Country;
                    _travel.Departure = travelDS.Departure;
                    _travel.Arrival = travelDS.Arrival;
                    _travel.Profession = travelDS.Profession;
                    _travel.Vessel = travelDS.Vessel;
                    _travel.AmountOfMoney = travelDS.AmountOfMoney;
                    _travel.Relatives = travelDS.Relatives;
                    _context.Update(_travel);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpPut]
        [Route("api/Immigration/EditTravelByCountryId/{id}")]
        public ActionResult EditTravelByCountryId([FromBody] JsonElement travel, int countryId)
        {
            if (!String.IsNullOrEmpty(travel.ToString()))
            {
                var _travel = _context.Travels.Where(t => t.CountryId == countryId).FirstOrDefault();
                var travelDS = JsonConvert.DeserializeObject<Travel>(travel.ToString());
                if (_travel != null)
                {
                    _travel.City = travelDS.City;
                    _travel.CountryCode = travelDS.CountryCode;
                    _travel.CityAbbrCode = travelDS.CityAbbrCode;
                    _travel.Country = travelDS.Country;
                    _travel.Departure = travelDS.Departure;
                    _travel.Arrival = travelDS.Arrival;
                    _travel.Profession = travelDS.Profession;
                    _travel.Vessel = travelDS.Vessel;
                    _travel.AmountOfMoney = travelDS.AmountOfMoney;
                    _travel.Relatives = travelDS.Relatives;
                    _context.Update(_travel);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();

        }

        #region Create Immigrant Information

        [HttpPost]
        [Route("api/Immigration/CreateImmigrationKeyById/Create")]
        public ActionResult CreateImmigrationKeyById([FromBody] JsonElement iKey)
        {
            if (!String.IsNullOrEmpty(iKey.ToString()))
            {
                var _iKeyDS = JsonConvert.DeserializeObject<ImmigrationKey>(iKey.ToString());
                ImmigrationKey _iKey = (ImmigrationKey)_iKeyDS;
                _context.Add(_iKey);
                _context.SaveChanges();
            }
            else 
            { 
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Immigration/CreateShipVessel/Create")]
        public ActionResult CreateShipVessel([FromBody] JsonElement ship)
        {
            if (!String.IsNullOrEmpty(ship.ToString()))
            {
                var _shipDS = JsonConvert.DeserializeObject<ShipVessel>(ship.ToString());
                ShipVessel _ship = (ShipVessel)_shipDS;
                _context.Add(_ship);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Immigration/CreateTravel/Create")]
        public ActionResult CreateTravel([FromBody] JsonElement travel)
        {
            if (!String.IsNullOrEmpty(travel.ToString()))
            {
                var _travelDS = JsonConvert.DeserializeObject<Travel>(travel.ToString());
                Travel _travel = (Travel)_travelDS;
                _context.Add(_travel);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        #endregion
    }
}
