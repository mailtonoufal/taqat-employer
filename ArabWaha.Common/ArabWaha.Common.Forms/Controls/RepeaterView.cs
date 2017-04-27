using ArabWaha.Common.Forms.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Controls
{
    public class RepeaterView : StackLayout
    {

        public RepeaterView() { }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create<RepeaterView, DataTemplate>(
                p => p.ItemTemplate,
                default(DataTemplate));

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<RepeaterView, IEnumerable>(
                p => p.ItemsSource,
                Enumerable.Empty<object>(),
                BindingMode.OneWay,
                null,
                ItemsChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private static void ItemsChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var repeater = (RepeaterView)bindable;
            repeater.Children.Clear();

            var dataTemplate = repeater.ItemTemplate;

            if (newvalue == null)
                return;

            foreach (object viewModel in newvalue)
            {
                var content = dataTemplate.CreateContent();
                if (!(content is View) && !(content is ViewCell))
                {
                    throw new InvalidVisualObjectException(content.GetType(),  nameof(content));
                }

                var view = (content is View) ? content as View : ((ViewCell)content).View;
                view.BindingContext = viewModel;

                repeater.Children.Add(view);
            }
        }
    }
}
