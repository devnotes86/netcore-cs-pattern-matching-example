public class Car()
{
    public string  Make { get; set; }
    public required string Model { get; set; }
    public required int EngineCapacityCM3 { get; set; }

    public required CarDimensions Dimensions { get; set; } 
    
     
    
    public string ValidateCar_patternMatching()
    {
        var car = this as Car;
        return car switch
        {
            null => "Car object is null.",

            { Make: null } => "Make cannot be null.",
            { Make: var m } when string.IsNullOrWhiteSpace(m) => "Make cannot be empty.",

            { Model: null } => "Model cannot be null.",
            { Model: var m } when string.IsNullOrWhiteSpace(m) => "Model cannot be empty.",

            { EngineCapacityCM3: <= 0 } => "Engine capacity must be greater than 0.",
            { EngineCapacityCM3: < 3000 or > 8000 } => "Engine capacity must be between 3000 and 8000 cm³.",

            { Dimensions: null } => "Dimensions cannot be null.",

            { Dimensions.LengthCm: <= 0 } => "Length must be greater than 0.",
            { Dimensions.LengthCm: < 350 or > 600 } => "Length must be between 350 and 600 cm.",

            { Dimensions.WidthCm: <= 0 } => "Width must be greater than 0.",
            { Dimensions.WidthCm: < 150 or > 200 } => "Width must be between 150 and 200 cm.",

            _ => "Car is valid."
        };
    }
    
    public string ValidateCar_traditionalIfs()
    {
        var car = this as Car;
        if (car == null || (car != null && car.Make == null && car.Model == null))
        {
            return "Car or required fields are null.";
        }
        else if (car.Make == null || car.Make != null && string.IsNullOrWhiteSpace(car.Make))
        {
            return "Make cannot be null or empty.";
        }
        else if (car.Model == null || (car.Model != null && car.Model.Trim().Length == 0))
        {
            return "Model cannot be null or empty.";
        }
        else if (car.EngineCapacityCM3 <= 0 || (car.EngineCapacityCM3 > 0 && (car.EngineCapacityCM3 < 3000 || car.EngineCapacityCM3 > 8000)))
        {
            return "Engine capacity must be between 3000 and 8000 cm³.";
        }
        else if (car.Dimensions == null || (car.Dimensions != null && (car.Dimensions.LengthCm <= 0 || car.Dimensions.WidthCm <= 0)))
        {
            return "Dimensions cannot be null and values must be positive.";
        }
        else if (
            (car.Dimensions.LengthCm < 350 && car.Dimensions.LengthCm > 0)
            || (car.Dimensions.LengthCm > 600 && car.Dimensions.LengthCm <= int.MaxValue)
        )
        {
            return "Length must be between 350 and 600 cm.";
        }
        else if (
            (car.Dimensions.WidthCm < 150 && car.Dimensions.LengthCm > 0)
            || (car.Dimensions.WidthCm > 200 )
        )
        {
            return "Width must be between 150 and 200 cm.";
        }

        return "Car is valid.";
    }
}