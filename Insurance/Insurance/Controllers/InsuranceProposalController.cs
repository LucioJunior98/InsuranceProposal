using Insurance.Domain.DTOs.Response;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Application;
using InsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceProposalController : Controller
    {
        private readonly IInsurancesService _insurancesService;

        public InsuranceProposalController(IInsurancesService insuranceService)
        {
            _insurancesService = insuranceService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateProposal(CreateProposalModel model)
        {
            try
            {
                if (model is null)
                    return BadRequest("Necessario informar os dados do seguro");

                Insurances insurance = new Insurances
                {
                    Name = model.Name,
                    TaxNumber = model.TaxNumber,
                    BirthDate = model.BirthDate,
                    Status = model.Status,
                    Type = model.Type,
                    InsuranceValue = model.InsuranceValue,
                    CreationDate = DateTime.Now
                };

                BaseResponseDTO response = await _insurancesService.CreateInsurances(insurance);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Success = false, Message = ex.Message });
            }
        }
    }
}
