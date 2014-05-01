using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiki.Common.Util
{
    [global::System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class MappingSettingsAttribute : Attribute
    {
        public enum MappingType { Simple, Complex };

        // See the attribute guidelines at 
        // http://go.microsoft.com/fwlink/?LinkId=85236
        readonly bool _required;
        readonly string _columnName;
        readonly MappingType _type;

        public MappingSettingsAttribute(bool required)
            : this(required, String.Empty, MappingType.Simple)
        {
        }
        public MappingSettingsAttribute(bool required, MappingType type)
            : this(required, String.Empty, type)
        {
        }
        public MappingSettingsAttribute(string columnName)
            : this(true, columnName, MappingType.Simple)
        {
        }

        public MappingSettingsAttribute(bool required, string columnName, MappingType type)
        {
            this._required = required;
            this._columnName = columnName;
            this._type = type;
        }

        public bool Required
        {
            get
            {
                return _required;
            }
        }

        public string ColumName
        {
            get
            {
                return _columnName;
            }

        }
        public MappingType Type
        {
            get
            {
                return _type;
            }
        }
    }
}
