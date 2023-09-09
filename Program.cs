using CarBuilder.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//* CORS - the security demands built into a browser can be satisfied by implementing CORS. "Our API is now telling the browser that it is safe to request the data from any origin."
builder.Services.AddCors(); //* allows cross-origin resource sharing since our API is serving the data our browser is asking for. Otherwise the browser's security features won't allow access to our API bc it could be a malicious source.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => //* "Our API is now telling the browser that it is safe to request the data from any origin."
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
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

//^ CREATE a new list of orders ... leave empty for now
List<Order> orders = new List<Order> 
{
    new Order
    {
        Id = 1,
        WheelId = 1,
        TechnologyId = 1,        
    } 
};


//^ENDPOINT for getting all wheels
app.MapGet("/wheels", () => 
{
   return wheels; 
});


//^ENDPOINT for getting all technologies
app.MapGet("/technologies", () => 
{
   return technologies; 
});


//^ENDPOINT for getting all interiors
app.MapGet("/interiors", () => 
{
   return interiors; 
});


//^ENDPOINT for getting all paintColors
app.MapGet("/paintColors", () => 
{
   return paintColors; 
});


//^ENDPOINT for getting all orders
// What are we trying to accomplish here? We want to pull up ALL orders in the database when we navigate to /orders. So why can't we just return orders?
app.MapGet("/orders/", () => 
{   // I am not now using it but i did use a select method before. WHy? We use Select method on the orders list here? Because the Select method is for assembling data from different sources and projecting (transforms) that data into a new object of its own. The new object is its own creation and construction. It is created from multiple sources/collections. So when you need to assemble this new Order instance from multiple collections, you have to take the user's chosen Ids for each collection and find it (with FirstOrDefault) and THEN all of those chosen objects get assembled with Select method. 
    foreach(Order order in orders)
    {
        order.Wheels = wheels.FirstOrDefault(w => w.Id == order.WheelId);
        order.Technology = technologies.FirstOrDefault(t => t.Id == order.TechnologyId);
        order.Interior = interiors.FirstOrDefault(w => w.Id == order.InteriorId);
        order.PaintColor = paintColors.FirstOrDefault(w => w.Id == order.PaintId);
    }
}
);

//^ ENDPOINT - add endpoint to POST a new order to the database
// The below "handler" tells the API two things: WHERE to go online and WHAT to do when we get there.
app.MapPost("/orders", (Order order) => // pass parameters for url and allow the order list to come into this method/function so we can access it/reference it
{
    //Since we are creating a new order, we need to create a new Id
    order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1; // so to create a new order Id we count the orders with .Max and add one. The ternary says to assign "1" if there are no existing orders.
    //But what is the lambda expression saying after .Max?
        // It's saying "look at all the order Ids on all of the orders and find the max/highest order Id integer. Then we plus one that number.
        //* So we find the max orderId integer and add one
    // include a time stamp on the order
    order.Timestamp = DateTime.Now;
    // this adds the new order we defined above to the orders list
    orders.Add(order); 
    // POST method on the new order object
    return order;
}   
);








app.Run();

