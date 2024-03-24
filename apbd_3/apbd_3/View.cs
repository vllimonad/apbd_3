using apbd_3.Containers;

namespace apbd_3;

public class View
{
    public void showShipsAndContainers(List<ContainerShip> ships, List<Container> freeContainers)
    {
        Console.WriteLine("\nList of container ships: ");
        if (ships.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine("Ship " + i + " " + ships[i].ToString());
            }
        }
        
        Console.WriteLine("\nList of containers: ");
        if (freeContainers.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            for (int i = 0; i < freeContainers.Count; i++)
            {
                Console.WriteLine("Container " + i + " " + freeContainers[i].ToString());
            }
        }
    }


    public int showActions(List<ContainerShip> ships, List<Container> containers)
    {
        Console.WriteLine("\nPossible actions:");
        if (ships.Count == 0)
        {
            Console.WriteLine("1. - Create a container ship");
        } else if (ships.Count > 0 && containers.Count == 0)
        {
            Console.WriteLine("1. - Create a container ship");
            Console.WriteLine("2. - Delete a container ship");
            Console.WriteLine("3. - Create a container");
        } else if (ships.Count > 0 && containers.Count > 0)
        {
            Console.WriteLine("1. - Create a container ship");
            Console.WriteLine("2. - Delete a container ship");
            Console.WriteLine("3. - Create a container");
            Console.WriteLine("4. - Delete a container");
            Console.WriteLine("5. - Load cargo into container");
            Console.WriteLine("6. - Unload cargo from container");
            Console.WriteLine("7. - Load container onto a ship");
            Console.WriteLine("8. - Remove container from the ship");
            Console.WriteLine("9. - Print information about container");
            Console.WriteLine("10. - Print information about ship and its cargo");
        }
        return Convert.ToInt32(Console.ReadLine());
    }

    public ContainerShip enterShipInfo()
    {
        Console.WriteLine("Enter maximum speed the container ship can develop (in knots): ");
        double maxSpeed = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter maximum number of containers that can be transported: ");
        int maxNumberOfContainers = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter maximum weight of all containers that can be transported by the ship (in tons): ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        return new ContainerShip(maxSpeed, maxNumberOfContainers, maxWeight);
    }

    public int listAllShips(List<ContainerShip> ships)
    {
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine("Ship " + i + " " + ships[i].ToString());
        }
        Console.WriteLine("Enter ship number:");
        return Convert.ToInt32(Console.ReadLine());
    }

    public Container createContainer()
    {
        Console.WriteLine("Enter height of container (in meters): ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter weight of container (in kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter depth of container (in meters): ");
        double depth = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter maximum payload of container (in kg): ");
        double maximumPayload = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Select type of container: ");
        Console.WriteLine("1. - Gas container");
        Console.WriteLine("2. - Liquid container");
        Console.WriteLine("3. - Refrigerated container");
        switch (Convert.ToDouble(Console.ReadLine()))
        {
            case 1:
                return new GasContainer(height, weight,depth,maximumPayload);
            case 2:
                return new LiquidContainer(height, weight,depth,maximumPayload);
            case 3:
                Console.WriteLine("Enter temperature of container: ");
                double temperature = Convert.ToDouble(Console.ReadLine());
                return new RefrigeratedContainer(height, weight,depth,maximumPayload, temperature);
            default:
                return createContainer();
        }
        
    }

    public int listAllContainers(List<Container> containers)
    {
        for (int j = 0; j < containers.Count; j++)
        {
            Console.WriteLine("Container " + j + " " + containers[j].ToString());
        }
        Console.WriteLine("Enter container number:");
        return Convert.ToInt32(Console.ReadLine());
    }
    
    public int listFreeContainers(List<Container> containers)
    {
        for (int j = 0; j < containers.Count; j++)
        {
            if (!containers[j].loadedOntoShip)
            {
                Console.WriteLine("Container " + j + " " + containers[j].ToString());
            }
        }
        Console.WriteLine("Enter container number:");
        return Convert.ToInt32(Console.ReadLine());
    }

    public double loadContainer()
    {
        Console.WriteLine("Enter cargo mass:");
        return Convert.ToDouble(Console.ReadLine());
    }

    public void configureContainer(Container container)
    {
        if (container.number.Contains("CON-L-"))
        {
            Console.WriteLine("Is it hazardous cargo? ");
            Console.WriteLine("1. - Yes");
            Console.WriteLine("2. - No");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                ((LiquidContainer)container).setIsHazard(true);
            }
            else
            {
                ((LiquidContainer)container).setIsHazard(false);
            }
        } else if (container.number.Contains("CON-C-"))
        {
            Console.WriteLine("Enter container temperature: ");
            double temperature = Convert.ToDouble(Console.ReadLine());
            ((RefrigeratedContainer)container).temperature = temperature;
            Console.WriteLine("Enter cargo product type: ");
            ((RefrigeratedContainer)container).setProductType(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Is it hazardous cargo? ");
            Console.WriteLine("1. - Yes");
            Console.WriteLine("2. - No");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                ((GasContainer)container).setIsHazard(true);
            }
            else
            {
                ((GasContainer)container).setIsHazard(false);
            }
        }
    }

    public void getInfoAboutContainer(List<Container> containers)
    {
        Console.WriteLine("Enter container numuber: ");
        Console.WriteLine(containers[Convert.ToInt32(Console.ReadLine())].ToString());
    }
    
    public void getInfoAboutShip(List<ContainerShip> ships)
    {
        Console.WriteLine("Enter container ship numuber: ");
        int index = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(ships[index].ToString());
        listAllContainers(ships[index].allShippedContainers);
    }
}