namespace SprotsWebsite.Services.Dtos
{
    public class GetTournamentsResponseDto
    {
        public GetTournamentsResponseDto()
        {
        }

        public GetTournamentsResponseDto(List<TournamentDetails> tournamentsDetails)
        {
            TournamentsDetails = tournamentsDetails;
        }

        public List<TournamentDetails> TournamentsDetails { get; set; }
    }
}
