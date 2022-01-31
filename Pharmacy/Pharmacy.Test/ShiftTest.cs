using Pharmacy.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Pharmacy.BL.Interfaces;
using Pharmacy.BL.Services;
using Pharmacy.Controllers;
using Pharmacy.DL.Interfaces;
using Pharmacy.Extensions;
using Pharmacy.Models.Requests;
using Pharmacy.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using Xunit;

namespace Pharmacy.Test
{
    public class ShiftTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShiftRepository> _shiftRepository;
        private readonly IShiftService _shiftService;
        private readonly ShiftController _shiftController;

        private IList<Shift> Shifts = new List<Shift>()
        {
            {new Shift() {
                Id = 1,
                Name = "TestName",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 1,
                        Name = "Test Name",
                        Salary = 500
                    }
                }
            }
            },
            {new() {
                Id = 2,
                Name = "TestName2",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 2,
                        Name = "Test Name 2",
                        Salary = 650
                    }
                }
            }
            }
        };

        public ShiftTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _shiftRepository = new Mock<IShiftRepository>();

            var logger = new Mock<ILogger>();

            _shiftService = new ShiftService(_shiftRepository.Object, logger.Object);

            _shiftController = new ShiftController(_shiftService, _mapper);
        }

        [Fact]
        public void Shift_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IShiftService>();

            mockedService.Setup(x => x.GetAll()).Returns(Shifts);

            //inject
            var controller = new ShiftController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var shifts = okObjectResult.Value as IEnumerable<Shift>;
            Assert.NotNull(shifts);
            Assert.Equal(expectedCount, shifts.Count());
        }

        [Fact]
        public void Shift_GetById_NameCheck()
        {
            //setup
            var shiftId = 2;
            var expectedName = "TestName2";

            _shiftRepository.Setup(x => x.GetById(shiftId))
                .Returns(Shifts.FirstOrDefault(t => t.Id == shiftId));

            //Act
            var result = _shiftController.GetById(shiftId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ShiftResponse;
            var shift = _mapper.Map<Shift>(response);

            Assert.NotNull(shift);
            Assert.Equal(expectedName, shift.Name);
        }



       
        [Fact]
        public void Shift_GetById_NotFound()
        {
            //setup
            var shiftId = 3;

            _shiftRepository.Setup(x => x.GetById(shiftId))
                .Returns(Shifts.FirstOrDefault(t => t.Id == shiftId));

            //Act
            var result = _shiftController.GetById(shiftId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(shiftId, response);
        }

        [Fact]
        public void Shift_Update_ShiftName()
        {
            var shiftId = 1;
            var expectedName = "Updated Shift Name";

            var shift = Shifts.FirstOrDefault(x => x.Id == shiftId);
            shift.Name = expectedName;

            _shiftRepository.Setup(x => x.GetById(shiftId))
                .Returns(Shifts.FirstOrDefault(t => t.Id == shiftId));
            _shiftRepository.Setup(x => x.Update(shift))
                .Returns(shift);

            //Act
            var shiftUpdateRequests = _mapper.Map<ShiftUpdateRequests>(shift);
            var result = _shiftController.Update(shiftUpdateRequests);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Shift;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Shift_Delete_ExistingShift()
        {
            //Setup
            var shiftId = 1;

            var shift = Shifts.FirstOrDefault(x => x.Id == shiftId);

            _shiftRepository.Setup(x => x.Delete(shiftId)).Callback(() => Shifts.Remove(shift)).Returns(shift);

            //Act
            var result = _shiftController.Delete(shiftId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Shift;
            Assert.NotNull(val);
            Assert.Equal(1, Shifts.Count);
            Assert.Null(Shifts.FirstOrDefault(x => x.Id == shiftId));
        }

        [Fact]
        public void Shift_Delete_NotExisting_Shift()
        {
            //Setup
            var shiftId = 3;

            var shift = Shifts.FirstOrDefault(x => x.Id == shiftId);

            _shiftRepository.Setup(x => x.Delete(shiftId)).Callback(() => Shifts.Remove(shift)).Returns(shift);

            //Act
            var result = _shiftController.Delete(shiftId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(shiftId, response);
        }

        [Fact]
        public void Shift_CreateShift()
        {
            //setup
            var shift = new Shift()
            {
                Id = 3,
                Name = "Name 3"
            };

            _shiftRepository.Setup(x => x.GetAll()).Returns(Shifts);

            _shiftRepository.Setup(x => x.Create(It.IsAny<Shift>())).Callback(() =>
            {
                Shifts.Add(shift);
            }).Returns(shift);

            //Act
            var result = _shiftController.CreateShift(_mapper.Map<ShiftRequests>(shift));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Shifts.FirstOrDefault(x => x.Id == shift.Id));
            Assert.Equal(3, Shifts.Count);

        }

    }
}