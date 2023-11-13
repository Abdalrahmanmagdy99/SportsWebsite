using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Data.Repository;
using SprotsWebsite.Domain.Entities;
using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddPlayer(AddPlayerRequestDto addPlayerRequestDto)
        {
            Player Player = new Player
            {
                Name = addPlayerRequestDto.Name,
                TeamId = addPlayerRequestDto.TeamId,
                DateOfBirth = addPlayerRequestDto.DateOfBirth
            };
            await _unitOfWork.PlayerRepository.InsertAsync(Player);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> UpdatePlayerInformation(UpdatePlayerRequestDto updatePlayerRequestDto)
        {
            Player Player = await _unitOfWork.PlayerRepository.GetAsIQueryable()
                .FirstOrDefaultAsync(x => x.Id == updatePlayerRequestDto.PlayerId);

            if (Player == null) return false;

            if (!String.IsNullOrEmpty(updatePlayerRequestDto.Name))
                Player.Name = updatePlayerRequestDto.Name;

            if (IdValidations.IsIdValidForUpdate(updatePlayerRequestDto.TeamId))
                Player.TeamId = (int)updatePlayerRequestDto.TeamId;

            if (updatePlayerRequestDto.DateOfBirth is not null)
                Player.DateOfBirth = (DateTime)updatePlayerRequestDto.DateOfBirth;

            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> SoftDeletePlayerById(int PlayerId)
        {
            Player Player = await _unitOfWork.PlayerRepository.GetByIdAsync(PlayerId);
            _unitOfWork.PlayerRepository.Delete(Player);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> HardDeletePlayerById(int PlayerId)
        {
                Player Player = await _unitOfWork.PlayerRepository.GetByIdAsync(PlayerId);
                _unitOfWork.PlayerRepository.HardDelete(Player);
                return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<PlayerDetails> GetPlayerDetailsById(int id)
        {
            var player = await _unitOfWork.PlayerRepository.GetWithNoTracking()
                .Where(x=>x.Id==id)
                .Select(s => new PlayerDetails
                {
                    PlayerId = s.Id,
                    Name = s.Name,
                    Age = DateTime.Now.Year - s.DateOfBirth.Year,
                    TeamName = s.Team.Name,
                    TeamId = s.Team.Id
                }).FirstOrDefaultAsync();
            return player;
        }
        public async Task<GetPlayersResponseDto> GetPlayersList()
        {
            var Players = await _unitOfWork.PlayerRepository.GetWithNoTracking()
                .Select(s => new PlayerDetails
                {
                    PlayerId = s.Id,
                    Name = s.Name,
                    Age = DateTime.Now.Year - s.DateOfBirth.Year,
                    TeamName = s.Team.Name
                }).ToListAsync();
            return new GetPlayersResponseDto(Players);
        }

    }
}
