using LeilaoWeb.Business.Intefaces;
using LeilaoWeb.Business.Models;
using LeilaoWeb.Data.Context;
using LeilaoWeb.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWeb.Test
{
    [TestClass]
    public class LeilaoTest
    {
        private Mock<DbSet<Leilao>> _dbSet;
        private Mock<MeuDbContext> _context;
        private ILeilaoRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            var sampleData = new List<Leilao>()
            {
                new Leilao() {
                    Id = Guid.NewGuid(),
                    Nome = "Fusca 1967",
                    Condicao = Condicao.Usado,
                    ValorInicial = 23000,
                    NomeResponsavel = "Erison",
                    UserId = Guid.NewGuid(),
                    DataAbetura = DateTime.Now,
                    DataFinalizacao = DateTime.Now.AddDays(10),
                    Ativo = true
                },
                new Leilao() {
                    Id = Guid.NewGuid(),
                    Nome = "Guitarra Fender Stratocaster 1976",
                    Condicao = Condicao.Usado,
                    ValorInicial = 17500,
                    NomeResponsavel = "João",
                    UserId = Guid.NewGuid(),
                    DataAbetura = DateTime.Now,
                    DataFinalizacao = DateTime.Now.AddDays(10),
                    Ativo = false
                },
            }.AsQueryable();

            _dbSet = new Mock<DbSet<Leilao>>();
            _dbSet.As<IQueryable<Leilao>>().Setup(x => x.Provider).Returns(sampleData.Provider);
            _dbSet.As<IQueryable<Leilao>>().Setup(x => x.Expression).Returns(sampleData.Expression);
            _dbSet.As<IQueryable<Leilao>>().Setup(x => x.ElementType).Returns(sampleData.ElementType);
            _dbSet.As<IQueryable<Leilao>>().Setup(x => x.GetEnumerator()).Returns(sampleData.GetEnumerator());

            _context = new Mock<MeuDbContext>();
            _context.Setup(x => x.Leiloes).Returns(_dbSet.Object);

            _repository = new LeilaoRepository(_context.Object);
        }

        [TestMethod]
        public void CadastrarNovoItemLeilao()
        {
            var item = new Leilao()
            {
                Id = Guid.NewGuid(),
                Nome = "Fusca 1967",
                Condicao = Condicao.Usado,
                ValorInicial = 23000,
                NomeResponsavel = "Erison",
                UserId = Guid.NewGuid(),
                DataAbetura = DateTime.Now,
                DataFinalizacao = DateTime.Now.AddDays(10),
                Ativo = true
            };
            _repository.Adicionar(item);

            _dbSet.Verify(m => m.Add(It.IsAny<Leilao>()), Times.Once());
            _context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void ObterLeiloes()
        {
            var leiloes = _repository.ObterLeliloes();

            Assert.IsNotNull(leiloes);
        }
    }
}
