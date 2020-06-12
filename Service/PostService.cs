using CdSite.Repository.Data;
using CdSite.IService;
using CdSite.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CdSite.Service
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// ���� Id ��ȡ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> GetPostById(int id)
        {
            return await base.QueryById(id);
        }

        /// <summary>
        /// ���� Slug ��ȡ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> GetPostBySlug(string slug)
        {
            return (await base.Query(a => a.Slug == slug)).FirstOrDefault();
        }

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetPosts()
        {
            return await base.Query(a => a.Id > 0);
        }
    }
}
