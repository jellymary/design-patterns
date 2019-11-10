using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public interface IOrmAdapter // ITarget
    {
        void AddUser(DbUserEntity user);
        void AddUserInfo(DbUserInfoEntity userInfo);
        DbUserEntity GetUser(int userId);
        DbUserInfoEntity GetUserInfo(int userId);
        void RemoveUserInfo(int userId);
        void RemoveUserAndInfo(int userId);
    }
}
