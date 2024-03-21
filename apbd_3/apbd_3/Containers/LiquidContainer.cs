namespace apbd_3.Containers;

public class LiquidContainer: Container, IHazardNotifier
{
    public bool isHazard;
    
    public LiquidContainer(double height, double weight, double depth, double maxPayload) : base(height, weight, depth, maxPayload)
    {
        number = "CON-" + "L-";
    }
    
    public void notifyAboutHazard()
    {
        Console.WriteLine("Hazardous situation in container " + number);
    }

    public void isDangerous()
    {
        if (isHazard)
        {
            if (cargoMass > maximumPayload/2)
            {
                Console.WriteLine("Attempt to perform a dangerous operation");
            }
        }
        else
        {
            if (cargoMass > maximumPayload*0.9)
            {
                Console.WriteLine("Attempt to perform a dangerous operation");
            }
        }
    }
}