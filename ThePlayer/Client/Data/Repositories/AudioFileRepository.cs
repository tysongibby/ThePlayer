using GenericRepositoryForEfCore;
using Microsoft.EntityFrameworkCore;
using ThePlayer.Client.Data.Context;
using ThePlayer.Client.Data.Models;
using ThePlayer.Client.Data.Repositories.Interfaces;

namespace ThePlayer.Client.Data.Repositories
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
