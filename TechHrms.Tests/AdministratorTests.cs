using FluentAssertions;
using System.Threading.Tasks;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Response;

namespace TechHrms.Tests
{
    public class CommandsTests : IClassFixture<AppTestFixture>
    {
        private readonly AppTestFixture _fixture;

        public CommandsTests(AppTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Employee_registered()
        {
            // Arrange
            CreateEmployeeCommand command = new()
            {
                Email = "testemployee@test.com",
                Password = "testabc",
                FirstName = "Sam",
                LastName = "Martin",
                Qualification ="Super",
                Skill = "Hero",
                WorkExperience = "Faker"
            };

            // Act
            EmployeeResponse result = await _fixture.Mediator.Send(command).ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
        }
    }
}