using AutoMapper;
using Revisao.Data.Providers.MongoDB.Collections;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.AutoMapper
{
    public class DomaninToCollection : Profile
    {
        public DomaninToCollection() { CreateMap<Carta, CartasCollection>(); }
    }
}
