using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface ICharactersServices
    {
        Task<IEnumerable<CharacterDTO>> GetAllCharacters();
        CharacterDTO GetCharacterByName(string name);
        Task<IEnumerable<CharacterDTO>> GetCharactersByAge(int age);
        Task<IEnumerable<CharacterDTO>> GetCharacterByMovieSerie(MovieSerieDTO movieSerieDTO);
        Result CreateCharacter(CharacterDTO characterDTO);
        Result UpdateCharacter(CharacterDTO characterDTO);
        Result DeleteCharacter(CharacterDTO characterDTO);
    }
}
