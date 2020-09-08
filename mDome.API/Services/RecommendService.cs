using mDome.API.Database;
using mDome.API.ML;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class RecommendService : IRecommendService
    {
        private mDomeT1Context _context;
        static MLContext mlcontext = null;
        ITransformer model = null;
        public RecommendService(mDomeT1Context context)
        {
            _context = context;
        }

        public void RefreshDiscoveryQueues()
        {
            try
            {
                if (mlcontext == null)
                {
                    mlcontext = new MLContext();
                    var contextData = _context.UserProfile.Include("UserTrackVote").ToList();
                    var data = new List<TrackRecommendEntry>();
                    foreach (var item in contextData)
                    {
                        var distinctTrackId = item.UserTrackVote.Where(a => a.Liked == true).Select(a => a.TrackId).ToList();
                        foreach (var x in distinctTrackId)
                        {
                            var overlappingLikesUsers = _context.UserTrackVote.Where(a => a.TrackId == x && a.UserId != item.UserId
                            && a.Liked == true).Select(a => a.UserId).Distinct().ToList();
                            var relatedItems = item.UserTrackVote.Where(a => a.TrackId != x).ToList();
                            foreach (var y in overlappingLikesUsers)
                            {
                                relatedItems.ForEach(a =>
                                {
                                    if (a.Liked == true)
                                    {
                                        data.Add(new TrackRecommendEntry()
                                        {
                                            TrackId = (uint)x,
                                            UserId = (uint)y
                                        });
                                    }
                                });
                            }

                        }
                    }
                    var traindata = mlcontext.Data.LoadFromEnumerable(data);
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(TrackRecommendEntry.TrackId);
                    options.MatrixRowIndexColumnName = nameof(TrackRecommendEntry.UserId);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    options.C = 0.00001;
                    var est = mlcontext.Recommendation().Trainers.MatrixFactorization(options);
                    model = est.Fit(traindata);
                }
                var allUsers = _context.UserProfile.ToList();
                var allTracks = _context.Track.ToList();
                foreach (var item in allUsers)
                {
                    var predictionResult = new List<Tuple<Track, float>>();
                    foreach (var x in allTracks)
                    {
                        var predictionengine = mlcontext.Model.CreatePredictionEngine<TrackRecommendEntry, TrackPrediction>(model);
                        var prediction = predictionengine.Predict(
                                                 new TrackRecommendEntry()
                                                 {
                                                     UserId = (uint)item.UserId,
                                                     TrackId = (uint)x.TrackId
                                                 });
                        predictionResult.Add(new Tuple<Track, float>(x, prediction.Score));
                    }
                    var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();
                    var usersDiscoveryQueueId = _context.Tracklist.Where(a => a.UserId == item.UserId && a.TracklistName == "My Discovery Queue").
                        Select(a => a.TracklistId).FirstOrDefault();
                    var usersHistoryId = _context.Tracklist.Where(a => a.UserId == item.UserId && a.TracklistName == "History").
                        Select(a => a.TracklistId).FirstOrDefault();
                    var tracksInHistory = _context.TracklistTrack.Where(a => a.TracklistId == usersHistoryId).ToList();
                    foreach (var x in tracksInHistory)
                    {
                        finalResult.Remove(_context.Track.Find(x.TrackId));
                    }
                    finalResult = finalResult.Take(10).ToList();
                    _context.TracklistTrack.RemoveRange(_context.TracklistTrack.Where(a => a.TracklistId == usersDiscoveryQueueId));
                    _context.SaveChanges();
                    foreach (var x in finalResult)
                    {
                        _context.TracklistTrack.Add(new TracklistTrack
                        {
                            DateAdded = DateTime.Now,
                            TracklistId = usersDiscoveryQueueId,
                            TrackId = x.TrackId
                        });
                    }
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

            }
        } 
    }
}
