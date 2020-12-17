using Metronics.ASPNETCore.API.Business.Services;
using Metronics.ASPNETCore.API.Core.Domain.DTOs;
using Metronics.ASPNETCore.API.Core.Domain.Entities;
using Metronics.ASPNETCore.API.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Business.Providers
{
    public interface IProvider<TEntity>
    {

    }

    public class Provider<TEntity> : IProvider<TEntity>
    {

    }

    public static class ProviderExtensions
    {}
}
