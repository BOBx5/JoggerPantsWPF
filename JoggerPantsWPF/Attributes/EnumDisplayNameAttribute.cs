using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggerPantsWPF.Attributes
{
    /// <summary>
    /// <see cref="EnumDisplayNameAttribute"/> is a attribute that is used to display a enum value as a string
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : System.Attribute
    {
        public string Name { get; init; }
        public EnumDisplayNameAttribute(string diplayName)
        {
            this.Name = diplayName;
        }
    }
}
