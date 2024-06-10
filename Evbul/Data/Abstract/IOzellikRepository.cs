using Evbul.Entity;

namespace Evbul.Data.Abstract;

public interface IOzellikRepository
{
    IQueryable<Ozellik> Ozellikler {get;}
    void OzellikOlustur(Ozellik ozellik);
}
