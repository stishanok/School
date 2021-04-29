using System.Data;

namespace Model.Entity
{
    public interface IAbstractDAO
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection connection);
    }
}