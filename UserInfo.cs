//Add "Micron.Security.net into References
//Import Micron library
using Micron.Web.Security;

namespace YourApplication.Classes.Helpers
{
    public class UserInfo
    {
        public static string GetUser()
        {
			      string path;
            path = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (path.ToLower().Contains("c:\\"))
            {
                var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                if (user.Contains("\\"))
                    user = user.Split('\\')[1]; // Strip the domain if present

				        return user;
            }
            else
            {
                SiteMinder siteMinder = new SiteMinder();
                return siteMinder.GetUsername();
            }
        }
     }
}
