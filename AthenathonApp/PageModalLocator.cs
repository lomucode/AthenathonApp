using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;

namespace AthenathonApp.PageModels.Base
{
    public class PageModalLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModalLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            // Register pages and page models

            // Register services 
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();

        }

        public static Page CreatePageFor( Type pageModelType)
        {

        }
    }
}
