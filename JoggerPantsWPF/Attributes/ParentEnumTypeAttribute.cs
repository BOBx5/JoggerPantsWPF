using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggerPantsWPF.Attributes
{
    /// <summary>
    /// Set the parent enum type of the enum value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ParentEnumTypeAttribute : System.Attribute
    {
        public Enum ParentEnum { get; init; }
        public ParentEnumTypeAttribute(Enum parentEnumType)
        {
            this.ParentEnum = parentEnumType;
        }
    }

    /// <summary>
    /// Set the parent enum type of the enum value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParentEnumTypeAttribute<T> : System.Attribute where T : Enum
    {
        public T ParentEnum { get; init; }
        public ParentEnumTypeAttribute(T parentEnumType)
        {
            this.ParentEnum = parentEnumType!;
        }
    }
}
