var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//^ CREATE a new list of paint colors
List<PaintColor> paintColors = new List<PaintColor> {
    new PaintColor
    {
        Id = 1,
        Price = 100.00M,
        Color = "Silver"
    },
    new PaintColor
    {
        Id = 2,
        Price = 110.00M,
        Color = "Midnight Blue"
    },
    new PaintColor
    {
        Id = 3,
        Price = 91.00M,
        Color = "Firebrick Red"
    },
    new PaintColor
    {
        Id = 4,
        Price = 80.00M,
        Color = "Spring Green"
    }
};

//^ CREATE a new list of interior options
List<Interior> interiors = new List<Interior> {
    new Interior
    {
        Id = 1,
        Price = 10.00M,
        Material = "Beige Fabric"
    },
    new Interior
    {
        Id = 2,
        Price = 11.00M,
        Material = "Charcoal Fabric"
    },
    new Interior
    {
        Id = 3,
        Price = 9.00M,
        Material = "White Leather"
    },
    new Interior
    {
        Id = 4,
        Price = 8.00M,
        Material = "Black Leather"
    }
};

//^ CREATE a new list of technology options
List<Technology> technologies = new List<Technology> {
    new Technology
    {
        Id = 1,
        Price = 1000.00M,
        Package = "Basic Package (basic sound system)"
    },
    new Technology
    {
        Id = 2,
        Price = 1100M,
        Package = "Navigation Package (includes integrated navigation controls)"
    },
    new Technology
    {
        Id = 3,
        Price = 9000M,
        Package = "Visibility Package (includes side and rear cameras)"
    },
    new Technology
    {
        Id = 4,
        Price = 8000M,
        Package = "Ultra Package (includes navigation and visibility packages)"
    }
};

//^ CREATE a new list of wheel options
List<Wheels> wheels = new List<Wheels> {
    new Wheels
    {
        Id = 1,
        Price = 120.00M,
        Style = "17-inch Pair Radial"
    },
    new Wheels
    {
        Id = 2,
        Price = 112.00M,
        Style = "17-inch Pair Radial Black"
    },
    new Wheels
    {
        Id = 3,
        Price = 96.00M,
        Style = "18-inch Pair Spoke Silver"
    },
    new Wheels
    {
        Id = 4,
        Price = 184.00M,
        Style = "18-inch Pair Spoke Black"
    }
};

//^ CREATE a new list of orders //leave empty for now...
List<Order> orders = new List<Order> {};


app.Run();

