using System;
using System.Data;

namespace Wiki.DataBase
{
    [Serializable()]
    public class DataAccessParameter
    {
        private string _name;
        private object _value;
        private ParameterDirection _direction;
        private Type _type;
        private int? _size;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public ParameterDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public Type Type
        {
            get
            {
                if ((_type == null & _value != null))
                {
                    return _value.GetType();
                }
                else
                {
                    return _type;
                }
            }
            set
            {
                _type = value;
            }
        }

        public int? Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
      
        /// <description> 
        /// Default constructor 
        /// </description> 
        /// <raiseErrors></raiseErrors> 
        public DataAccessParameter()
            : this(String.Empty, null, null, ParameterDirection.Input)
        {
        }

        public DataAccessParameter(string name, object value, Type type)
            : this(name, value, type, ParameterDirection.Input)
        {
        }


        public DataAccessParameter(string name, Type type, ParameterDirection direction)
            : this(name, null, type, direction)
        {
        }

        public DataAccessParameter(string name, object value, Type type, int size)
            : this(name, value, type, size, ParameterDirection.Input)
        {
        }


        public DataAccessParameter(string name, Type type, int? size, ParameterDirection direction)
            : this(name, null, type, size, direction)
        {
        }

        public DataAccessParameter(string name, object value, Type type, ParameterDirection direction)
            : this(name, value, type, Int32.MinValue, direction)
        {
        }

        public DataAccessParameter(string name, object value, Type type, int? size, ParameterDirection direction)
        {
            _name = name;
            _value = value;
            _direction = direction;
            _type = type;
            _size = size;
        }
    }
}