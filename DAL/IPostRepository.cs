using System.Collections.Generic;

namespace DAL
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll(int limit = 10, int offset = 0);
        Post GetById(int id);
        void Add(Post post);
    }
}