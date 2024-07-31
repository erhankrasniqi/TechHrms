using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Commands.HRRaportCommands;
using TechHrms.Application.Response;

namespace TechHrms.Tests
{
    public class HRRaportTests : IClassFixture<AppTestFixture>
    {
        private readonly AppTestFixture _fixture;

        public HRRaportTests(AppTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task HRRaport_registered()
        {
            // Arrange
            CreateHRRaportCommand command = new()
            {
                Title = "testemployee@test.com",
                Description = "testabc",
                GeneratedBy = DateTime.Parse("2012-10-10"),
                GeneratedOn = DateTime.Parse("2012-10-10"),
                FilePath = "Super", 
            };

            // Act
            HRRaportResponse result = await _fixture.Mediator.Send(command).ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
        }
    }
}