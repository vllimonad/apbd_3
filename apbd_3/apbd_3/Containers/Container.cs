namespace apbd_3.Containers;

public class Container
{
    public double cargoMass;
    public double height;
    public double weight;
    public double depth;
    public string number;
    public double maximumPayload;
    public bool loadedOntoShip;

    public Container(double height, double weight, double depth, double maxPayload)
    {
        this.height = height;
        this.weight = weight;
        this.depth = depth;
        maximumPayload = maxPayload;
        loadedOntoShip = false;
    }

    public void setNumber(int num)
    {
        number += num;
    }
    public virtual void unload()
    {
        cargoMass = 0;
    }
    public virtual void load(double mass)
    {
        cargoMass = mass;
        checkMass();
    }

    public virtual void checkMass()
    {
        if (cargoMass > maximumPayload)
        {
            throw new OverFillException();
        }
    }

    public override string ToString()
    {
        return "(number=" + number + " cargoMass=" + cargoMass + " maximumPayload" + maximumPayload + ")";
    }
}