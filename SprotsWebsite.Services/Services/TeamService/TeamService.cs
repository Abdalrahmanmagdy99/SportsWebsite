using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Data.Repository;
using SprotsWebsite.Domain.Entities;
using SprotsWebsite.Services.Dtos;

namespace SprotsWebsite.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public TeamService(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<bool> AddTeam(AddTeamRequestDto addTeamRequestDto)
        {
            var imageId = await _imageService.AddImage(addTeamRequestDto.Logo);
            if (imageId == 0) return false;
            Team team = new Team
            {
                Description = addTeamRequestDto.Description,
                FoundationDate = addTeamRequestDto.FoundationDate,
                WebsiteURL = addTeamRequestDto.WebsiteURL,
                Name = addTeamRequestDto.Name,
                ImageId = imageId
            };
            await _unitOfWork.TeamRepository.InsertAsync(team);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> UpdateTeamInformation(UpdateTeamRequestDto updateTeamRequestDto)
        {
            Team team = await _unitOfWork.TeamRepository.GetAsIQueryable()
                .FirstOrDefaultAsync(x => x.Id == updateTeamRequestDto.TeamId);

            if (team == null) return false;

            if (!String.IsNullOrEmpty(updateTeamRequestDto.Name))
                team.Name = updateTeamRequestDto.Name;

            if (!String.IsNullOrEmpty(updateTeamRequestDto.Description))
                team.Description = updateTeamRequestDto.Description;

            if (!String.IsNullOrEmpty(updateTeamRequestDto.WebsiteURL))
                team.WebsiteURL = updateTeamRequestDto.WebsiteURL;

            if (updateTeamRequestDto.Logo is not null)
                await _imageService.UpdateImagePath(updateTeamRequestDto.Logo, team.ImageId);

            return true;
        }
        public async Task<bool> SoftDeleteTeamById(int teamId)
        {
            Team team = await _unitOfWork.TeamRepository.GetByIdAsync(teamId);
            _unitOfWork.TeamRepository.Delete(team);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> HardDeleteTeamById(int teamId)
        {
            Team team = await _unitOfWork.TeamRepository.GetByIdAsync(teamId);
            _unitOfWork.TeamRepository.HardDelete(team);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetTeamsResponseDto> GetTeamsList()
        {
            var teams = await _unitOfWork.TeamRepository.GetWithNoTracking()
                .Select(s => new TeamDetails
                {
                    Description = s.Description,
                    FoundationDate = s.FoundationDate,
                    ImageName = s.Image.PhotoName,
                    TeamId = s.Id,
                    Name = s.Name,
                    WebsiteURL = s.WebsiteURL
                }).ToListAsync();
            return new GetTeamsResponseDto(teams);
        }
        public async Task<TeamDetails> GetTeamDetailsById(int teamId)
        {
            var team = await _unitOfWork.TeamRepository.GetWithNoTracking()
                .Where(x=>x.Id == teamId)
                .Select(s => new TeamDetails
                {
                    Description = s.Description,
                    FoundationDate = s.FoundationDate,
                    ImageName = s.Image.PhotoName,
                    TeamId = s.Id,
                    Name = s.Name,
                    WebsiteURL = s.WebsiteURL
                }).FirstOrDefaultAsync();
            return team;
        }
        public async Task<GetPlayersResponseDto> GetTeamPlayersList(int teamId)
        {
            var Players = await _unitOfWork.PlayerRepository.GetWithNoTracking()
                .Where(x => x.TeamId == teamId)
                .Select(s => new PlayerDetails
                {
                    PlayerId = s.Id,
                    Name = s.Name,
                    Age = DateTime.Now.Year - s.DateOfBirth.Year
                }).ToListAsync();
            return new GetPlayersResponseDto(Players);
        }

        public async Task<List<TeamName>> GetTeamsDropDownInfo()
        {
            return await _unitOfWork.TeamRepository.GetWithNoTracking()
                .Select(s=>new TeamName 
                {
                    Name = s.Name,
                    TeamId = s.Id
                })
                .ToListAsync();
        }
        public async Task<GetTeamsResponseDto> GetLastAddedTeams(int numberOfTeams)
        {
            var teams = await _unitOfWork.TeamRepository.GetWithNoTracking()
                .Select(s => new TeamDetails
                {
                    Description = s.Description,
                    FoundationDate = s.FoundationDate,
                    ImageName = s.Image.PhotoName,
                    TeamId = s.Id,
                    Name = s.Name,
                    WebsiteURL = s.WebsiteURL,
                    CreatedAt = s.CreatedAt
                })
                .OrderByDescending(x => x.CreatedAt)
                .Take(numberOfTeams)
                .ToListAsync();
            return new GetTeamsResponseDto(teams);
        }
    }
}
