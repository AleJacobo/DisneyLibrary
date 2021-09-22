using AutoMapper;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using Disney.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class CharactersServices : ICharactersService
    {
        #region Objects and Constructor
        private readonly IMapper mapper;
        private readonly IBaseRepository<Character> baseRepository;
        private readonly CharactersRepository charactersRepository;

        public CharactersServices(IMapper mapper, IBaseRepository<Character> baseRepository, CharactersRepository charactersRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
            this.charactersRepository = charactersRepository;
        }
        #endregion

        public async Task<IEnumerable<CharacterDTO>> GetAllCharacters()
        {
            var response = await baseRepository.GetAll();
            var result = mapper.Map<IEnumerable<CharacterDTO>>(response);

            return result;
        }
        public CharacterDTO GetCharacterByName(string name)
        {
            var response = baseRepository.GetbyName(name);
            var result = mapper.Map<CharacterDTO>(response);

            return result;
        }
        public async Task<IEnumerable<CharacterDTO>> GetCharactersByAge(int age)
        {
            var response = await charactersRepository.GetbyAge(age);
            var result = mapper.Map<IEnumerable<CharacterDTO>>(response);

            return result;
        }
        public async Task<IEnumerable<CharacterDTO>> GetCharacterByMovieSerie(MovieSerieDTO movieSerieDTO)
        {
            var request = await charactersRepository.GetbyMovieSerie(movieSerieDTO);
            var result = mapper.Map<IEnumerable<CharacterDTO>>(request);

            return result;
        }
        public Result CreateCharacter(CharacterDTO characterDTO)
        {
            var entity = mapper.Map<Character>(characterDTO);
            bool confirmation = baseRepository.Exists(entity);

            if (confirmation == true)
                return new Result().Fail($"Ya existe un registro previo de dicho personaje");

            baseRepository.Create(entity);
            return new Result().Success($"Se ha agregado con exito al personaje {entity.Name} a la base de datos!");
        }
        public Result UpdateCharacter(CharacterDTO characterDTO)
        {
            var entity = mapper.Map<Character>(characterDTO);
            var confirmation = baseRepository.Exists(entity);

            if (confirmation == false)
                return new Result().NotFound();

            baseRepository.Update(entity);
            return new Result().Success($"Se ha actualizado la informacion del personaje!");
        }
        public Result DeleteCharacter(CharacterDTO characterDTO)
        {
            var entity = mapper.Map<Character>(characterDTO);
            var confirmation = baseRepository.Exists(entity);

            if (confirmation == false)
                return new Result().NotFound();

            entity.Status = false;
            baseRepository.Update(entity);

            return new Result().Success($"Se ha borrado al personaje de la base de datos");
        }
    }
}
