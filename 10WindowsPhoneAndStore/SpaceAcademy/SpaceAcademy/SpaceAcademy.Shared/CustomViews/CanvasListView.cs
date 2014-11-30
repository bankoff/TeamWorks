using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace SpaceAcademy.CustomViews
{
    public class CanvasListView : ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var control = element as FrameworkElement;
            if (control == null)
            {
                return;
            }

            var topBinding = new Binding()
            {
                Path = new PropertyPath("Position.X")
            };

            control.SetBinding(Canvas.TopProperty, topBinding);

            var leftBinding = new Binding()
            {
                Path = new PropertyPath("Position.Y")
            };

            control.SetBinding(Canvas.LeftProperty, leftBinding);

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}