using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfControlLibrary.Helpers
{
    /// <summary>
    /// IFileDragDropTarget Interface. This interface is used to define a target that can accept file drag and drop.
    /// </summary>
    public interface IFileDragDropTarget
    {
        void OnFileDrop(string[] filepaths);
    }
    
    public class FileDragDropHelper
    {
        public static readonly DependencyProperty IsFileDragDropEnabledProperty =
                DependencyProperty.RegisterAttached("IsFileDragDropEnabled", typeof(bool), typeof(FileDragDropHelper), new PropertyMetadata(OnFileDragDropEnabled));

        public static readonly DependencyProperty FileDragDropTargetProperty =
                DependencyProperty.RegisterAttached("FileDragDropTarget", typeof(object), typeof(FileDragDropHelper), null);

        /// <summary>
        /// Gets the value of the IsFileDragDropEnabled property.
        /// </summary>
        public static bool GetIsFileDragDropEnabled(DependencyObject obj) 
            => (bool)obj.GetValue(IsFileDragDropEnabledProperty);

        /// <summary>
        /// Sets the value of the IsFileDragDropEnabled property.
        /// </summary>
        public static void SetIsFileDragDropEnabled(DependencyObject obj, bool value) 
            => obj.SetValue(IsFileDragDropEnabledProperty, value);

        /// <summary>
        /// Gets the value of the FileDragDropTarget property.
        /// </summary>
        public static bool GetFileDragDropTarget(DependencyObject obj) 
            => (bool)obj.GetValue(FileDragDropTargetProperty);

        /// <summary>
        /// Sets the value of the FileDragDropTarget property.
        /// </summary>
        public static void SetFileDragDropTarget(DependencyObject obj, bool value) 
            => obj.SetValue(FileDragDropTargetProperty, value);

        /// <summary>
        /// OnFileDragDropEnabled is called when the IsFileDragDropEnabled property is changed.
        /// </summary>
        private static void OnFileDragDropEnabled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue) 
                return;

            if (d is Control control && control != null) 
                control.Drop += OnDrop;
        }
        
        private static void OnDrop(object _sender, DragEventArgs _dragEventArgs)
        {
            if (_sender is DependencyObject d && d != null)
            {
                object target = d.GetValue(FileDragDropTargetProperty);

                if (target is IFileDragDropTarget fileTarget && fileTarget != null)
                {
                    if (_dragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        fileTarget.OnFileDrop((string[])_dragEventArgs.Data.GetData(DataFormats.FileDrop));
                    }
                }
                else
                    throw new Exception("FileDragDropTarget object must be of type IFileDragDropTarget");
            }
            else
                return;
        }
    }
}
