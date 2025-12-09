public class Car()
{
    public string  Make { get; set; }
    public required string Model { get; set; }
    public required int EngineCapacityCM3 { get; set; }

    public required CarDimensions Dimensions { get; set; } 
}