namespace Laboratory.Domain.Entities.Company;

public class ConstructionSite
{
    public Guid ConstructionSiteId { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }

    public ConstructionSite()
    {
        // For EFCore
    }

    public ConstructionSite(string name, string address)
    {
        ConstructionSiteId = Guid.NewGuid();
        Name = name;
        Address = address;
    }

    public void Update(string name, string address)
    {
        Name = name;
        Address = address;
    }
}