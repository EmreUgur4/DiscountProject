using AutoMapper;
using DiscountProject.Business.Interfaces;
using DiscountProject.DTO.Dtos;
using DiscountProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[ApiKey]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoicesController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDiscount([FromQuery] string invoiceNo)
        {
            var response = await _invoiceService.GetDiscountAsync(invoiceNo);

            if (response.IsSuccessfull)
            {
                return Ok(_mapper.Map<InvoiceListDto>(response.Data));
            }

            return BadRequest(response.Error);
        }
    }
}
