using apbd_3.Containers;

namespace apbd_3;

public class Controller
{
    public List<ContainerShip> ships;
    public List<Container> containers;
    public View view;
    public int conteinerIndex = 0;

    public Controller()
    {
        ships = new List<ContainerShip>();
        containers = new List<Container>();
        view = new View();
    }

    public void showMainInfo()
    {
        while (true)
        {
            view.showShipsAndContainers(ships, containers);
            switch (view.showActions(ships, containers))
            {
                case 1:
                    ships.Add(view.enterShipInfo());
                    break;
                case 2:
                    ships.RemoveAt(view.listAllShips(ships));
                    break;
                case 3:
                    Container con = view.createContainer();
                    con.setNumber(conteinerIndex);
                    conteinerIndex++;
                    containers.Add(con);
                    break;
                case 4:
                    containers.RemoveAt(view.listAllContainers(containers));
                    break;
                case 5:
                    Container container = containers[view.listFreeContainers(containers)];
                    container.load(view.loadContainer());
                    view.configureContainer(container);
                    break;
                case 6:
                    Container container1 = containers[view.listFreeContainers(containers)];
                    container1.unload();
                    break;
                case 7:
                    Container container2 = containers[view.listFreeContainers(containers)];
                    ships[view.listAllShips(ships)].allShippedContainers.Add(container2);
                    container2.loadedOntoShip = true;
                    break;
                case 8:
                    ContainerShip ship = ships[view.listAllShips(ships)];
                    Container container3 = ship.allShippedContainers[view.listAllContainers(ship.allShippedContainers)];
                    ship.allShippedContainers.Remove(container3);
                    container3.loadedOntoShip = false;
                    break;
                case 9:
                    view.getInfoAboutContainer(containers);
                    break;
                case 10:
                    view.getInfoAboutShip(ships);
                    break;
            }
        }
    }
}