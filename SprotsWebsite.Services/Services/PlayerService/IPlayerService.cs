using SprotsWebsite.Services.Dtos;

namespace SprotsWebsite.Services
{
    public interface IPlayerService
    {
        Task<bool> AddPlayer(AddPlayerRequestDto addPlayerRequestDto);
        Task<bool> UpdatePlayerInformation(UpdatePlayerRequestDto updatePlayerRequestDto);
        Task<bool> SoftDeletePlayerById(int PlayerId);
        Task<bool> HardDeletePlayerById(int PlayerId);
        Task<PlayerDetails> GetPlayerDetailsById(int PlayerId);
        Task<GetPlayersResponseDto> GetPlayersList();
    }
}
