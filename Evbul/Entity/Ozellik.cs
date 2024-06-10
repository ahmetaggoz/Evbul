namespace Evbul.Entity;

public enum OzellikRenkleri
{
    primary, danger, warning, success, secondary, info
}
public class Ozellik
{
    public int OzellikId { get; set; }
    public string? Yazi { get; set; }
    public string? Url { get; set; }
    public OzellikRenkleri? Renk { get; set; }

    public List<Ev> Evler { get; set; } = new List<Ev>();
}
