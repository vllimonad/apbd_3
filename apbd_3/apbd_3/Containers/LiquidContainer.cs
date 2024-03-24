namespace apbd_3.Containers;

public class LiquidContainer: Container, IHazardNotifier
{
    public bool isHazard;
    
    public LiquidContainer(double height, double weight, double depth, double maxPayload) : base(height, weight, depth, maxPayload)
    {
        number = "CON-" + "L-";
        isHazard = false;
    }
    
    public void setIsHazard(bool b)
    {
        isHazard = b;
        notifyAboutHazard();
        checkMass();
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