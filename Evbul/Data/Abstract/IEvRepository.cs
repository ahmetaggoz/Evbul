using Evbul.Entity;

namespace Evbul.Data.Abstract;

public interface IEvRepository
{
    IQueryable<Ev> Evler {get;}
    void EvOlustur(Ev ev);
}
