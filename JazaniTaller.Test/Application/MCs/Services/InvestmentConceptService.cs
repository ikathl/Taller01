using Moq;
using AutoFixture;
using AutoMapper;
using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts;
using JazaniTaller.Application.MC.Services;
using JazaniTaller.Application.MC.Services.Implementations;
using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts.Profiles;


namespace Jazani.UnitTest.Application.Generals.Services
{
    public class InvestmentConceptServiceTest
    {
        Mock<IInvestmentConceptRepository> _mockInvestmentConceptRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentConceptService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public InvestmentConceptServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentConceptProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockInvestmentConceptRepository = new Mock<IInvestmentConceptRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentConceptService>>();
        }


        [Fact]
        public async void returnInvestmentConceptDtoWhenFindByIdAsync()
        {

            // Arrange
            InvestmentConcept investmentConcept = _fixture.Create<InvestmentConcept>();

            _mockInvestmentConceptRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmentConcept);


            // Act
            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);


            InvestmentConceptDto investmentConceptDto = await investmentConceptService.FindByIdAsync(investmentConcept.Id);

            // Assert

            Assert.Equal(investmentConcept.Name, investmentConceptDto.Name);
        }

        [Fact]
        public async void returnInvestmentConceptsDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<InvestmentConcept> investmentConcepts = _fixture.CreateMany<InvestmentConcept>(5)
                .ToList();

            _mockInvestmentConceptRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investmentConcepts);

            // Act
            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentConceptDto> investmentConceptDtos = await investmentConceptService.FindAllAsync();

            // Assert
            Assert.Equal(investmentConcepts.Count, investmentConceptDtos.Count);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenCreateAsync()
        {

            // Arrage
            InvestmentConcept investmentConcept = new()
            {
                //Id = 1,
                Name = "Name test",
                Description = "Last name test",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentConceptRepository
                .Setup(r => r.SaveAsync(It.IsAny<InvestmentConcept>()))
                .ReturnsAsync(investmentConcept);


            // Act
            InvestmentConceptSaveDto investmentConceptSaveDto = new()
            {
                Name = investmentConcept.Name,
                Description = investmentConcept.Description               
            };

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.CreateAsync(investmentConceptSaveDto);


            // Assert
            Assert.Equal(investmentConcept.Name, investmentConceptDto.Name);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            InvestmentConcept investmentConcept = new()
            {
                Id = id,
                Name = "Name test",
                Description = "Last name test",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentConceptRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmentConcept);

            _mockInvestmentConceptRepository
                .Setup(r => r.SaveAsync(It.IsAny<InvestmentConcept>()))
                .ReturnsAsync(investmentConcept);

            // Act
            InvestmentConceptSaveDto investmentConceptSaveDto = new()
            {
                Name = investmentConcept.Name,
                Description = investmentConcept.Description
            };

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.EditAsync(id, investmentConceptSaveDto);


            // Assert
            Assert.Equal(investmentConcept.Id, investmentConceptDto.Id);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            InvestmentConcept investmentConcept = new()
            {
                Id = id,
                Name = "Name test",
                Description = "Last name test",
                State = true,
                RegistrationDate = DateTime.Now
            };


            _mockInvestmentConceptRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmentConcept);

            _mockInvestmentConceptRepository
                .Setup(r => r.SaveAsync(It.IsAny<InvestmentConcept>()))
                .ReturnsAsync(investmentConcept);

            // Act

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.DisableAsync(id);


            // Assert
            Assert.Equal(investmentConcept.State, investmentConceptDto.State);
        }

    }
}