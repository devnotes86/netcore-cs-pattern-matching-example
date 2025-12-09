/*---------------------------TYPE CHECK ------------------------------*/
object myItem = "test1";

// traditional type check
if (myItem.GetType() == typeof(string))
{
    Console.WriteLine("myItem type is string");
}

// type check with pattern matching
if (myItem is string)
{
    Console.WriteLine("myItem is string");
}

/*---------------------------COMPARING VALUES -------------------------*/

// comparing values - for value types
const string valueToCheck = "test1";
if (myItem is valueToCheck)
{
    Console.WriteLine($"myItem value is {valueToCheck}");
}


var motorcycle1 = new Motorcycle { Make = "Honda", Model = "Hornet" };
var motorcycle2 = new Motorcycle { Make = "Harley Davidson", Model = "Fat Boy" };

// comparing values - for reference types - Error CS9135 : A constant value of type 'Motorcycle' is expected
// if (motorcycle1 is motorcycle2)
// {
//     Console.WriteLine($"motorcycle1 is equal to motorcycle2");
// }

var motorcycleTypeCompareResult = motorcycle1 is Motorcycle && motorcycle2 is Motorcycle;
if (motorcycleTypeCompareResult)
{
    Console.WriteLine($"motorcycle1 and motorcycle2 are Motorcycle");
}


var areMotorcyclesEqual = motorcycle1.Equals(motorcycle2);
Console.WriteLine($"motorcycle1 and motorcycle2 are {(areMotorcyclesEqual ? "" : "NOT ")}equal");





// Possible unintended reference comparison.
// To get a value comparison, cast the left hand side to type string
var myItemCastedToString = myItem.ToString();
if (myItemCastedToString == valueToCheck)
{
    Console.WriteLine($"myItem value is {valueToCheck}");
}

var car1 = new Car
{
    Make = "BMW",
    Model = "850i",
    EngineCapacityCM3 = 5000,
    Dimensions = new CarDimensions { LengthCm = 400, WidthCm = 180 }
};


/*---------------------------COMPARING CLASS PROPERTIES -------------------------*/

// traditional way of checking property
// caution: if we reverse parameters.
// first check car1.Modal and car1 is null - then NullReferenceException will be thrown
if (car1 != null && car1.Model == "BMW") 
{
        Console.WriteLine("This is BMW");
}


// this expression checks if car is not null and if not - then if Make == "BMW"
// it takes care of all null checks
if (car1 is { Make: "BMW" })
{
    Console.WriteLine("This is BMW");
}


// traditional
if (car1 != null && car1.Dimensions!=null && car1.Make=="BMW" && car1.Dimensions.LengthCm == 400)
{
    Console.WriteLine("[traditional]: This is BMW, it's length is 4 metres");
}

// pattern matching
if (car1 is { Make: "BMW", Dimensions.LengthCm: 400 })
{
    Console.WriteLine("[pattern matching]: This is BMW, it's length is 4 metres");
}




// this expression checks if car is not null and if not - then if Make == "BMW",
// if true - it takes the Model property to local variable currentModel - which can be used inside the expression 
if (car1 is { Make: "BMW", Model: var currentModel })
{
    // currentModel is accessible only within this if statement body
    Console.WriteLine($"This is BMW {currentModel}");
}


/*---------------------------MATCHING INEQUALITIES -------------------------*/

var isCarQualifiedForTheRace = car1 is { EngineCapacityCM3: > 4000 and < 6000 }; 
Console.WriteLine($"This car's engine capacity is " +
                  $"{car1.EngineCapacityCM3} and {(isCarQualifiedForTheRace ? "qualifies" : "DOES NOT qualify")} " +
                  $"for the race");


var isCarLongerThan5m = car1 is { Dimensions.LengthCm: > 500 };
Console.WriteLine($"This car's length  is {car1.Dimensions.LengthCm} cm " +
                  $"and it's {(isCarLongerThan5m ? "longer" : "shorter")} than 5m");
 


/*---------------------------COMPARING COLLECTIONS -------------------------*/

// comparing collections
string[] motorcycleMakes = { "Honda", "Yamaha", "Kawasaki", "Suzuki", "Ducati", "Harley-Davidson", "Triumph", "BMW", "KTM", "Aprilia", "Indian" };


var areArraysEqual = (motorcycleMakes is
[
    "Honda", "Yamaha", "Kawasaki", "Suzuki", "Ducati", "Harley-Davidson", "Triumph", "BMW", "KTM", "Aprilia", "Indian"
]);
Console.WriteLine($"Motorcycle Arrays are {(areArraysEqual ? "" : "NOT")} equal");



/*---------------------------SPREAD OPERATOR FOR COLLECTIONS -------------------------*/

// with spread operator - familiar from JavaScript
if (motorcycleMakes is ["Honda", .., "Indian"])
{
    Console.WriteLine("Honda is first, Indian is last");
}

// traditional way
if (motorcycleMakes.Length >= 2 &&
    motorcycleMakes[0] == "Honda" &&
    motorcycleMakes[motorcycleMakes.Length - 1] == "Indian")
{
    Console.WriteLine("Honda is first, Indian is last");
}

// last index
var lastMotorcycle_1 = motorcycleMakes[^1];
Console.WriteLine($"lastMotorcycle_1: {lastMotorcycle_1}"); // Indian
var lastMotorcycle_2 = motorcycleMakes[motorcycleMakes.Length - 1];
Console.WriteLine($"lastMotorcycle_2: {lastMotorcycle_2}"); // Indian
 
// secondLast index
var secondLastMotorcycle = motorcycleMakes[^2];
Console.WriteLine($"secondLastMotorcycle: {secondLastMotorcycle}"); // Aprilia