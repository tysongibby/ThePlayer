﻿using ThePlayer.Shared.Log;
using ThePlayer.Shared.Models.Factories;
using ThePlayer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Models.Repositories
{
    public class QueuedTrackRepository : IQueuedTrackRepository
    {
        private ISQLiteConnectionFactory factory;

        public QueuedTrackRepository(ISQLiteConnectionFactory factory)
        {
            this.factory = factory;
        }

        public async Task<List<QueuedTrack>> GetSavedQueuedTracksAsync()
        {
            var tracks = new List<QueuedTrack>();

            await Task.Run(() =>
            {
                try
                {
                    using (var conn = this.factory.GetConnection())
                    {
                        try
                        {
                            tracks = conn.Query<QueuedTrack>("SELECT * FROM QueuedTrack ORDER BY OrderID;");
                        }
                        catch (Exception ex)
                        {
                            LogClient.Error("Could not get Queued tracks. Exception: {0}", ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogClient.Error("Could not connect to the database. Exception: {0}", ex.Message);
                }
            });

            return tracks;
        }

        public async Task SaveQueuedTracksAsync(IList<QueuedTrack> tracks)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var conn = this.factory.GetConnection())
                    {
                        try
                        {
                            conn.Execute("BEGIN TRANSACTION;");
                            conn.Execute("DELETE FROM QueuedTrack;"); // First, clear old queued tracks.
                            conn.InsertAll(tracks); // Then, insert new queued tracks.
                            conn.Execute("COMMIT;");
                        }
                        catch (Exception ex)
                        {
                            LogClient.Error("Could not save queued tracks. Exception: {0}", ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogClient.Error("Could not connect to the database. Exception: {0}", ex.Message);
                }
            });
        }

        public async Task<QueuedTrack> GetPlayingTrackAsync()
        {
            QueuedTrack track = null;

            await Task.Run(() =>
            {
                try
                {
                    using (var conn = this.factory.GetConnection())
                    {
                        try
                        {
                            track = conn.Query<QueuedTrack>("SELECT * FROM QueuedTrack WHERE IsPlaying=1;").FirstOrDefault();
                        }
                        catch (Exception ex)
                        {
                            LogClient.Error("Could not get the playing queued Track. Exception: {0}", ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogClient.Error("Could not connect to the database. Exception: {0}", ex.Message);
                }
            });

            return track;
        }
    }
}
