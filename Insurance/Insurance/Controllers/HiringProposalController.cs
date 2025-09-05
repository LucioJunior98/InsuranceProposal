using Insurance.Application.Services;
using Insurance.Domain.DTOs.Response;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Application;
using InsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HiringProposalController : Controller
    {
        private readonly IProposalHiringService _proposalHiringService;

        public HiringProposalController(IProposalHiringService proposalHiringService)
        {
            _proposalHiringService = proposalHiringService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateProposalHiring(ProposalHiringModal model)
        {
            try
            {
                if (model is null)
                    return BadRequest("Necessario informar os dados do seguro");

                ProposalHiring proposalHiring = new ProposalHiring
                {
                    InsurancesId = model.InsurancesId,
                    Name = model.Name,
                    TaxNumber = model.TaxNumber,
                    BirthDate = model.BirthDate,
                    Status = model.Status,
                    CreationDate = DateTime.Now
                };

                BaseResponseDTO response = await _proposalHiringService.CreateProposalHiring(proposalHiring);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Success = false, Message = ex.Message });
            }
        }

        [HttpPost("getallproposalhiring")]
        public async Task<ActionResult> GetAllProposalHiring()
        {
            try
            {
                BaseResponseDTO response = await _proposalHiringService.GetAllProposalHiring();

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Success = false, Message = ex.Message });
            }
        }

        [HttpPost("updateproposalhiring")]
        public async Task<ActionResult> UpdateProposalHiring(long id, ProposalHiringStatus status)
        {
            try
            {
                if (id == null || status == null)
                    return BadRequest("Necessario informar o id e o status do seguro");

                BaseResponseDTO response = await _proposalHiringService.UpdateProposalHiring(id, status);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Success = false, Message = ex.Message });
            }
        }
    }
}
