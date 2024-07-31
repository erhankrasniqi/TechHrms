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
    public class ProjectManagmentTests :IClassFixture<AppTestFixture>
    {
        private readonly AppTestFixture _fixture;

    public ProjectManagmentTests(AppTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task PM_registered()
    {
        // Arrange
        CreatePMCommand command  = new()
        {
            EmployeeId = "2",
            ProjectName = "sdgsfsdfsdf 1",
            Description = "sdgsfsdfsdf 1",
            StartDate = DateTime.Parse("2012-10-10"),
            EndDate = DateTime.Parse("2012-10-10"),
            Status = "2dsdsd",
            ClientName = "sddsd" 

    };

        // Act
        PMResponse result = await _fixture.Mediator.Send(command).ConfigureAwait(false);

        // Assert
        result.Id.Should().BeGreaterThan(0);
    }
}
}