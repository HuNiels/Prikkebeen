
using Microsoft.AspNetCore.Http;

namespace Acupunctuur.Business {
    public class SessionManager {
        private readonly ISession sess;

        public const string NAME = "NAME";
        public const string ID = "USER_ID";
        public const string ADMIN = "ADMIN";

        public SessionManager(IHttpContextAccessor accessor) {
            sess = accessor.HttpContext.Session;
        }

        public void Login(int userId, string name, bool isAdmin) {
            sess.SetInt32(ID, userId);
            sess.SetString(NAME, name);
            sess.SetString(ADMIN, isAdmin.ToString());
        }

        public void Logout() {
            sess.Remove(ID);
            sess.Remove(NAME);
            sess.Remove(ADMIN);
        }

        public bool IsLoggedIn() {
            return sess.GetInt32(ID) != null && sess.GetString(NAME) != null;
        }

        public bool IsAdmin() {
            bool isAdmin;
            bool.TryParse(sess.GetString(ADMIN), out isAdmin);
            return isAdmin;
        }

        public string GetUserName() {
            return sess.GetString(NAME);
        }

        public int GetUserId() {
            int? id = sess.GetInt32(ID);
            return id == null ? -1 : (int)id;
        }
    }
}
