using Evbul.Entity;

namespace Evbul.Data.Abstract;

public interface IEvRepository
{
    IQueryable<Ev> Evler {get;}
    void EvOlustur(Ev ev);
    void EditEv(Ev ev);
    void EditEv(Ev ev, int[] ozelliklerIdler);
    void Delete(Ev ev);
}
