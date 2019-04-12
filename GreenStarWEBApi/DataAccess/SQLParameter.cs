using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiServiceDataAccess
{
    /// <summary>
    /// SQLParameter class
    /// </summary>
    public class SQLParameter
    {
        #region Fields

        private DbType _dbType;
        private String _name;
        private Object _value;
        private int _size;
        private ParameterDirection _direction;
        //private NpgsqlDbType _npgSQLDBType;

        #endregion

        #region Properties

        public DbType Type { get { return _dbType; } set { _dbType = value; } }
        public String Name { get { return _name; } set { _name = value; } }
        public Object Value { get { return _value; } set { _value = value; } }
        public int Size { get { return _size; } set { _size = value; } }
        public ParameterDirection Direction { get { return _direction; } set { _direction = value; } }
        //public NpgsqlDbType NpgSQLDBType { get { return _npgSQLDBType; } set { _npgSQLDBType = value; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="type">DB type</param>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <param name="size">Size</param>
        /// <param name="direction">Parameter direction</param>
        public SQLParameter(DbType type, String name, Object value, int size, ParameterDirection direction)
        {
            _dbType = type;
            _name = name;
            _value = value;
            _size = size;
            _direction = direction;
        }

        //public SQLParameter(NpgsqlDbType type, String name, Object value, int size, ParameterDirection direction)
        //{
        //    _npgSQLDBType = type;
        //    _name = name;
        //    _value = value;
        //    _size = size;
        //    _direction = direction;
        //}

        #endregion
    }
}
