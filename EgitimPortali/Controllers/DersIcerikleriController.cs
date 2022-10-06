using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;
using EgitimPortali.Repository.DersIcerik;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimPortali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersIcerikleriController : ControllerBase
    {
        private readonly IDersIcerikRepository _dersicerikleriRepository;
        private readonly IMapper _mapper;

        public DersIcerikleriController(IDersIcerikRepository dersicerikleriRepository, IMapper mapper)
        {
            _dersicerikleriRepository = dersicerikleriRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DersIcerikleri>))]
        public IActionResult DersListele()
        {
            var deger = _dersicerikleriRepository.DersIcerikleriniListele();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(deger);
        }
        [HttpPost]
        public IActionResult DersEkle(DersIcerikleriDto dersicerikleriCreate)
        {
            if (dersicerikleriCreate == null)
                return BadRequest(ModelState);

            var category = _dersicerikleriRepository.DersIcerikleriniListele()
                .Where(x => x.Name.Trim().ToUpper() == dersicerikleriCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<DersIcerikleri>(dersicerikleriCreate);

            if (!_dersicerikleriRepository.DersIcerikleriEkle(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }
        [HttpPut("{derslericerikleriId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DersGuncelle(int derslericerikleriId, [FromBody] DersIcerikleriDto updatedDersicerikleri)
        {
            if (updatedDersicerikleri == null)
                return BadRequest(ModelState);

            if (!_dersicerikleriRepository.DersIcerikleriKontrol(derslericerikleriId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryMap = _mapper.Map<DersIcerikleri>(updatedDersicerikleri);

            if (!_dersicerikleriRepository.DersIcerikleriGuncelle(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{derslericerikleriId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DersSil(int derslericerikleriId)
        {
            if (!_dersicerikleriRepository.DersIcerikleriKontrol(derslericerikleriId))
            {
                return NotFound();
            }

            var categoryToDelete = _dersicerikleriRepository.DersIcerikleriGetir(derslericerikleriId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_dersicerikleriRepository.DersIcerikleriSil(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
        [HttpGet("{derslericerikleriId}")]
        [ProducesResponseType(200, Type = typeof(DersIcerikleri))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int derslericerikleriId)
        {
            if (!_dersicerikleriRepository.DersIcerikleriKontrol(derslericerikleriId))
                return NotFound();
            var kategori = _mapper.Map<DersIcerikleriDto>(_dersicerikleriRepository.DersIcerikleriGetir(derslericerikleriId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(kategori);
        }
    }
}
