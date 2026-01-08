#region __MAIN__PURE__CQRS

using CQRSDesignPattern;
using CQRSDesignPattern.Commands;
using CQRSDesignPattern.Db;
using CQRSDesignPattern.Handlers;
using CQRSDesignPattern.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var dbUser = new List<User>();

var addHandler = new AddUserCommandHandler(dbUser);

var getHandler = new GetAllUserQueryHandler(dbUser);

addHandler.Handle(new AddUserCommand { Name = "Alice" });
addHandler.Handle(new AddUserCommand { Name = "Bob" });

List<User> userList = getHandler.Handle(new GetAllUsersQuery());

Console.WriteLine("Users in the database:");
foreach (var user in userList)
{
    Console.WriteLine($"\t{user.Name}");
}

#endregion


#region __MAIN__MEDIATR__CQRS

// setting up the host and services
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<List<Product>>(); // In-memory database for products

builder.Services.AddScoped<IRequestHandler<AddProductCommand, Unit>, AddProductCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllProductsQuery, List<Product>>, GetAllProductsQueryHandler>();

var app = builder.Build();

// running a CQRS MediatR Demo
using(var scope = app.Services.CreateScope())
{
    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
    var demo = new Demo(mediator);
    await demo.Run();
}

// running my app
app.Run();

#endregion


#region Basic example of pure CQRS implementation
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class AddUserCommand
{
    public string Name { get; set; }
}

public class AddUserCommandHandler
{
    private readonly List<User> _dbUser;

    public AddUserCommandHandler(List<User> dbUser)
    {
        _dbUser = dbUser;
    }

    public void Handle(AddUserCommand command)
    {
        var user = new User
        {
            Id = _dbUser.Count + 1,
            Name = command.Name
        };

        _dbUser.Add(user);

    }
}



public class GetAllUsersQuery
{
}

public class  GetAllUserQueryHandler
{
    private readonly List<User> _dbUser;

    public GetAllUserQueryHandler(List<User> dbUser)
    {
        _dbUser = dbUser;
    }

    public List<User> Handle(GetAllUsersQuery query)
    {
        return _dbUser;
    }

}

#endregion