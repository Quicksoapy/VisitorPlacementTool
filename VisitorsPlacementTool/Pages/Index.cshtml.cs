using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamlDotNet.Serialization;
using System.IO;

namespace VisitorsPlacementTool.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public int RowCount;
    public int ColumnCount;
    public List<Sector> Sectors = new List<Sector>();
    
    public void OnGet()
    {
        Sectors = GetSectors();
    }

    public void OnPost()
    {
        Sectors = GetSectors();
        var sector = new Sector(RowCount,ColumnCount, (CountToLetter)Sectors.Count);
        Sectors.Add(sector);
        SetSectors(Sectors);
        
        OnGet();
    }

    public List<Sector> GetSectors()
    {
        var deserializer = new DeserializerBuilder().Build();
        string yaml = System.IO.File.ReadAllText("./SavedSectors.yaml");
        var sectors = deserializer.Deserialize<List<Sector>>(yaml);
        return sectors;
    }

    public void SetSectors(List<Sector> sectors)
    {
        var serializer = new SerializerBuilder().Build();
        string yaml = serializer.Serialize(sectors);
        System.IO.File.AppendAllText("./SavedSectors.yaml", yaml);
    }
}