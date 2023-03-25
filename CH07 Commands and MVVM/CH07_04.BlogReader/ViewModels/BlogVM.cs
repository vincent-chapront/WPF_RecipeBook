using CH07_03.CookbookMVVM;
using CH07_04.BlogReader.Models;
using CH07_04.BlogReader.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CH07_04.BlogReader.ViewModels
{
    internal class BlogVM : ViewModelBase<Blog>
    {
        private ICommand? _newPostCommand;

        public BloggerVM Blogger
        {
            get { return new BloggerVM { Model = Model.Blogger }; }
        }

        public ICommand NewPostCommand
        {
            get
            {
                return _newPostCommand ??=
                    new RelayCommand(() =>
                    {
                        var post = new BlogPostVM
                        {
                            Model = new BlogPost()
                        };
                        var dlg = new NewPostWindow
                        {
                            DataContext = post
                        };
                        if (dlg.ShowDialog() == true)
                        {
                            post.Model.When = DateTime.Now;
                            Model.Posts.Add(post.Model);
                            OnPropertyChanged("Posts");
                        }
                    });
            }
        }

        public IEnumerable<BlogPostVM> Posts
        {
            get
            {
                return Model.Posts.Select(post => new BlogPostVM { Model = post });
            }
        }
    }
}