namespace CarBuilder.Models; //* what does this do? Declaring a namespace will allow this model/module/entity to call on other models for their data and properties. For example, below I can declare a new property in the Order class called PaintColor and it will inherit the properties of the PaintColor class right here in this Order class/model.

public class Order
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int WheelId { get; set; }
    public Wheels Wheels { get; set; } // Get access to the Wheels model and its properties
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; }
    public int PaintId { get; set; }
    public PaintColor PaintColor { get; set; } // what is this doing? This is called Composition. It's creating another property on the Order class. The property is PaintColor.  The type of that property is the PaintColor type. Where did that come from? PaintColor is its own class/type that we custom created earlier. It has its own properties too and now, we can access PaintColor properties within the Order class.
    public int InteriorId { get; set; }
    public Interior Interior { get; set; } // Get access to the Interior class and its properties
    public decimal Price { get; set; }
    

}