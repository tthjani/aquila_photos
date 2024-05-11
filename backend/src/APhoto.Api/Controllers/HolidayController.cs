using APhoto.Api.Requests;
using APhoto.Api.Services;
using APhoto.Data;
using Microsoft.AspNetCore.Mvc;

namespace APhoto.Api.Controllers
{
    [ApiController]
    public class HolidayController(
        ILogger<HolidayController> logger,
        IHolidayService holidayService)
        : CustomControllerBase<HolidayController>(logger)
    {
        private readonly IHolidayService _holidayService = holidayService;

        [HttpGet]
        [ProducesResponseType(typeof(IAsyncEnumerable<Holiday>), StatusCodes.Status200OK)]
        public IAsyncEnumerable<Holiday> GetAllHolidays(CancellationToken cancellationToken)
        {
            return _holidayService.GetHolidays(cancellationToken);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddHoliday(AddHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await _holidayService.CreateHoliday(request, cancellationToken);

            if (result.IsFailure)
            {
                return ValidationProblem(result.Reason);
            }

            return Created();
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateHoliday(UpdateHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await _holidayService.UpdateHoliday(request, cancellationToken);

            if (result.IsFailure)
            {
                return ValidationProblem(result.Reason);
            }

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveHoliday(RemoveHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await _holidayService.DeleteHoliday(request, cancellationToken);

            if (result.IsFailure)
            {
                return ValidationProblem(result.Reason);
            }

            return Ok();
        }
    }
}
