using Moq;
using AutoFixture;
using AutoMapper;
using JazaniTaller.Application.SOC.Dtos.Holders;
using JazaniTaller.Application.SOC.Services;
using JazaniTaller.Application.SOC.Services.Implementations;
using JazaniTaller.Domain.SOC.Models;
using JazaniTaller.Domain.SOC.Repositories;
using JazaniTaller.Application.SOC.Dtos.Holders.Profiles;


namespace Jazani.UnitTest.Application.Generals.Services
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<HolderService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HolderProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockHolderRepository = new Mock<IHolderRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<HolderService>>();
        }


        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {

            // Arrange
            Holder holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);


            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);


            HolderDto holderDto = await holderService.FindByIdAsync(holder.Id);

            // Assert

            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHoldersDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5)
                .ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(holders);

            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<HolderDto> holderDtos = await holderService.FindAllAsync();

            // Assert
            Assert.Equal(holders.Count, holderDtos.Count);
        }

        [Fact]
        public async void returnHolderDtoWhenCreateAsync()
        {

            // Arrage
            Holder holder = new()
            {
                //Id = 1,
                Name = "Name test",
                Lastname = "Last name test",
                MaidenName = "M",
                DocumentNumber = "",
                LandLine = "",
                Mobile = "",
                Corporatemail="",
                PersonalMail="",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);


            // Act
            HolderSaveDto holderSaveDto = new()
            {
                Name = holder.Name,
                Lastname = holder.Lastname,
                MaidenName = holder.MaidenName,
                DocumentNumber = holder.DocumentNumber,
                LandLine = holder.LandLine,
                Mobile = holder.Mobile,
                Corporatemail = holder.Corporatemail,
                PersonalMail = holder.PersonalMail
            };

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

            HolderDto holderDto = await holderService.CreateAsync(holderSaveDto);


            // Assert
            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHolderDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            Holder holder = new()
            {
                Id = id,
                Name = "Name test",
                Lastname = "Last name test",
                MaidenName = "M",
                DocumentNumber = "",
                LandLine = "",
                Mobile = "",
                Corporatemail = "",
                PersonalMail = "",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            // Act
            HolderSaveDto holderSaveDto = new()
            {
                Name = holder.Name,
                Lastname = holder.Lastname,
                MaidenName = holder.MaidenName,
                DocumentNumber = holder.DocumentNumber,
                LandLine = holder.LandLine,
                Mobile = holder.Mobile,
                Corporatemail = holder.Corporatemail,
                PersonalMail = holder.PersonalMail
            };

            IHolderService HolderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

            HolderDto holderDto = await HolderService.EditAsync(id, holderSaveDto);


            // Assert
            Assert.Equal(holder.Id, holderDto.Id);
        }

        [Fact]
        public async void returnHolderDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Holder holder = new()
            {
                Id = id,
                Name = "Name test",
                Lastname = "Last name test",
                MaidenName = "M",
                DocumentNumber = "",
                LandLine = "",
                Mobile = "",
                Corporatemail = "",
                PersonalMail = "",
                State = true,
                RegistrationDate = DateTime.Now
            };


            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            // Act

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

            HolderDto holderDto = await holderService.DisabledAsync(id);


            // Assert
            Assert.Equal(holder.State, holderDto.State);
        }

    }
}