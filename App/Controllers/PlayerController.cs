namespace App.Controllers
{
    public class PlayerController(ICasinoWagerService casinoWagerService, IRabbitMQPublisher<CasinoWagerDto> rabbitMQPublisher) : BaseApiController
    {
        private readonly ICasinoWagerService _casinoWagerService = casinoWagerService;
        private readonly IRabbitMQPublisher<CasinoWagerDto> _rabbitMQPublisher = rabbitMQPublisher;

        [HttpGet("{playerId}/casino")]
        public async Task<ActionResult<PagedResponse<CasinoListDto>>> GetCasinoWagersForPlayer(Guid playerId, [FromQuery] PaginationParams paginationParams)
        {
            var casino = await _casinoWagerService.GetCasinoWagersForPlayer(playerId, paginationParams);
            return Ok(casino);
        }

        [HttpGet("topSpenders")]
        public async Task<ActionResult<IEnumerable<TopSpendersDto>>> GetTopSpenders([FromQuery] int count)
        {
            var topSpenders = await _casinoWagerService.GetTopSpendersAsync(count);
            return Ok(topSpenders);
        }

        [HttpPost("casinowager")]
        public async Task<ActionResult> AddCasinoWager(CasinoWagerDto wagerDto)
        {
            await _rabbitMQPublisher.PublishMessageAsync(wagerDto, RabbitMQQueues.CasinoWagerQueue);
            return Ok();
        }
    }
}
