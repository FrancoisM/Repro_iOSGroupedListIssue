using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ReproiOSGroupedListIssuer.Shared
{
    public class GroupedSourceBehavior
    {
        public static object GetItemsSource(ItemsControl obj) => (object)obj.GetValue(ItemsSourceProperty);

        public static void SetItemsSource(ItemsControl obj, object value) => obj.SetValue(ItemsSourceProperty, value);

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.RegisterAttached("ItemsSource", typeof(object), typeof(GroupedSourceBehavior), new PropertyMetadata(null, OnItemsSourceChanged));

        private static void OnItemsSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is ItemsControl itemsControl)) return;
            var source = new CollectionViewSource
            {
                Source = args.NewValue,
                IsSourceGrouped = true
            };
            itemsControl.ItemsSource = source.View;
        }
    }
}