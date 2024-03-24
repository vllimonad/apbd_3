namespace apbd_3.Containers;

public class GasContainer: Container, IHazardNotifier
{
    public double pressure;
    public bool isHazard;
    
    public GasContainer(double height, double weight, double depth, double maxPayload) : base( height, weight, depth, maxPayload)
    {
        number = "CON-" + "G-";
        isHazard = false;
    }

    public void setIsHazard(bool b)
    {
        isHazard = b;
        notifyAboutHazard();
    }

    public override void unload()
    {
        cargoMass *= 0.05;
    }

    public void notifyAboutHazard()
    {
        if (isHazard)
        {
            Console.WriteLine("Hazardous situation in container " + number);
        }
    }

    public override void checkMass()
    {
        if (cargoMass > maximumPayload)
        {
            throw new Exception();
        }
    }
}