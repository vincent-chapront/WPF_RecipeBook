using CH07_03.CookbookMVVM;
using CH07_04.BlogReader.Models;

namespace CH07_04.BlogReader.ViewModels
{
    internal class BlogCommentVM : ViewModelBase<BlogComment>
    {
        public bool IsCommentOK
        {
            get { return !string.IsNullOrWhiteSpace(Model.Name) && !string.IsNullOrWhiteSpace(Model.Text); }
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                OnPropertyChanged("IsCommentOK");
            }
        }

        public string Text
        {
            get { return Model.Text; }
            set
            {
                Model.Text = value;
                OnPropertyChanged("IsCommentOK");
            }
        }
    }
}