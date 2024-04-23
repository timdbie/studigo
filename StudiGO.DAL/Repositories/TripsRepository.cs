﻿using StudiGO.Core.DTOs;
using StudiGO.Core.Interfaces;
using StudiGO.Core.Mappers;

namespace StudiGO.DAL.Repositories;

public class TripsRepository : ApiBaseRepository, ITripsRepository
{
    public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        string endpoint = $"/reisinformatie-api/api/v3/trips?fromStation={fromStation}&toStation={toStation}&dateTime={dateTime}";
        return await GetApiResponseAsync(endpoint, TripsMapper.MapFromJson);
    }
}