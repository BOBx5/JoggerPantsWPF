using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace JoggerPantsWPF.Attributes
{
    /// <summary>
    /// Enum에 할당된 이미지
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayImageAttribute : System.Attribute
    {
        private static ResourceManager _resourceManager = null;
        private static ResourceManager ResourceManager 
            => _resourceManager ?? throw new NullReferenceException($"{nameof(EnumDisplayImageAttribute)}.{nameof(_resourceManager)} is null. You must initialize the resource manager before using it.");
        

        /// <summary>
        /// Get the image from the resource as <see cref="Image"/>.
        /// </summary>
        public Image Image
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Source))
                {
                    object obj = ResourceManager?.GetObject(this.Source, System.Globalization.CultureInfo.CurrentCulture);
                    if (obj != null && obj is Image img)
                    {
                        return img;
                    }
                }
                return null;
            }
        }
        
        /// <summary>
        /// Get the image from the resource as <see cref="Bitmap"/>.
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Source))
                {
                    object obj = ResourceManager?.GetObject(this.Source, System.Globalization.CultureInfo.CurrentCulture);
                    if (obj != null && obj is Bitmap img)
                    {
                        return img;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// <paramref name="Source"/> is the name of the image in the resource.
        /// </summary>
        public string Source { get; init; }
        
        public EnumDisplayImageAttribute(string source)
        {
            this.Source = source;
        }

        public static void InitResource(ResourceManager resx)
        {
            _resourceManager = resx;
        }
    }
}
