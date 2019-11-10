using System.Linq;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class SecondOrmAdapter : IOrmAdapter
    {
        private readonly ISecondOrm _secondOrm;

        public SecondOrmAdapter(ISecondOrm secondOrm) => _secondOrm = secondOrm;

        public void AddUser(DbUserEntity user) => _secondOrm.Context.Users.Add(user);

        public void AddUserInfo(DbUserInfoEntity userInfo) => _secondOrm.Context.UserInfos.Add(userInfo);

        public DbUserEntity GetUser(int userId) => _secondOrm.Context.Users.First(z => z.Id == userId);

        public DbUserInfoEntity GetUserInfo(int userId) => _secondOrm.Context.UserInfos.First(z => z.Id == userId);

        public void RemoveUserInfo(int userId) => _secondOrm.Context.UserInfos.Remove(GetUserInfo(userId));

        public void RemoveUserAndInfo(int userId)
        {
            _secondOrm.Context.Users.Remove(GetUser(userId));
            _secondOrm.Context.UserInfos.Remove(GetUserInfo(userId));
        }
    }
}