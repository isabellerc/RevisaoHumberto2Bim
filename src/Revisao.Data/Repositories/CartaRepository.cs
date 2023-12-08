using AutoMapper;
using Newtonsoft.Json;
using Revisao.Data.Providers.MongoDB.Collections;
using Revisao.Data.Providers.MongoDB.Interfaces;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Repositories
{
    public class CartaRepository : ICartaRepository
    {
        private readonly IMongoRepository<CartasCollection> _CartasRepository;

        private readonly IMapper _Mapper;
        public CartaRepository(IMongoRepository<CartasCollection> CartaRepository, IMapper mapper)
        {
            _CartasRepository = CartaRepository;
            _Mapper = mapper;

        }

        public async Task Adicionar(Carta documentosCarta)
        {
            await _CartasRepository.InsertOneAsync(_Mapper.Map<CartasCollection>(documentosCarta));

        }


        public IEnumerable<Carta> ObterTodos()
        {
            var CartaList = _CartasRepository.FilterBy(filter => true);
            return _Mapper.Map<IEnumerable<Carta>>(CartaList);
        }

        //private List<DocumentosCarta> LerCartaDoArquivo()
        //{
        //    if (!System.IO.File.Exists(_CartaCaminhoArquivo))
        //        return new List<DocumentosCarta>();
        //    string json = System.IO.File.ReadAllText(_CartaCaminhoArquivo);
        //    return JsonConvert.DeserializeObject<List<DocumentosCarta>>(json);
        //}

        //private void EscreverCartaNoArquivo(List<DocumentosCarta> documentosCarta)
        //{
        //    string json = JsonConvert.SerializeObject(documentosCarta);
        //    System.IO.File.WriteAllText(_CartaCaminhoArquivo, json);
        //}
    }
}
