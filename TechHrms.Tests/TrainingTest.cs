using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.TrainingCommand;
using TechHrms.Application.Response;

namespace TechHrms.Tests
{
    public class TrainingTest : IClassFixture<AppTestFixture>
    {
        private readonly AppTestFixture _fixture;

        public TrainingTest(AppTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Training_registered()
        {
            // Arrange
            CreateTrainingCommand command = new()
            {
                Title = "Trajnim profesional",
                Description = "sdgsfsdfsdf 1",
                StartDate = DateTime.Parse("2012-10-10"),
                EndDate = DateTime.Parse("2012-10-10"), 
            };

            // Act
            TrainingResponse result = await _fixture.Mediator.Send(command).ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
        }


    }
}