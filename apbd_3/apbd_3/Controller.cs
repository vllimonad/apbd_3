using apbd_3.Containers;

namespace apbd_3;

public class Controller
{
    public List<ContainerShip> ships;
    public List<Container> freeContainers;
    public View view;
    public int conteinerIndex = 0;

    public Controller()
    {
        ships = new List<ContainerShip>();
        freeContainers = new List<Container>();
        view = new View();
    }

    public void showMainInfo()
    {
        while (true)
        {
            view.showShipsAndContainers(ships, freeContainers);
            switch (view.showActions(ships, freeContainers))
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
                    freeContainers.Add(con);
                    break;
                case 4:
                    freeContainers.RemoveAt(view.listAllContainers(freeContainers));
                    break;
                case 5:
                    Container container = freeContainers[view.listAllContainers(freeContainers)];
                    container.load(view.loadContainer());
                    view.configureContainer(container);
                    break;
                case 6:
                    Container container1 = freeContainers[view.listAllContainers(freeContainers)];
                    container1.unload();
                    break;
                case 7:
                    Container container2 = freeContainers[view.listAllContainers(freeContainers)];
                    ships[view.listAllShips(ships)].allShippedContainers.Add(container2);
                    freeContainers.Remove(container2);
                    break;
                case 8:
                    ContainerShip ship = ships[view.listAllShips(ships)];
                    Container container3 = ship.allShippedContainers[view.listAllContainers(ship.allShippedContainers)];
                    ship.allShippedContainers.Remove(container3);
                    freeContainers.Add(container3);
                    break;
            }
        }
    }
}