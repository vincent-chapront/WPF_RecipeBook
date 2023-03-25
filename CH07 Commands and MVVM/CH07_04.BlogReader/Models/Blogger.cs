using CH07_03.CookbookMVVM;
using System.IO;

namespace CH07_04.BlogReader.Models
{
    internal class Blogger : ObservableObject
    {
        private string _email = string.Empty;
        private string _name = string.Empty;
        private Stream _picture;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value, () => Email); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value, () => Name); }
        }

        public Stream Picture
        {
            get { return _picture; }
            set { SetProperty(ref _picture, value, () => Picture); }
        }
    }
}