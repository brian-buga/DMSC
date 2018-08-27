using DMSC.Assessment.Data.Model;

namespace DMSC.Assessment.Data.Interface
{
    public interface ILikeRepository 
    {
        void SaveChanges();
        void Create(Like like);
    }
}
