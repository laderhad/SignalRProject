using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        [HttpGet]

        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);


        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Title= createTestimonialDto.Title,
                Comment= createTestimonialDto.Comment,
                ImageUrl= createTestimonialDto.ImageUrl,
                Name=createTestimonialDto.Name,
                Status=createTestimonialDto.Status
             



            });
            return Ok("Yorum bilgisi eklendi");



        }


        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");

        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {

            var value = _testimonialService.TGetByID(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
               TestimonialID=updateTestimonialDto.TestimonialID,
               Comment=updateTestimonialDto.Comment,
               Name=updateTestimonialDto.Name,
               ImageUrl=updateTestimonialDto.ImageUrl,
               Status=updateTestimonialDto.Status,
               Title=updateTestimonialDto.Title,
              





            });
            return Ok("Yorum Güncellendi");

        }
    }
}
