using TaskManagement.API.DataLayer.Repositories;

namespace CommentManagement.API.ServiceLayer
{

    public interface ICommentService
    {
        
    }
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
    }

    
}
