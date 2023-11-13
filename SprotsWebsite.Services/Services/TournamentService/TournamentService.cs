using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Data.Repository;
using SprotsWebsite.Domain.Entities;
using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Helpers;

namespace SprotsWebsite.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IImageService _imageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHtmlHelper _htmlHelper;

        public TournamentService(IImageService imageService,IUnitOfWork unitOfWork, IHtmlHelper htmlHelper)
        {
            _imageService = imageService;
            _unitOfWork = unitOfWork;
            _htmlHelper = htmlHelper;
        }

        public async Task<bool> AddTournament(AddTournamentRequestDto addTournamentRequestDto)
        {
            var imageId = await _imageService.AddImage(addTournamentRequestDto.Logo);
            if (imageId == 0) return false;
            Tournament tournament = new Tournament
            {
                Description = addTournamentRequestDto.Description,
                Name = addTournamentRequestDto.Name,
                ImageId = imageId,
                VideoUrl = _htmlHelper.GetIframeSrc(addTournamentRequestDto.VideoUrl),
            };
            await _unitOfWork.TournamentRepository.InsertAsync(tournament);
            await _unitOfWork.SaveChangesAsync();
            var IsTeamsAddedToTournament = await AddTeamsToTournament(addTournamentRequestDto.SelectedTeamsIds, tournament.Id);
            if(!IsTeamsAddedToTournament)
            {
                await SoftDeleteTournamentById(tournament.Id);
                return false;
            }
            return true;
        }

        public async Task<bool> HardDeleteTournamentById(int tournamentId)
        {
            Tournament tournament = await _unitOfWork.TournamentRepository.GetByIdAsync(tournamentId);
            _unitOfWork.TournamentRepository.HardDelete(tournament);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteTournamentById(int tournamentId)
        {
            Tournament tournament = await _unitOfWork.TournamentRepository.GetByIdAsync(tournamentId);
            _unitOfWork.TournamentRepository.Delete(tournament);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTournamentInformation(UpdateTournamentRequestDto updateTournamentRequestDto)
        {
            Tournament tournament = await _unitOfWork.TournamentRepository.GetAsIQueryable()
                .FirstOrDefaultAsync(x => x.Id == updateTournamentRequestDto.TournamentId);

            if (tournament == null) return false;

            if (!String.IsNullOrEmpty(updateTournamentRequestDto.Name))
                tournament.Name = updateTournamentRequestDto.Name;

            if (!String.IsNullOrEmpty(updateTournamentRequestDto.VideoUrl))
                tournament.VideoUrl = _htmlHelper.GetIframeSrc(updateTournamentRequestDto.VideoUrl);

            if (!String.IsNullOrEmpty(updateTournamentRequestDto.Description))
                tournament.Description = updateTournamentRequestDto.Description;

            if (updateTournamentRequestDto.Logo is not null)
                await _imageService.UpdateImagePath(updateTournamentRequestDto.Logo, tournament.ImageId);

            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<GetTournamentsResponseDto> GetTournamentsList()
        {
            var tournament = await _unitOfWork.TournamentRepository.GetWithNoTracking()
                .Select(s => new TournamentDetails
                {
                    Description = s.Description,
                    ImagePath = s.Image.PhotoName,
                    Name = s.Name,
                    NumberOfTeams = s.Teams.Count,
                    TournamentId = s.Id,
                    VideoUrl = s.VideoUrl
                }).ToListAsync();
            return new GetTournamentsResponseDto(tournament);
        }
        public async Task<string> GetTournamentNameById(int tournamentId)
        {
            var tournamentName = await _unitOfWork.TournamentRepository.GetWithNoTracking()
                .Where(x=>x.Id == tournamentId)
                .Select(s => s.Name)
                .FirstOrDefaultAsync();
            return tournamentName;
        } 
        public async Task<bool> RemoveTeamFromTournament(int tournamentId,int teamId)
        {
            var team = await _unitOfWork.TournamentTeamsRepository.GetAsIQueryable()
                .FirstOrDefaultAsync(x=>x.TeamId == teamId && x.TournamentId == tournamentId);

            _unitOfWork.TournamentTeamsRepository.Delete(team);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<TournamentDetails> GetTournamentDetailsById(int tournamentId)
        {
            var tournamentName = await _unitOfWork.TournamentRepository.GetWithNoTracking()
                .Where(x=>x.Id == tournamentId)
                .Select(s => new TournamentDetails
                {
                    Description = s.Description,
                    ImagePath= s.Image.PhotoName,
                    Name= s.Name,
                    TournamentId= s.Id,
                    VideoUrl= s.VideoUrl
                })
                .FirstOrDefaultAsync();
            return tournamentName;
        } 
        public async Task<GetTeamsResponseDto> GetTournamentTeamsById(int tournamentId)
        {
            var tournamentTeams = await _unitOfWork.TournamentTeamsRepository.GetWithNoTracking()
                .Where(x=>x.TournamentId == tournamentId)
                .Select(s => new TeamDetails
                {
                    Name = s.Team.Name,
                    Description = s.Team.Description,
                    FoundationDate = s.Team.FoundationDate,
                    WebsiteURL = s.Team.WebsiteURL,
                    ImageName = s.Team.Image.PhotoName,
                    TeamId = s.Team.Id
                })
                .ToListAsync();
            return new GetTeamsResponseDto(tournamentTeams) ;
        }
        public async Task<bool> AddTeamsToTournament(List<int> tournamentTeamsIds, int tournamentId)
        {
            List<TournamentTeams> tournamentTeams = new List<TournamentTeams>();
            var teamsIds = await _unitOfWork.TeamRepository.GetWithNoTracking()
                .Where(x => tournamentTeamsIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync();
            foreach (var teamId in teamsIds)
                tournamentTeams.Add(new TournamentTeams(teamId, tournamentId));
            await _unitOfWork.TournamentTeamsRepository.InsertRangeAsync(tournamentTeams);
            return await _unitOfWork.SaveChangesAsync();
        } 
        public async Task<bool> AddTeamToTournament(int teamId, int tournamentId)
        {
            var team = new TournamentTeams(teamId,tournamentId);
            await _unitOfWork.TournamentTeamsRepository.InsertAsync(team);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
