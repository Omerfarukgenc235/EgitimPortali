using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;
using EgitimPortali.Repository.Yorum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimPortali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YorumlarController : ControllerBase
    {
        private readonly IYorumRepository _yorumRepository;
        private readonly IMapper _mapper;

        public YorumlarController(IYorumRepository yorumRepository, IMapper mapper)
        {
            _yorumRepository = yorumRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Yorumlar>))]

        public IActionResult KonuListele()
        {
            var deger = _yorumRepository.YorumiListele();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(deger);
        }
        [HttpPost]
        public IActionResult KonuEkle(YorumlarDto yorumlarCreate)
        {
            if (yorumlarCreate == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Yorumlar>(yorumlarCreate);

            if (!_yorumRepository.YorumEkle(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }
      
        [HttpDelete("{yorumId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult KonuSil(int yorumId)
        {
            if (!_yorumRepository.YorumKontrol(yorumId))
            {
                return NotFound();
            }

            var categoryToDelete = _yorumRepository.YorumGetir(yorumId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_yorumRepository.YorumSil(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }

        [HttpGet("{yorumId}")]
        [ProducesResponseType(200, Type = typeof(Konular))]
        [ProducesResponseType(400)]
        public IActionResult KonuGetir(int yorumId)
        {
            if (!_yorumRepository.YorumKontrol(yorumId))
                return NotFound();
            var kategori = _mapper.Map<YorumlarDto>(_yorumRepository.YorumGetir(yorumId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(kategori);
        }
    }
}
