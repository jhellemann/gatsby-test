using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avonova.GraphQL.Functions.StarWars.Data;
using Avonova.GraphQL.Functions.StarWars.Models;
using Avonova.GraphQL.Functions.Weather.Repositories;
using HotChocolate.Resolvers;

namespace Avonova.GraphQL.Functions.GraphQL
{
    public class Query
    {
        private readonly CharacterRepository _repository;
        private readonly WeatherRepository _weatherRepository;

        public Query(CharacterRepository repository, WeatherRepository weatherRepository)
        {
            _repository = repository
                          ?? throw new ArgumentNullException(nameof(repository));
            _weatherRepository = weatherRepository;
        }

        public ICharacter GetHero(Episode episode)
        {
            return _repository.GetHero(episode);
        }

        public Human GetHuman(string id)
        {
            return _repository.GetHuman(id);
        }

        public Droid GetDroid(string id)
        {
            return _repository.GetDroid(id);
        }

        public IEnumerable<ICharacter> GetCharacter(string[] characterIds, IResolverContext context)
        {
            foreach (string characterId in characterIds)
            {
                ICharacter character = _repository.GetCharacter(characterId);
                if (character == null)
                {
                    context.ReportError(
                        "Could not resolve a charachter for the " +
                        $"character-id {characterId}.");
                }
                else
                {
                    yield return character;
                }
            }
        }

        public List<ICharacter> GetCharacters()
        {
            return _repository.GetCharacters();
        }

        public Task<Weather.Models.Weather> GetWeather(double latitude, double longitude)
        {
            return _weatherRepository.GetWeather(latitude, longitude);
        }
    }
}
