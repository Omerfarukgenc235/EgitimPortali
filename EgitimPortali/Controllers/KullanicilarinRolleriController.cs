using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;
using EgitimPortali.Repository.KullaniciRol;
using EgitimPortali.Request.KullanicilarinRolleri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimPortali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanicilarinRolleriController : ControllerBase
    {
        private readonly IKullaniciRolRepository _kullanicirolRepository;
        private readonly IMapper _mapper;

        public KullanicilarinRolleriController(IKullaniciRolRepository kullanicirolRepository, IMapper mapper)
        {
            _kullanicirolRepository = kullanicirolRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KullanicilarinRolleri>))]

        public IActionResult KullaniciListele()
        {
            var deger = _kullanicirolRepository.KullanicilarinRolleriListele();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(deger);
        }
        [HttpPost]
        public IActionResult KonuEkle(KullaniciRolDto kullanicirolCreate)
        {
            if (kullanicirolCreate == null)
                return BadRequest(ModelState);

          


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<KullanicilarinRolleri>(kullanicirolCreate);

            if (!_kullanicirolRepository.KullanicilarinRolEkle(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }
        [HttpPut("{kullanicirolId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult KonuGuncelle(int kullanicirolId, [FromBody] KullanicilarinRolleriUpdateRequest updatedKullanicirol)
        {
            if (_kullanicirolRepository.KullanicilarinRolGuncelle(kullanicirolId, updatedKullanicirol))
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{kullanicirolId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult KonuSil(int kullanicirolId)
        {
            if (!_kullanicirolRepository.KullanicilarinRolKontrol(kullanicirolId))
            {
                return NotFound();
            }

            var categoryToDelete = _kullanicirolRepository.KullanicilarinRolleriGetir(kullanicirolId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_kullanicirolRepository.KullanicilarinRolSil(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }

        [HttpGet("{kullanicirolId}")]
        [ProducesResponseType(200, Type = typeof(Konular))]
        [ProducesResponseType(400)]
        public IActionResult KonuGetir(int kullanicirolId)
        {
            if (!_kullanicirolRepository.KullanicilarinRolKontrol(kullanicirolId))
                return NotFound();
            var kategori = _mapper.Map<KullaniciRolDto>(_kullanicirolRepository.KullanicilarinRolleriGetir(kullanicirolId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(kategori);
        }
    }
}
