using FluentAssertions;
using System.Threading.Tasks;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Queries.EmployeeQueries;
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

        [Fact]
        public async Task Employee_deleted()
        {
            // Arrange: First, create an employee to delete
            CreateEmployeeCommand createCommand = new()
            {
                Email = "testemployee@test.com",
                Password = "testabc",
                FirstName = "Sam",
                LastName = "Martin",
                Qualification = "Super",
                Skill = "Hero",
                WorkExperience = "Faker"
            };

            // Act: Send the command to create the employee
            EmployeeResponse createResult = await _fixture.Mediator.Send(createCommand).ConfigureAwait(false);

            // Assert: Ensure the employee was created
            createResult.Id.Should().BeGreaterThan(0);

            // Arrange: Set up the delete command with the created employee's ID
            DeleteEmployeePersonalInfoCommand deleteCommand = new()
            {
                Id = createResult.Id
            };

            // Act: Send the command to delete the employee
            EmployeeResponse deleteResult = await _fixture.Mediator.Send(deleteCommand).ConfigureAwait(false);

            // Assert: Check the delete result. Adapt this to your actual response structure.
            deleteResult.Should().NotBeNull();

            // Assuming DeleteEmployeeResponse has an Id property that should match the deleted employee's ID
            deleteResult.Id.Should().Be(createResult.Id);

            // Alternatively, you might verify the employee no longer exists
            EmployeeByIdQuery query = new() { Id = createResult.Id };
            EmployeeDetailResponse employeeDetail = await _fixture.Mediator.Send(query).ConfigureAwait(false);
            employeeDetail.Should().BeNull(); // Assuming the detail query returns null if the employee doesn't exist
        }


        [Fact]
        public async Task Employee_updated()
        {
            // Arrange: First, create an employee to update
            CreateEmployeeCommand createCommand = new()
            {
                Email = "testemployee@test.com",
                Password = "testabc",
                FirstName = "Sam",
                LastName = "Martin",
                Qualification = "Super",
                Skill = "Hero",
                WorkExperience = "Faker"
            };

            // Act: Send the command to create the employee
            EmployeeResponse createResult = await _fixture.Mediator.Send(createCommand).ConfigureAwait(false);

            // Assert: Ensure the employee was created
            createResult.Id.Should().BeGreaterThan(0);

            // Arrange: Set up the update command with the created employee's ID
            ChangeEmployeePersonalInfoCommand updateCommand = new()
            {
                Id = createResult.Id,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
            };

            // Act: Send the command to update the employee
            await _fixture.Mediator.Send(updateCommand).ConfigureAwait(false);

            // Re-fetch the updated employee details
            EmployeeByIdQuery query = new() { Id = createResult.Id };
            EmployeeDetailResponse updatedEmployee = await _fixture.Mediator.Send(query).ConfigureAwait(false);

            // Assert: Verify the updated employee details
            updatedEmployee.Should().NotBeNull();
            updatedEmployee.Id.Should().Be(createResult.Id);
            updatedEmployee.FirstName.Should().Be(updateCommand.FirstName);
            updatedEmployee.LastName.Should().Be(updateCommand.LastName);
        }

        [Fact]
        public async Task Employee_list_retrieved()
        {
            // Arrange: Create a few employees to ensure there is a list to retrieve
            CreateEmployeeCommand createCommand1 = new()
            {
                Email = "employee1@test.com",
                Password = "testabc",
                FirstName = "John",
                LastName = "Doe",
                Qualification = "Degree",
                Skill = "Skill1",
                WorkExperience = "Experience1"
            };

            CreateEmployeeCommand createCommand2 = new()
            {
                Email = "employee2@test.com",
                Password = "testabc",
                FirstName = "Jane",
                LastName = "Smith",
                Qualification = "Masters",
                Skill = "Skill2",
                WorkExperience = "Experience2"
            };

            // Act: Send the commands to create the employees
            EmployeeResponse createResult1 = await _fixture.Mediator.Send(createCommand1).ConfigureAwait(false);
            EmployeeResponse createResult2 = await _fixture.Mediator.Send(createCommand2).ConfigureAwait(false);

            // Assert: Ensure the employees were created
            createResult1.Id.Should().BeGreaterThan(0);
            createResult2.Id.Should().BeGreaterThan(0);

            // Act: Retrieve the list of employees
            EmployeeListQuery query = new();
            EmployeeListResponse listResult = await _fixture.Mediator.Send(query).ConfigureAwait(false);

            // Assert: Verify the list contains the created employees
            listResult.Should().NotBeNull();
            listResult.Employees.Should().NotBeEmpty();
            listResult.Employees.Should().Contain(e => e.Id == createResult1.Id && e.FirstName == "John" && e.LastName == "Doe");
            listResult.Employees.Should().Contain(e => e.Id == createResult2.Id && e.FirstName == "Jane" && e.LastName == "Smith");
        }

    }
}