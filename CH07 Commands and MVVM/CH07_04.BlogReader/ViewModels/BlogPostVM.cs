using CH07_03.CookbookMVVM;
using CH07_04.BlogReader.Models;
using CH07_04.BlogReader.Views;
using System;
using System.Windows.Input;

namespace CH07_04.BlogReader.ViewModels
{
    internal class BlogPostVM : ViewModelBase<BlogPost>
    {
        private ICommand? _newCommentCommand;

        public bool IsPostOK
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Model.Title) && !string.IsNullOrWhiteSpace(Model.Text);
            }
        }

        public ICommand NewCommentCommand
        {
            get
            {
                return _newCommentCommand ??=
                    new RelayCommand(() =>
                    {
                        var comment = new BlogComment();
                        var dlg = new NewCommentWindow { DataContext = new BlogCommentVM { Model = comment } };
                        if (dlg.ShowDialog() == true)
                        {
                            comment.When = DateTime.Now;
                            Model.Comments.Add(comment);
                        }
                    });
            }
        }

        public string Text
        {
            get { return Model.Text; }
            set
            {
                Model.Text = value;
                OnPropertyChanged("IsPostOK");
            }
        }

        public string Title
        {
            get { return Model.Title; }
            set
            {
                Model.Title = value;
                OnPropertyChanged("IsPostOK");
            }
        }
    }
}