using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServiceDataAccess
{
    /// <summary>
    /// ISession interface
    /// </summary>
    public interface ISession : IDbConnection
    {
        #region Properties

        IDbConnection Connection { get; set; }
        bool HasTransaction { get; }
        IDbTransaction Transaction { get; set; }

        #endregion

        #region Methods

        void CommitTransaction();
        bool OpenTransactionIfNot();
        void RollbackTransaction();

        #endregion
    }
}
