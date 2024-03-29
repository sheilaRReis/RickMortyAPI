﻿using AutoMapper;
using Rick_MortyAPI.Helper;
using Rick_MortyAPI.Models.Domain;
using Rick_MortyAPI.Models.DTO;
using Rick_MortyAPI.Models.Enums;

namespace Rick_MortyAPI.Mapper
{
    internal class MapperModule
    {
        internal static IRickAndMortyMapper Resolve()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CharacterLocationDto, CharacterLocation>()
                    .ConstructUsing(cls =>
                        new CharacterLocation(cls.Name, cls.Url.ToUri()));

                cfg.CreateMap<CharacterOriginDto, CharacterOrigin>()
                    .ConstructUsing(cls =>
                        new CharacterOrigin(cls.Name, cls.Url.ToUri()));

                cfg.CreateMap<CharacterDto, Character>()
                    .ConstructUsing(cls =>
                        new Character(cls.Id, cls.Name, cls.Status.ToEnum<Status>(),
                            cls.Species, cls.Type, cls.Gender.ToEnum<CharacterGender>(),
                            new CharacterLocation(cls.Location.Name, cls.Location.Url.ToUri()),
                            new CharacterOrigin(cls.Origin.Name, cls.Origin.Url.ToUri()),
                            cls.Url.ToUri(), cls.Episode.Select(x => x.ToUri()).ToList(),
                            cls.Url.ToUri(), cls.Created.ToDateTime()));


                cfg.CreateMap<LocationDto, Location>()
                    .ConstructUsing(cls =>
                        new Location(cls.Id, cls.Name, cls.Type, cls.Dimension, cls.Residents.Select(x => x.ToUri()).ToList(), cls.Url.ToUri(),
                            cls.Created.ToDateTime()));

                cfg.CreateMap<EpisodeDto, Episode>()
                    .ConstructUsing(cls =>
                        new Episode(cls.Id, cls.Name, cls.Air_date.ToDateTime(), cls.Episode,
                            cls.Characters.Select(x => x.ToUri()).ToList(), cls.Url.ToUri(), cls.Created.ToDateTime()));

                cfg.AllowNullCollections = true;
            });

            return new RickAndMortyMapper { Mapper = config.CreateMapper() };
        }
    }
}
