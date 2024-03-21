using apbd_3.Containers;

namespace apbd_3;

public class ContainerShip
{
    public List<Container> allShippedContainers;
    public double maxSpeed;
    public int maxNumberOfContainers;
    public double maxWeight;

    public ContainerShip(double maxSpeed, int maxNumberOfContainers, double maxWeight)
    {
        allShippedContainers = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.maxNumberOfContainers = maxNumberOfContainers;
        this.maxWeight = maxWeight;
    }

    public override string ToString()
    {
        return "(speed=" + maxSpeed + ", maxContainers=" + maxNumberOfContainers + ", maxWeight=" + maxWeight + ")";
    }
}