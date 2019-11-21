using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> activities = new List<Activity>(); //create list to hold all activities available
        List<Activity> selActivities = new List<Activity>();
        List<Activity> filActivities = new List<Activity>();
        decimal total = 0.00m;
        bool filters = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {

            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            //add the above activities to the all activities list
            activities.Add(l1);
            activities.Add(l2);
            activities.Add(l3);
            activities.Add(w1);
            activities.Add(w2);
            activities.Add(w3);
            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);

            activities.Sort();  //sorts the all activities list by date order using the icomparable compareTo
            lstbxAllActivities.ItemsSource = activities; //assign All activities list as the itemsource for the appropiate listbox
            lstBxSelectedActivities.ItemsSource = selActivities;
        }

        private void lstbxAllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //will allow for an object to be selected from the list and display the description in the txtBlkDescription text block
            Activity selected = lstbxAllActivities.SelectedItem as Activity;
            if (selected != null)
                txtBlkDescription.Text = selected.Description;
        }

        private void lstBxSelectedActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //will allow for an object to be selected from the list and display the description in the txtBlkDescription text block
            Activity selected = lstBxSelectedActivities.SelectedItem as Activity;
            if (selected != null)
                txtBlkDescription.Text = selected.Description;
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            //will add the object selected from AllActivities to selActivities list
            Activity selectedActivity = lstbxAllActivities.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                //move activity to selActivities list
                activities.Remove(selectedActivity);
                selActivities.Add(selectedActivity);
                if (filters == false)
                {
                    SortAndDisplayLists();
                }
                if (filters == true)
                {
                    SortAndDisplayFilteredLists();
                }
                //var duplicates = selActivities.GroupBy(item => item.ActivityDate).Where(g => g.Count() > 1).Select(g => g.Key);
                //if (duplicates.Count() > 0)
                //{
                //    txtBlkDescription.Text = "Date Conflict detected";
                //}
            }
            if (selectedActivity == null)
                txtBlkDescription.Text = "Nothing has been selected";
            
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            //will remove the object selected from selected Activities list and put it back in the AllActivities list
            Activity selectedActivity = lstBxSelectedActivities.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                //move selected activity back to the All Activities list
                selActivities.Remove(selectedActivity);
                activities.Add(selectedActivity);
                if (filters == false)
                {
                    SortAndDisplayLists();
                }
                if (filters == true)
                {
                    SortAndDisplayFilteredLists();
                }
            }
            if (selectedActivity == null)
                txtBlkDescription.Text = "Nothing has been selected";
            
        }
        public void totalCost()   //method to total up and display costs for selected activities
        {
            total = selActivities.Sum(item => item.Cost);
            txtBlkTotalCost.Text = $"{total:#.00}";
        }

        private void SortAndDisplayLists()
        {
            lstbxAllActivities.ItemsSource = null;
            activities.Sort();
            lstbxAllActivities.ItemsSource = activities;

            lstBxSelectedActivities.ItemsSource = null;
            selActivities.Sort();
            lstBxSelectedActivities.ItemsSource = selActivities;
            totalCost();
            var duplicates = selActivities.GroupBy(item => item.ActivityDate).Where(g => g.Count() > 1).Select(g => g.Key);
            if (duplicates.Count() > 0)
            {
                txtBlkDescription.Text = "Date Conflict detected";
            }

        }

        private void SortAndDisplayFilteredLists()
        {
            lstbxAllActivities.ItemsSource = null;
            filActivities.Sort();
            lstbxAllActivities.ItemsSource = filActivities;

            lstBxSelectedActivities.ItemsSource = null;
            selActivities.Sort();
            lstBxSelectedActivities.ItemsSource = selActivities;
            totalCost();
            var duplicates = selActivities.GroupBy(item => item.ActivityDate).Where(g => g.Count() > 1).Select(g => g.Key);
            if (duplicates.Count() > 0)
            {
                txtBlkDescription.Text = "Date Conflict detected";
            }

        }

        private void rBtnAll_Click(object sender, RoutedEventArgs e)
        {
            //clear filActivities list first
            filActivities.Clear();

            if (rBtnAll.IsChecked == true)
            {
                //display and sort both unfiltered lists
                SortAndDisplayLists();
                filters = false;
            }
            else if (rBtnLand.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filActivities.Add(activity);
                        filters = true;
                        //SortAndDisplayFilteredLists();
                    }
                }
                SortAndDisplayFilteredLists();
            }
            else if (rBtnWater.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filActivities.Add(activity);
                        filters = true;
                        //SortAndDisplayFilteredLists();
                    }
                }
                SortAndDisplayFilteredLists();
            }
            else if (rBtnAir.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filActivities.Add(activity);
                        filters = true;
                        //SortAndDisplayFilteredLists();                       
                    }
                }
                SortAndDisplayFilteredLists();
            }
        }

    }
}