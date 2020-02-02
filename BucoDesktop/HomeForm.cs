using Buco.Data;
using System;
using System.Windows.Forms;
using BucoDesktop.Views;

namespace BucoDesktop
{
    public partial class HomeForm : Form
    {
        private readonly ApplicationDbContext _dataContext;
        public HomeForm(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
            InitializeComponent();
            Icon = new System.Drawing.Icon("icon.ico");
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var petView = new PetsView(_dataContext);
            petView.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mealEntryView = new MealEntriesView(_dataContext);
            mealEntryView.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var petView = new PetsView(_dataContext);
            petView.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var weightEntryView = new WeightEntiesView(_dataContext);
            weightEntryView.ShowDialog();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ActivityTypesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var activityChildForm = new ActivityTypesForm(_dataContext);
            activityChildForm.ShowDialog();
        }

        private void PetTypesLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var petTypeChildForm = new PetTypesView(_dataContext);
            petTypeChildForm.ShowDialog();
        }

        private void activityEntriesLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var activityEntryView = new ActivityEntriesView(_dataContext);
            activityEntryView.ShowDialog();
        }

    }
}
