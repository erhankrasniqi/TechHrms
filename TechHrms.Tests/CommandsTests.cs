using FluentAssertions;
using System;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Response;

namespace TechHrms.Tests
{
    public class AdministratorTests : IClassFixture<AppTestFixture>
    {
        private readonly AppTestFixture _fixture;

        public AdministratorTests(AppTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Administrator_registered()
        {
            // Arrange
            CreateAdminstrationCommand command = new()
            {
                EmployeeId = "1",
                ApplicationDate = DateTime.Parse("2012-10-10"),
                InterviewDate = DateTime.Parse("2012-10-10"),
                RecruiterName = "Martin",
                HiringStatus ="Super",
                Department = "Hero",
                Notes = "Faker",
                Position = "Faker",
                Salary = "1 milion",
            };

            // Act
            AdministrationResponse result = await _fixture.Mediator.Send(command).ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
        }
    }
}