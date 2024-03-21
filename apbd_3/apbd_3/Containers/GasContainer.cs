namespace apbd_3.Containers;

public class GasContainer: Container, IHazardNotifier
{
    public GasContainer(double height, double weight, double depth, double maxPayload) : base( height, weight, depth, maxPayload)
    {
        number = "CON-" + "G-";
    }
    
    public override void unload()
    {
        cargoMass *= 0.05;
    }

    public void notifyAboutHazard()
    {
        Console.WriteLine("Hazardous situation in container " + number);
    }

    public override void checkMass()
    {
        if (cargoMass > maximumPayload)
        {
            throw new Exception();
        }
    }
}