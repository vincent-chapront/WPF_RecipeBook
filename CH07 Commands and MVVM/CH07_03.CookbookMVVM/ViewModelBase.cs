using System.CodeDom;

namespace CH07_03.CookbookMVVM
{
    public abstract class ViewModelBase : ObservableObject
    { }

    public abstract class ViewModelBase<TModel> : ViewModelBase
    {
        private TModel _model;

        public TModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value, () => Model); }
        }
    }
}