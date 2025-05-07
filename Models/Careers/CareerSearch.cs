namespace DotnetTaskSeleniumNunit.Models.Careers;

public class CareerSearch
{
    public string Criteria { get; set; }
    public string Location { get; set; }
    public CareerModality Modality { get; set; }

    public CareerSearch(string criteria, string location, CareerModality modality)
    {
        Criteria = criteria;
        Location = location;
        Modality = modality;
    }
}
