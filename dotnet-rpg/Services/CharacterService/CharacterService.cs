using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        //private static List<Character> characters = new List<Character>
        //{
        //   new Character { },
        //   new Character { Id = 1, Name = "Sam" }
        //};

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context; 
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            _context.Characters.Add(_mapper.Map<Character>(newCharacter));
            
            await _context.SaveChangesAsync();
            //characters.Add(_mapper.Map<Character>(newCharacter));
            //serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetALlCharacter()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            //serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList(); ;
            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList(); ;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            //serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(_context.Characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                //Character character = characters.FirstOrDefault(c => c.Id == updateCharacterDto.Id);
                Character character = await _context.Characters.FirstAsync(c => c.Id == updateCharacterDto.Id);
                character.Name = updateCharacterDto.Name;
                character.HitPoints = updateCharacterDto.HitPoints;
                character.Strength = updateCharacterDto.Strength;
                character.Defense = updateCharacterDto.Defense;
                character.Intelligence = updateCharacterDto.Intelligence;
                character.Class = updateCharacterDto.Class;
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                _context.Characters.Update(character);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Successs = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                //Character character = characters.First(c => c.Id == id);
                Character character = await _context.Characters.FirstAsync(c => c.Id == id);
                // remove from store 
                //characters.Remove(character);
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                //serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Successs = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse; 
        }
    }
}
