using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Services.CharacterService;

public class CharacterService : ICharacterService
{

    private static List<Character> characters = new List<Character> {
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CharacterService(IMapper mapper, DataContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        
        var character = _mapper.Map<Character>(newCharacter);

        var addedCharacter = await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();
        
        var dbCharacters = await _context.Characters.ToListAsync();
        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        
        return serviceResponse;
    }
        // character.Id = characters.Max(c => c.Id) + 1;
        // characters.Add(character);
        // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var dbCharacters = await _context.Characters.ToListAsync();

        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
        // return characters;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var dbCharacters = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        // var character = characters.FirstOrDefault(c => c.Id == id);

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacters);
        return serviceResponse;
        
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();

        try
        {
            var character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
            // var dbCharacters = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);

            if (character is null)
                throw new Exception($"character with Id '${updateCharacter.Id}' is not found");

            character.Name = updateCharacter.Name;
            character.Name = updateCharacter.Name;
            character.HitPoints = updateCharacter.HitPoints;
            character.Strength = updateCharacter.Strength;
            character.Defense = updateCharacter.Defense;
            character.Intelligence = updateCharacter.Intelligence;
            character.Class = updateCharacter.Class;
            
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;            
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

        try
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            if (character is null)
                throw new Exception($"character with Id '${id}' is not found");

            characters.Remove(character);
            
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;            
        }

        return serviceResponse;
    }
}