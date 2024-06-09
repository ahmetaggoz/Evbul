namespace Evbul.Entity;

public class Ozellik
{
    public int OzellikId { get; set; }
    public string? Yazi { get; set; }
    public List<Ev> Evler { get; set; } = new List<Ev>();
}
