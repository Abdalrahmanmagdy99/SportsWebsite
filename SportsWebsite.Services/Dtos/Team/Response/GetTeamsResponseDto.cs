namespace SprotsWebsite.Services.Dtos
{
    public class GetTeamsResponseDto
    {
        public GetTeamsResponseDto()
        {
        }

        public GetTeamsResponseDto(List<TeamDetails> teamsDetails)
        {
            TeamsDetails = teamsDetails;
        }

        public List<TeamDetails> TeamsDetails { get; set; }
    }
}
