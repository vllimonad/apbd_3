namespace apbd_3.Containers;

public class RefrigeratedContainer : Container
{
    public double temperature;
    public string productType;
    
    public RefrigeratedContainer(double height, double weight, double depth, double maxPayload, double temperature) : base( height, weight, depth, maxPayload)
    {
        number = "CON-" + "C-";
        this.temperature = temperature;
    }
    
    public Dictionary<string, double> products = new Dictionary<string, double>()
    {
        {"Bananas", 13.3}, {"Chocolate", 18}, {"Fish",2}, {"Meat", -15}, {"Ice cream", -18}, 
        {"Frozen pizza", -30}, {"Cheese", 7.2}, {"Sausages", 5}, {"Butter", 20.5}, {"Eggs", 19}
    };
}