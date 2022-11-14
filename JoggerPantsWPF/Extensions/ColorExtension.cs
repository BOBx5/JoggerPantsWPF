using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace JoggerPantsWPF.Extensions
{
    /// <summary>
    /// <see cref="ColorExtension"/> is a extension methods that converts a between '<see cref="System.Drawing.Color"/>' and '<see cref="System.Windows.Media.Color"/>'
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// Converts a '<see cref="System.Drawing.Color"/>' to a '<see cref="System.Windows.Media.Color"/>'
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static System.Drawing.Color AsDrawingColor(this System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        /// <summary>
        /// Converts a '<see cref="string"/>' to a '<see cref="System.Drawing.Color"/>'
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static System.Drawing.Color AsDrawingColor(this string color)
        {
            var value = new System.Drawing.ColorConverter().ConvertFromString(color);

            return (System.Drawing.Color)value;
        }
        /// <summary>
        /// Converts a '<see cref="System.Windows.Media.Color"/>' to a '<see cref="System.Drawing.Color"/>'
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color AsMediaColor(this System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        /// <summary>
        /// Converts a '<see cref="string"/>' to a '<see cref="System.Windows.Media.Color"/>'
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color AsMediaColor(this string color)
        {
            return (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color);
        }

    }
}
