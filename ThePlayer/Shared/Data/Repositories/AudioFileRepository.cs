using Microsoft.EntityFrameworkCore;
using ThePlayer.Shared.Data.Context;
using ThePlayer.Shared.Data.Models;
using ThePlayer.Shared.Data.Repositories.Interfaces;
using GenericRepositoryForEfCore;


namespace ThePlayer.Shared.Data.Repositories
{
    public class AudioFileRepository : GenericRepository<AudioFile>, IAudioFileRepository
    {
        public AudioFileRepository(DbContext context) : base(context)
        {
        }

        public ThePlayerContext ThePlayerContext
        {
            get
            {
                return ThePlayerContext as ThePlayerContext;
            }
        }
    }
}
