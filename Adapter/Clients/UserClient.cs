using System.Linq;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private readonly IOrmAdapter _ormAdapter;
        
        public UserClient(IOrmAdapter ormAdapter) => _ormAdapter = ormAdapter;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId) => (_ormAdapter.GetUser(userId), _ormAdapter.GetUserInfo(userId));

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _ormAdapter.AddUser(user);
            _ormAdapter.AddUserInfo(userInfo);
        }

        public void Remove(int userId) => _ormAdapter.RemoveUserAndInfo(userId);
    }
}
