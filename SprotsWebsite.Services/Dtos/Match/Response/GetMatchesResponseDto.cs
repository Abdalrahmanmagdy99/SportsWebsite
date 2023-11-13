namespace SprotsWebsite.Services.Dtos
{
    public class GetMatchesResponseDto
    {
        public GetMatchesResponseDto()
        {
        }

        public GetMatchesResponseDto(List<MatchDetails> matchsDetails)
        {
            MatchsDetails = matchsDetails;
        }

        public List<MatchDetails> MatchsDetails { get; set; }
    }
}
