using System;
using System.Windows;

namespace BlocklistUpdater.Core
{
    public class UpdateState : DependencyObject
    {
        /// <summary>
        /// Dependency property registration for the wrapper <see cref="Url"/> property.
        /// </summary>
        public static readonly DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(Uri), typeof(UpdateState));

        public Uri Url
        {
            get { return (Uri)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        /// <summary>
        /// Dependency property registration for the wrapper <see cref="ProgressPercentage"/> property.
        /// </summary>
        public static readonly DependencyProperty ProgressPercentageProperty = DependencyProperty.Register("ProgressPercentage", typeof(int), typeof(UpdateState));

        public int ProgressPercentage
        {
            get { return (int)GetValue(ProgressPercentageProperty); }
            set { SetValue(ProgressPercentageProperty, value); }
        }

        /// <summary>
        /// Dependency property registration for the wrapper <see cref="ProgressCaption"/> property.
        /// </summary>
        public static readonly DependencyProperty ProgressCaptionProperty = DependencyProperty.Register("ProgressCaption", typeof(string), typeof(UpdateState));

        public UpdateState()
        {
        }

        public UpdateState(Uri uri, string progressCaption, int progressPercentage)
        {
            Url = uri;
            ProgressCaption = progressCaption;
            ProgressPercentage = progressPercentage;
        }

        public string ProgressCaption
        {
            get { return (string)GetValue(ProgressCaptionProperty); }
            set { SetValue(ProgressCaptionProperty, value); }
        }
    }
}