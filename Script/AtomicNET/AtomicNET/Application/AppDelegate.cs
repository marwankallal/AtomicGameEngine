using System;
using System.Reflection;
using System.Linq;

namespace AtomicEngine
{

    public class AppDelegate
    {
        static Application application;

        public static Application Application
        {
            get
            {
                if (application == null)
                    throw new InvalidOperationException("The application is not configured yet");
                return application;
            }
            private set { application = value; }
        }

        public static bool HasApplication => application != null;

        public static T CreateInstance<T>(AppOptions options = null) where T : AppDelegate
        {
            return (T)CreateInstance(typeof(T), options);
        }

        public static AppDelegate CreateInstance(Type applicationType, AppOptions options = null)
        {
            var ctors = applicationType.GetTypeInfo().DeclaredConstructors.ToArray();

            var ctorWithOptions = ctors.FirstOrDefault(c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(AppOptions));
            if (ctorWithOptions != null)
            {
                return (AppDelegate)Activator.CreateInstance(applicationType, options);
            }

            var ctorDefault = ctors.FirstOrDefault(c => c.GetParameters().Length == 0);
            if (ctorDefault != null)
            {
                return (AppDelegate)Activator.CreateInstance(applicationType);
            }

            throw new InvalidOperationException($"{applicationType} doesn't have parameterless constructor.");
        }

    }

}
