using Microsoft.EntityFrameworkCore;
using GenericRepositoryForEfCore;
using Data.Context;
using Data.Models;
using Data.Repositories.Interfaces;


namespace Data.Repositories
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
