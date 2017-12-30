using System;
using Xamarin.Forms;

namespace Zwaby.CustomControls
{
    public class ExtendedTimePicker : TimePicker
    {
        /// <summary>
        /// The HasBorder property
        /// </summary>
        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create("HasBorder", typeof(bool), typeof(ExtendedTimePicker), true);

        /// <summary>
        /// The MinimumTime property
        /// </summary>
        public static readonly BindableProperty MinimumTimeProperty =
            BindableProperty.Create("MinimumTime", typeof(TimeSpan), typeof(ExtendedTimePicker), new TimeSpan(0, 0, 0));

        /// <summary>
        /// The MaximumTime property
        /// </summary>
        public static readonly BindableProperty MaximumTimeProperty =
            BindableProperty.Create("MaximumTime", typeof(TimeSpan), typeof(ExtendedTimePicker), new TimeSpan(24, 0, 0));

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedTimePicker"/> class.
        /// </summary>
        public ExtendedTimePicker()
        {
        }

        /// <summary>
        /// Gets or sets if the border should be shown or not
        /// </summary>
        /// <value><c>true</c> if this instance has border; otherwise, <c>false</c>.</value>
        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum time
        /// </summary>
        /// <value>The minimum time.</value>
        public TimeSpan MinimumTime
        {
            get { return (TimeSpan)GetValue(MinimumTimeProperty); }
            set { SetValue(MinimumTimeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum time
        /// </summary>
        /// <value>The maximum time.</value>
        public TimeSpan MaximumTime
        {
            get { return (TimeSpan)GetValue(MaximumTimeProperty); }
            set { SetValue(MaximumTimeProperty, value); }
        }
    }
}
