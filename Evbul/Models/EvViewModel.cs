using Evbul.Entity;

namespace Evbul.Models;

public class EvViewModel
{
    public List<Ev> Evler {get; set;} = new();
    public List<Ozellik> Ozellikler {get; set;} = new();
}
