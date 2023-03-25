using CH07_03.CookbookMVVM;
using System;

namespace CH07_04.BlogReader.Models
{
    internal class BlogComment : ObservableObject
    {
        private string _name = string.Empty;
        private string _text = string.Empty;
        private DateTime _when;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value, () => Name); }
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value, () => Text); }
        }

        public DateTime When
        {
            get { return _when; }
            set { SetProperty(ref _when, value, () => When); }
        }
    }
}