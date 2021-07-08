using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private List<string> currentDayMeetings;
        private ScheduleAppointmentCollection events;
        private List<Brush> ColorCollection;
        internal List<string> nameCollection;
        private ObservableCollection<object> employees;
        public SchedulerViewModel()
        {
            this.events = new ScheduleAppointmentCollection();
            this.employees = new ObservableCollection<object>();
            this.InitializeDataForBookings();
            this.CreateResources();
            this.CreateResourceAppointments();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ScheduleAppointmentCollection Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                this.RaiseOnPropertyChanged("Events");
            }
        }
        public ObservableCollection<object> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                this.RaiseOnPropertyChanged("Employees");
            }
        }
        private void CreateResources()
        {
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                Employees.Add(new Employee()
                {
                    Name = nameCollection[i],
                    BackgroundBrush = this.ColorCollection[random.Next(8)],
                    ID = "560" + i.ToString(),
                    ImageSource = "People_Circle" + i.ToString() + ".png"
                });
            }
        }
        private void CreateResourceAppointments()
        {
            Random random = new Random();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddYears(-1).AddDays(-20);
            DateTime dateTo = DateTime.Now.AddYears(1).AddDays(20);
            foreach (var resource in Employees)
            {
                for (date = dateFrom; date < dateTo; date = date.AddDays(1))
                {
                    ScheduleAppointment workDetails = new ScheduleAppointment();
                    workDetails.StartTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    workDetails.EndTime = workDetails.StartTime.AddHours(1);
                    workDetails.Subject = this.currentDayMeetings[random.Next(6)];
                    workDetails.AppointmentBackground = workDetails.Subject == "Work" ? new SolidColorBrush(Colors.Green) : (workDetails.Subject == "Off" ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.Red));
                    workDetails.IsAllDay = true;
                    workDetails.ResourceIdCollection = new ObservableCollection<object>
                        {
                            (resource as Employee).ID
                        };
                    this.Events.Add(workDetails);
                }
            }
        }
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Leave");
            this.currentDayMeetings.Add("Off");
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Work");

            this.nameCollection = new List<string>();
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Danial Addison");

            this.nameCollection.Add("Brooklyn");

            this.ColorCollection = new List<Brush>();
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    

