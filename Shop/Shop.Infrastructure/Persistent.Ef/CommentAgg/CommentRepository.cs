using Shop.Domain.CommentAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    private readonly ShopContext _context;
    public CommentRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task DeleteAndSave(Comment comment)
    {
        _context.Remove(comment);
        await _context.SaveChangesAsync();
    }
}