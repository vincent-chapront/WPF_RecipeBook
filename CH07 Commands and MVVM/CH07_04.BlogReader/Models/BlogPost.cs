using CH07_03.CookbookMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CH07_04.BlogReader.Models
{
    internal class BlogPost : ObservableObject
    {
        private readonly ObservableCollection<BlogComment> _comments = new();
        private string _text = string.Empty;
        private string _title = string.Empty;
        private DateTime _when;

        public IList<BlogComment> Comments
        {
            get
            {
                return _comments;
            }
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value, () => Text); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        public DateTime When
        {
            get { return _when; }
            set { SetProperty(ref _when, value, () => When); }
        }
    }
}