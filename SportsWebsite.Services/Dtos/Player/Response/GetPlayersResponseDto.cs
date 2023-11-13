namespace SprotsWebsite.Services.Dtos
{
    public class GetPlayersResponseDto
    {
        public GetPlayersResponseDto()
        {
        }

        public GetPlayersResponseDto(List<PlayerDetails> playersDetails)
        {
            PlayersDetails = playersDetails;
        }

        public List<PlayerDetails> PlayersDetails { get; set; }
    }
}
