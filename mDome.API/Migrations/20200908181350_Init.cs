using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mDome.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministratorLogin",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(maxLength: 25, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminId", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(maxLength: 100, nullable: false),
                    ArtistBio = table.Column<string>(nullable: true),
                    ArtistMembers = table.Column<string>(nullable: true),
                    ArtistPhoto = table.Column<byte[]>(nullable: true),
                    ArtistPhotoThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(maxLength: 25, nullable: false),
                    GenreDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(maxLength: 200, nullable: false),
                    AlbumDescription = table.Column<string>(nullable: true),
                    AlbumGeneratedRating = table.Column<double>(nullable: true, defaultValueSql: "((0))"),
                    AlbumPhoto = table.Column<byte[]>(nullable: true),
                    AlbumPhotoThumb = table.Column<byte[]>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false),
                    DateReleased = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_AlbumArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistGenre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenre", x => new { x.GenreId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_ArtistGenreArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistGenreGenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(maxLength: 200, nullable: false),
                    TrackViews = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    TrackYoutubeId = table.Column<string>(maxLength: 50, nullable: true),
                    TrackLyrics = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    AlbumId = table.Column<int>(nullable: false),
                    TrackNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_TrackAlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    About = table.Column<string>(nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    SuspendedFlag = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    RecommendedAlbum1 = table.Column<int>(nullable: true),
                    RecommendedAlbum2 = table.Column<int>(nullable: true),
                    RecommendedAlbum3 = table.Column<int>(nullable: true),
                    RecommendedArtist1 = table.Column<int>(nullable: true),
                    RecommendedArtist2 = table.Column<int>(nullable: true),
                    RecommendedArtist3 = table.Column<int>(nullable: true),
                    UserPhoto = table.Column<byte[]>(nullable: true),
                    UserWallpaper = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserRecommendedAlbum1",
                        column: x => x.RecommendedAlbum1,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecommendedAlbum2",
                        column: x => x.RecommendedAlbum2,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecommendedAlbum3",
                        column: x => x.RecommendedAlbum3,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecommendedArtist1",
                        column: x => x.RecommendedArtist1,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecommendedArtist2",
                        column: x => x.RecommendedArtist2,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecommendedArtist3",
                        column: x => x.RecommendedArtist3,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlbumList",
                columns: table => new
                {
                    AlbumListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumListName = table.Column<string>(maxLength: 100, nullable: false),
                    ListDateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UniqueKey = table.Column<string>(maxLength: 20, nullable: true),
                    AlbumListType = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "('Private')"),
                    AlbumListDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumList", x => x.AlbumListId);
                    table.ForeignKey(
                        name: "FK_AlbumListUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifText = table.Column<string>(nullable: false),
                    NotifDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_UserID",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestText = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    NameOfUser = table.Column<string>(maxLength: 25, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_RequestUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewText = table.Column<string>(nullable: false),
                    FavouriteSongs = table.Column<string>(nullable: true),
                    LeastFavouriteSongs = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewAlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracklist",
                columns: table => new
                {
                    TracklistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TracklistName = table.Column<string>(maxLength: 100, nullable: false),
                    ListDateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UniqueKey = table.Column<string>(maxLength: 20, nullable: true),
                    TracklistType = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "('Private')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracklist", x => x.TracklistId);
                    table.ForeignKey(
                        name: "FK_TracklistUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAlbumVote",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false),
                    Liked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAlbumVote", x => new { x.UserId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_UserAlbumVoteAlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAlbumVoteUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FollowedByUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => new { x.UserId, x.FollowedByUserId });
                    table.ForeignKey(
                        name: "FK_UserFollowersBy",
                        column: x => x.FollowedByUserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFollowersUser",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowsArtist",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowsArtist", x => new { x.UserId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_UserFollowsArtistArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFollowsArtistUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTrackVote",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    Liked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrackVote", x => new { x.UserId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_UserTrackVoteTrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTrackVoteUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlbumListAlbum",
                columns: table => new
                {
                    AlbumListId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumListAlbum", x => new { x.AlbumListId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_AlbumListAlbumA",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlbumListAlbumAL",
                        column: x => x.AlbumListId,
                        principalTable: "AlbumList",
                        principalColumn: "AlbumListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostText = table.Column<string>(nullable: false),
                    UserRelatedId = table.Column<int>(nullable: true),
                    ReviewRelatedId = table.Column<int>(nullable: true),
                    ArtistRelatedId = table.Column<int>(nullable: true),
                    IsGlobal = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    PostDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PostTitle = table.Column<string>(maxLength: 100, nullable: false),
                    PostPhoto = table.Column<byte[]>(nullable: true),
                    OPPhoto = table.Column<byte[]>(nullable: true),
                    AdminName = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostArtistRelatedId",
                        column: x => x.ArtistRelatedId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostReviewRelatedId",
                        column: x => x.ReviewRelatedId,
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostUserRelatedId",
                        column: x => x.UserRelatedId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TracklistTrack",
                columns: table => new
                {
                    TracklistId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TracklistTrack", x => new { x.TracklistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_TracklistTrackT",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TracklistTrackTL",
                        column: x => x.TracklistId,
                        principalTable: "Tracklist",
                        principalColumn: "TracklistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCommentPost",
                columns: table => new
                {
                    UserCommentPostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommentPost", x => x.UserCommentPostId);
                    table.ForeignKey(
                        name: "FK_UserCommentPostPostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCommentPostUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLikePost",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    Liked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikePost", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserLikePostPostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLikePostUserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "UQ__AlbumLis__2DE46E93D323461F",
                table: "AlbumList",
                column: "UniqueKey",
                unique: true,
                filter: "[UniqueKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumList_UserId",
                table: "AlbumList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumListAlbum_AlbumId",
                table: "AlbumListAlbum",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenre_ArtistId",
                table: "ArtistGenre",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ArtistRelatedId",
                table: "Post",
                column: "ArtistRelatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ReviewRelatedId",
                table: "Post",
                column: "ReviewRelatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserRelatedId",
                table: "Post",
                column: "UserRelatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserId",
                table: "Request",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_AlbumId",
                table: "Review",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumId",
                table: "Track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "UQ__Tracklis__2DE46E9327EC5917",
                table: "Tracklist",
                column: "UniqueKey",
                unique: true,
                filter: "[UniqueKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tracklist_UserId",
                table: "Tracklist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TracklistTrack_TrackId",
                table: "TracklistTrack",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlbumVote_AlbumId",
                table: "UserAlbumVote",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentPost_PostId",
                table: "UserCommentPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentPost_UserId",
                table: "UserCommentPost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowedByUserId",
                table: "UserFollowers",
                column: "FollowedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowsArtist_ArtistId",
                table: "UserFollowsArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikePost_PostId",
                table: "UserLikePost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RecommendedAlbum1",
                table: "UserProfile",
                column: "RecommendedAlbum1");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RecommendedAlbum2",
                table: "UserProfile",
                column: "RecommendedAlbum2");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RecommendedAlbum3",
                table: "UserProfile",
                column: "RecommendedAlbum3");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RecommendedArtist1",
                table: "UserProfile",
                column: "RecommendedArtist1");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RecommendedArtist2",
                table: "UserProfile",
                column: "RecommendedArtist2");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RecommendedArtist3",
                table: "UserProfile",
                column: "RecommendedArtist3");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrackVote_TrackId",
                table: "UserTrackVote",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorLogin");

            migrationBuilder.DropTable(
                name: "AlbumListAlbum");

            migrationBuilder.DropTable(
                name: "ArtistGenre");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "TracklistTrack");

            migrationBuilder.DropTable(
                name: "UserAlbumVote");

            migrationBuilder.DropTable(
                name: "UserCommentPost");

            migrationBuilder.DropTable(
                name: "UserFollowers");

            migrationBuilder.DropTable(
                name: "UserFollowsArtist");

            migrationBuilder.DropTable(
                name: "UserLikePost");

            migrationBuilder.DropTable(
                name: "UserTrackVote");

            migrationBuilder.DropTable(
                name: "AlbumList");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Tracklist");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
