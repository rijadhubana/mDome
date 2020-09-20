using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Genre, Model.Genre>();
            CreateMap<Database.Genre, GenreUpsertRequest>().ReverseMap();
            CreateMap<Database.Artist, Model.Artist>();
            CreateMap<Database.Artist, ArtistUpsertRequest>().ReverseMap();
            CreateMap<Database.ArtistGenre, Model.ArtistGenre>();
            CreateMap<Database.ArtistGenre, ArtistGenreSearchRequest>().ReverseMap();
            CreateMap<Database.Album, Model.Album>();
            CreateMap<Database.Album, AlbumUpsertRequest>().ReverseMap();
            CreateMap<Database.Track, Model.Track>();
            CreateMap<Database.Track, TrackUpsertRequest>().ReverseMap();
            CreateMap<Database.Request, Model.Request>();
            CreateMap<Database.Request, RequestUpsertRequest>().ReverseMap();
            CreateMap<Database.Notification, Model.Notification>();
            CreateMap<Database.Notification, NotificationUpsertRequest>().ReverseMap();
            CreateMap<Database.UserProfile, Model.UserProfile>();
            CreateMap<Database.UserProfile, UserProfileUpsertRequest>().ReverseMap();
            CreateMap<Database.AdministratorLogin, Model.AdministratorLogin>();
            CreateMap<Database.AdministratorLogin, AdminUpsertRequest>().ReverseMap();
            CreateMap<Database.Post, Model.Post>();
            CreateMap<Database.Post, PostUpsertRequest>().ReverseMap();
            CreateMap<Database.UserFollowsArtist, Model.UserFollowsArtist>();
            CreateMap<Database.UserFollowsArtist, UserFollowsArtistUpsertRequest>().ReverseMap();
            CreateMap<Database.UserFollowers, Model.UserFollowers>();
            CreateMap<Database.UserFollowers,UserFollowersUpsertRequest>().ReverseMap();
            CreateMap<Database.UserCommentPost, Model.UserCommentPost>();
            CreateMap<Database.UserCommentPost, UserCommentPostUpsertRequest>().ReverseMap();
            CreateMap<Database.UserLikePost, Model.UserLikePost>();
            CreateMap<Database.UserLikePost, UserLikePostUpsertRequest>().ReverseMap();
            CreateMap<Database.Tracklist, Model.Tracklist>();
            CreateMap<Database.Tracklist, TracklistUpsertRequest>().ReverseMap();
            CreateMap<Database.TracklistTrack, Model.TracklistTrack>();
            CreateMap<Database.TracklistTrack, TracklistTrackUpsertRequest>().ReverseMap();
            CreateMap<Database.AlbumList, Model.AlbumList>();
            CreateMap<Database.AlbumList, AlbumListUpsertRequest>().ReverseMap();
            CreateMap<Database.AlbumListAlbum, Model.AlbumListAlbum>();
            CreateMap<Database.AlbumListAlbum, AlbumListAlbumUpsertRequest>().ReverseMap();
            CreateMap<Database.UserAlbumVote, Model.UserAlbumVote>();
            CreateMap<Database.UserAlbumVote, UserAlbumVoteUpsertRequest>().ReverseMap();
            CreateMap<Database.UserTrackVote, Model.UserTrackVote>();
            CreateMap<Database.UserTrackVote, UserTrackVoteUpsertRequest>().ReverseMap();
            CreateMap<Database.Review, Model.Review>();
            CreateMap<Database.Review, ReviewUpsertRequest>().ReverseMap();
            CreateMap<Database.LoginLogTable, Model.LoginLogTable>();
            CreateMap<Database.LoginLogTable, LoginLogUpsertRequest>().ReverseMap();
        }
    }
}
