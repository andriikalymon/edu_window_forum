using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Forum.Data.Entities;
using Forum.Data.Context;
using Forum.Data.Infrastructure;
using Forum.Test.Base;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Forum.Test.Repository
{
    public class RepositoryTest : TestBase
    {
        private readonly IRepository<User> repository;
        private readonly ForumContext dbContext;

        public RepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ForumContext>()
                .UseInMemoryDatabase(databaseName: "ForumTest")
                .Options;
            dbContext = new ForumContext(options);
            repository = new Repository<User>(dbContext);
        }

        [Theory]
        [AutoEntityData]
        public async Task GetByIdAsync_EntityExists_ReturnsEntity(IEnumerable<User> entities)
        {
            // Arrange
            await dbContext.Users.AddRangeAsync(entities);
            var entity = entities.First();

            // Act
            var result = await repository.GetByIdAsync(entity.Id);

            // Assert
            result.Should().BeEquivalentTo(entity);
        }

        [Theory]
        [AutoEntityData]
        public async Task GetByIdAsync_EntityNotExist_ReturnsNull(IEnumerable<User> entities)
        {
            // Arrange
            await dbContext.Users.AddRangeAsync(entities);
            var entity = Fixture.Create<User>();

            // Act
            var result = await repository.GetByIdAsync(entity.Id);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [AutoEntityData]
        public async Task Query_ParametersNotPassed_ReturnsIQueryable(IEnumerable<User> entities)
        {
            // Arrange
            await dbContext.Users.AddRangeAsync(entities);
            var expected = dbContext.Users.AsQueryable();

            // Act
            var result = repository.Query();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoEntityData]
        public async Task AddAsync_EntityIsValid_ReturnsAddedEntity(User entity)
        {
            // Act
            var result = await repository.AddAsync(entity);

            // Assert
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task AddAsync_EntityIsNotValid_ThrowsArgumentNullException()
        {
            // Arrange
            User entity = null;

            // Act
            var result = new Func<Task>(() => repository.AddAsync(entity));

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(result);
        }
    }
}
