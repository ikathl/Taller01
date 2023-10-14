using AutoFixture;
using AutoMapper;
using JazaniTaller.Application.Generals.Dtos.MesureUnits.Profiles;
using JazaniTaller.Application.Generals.Dtos.PeriodTypes.Profiles;
using JazaniTaller.Application.MC.Dtos.Investments;
using JazaniTaller.Application.MC.Dtos.Investments.Profiles;
using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts.Profiles;
using JazaniTaller.Application.MC.Dtos.InvestmentTypes.Profiles;
using JazaniTaller.Application.MC.Dtos.MiningConcessions.Profiles;
using JazaniTaller.Application.MC.Services;
using JazaniTaller.Application.MC.Services.Implementation;
using JazaniTaller.Application.SOC.Dtos.Holders.Profiles;
using JazaniTaller.Domain.Generals.Models;
using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using Moq;

namespace JazaniTaller.Test.Application.MCs.Services
{
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<MiningConcessionProfile>();
                c.AddProfile<InvestmentTypeProfile>();
                c.AddProfile<PeriodTypeProfile>();
                c.AddProfile<MiningConcessionProfile>();
                c.AddProfile<MeasureUnitProfile>();
                c.AddProfile<InvestmentConceptProfile>();
                c.AddProfile<HolderProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockInvestmentRepository = new Mock<IInvestmentRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>>();
        }


        [Fact]
        public async void ReturnInvestmentDtoFindByIdAsync()
        {
            //Arrange
            Investment investment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            //Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

            //Assert
            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void ReturnInvestmentDtoFindAllAsync()
        {
            //Arrange
            IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);

            //Act
            IInvestmentService mineralTypeService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentDto> investmentDtos = await mineralTypeService.FindAllAsync();

            //Assert
            Assert.NotNull(investmentDtos);
            Assert.Equal(investments.Count, investmentDtos.Count);
        }

        [Fact]
        public async void returnInvestmentDtoWhenCreateAsync()
        {

            // Arrage
            Investment Investment = new()
            {
                AmountInvested = 100,
                Year = DateTime.Now.Year,
                Description = "string test",
                MiningConcessionId = 15,
                InvestmentTypeId = 1,
                CurrencyTypeId = 0,
                PeriodTypeId = 1,
                MeasureUnitId = 1,
                MonthName = "Enero",
                MonthId = 1,
                AccreditationCode = "string",
                AccountantCode = "string",
                HolderId = 3,
                DeclaredTypeId = 0,
                DocumentId = 34146,
                InvestmentConceptId = 9,
                Module = null,
                Frecuency=null,
                IsDAC=null,
                MetricTons=null,
                DeclarationDate=DateTime.Now,
                RegistrationDate = DateTime.Now,
                State = true
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(Investment);


            // Act
            InvestmentSaveDto InvestmentSaveDto = new()
            {
                AmountInvested=Investment.AmountInvested,
                Description = Investment.Description,
                DocumentId=Investment.DocumentId
            };

            IInvestmentService InvestmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto InvestmentDto = await InvestmentService.CreateAsync(InvestmentSaveDto);


            // Assert
            Assert.Equal(Investment.AmountInvested, InvestmentDto.AmountInvested);
        }

        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {

            // Arrage
            int id = 114;

            Investment Investment = new()
            {
                Id=114,
                AmountInvested = 100,
                Year = DateTime.Now.Year,
                Description = "string test",
                MiningConcessionId = 15,
                InvestmentTypeId = 1,
                CurrencyTypeId = 0,
                PeriodTypeId = 1,
                MeasureUnitId = 1,
                MonthName = "Enero",
                MonthId = 1,
                AccreditationCode = "string",
                AccountantCode = "string",
                HolderId = 3,
                DeclaredTypeId = 0,
                DocumentId = 34146,
                InvestmentConceptId = 9,
                Module = null,
                Frecuency = null,
                IsDAC = null,
                MetricTons = null,
                DeclarationDate = DateTime.Now,
                RegistrationDate = DateTime.Now,
                State = true
            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(Investment);

            // Act
            InvestmentSaveDto InvestmentSaveDto = new()
            {
                AmountInvested = Investment.AmountInvested,
                Description = Investment.Description,
                DocumentId = Investment.DocumentId
            };

            IInvestmentService InvestmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto InvestmentDto = await InvestmentService.EditAsync(id, InvestmentSaveDto);


            // Assert
            Assert.Equal(Investment.Id, InvestmentDto.Id);
        }

        [Fact]
        public async void returnInvestmentDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Investment Investment = new()
            {
                Id = 114,
                AmountInvested = 100,
                Year = DateTime.Now.Year,
                Description = "string test",
                MiningConcessionId = 15,
                InvestmentTypeId = 1,
                CurrencyTypeId = 0,
                PeriodTypeId = 1,
                MeasureUnitId = 1,
                MonthName = "Enero",
                MonthId = 1,
                AccreditationCode = "string",
                AccountantCode = "string",
                HolderId = 3,
                DeclaredTypeId = 0,
                DocumentId = 34146,
                InvestmentConceptId = 9,
                Module = null,
                Frecuency = null,
                IsDAC = null,
                MetricTons = null,
                DeclarationDate = DateTime.Now,
                RegistrationDate = DateTime.Now,
                State = false
            };


            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(Investment);

            // Act

            IInvestmentService InvestmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto InvestmentDto = await InvestmentService.DisabledAsync(id);


            // Assert
            Assert.Equal(Investment.State, InvestmentDto.State);
        }
    }
}
