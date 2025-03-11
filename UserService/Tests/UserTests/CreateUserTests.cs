using Moq;
using Xunit;
using System.Net;
using AutoMapper;
using UserService.Domain.Dtos.UserDtos;
using UserService.Domain.Enums;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.UserRepositories;
using UserService.Services.UserServices;
using Moq.Protected;

namespace UserService.Tests.UserTests;
public class UsersServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly HttpClient _httpClient;
    private readonly IUserService _usersService;

    public UsersServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _mapperMock = new Mock<IMapper>();
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

        _httpClient = new HttpClient(handlerMock.Object);
        _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(_httpClient);

        _usersService = new UsersService(_userRepositoryMock.Object, _mapperMock.Object, _httpClientFactoryMock.Object);
    }

    [Fact]
    public async Task CreateUser_ShouldHashPassword_AndReturnUserDto()
    {
        var createUserDto = new CreateUserDto { Password = "123456", Roles = Roles.User };
        var userModel = new User { Id = Guid.NewGuid(), Password = "hashedPassword", Roles = Roles.User };
        var userDto = new UserDto { id = userModel.Id };

        _mapperMock.Setup(m => m.Map<User>(It.IsAny<CreateUserDto>())).Returns(userModel);
        _userRepositoryMock.Setup(r => r.CreateUser(It.IsAny<User>())).ReturnsAsync(userModel);
        _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        var result = await _usersService.CreateUser(createUserDto);

        Assert.NotNull(result);
        Assert.Equal(userModel.Id, result.id);
        _userRepositoryMock.Verify(r => r.CreateUser(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task CreateUser_ShouldSendRequest_WhenRoleIsAdminOrManager()
    {
        var createUserDto = new CreateUserDto { Password = "123456", Roles = Roles.Manager };
        var userModel = new User { Id = Guid.NewGuid(), Password = "hashedPassword", Roles = Roles.Manager };
        var userDto = new UserDto { id = userModel.Id };

        _mapperMock.Setup(m => m.Map<User>(It.IsAny<CreateUserDto>())).Returns(userModel);
        _userRepositoryMock.Setup(r => r.CreateUser(It.IsAny<User>())).ReturnsAsync(userModel);
        _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        var result = await _usersService.CreateUser(createUserDto);

        Assert.NotNull(result);
        Assert.Equal(userModel.Id, result.id);
        _userRepositoryMock.Verify(r => r.CreateUser(It.IsAny<User>()), Times.Once);
        _httpClientFactoryMock.Verify(h => h.CreateClient(It.IsAny<string>()), Times.Once);
    }
}
