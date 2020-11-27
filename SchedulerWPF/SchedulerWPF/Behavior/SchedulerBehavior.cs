using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;

namespace WpfScheduler
{
    public class SchedulerBehavior : Behavior<SfScheduler>
    {
        SfScheduler scheduler;
        protected override void OnAttached()
        {
            base.OnAttached();
            scheduler = this.AssociatedObject;
            this.AssociatedObject.TimelineViewSettings.TimeInterval = new TimeSpan(24, 0, 0);
            this.AssociatedObject.DisplayDate = this.FindFirstDateofWeek();
        }
        private DateTime FindFirstDateofWeek()
        {
            var currentDay = (int)DateTime.Now.DayOfWeek;
            return DateTime.Now.Date.AddDays(-currentDay);
        }
    }
}

