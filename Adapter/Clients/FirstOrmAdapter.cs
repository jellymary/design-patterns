using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public class FirstOrmAdapter : IOrmAdapter
    {
        private readonly IFirstOrm<DbUserEntity> _dbUserEntity;
        private readonly IFirstOrm<DbUserInfoEntity> _dbUserInfoEntity;

        public FirstOrmAdapter(IFirstOrm<DbUserEntity> dbUserEntity, IFirstOrm<DbUserInfoEntity> dbUserInfoEntity)
        {
            _dbUserEntity = dbUserEntity;
            _dbUserInfoEntity = dbUserInfoEntity;
        }

        public void AddUser(DbUserEntity user) => _dbUserEntity.Add(user);

        public void AddUserInfo(DbUserInfoEntity userInfo) => _dbUserInfoEntity.Add(userInfo);

        public DbUserEntity GetUser(int userId) => _dbUserEntity.Read(userId);

        public DbUserInfoEntity GetUserInfo(int userId) => _dbUserInfoEntity.Read(userId);

        public void RemoveUserInfo(int userId) => _dbUserInfoEntity.Delete(GetUserInfo(userId));

        public void RemoveUserAndInfo(int userId)
        {
            _dbUserEntity.Delete(GetUser(userId));
            _dbUserInfoEntity.Delete(GetUserInfo(userId));
        }
    }
}