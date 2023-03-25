using CH07_03.CookbookMVVM;
using CH07_04.BlogReader.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CH07_04.BlogReader.ViewModels
{
    internal class MainVM : ViewModelBase<IEnumerable<Blog>>
    {
        private BlogVM? _selectedBlog;

        public MainVM(IEnumerable<Blog> blogs)
        {
            Model = new ObservableCollection<Blog>(blogs);
        }

        public IEnumerable<BlogVM> Blogs
        {
            get
            {
                return Model.Select(blog => new BlogVM { Model = blog });
            }
        }

        public Visibility IsSelectedBlog
        {
            get
            {
                return SelectedBlog != null ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public BlogVM SelectedBlog
        {
            get { return _selectedBlog; }
            set
            {
                if (SetProperty(ref _selectedBlog, value, () => SelectedBlog))
                {
                    OnPropertyChanged("IsSelectedBlog");
                }
            }
        }
    }
}