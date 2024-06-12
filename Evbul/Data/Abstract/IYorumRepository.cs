using Evbul.Entity;

namespace Evbul.Data.Abstract;

public interface IYorumRepository
{
    IQueryable<Yorum> Yorumlar {get;}
    void YorumOlustur(Yorum yorum);
}
