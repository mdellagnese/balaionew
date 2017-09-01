using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaioCulturalNew.Models
{
    public class CustomMenuItem : BindableBase
    {        
        private string _uri;
        public string Uri
        {
            get { return _uri; }
            set { SetProperty(ref _uri, value); }
        }

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
