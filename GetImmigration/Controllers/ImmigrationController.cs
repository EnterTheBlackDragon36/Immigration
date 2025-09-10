using GetImmigration.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetImmigration.Controllers
{

    [ApiController]
    public class ImmigrationController : Controller
    {
        private readonly ImmigrationContext _context;


        public ImmigrationController(ImmigrationContext context)
        {
            _context = context;
        }

        #region ImmigrationKeys
        // GET: api/<ImmigrationController>
        //Get Immigration Key Table
        [HttpGet]
        [Route("api/immigration/GetImmigrationKeys")]
        public ActionResult GetImmigrationKeys()
        {
            var immigrationKeys = _context.ImmigrationKeys.ToList();
            if(immigrationKeys.Count > 0)
            {
                return Ok(immigrationKeys);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/immigration/GetImmigrationKeysById/{personKey:int}")]
        public ActionResult GetImmigrationKeysById(int personKey)
        {
            var immigrationKey = _context.ImmigrationKeys.Where(k => k.PersonKey == personKey).SingleOrDefault();
            if (immigrationKey!= null)
            {
                return Ok(immigrationKey);
            }
            else
            {
                return BadRequest();
            }
        }


        // POST api/<ImmigrationController>
        [HttpPost]
        [Route("api/immigration/CreateImmigrationKey/{immigrationKey}")]
        public ActionResult CreateImmigrationKey([FromBody] string immigrationKey)
        {
            ImmigrationKey key = new ImmigrationKey();
            if (immigrationKey != null) 
            {
                key = JsonConvert.DeserializeObject<ImmigrationKey>(immigrationKey);
                _context.ImmigrationKeys.Add(key);
                _context.SaveChanges();
                return Ok(key);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ImmigrationController>/5
        [HttpPut]
        [Route("api/immigration/UpdateImmigrationKey/{keyId}")]
        public ActionResult UpdateImmigrationKey(int keyId)
        {
            var immigrationKey = _context.ImmigrationKeys.Where(k => k.Id == keyId).FirstOrDefault();
            if (immigrationKey != null)
            {
                _context.SaveChanges();
                return Ok(immigrationKey);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ImmigrationController>/5
        [HttpDelete]
        [Route("api/immigration/DeleteImmigrationKey/{keyId}")]
        public ActionResult DeleteImmigrationKey(int keyId)
        {
            var immigrationKey = _context.ImmigrationKeys.Where(k => k.Id == keyId).FirstOrDefault();
            if (immigrationKey != null)
            {
                _context.ImmigrationKeys.Remove(immigrationKey);
                _context.SaveChanges();
                return Ok(immigrationKey);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

        #region Vessels

        [HttpGet]
        [Route("api/immigration/GetAllVessels")]
        public ActionResult GetAllVessels()
        {
            var vessels = _context.ShipVessels.ToList();
            if (vessels.Count > 0)
            {
                return Ok(vessels);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/immigration/GetVesselById/{vesselId:int}")]
        public ActionResult GetVesselById(int vesselId)
        {
            var vessel = _context.ShipVessels.Where(v => v.Id == vesselId).SingleOrDefault();
            if (vessel != null)
            {
                return Ok(vessel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/immigration/CreateVessel/{vessel}")]
        public ActionResult CreateVessel([FromBody] string vessel)
        {
            var shipVessel = new ShipVessel();
            if (vessel != null)
            {
                shipVessel = JsonConvert.DeserializeObject<ShipVessel>(vessel);
                _context.ShipVessels.Add(shipVessel);
                _context.SaveChanges();
                return Ok(shipVessel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/immigration/UpdateVessel/{vesselId}")]
        public ActionResult UpdateVessel(int vesselId)
        {
            var vessel = _context.ShipVessels.Where(v => v.Id == vesselId).FirstOrDefault();
            if (vessel != null)
            {
                _context.SaveChanges();
                return Ok(vessel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/immigration/DeleteVessel/{vesselId}")]
        public ActionResult DeleteVessel(int vesselId)
        {
            var vessel = _context.ShipVessels.Where(v => v.Id == vesselId).FirstOrDefault();
            if (vessel != null)
            {
                _context.ShipVessels.Remove(vessel);
                _context.SaveChanges();
                return Ok(vessel);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
