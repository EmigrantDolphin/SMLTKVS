using Laboratory.Domain.Entities.Company;
using Laboratory.Domain.Exceptions;

namespace Laboratory.Domain.Aggregates;

public class Company
{
    public Guid CompanyId { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string CompanyCode { get; private set; }

    public List<ConstructionSite> ConstructionSites { get; private set; } = new List<ConstructionSite>();

    public Company()
    {
        // For EFCore
    }

    public Company(string name, string address, string companyCode, List<ConstructionSite>? constructionSites)
    {
        CompanyId = Guid.NewGuid();
        Name = name;
        Address = address;
        CompanyCode = companyCode;
        if (constructionSites is not null)
        {
            ConstructionSites.AddRange(constructionSites);
        }
    }

    public void Update(string name, string address, string companyCode)
    {
        Name = name;
        Address = address;
        CompanyCode = companyCode;
    }

    public void UpdateConstructionSite(Guid constructionSiteId, string name, string address)
    {
        var site = ConstructionSites.FirstOrDefault(x => x.ConstructionSiteId == constructionSiteId);
        if (site is null)
        {
            throw new RecordNotFoundException("Įmonės objektas nerastas");
        }

        site.Update(name, address);
    }

    public void AddConstructionSite(string name, string address)
    {
        ConstructionSites.Add(new ConstructionSite(name, address));
    }
}