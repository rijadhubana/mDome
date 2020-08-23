using mDome.MobileApp.Helper;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class CommentsLikesViewModel : BaseViewModel
    {
        private readonly APIService _commentService = new APIService("UserCommentPost");
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _userLikePostService = new APIService("UserLikePost");
        private readonly APIService _postService = new APIService("Post");
        private readonly APIService _notificationService = new APIService("Notification");
        public CommentsLikesViewModel()
        {
            Init = new Command(async () => await LoadCommentsLikes());
            SubmitCommentCommand = new Command(async () => await SubmitComment());
        }
        public ICommand Init { get; set; }
        public ICommand SubmitCommentCommand { get; set; }
        public int postId { get; set; }
        public ObservableCollection<CommentHelperVM> Comments { get; set; } = new ObservableCollection<CommentHelperVM>();
        public ObservableCollection<UserProfile> Likes { get; set; } = new ObservableCollection<UserProfile>();
        public List<UserProfile> AllUsers { get; set; }
        string _newCommentText;
        public string NewCommentText
        {
            get
            {
                return _newCommentText;
            }

            set
            {
                _newCommentText = value;
                OnPropertyChanged("NewCommentText");
            }
        }
        Model.UserProfile _selectedUser;
        public Model.UserProfile SelectedUser
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        CommentHelperVM _selectedCommenter;
        public CommentHelperVM SelectedCommenter
        {
            get
            {
                return _selectedCommenter;
            }

            set
            {
                _selectedCommenter = value;
                OnPropertyChanged("SelectedCommenter");
            }
        }
        private async Task SubmitComment()
        {
            if (string.IsNullOrWhiteSpace(NewCommentText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "To submit a comment, you must first type into the textbox", "OK");
                return;
            }
            UserCommentPostUpsertRequest request = new UserCommentPostUpsertRequest()
            {
                CommentDate = DateTime.Now,
                CommentText = NewCommentText,
                PostId = postId,
                UserId = APIService.loggedProfile.UserId
            };
            await _commentService.Insert<Model.UserCommentPost>(request);
            var thisPost = await _postService.GetById<Model.Post>(postId);
            if (thisPost.UserRelatedId.HasValue && APIService.loggedProfile.UserId!=thisPost.UserRelatedId)
            {
                await _notificationService.Insert<Model.Notification>(new NotificationUpsertRequest()
                {
                    NotifDateTime = DateTime.Now,
                    NotifText = APIService.loggedProfile.Username + " commented on your post: " + thisPost.PostTitle,
                    UserId = (int)thisPost.UserRelatedId
                });
            }
            NewCommentText = "";
            await LoadComments();
        }
        private async Task LoadComments()
        {
            Comments.Clear();
            var result = await _commentService.Get<List<Model.UserCommentPost>>(new UserCommentPostSearchRequest()
            {
                PostId = postId
            });
            AllUsers = await _userService.Get<List<Model.UserProfile>>(null);
            foreach (var item in result)
            {
                CommentHelperVM local = new CommentHelperVM()
                {
                    CommentDate = item.CommentDate,
                    CommentText = item.CommentText,
                    PostId = item.PostId,
                    UserId = item.UserId
                };
                local.CommenterPhoto = AllUsers.Where(a => a.UserId == item.UserId).Select(a => a.UserPhoto).FirstOrDefault();
                local.CommenterName = AllUsers.Where(a => a.UserId == item.UserId).Select(a => a.Username).FirstOrDefault();
                Comments.Add(local);
            }
            Comments.OrderBy(x => x.CommentDate);
        }
        private async Task LoadLikes()
        {
            var result = await _userLikePostService.Get<List<Model.UserLikePost>>(new UserLikePostSearchRequest() { Liked = true, PostId = postId });
            foreach (var item in result)
                Likes.Add(AllUsers.Where(a => a.UserId == item.UserId).FirstOrDefault());
        }
        private async Task LoadCommentsLikes()
        {
            await LoadComments();
            await LoadLikes();
        }
    }
}
