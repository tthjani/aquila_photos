using APhoto.Infrastructure.Test.Unit.Utility;
using Microsoft.EntityFrameworkCore;

namespace APhoto.Infrastructure.Test.Unit
{
    public class AbstractRepositoryShould
    {
        private readonly Faker _faker;
        private readonly FakeDbContext _dbContext;
        private readonly IAbstractRepository<FakeEntity> _repository;

        public AbstractRepositoryShould()
        {
            _faker = new Faker();
            var options = new DbContextOptionsBuilder<FakeDbContext>()
                .UseInMemoryDatabase(databaseName: _faker.Random.String(15))
                .Options;
            _dbContext = new FakeDbContext(options);
            _repository = new TestableAbstractRepository(_dbContext);
        }

        [Theory, AutoData]
        public async Task GetAllAsync_ShouldReturnElements_WhenDatabaseHasData(
            IEnumerable<FakeEntity> elements)
        {
            // Arrange
            await _dbContext.TestTable.AddRangeAsync(elements);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = _repository.GetAllAsync(It.IsAny<CancellationToken>());

            // Assert
            result.Should().NotBeNull();
            var resultElements = await result.ToListAsync();
            resultElements.Should().BeEquivalentTo(elements);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnNoElements_WhenDatabaseHasNoData()
        {
            // Act
            var result = _repository.GetAllAsync(It.IsAny<CancellationToken>());

            // Assert
            result.Should().NotBeNull();
            var resultElements = await result.ToListAsync();
            resultElements.Should().BeEmpty();
        }

        [Theory, AutoData]
        public async Task GetOneAsync_ShouldReturnElement_WhenDatabaseHasRequiredElement(
            IEnumerable<FakeEntity> elements,
            Guid id)
        {
            // Arrange
            await _dbContext.TestTable.AddRangeAsync(elements);
            await _dbContext.TestTable.AddAsync(new FakeEntity
            {
                Id = id
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetOneAsync(
                x => x.Id == id,
                It.IsAny<CancellationToken>());

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(id);
        }

        [Theory, AutoData]
        public async Task GetOneAsync_ShouldReturnNull_WhenRequiredElementCanNotBeFound(
            Guid id)
        {
            // Act
            var result = await _repository.GetOneAsync(
                x => x.Id == id,
                It.IsAny<CancellationToken>());

            // Assert
            result.Should().BeNull();
        }

        [Theory, AutoData]
        public async Task GetOneAsync_ShouldThrowException_WhenMoreThanOneElmentWasFound(
            string value)
        {
            // Arrange
            var elements = new List<FakeEntity>
            {
                new FakeEntity
                {
                    Id = _faker.Random.Guid(),
                    Value = value
                },
                new FakeEntity
                {
                    Id = _faker.Random.Guid(),
                    Value = value
                }
            };

            await _dbContext.TestTable.AddRangeAsync(elements);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = async () => { 
                await _repository.GetOneAsync(x => x.Value == value, It.IsAny<CancellationToken>());
            };

            // Assert
            await result.Should().ThrowAsync<InvalidOperationException>();
        }

        [Theory, AutoData]
        public async Task GetMany_ShouldReturnElements_WhenDatabaseHasElements(
            IEnumerable<FakeEntity> elements)
        {
            // Arrange
            await _dbContext.TestTable.AddRangeAsync(elements);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = _repository.GetMany(x => x.Value != null);

            // Assert
            result.Any().Should().BeTrue();
        }

        [Theory, AutoData]
        public async Task GetMany_ShouldReturnEmpty_WhenNoElementsMatchPredicate(
            IEnumerable<FakeEntity> elements,
            Guid id)
        {
            // Arrance
            await _dbContext.TestTable.AddRangeAsync(elements);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = _repository.GetMany(x => x.Id == id);

            // Assert
            result.Any().Should().BeFalse();
        }

        [Theory, AutoData]
        public async Task Create_ShouldCreateEntity(
            FakeEntity entity)
        {
            // Act
            await _repository.CreateAsync(entity, It.IsAny<CancellationToken>());

            // Assert
            _dbContext.Entry(entity).Should().NotBeNull();
        }

        [Theory, AutoData]
        public async Task Update_ShouldUpdateEntity(
            FakeEntity entity,
            string value)
        {
            // Arrange
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            // Act
            entity.Value = value;
            await _repository.UpdateAsync(entity, It.IsAny<CancellationToken>());

            // Assert
            _dbContext.TestTable.Any(x => x.Value == value).Should().BeTrue();
        }

        [Theory, AutoData]
        public async Task Delete_ShouldRemoveEntity(
            FakeEntity entity)
        {
            // Arrange
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(entity, It.IsAny<CancellationToken>());

            // Assert
            _dbContext.TestTable.Any(x => x.Id == entity.Id).Should().BeFalse();
        }
    }
}
