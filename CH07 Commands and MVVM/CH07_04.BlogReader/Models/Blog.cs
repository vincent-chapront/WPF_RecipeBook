using CH07_03.CookbookMVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CH07_04.BlogReader.Models
{
    internal class Blog : ObservableObject
    {
        private readonly ObservableCollection<BlogPost> _posts = new();
        private Blogger _blogger;
        private string _blogTitle = string.Empty;

        public Blogger Blogger
        {
            get { return _blogger; }
            set { SetProperty(ref _blogger, value, () => Blogger); }
        }

        public string BlogTitle
        {
            get { return _blogTitle; }
            set { SetProperty(ref _blogTitle, value, () => BlogTitle); }
        }

        public IList<BlogPost> Posts
        {
            get { return _posts; }
        }
    }
}