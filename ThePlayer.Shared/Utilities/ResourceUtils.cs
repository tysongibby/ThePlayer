using System.Windows;
//using System.Windows.Media;

namespace ThePlayer.Shared.Utilities
{
    public static class ResourceUtils
    {
        /// <summary>
        /// Gets a string resource for the current application
        /// </summary>
        /// <param name="resourceName">The resource's name</param>
        /// <returns>The resources string content</returns>
        public static string GetString(string resourceName)
        {
            //TODO: fixe System.Windows reference
            //object resource = Application.Current.TryFindResource(resourceName);
            object resource = "TODO: ResourceUtils.cs line 16 - fix System.Windows reference";
            return resource == null ? resourceName : resource.ToString();
        }

        /// <summary>
        /// Gets a Geometry resource for the current application
        /// </summary>
        /// <param name="resourceName">The resource's name</param>
        /// <returns>The resources Geometry content</returns>
        /// <returns></returns>
        public static string GetGeometry(string resourceName)
        {
            //function used to return "Geometry type: used to render 2D graphic data"
            //TODO: fix System.Windows.Media reference
            //return (Geometry)Application.Current.TryFindResource(resourceName);
            return "TODO: ResourceUtils.cs line 30 - fix System.Windows.Media reference";
        }
    }
}
