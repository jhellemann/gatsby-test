﻿using System.Collections.Generic;
using Avonova.GraphQL.Functions.StarWars.Data;
using Avonova.GraphQL.Functions.StarWars.Models;
using HotChocolate;

namespace Avonova.GraphQL.Functions.StarWars.Resolvers
{
    public class SharedResolvers
    {
        public IEnumerable<ICharacter> GetCharacter(
            [Parent]ICharacter character,
            [Service]CharacterRepository repository)
        {
            foreach (string friendId in character.Friends)
            {
                ICharacter friend = repository.GetCharacter(friendId);
                if (friend != null)
                {
                    yield return friend;
                }
            }
        }

        public double GetHeight(Unit? unit, [Parent]ICharacter character)
            => ConvertToUnit(character.Height, unit);

        public double GetLength(Unit? unit, [Parent]Starship starship)
            => ConvertToUnit(starship.Length, unit);

        private double ConvertToUnit(double length, Unit? unit)
        {
            if (unit == Unit.Foot)
            {
                return length * 3.28084d;
            }
            return length;
        }
    }
}
