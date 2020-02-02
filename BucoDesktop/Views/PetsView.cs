using Buco.Data;
using BucoDesktop.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BucoDesktop.Views
{
    public partial class PetsView : Form
    {
        private readonly PetsProvider Provider;
        private int CurrentPage = 1;
        private int TotalPages;
        protected int selectedPetId = 0;
        protected string userId = "None";
        protected int typeId = 0;
        protected string photoPath = "None";

        AutoCompleteStringCollection UserCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection TypeCollection = new AutoCompleteStringCollection();

        private readonly string DB_ERROR = "An error has occured with the database! Please try again...";
        private readonly string CREATE_SUCCESS = "New pet has successfully been created.";
        private readonly string INVALID_INPUT = "Invalid input!";

        private readonly string UPDATE_SUCCESS = "Pet has successfully been updated.";

        private readonly string DELETE_SUCCESS = "Pet has successfully been deleted!";

        public PetsView(ApplicationDbContext dataContext)
        {
            Provider = new PetsProvider(dataContext);
            InitializeComponent();
            Icon = new Icon("icon.ico");
            TotalPages = Provider.GetTotalPages();
            SetPagingButtons();
            DataGrid.DataSource = GetGridData(CurrentPage);
            DataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
            SizeGrid();

            UserTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            UserTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            UserTextBox.AutoCompleteCustomSource = UserCollection;

            TypeTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            TypeTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TypeTextBox.AutoCompleteCustomSource = TypeCollection;

            SpayedComboBox.DataSource = new string[]
            {
                "Yes", "No"
            };

            GenderComboBox.DataSource = new string[]
            {
                "Female", "Male"
            };

            ActivityLevelComboBox.DataSource = new string[]
            {
                "1", "2", "3"
            };

            BCSComboBox.DataSource = new string[]
            {
                 "1", "2", "3", "4", "5", "6", "7", "8", "9"
            };

            PopulateUserCollection();
            PopulateTypeCollection();
        }

        private void SetPagingButtons()
        {
            if (CurrentPage == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }

            if (CurrentPage == TotalPages)
            {
                NextButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = true;
            }
        }

        private DataTable GetGridData(int page)
        {
            var entries = Provider.PopulateGrid(page).ToList();
            DataTable tableData = new DataTable();

            tableData.Columns.Add("ID", typeof(int));
            tableData.Columns[0].ColumnName = "Pet ID";

            tableData.Columns.Add("Name", typeof(string));
            tableData.Columns[1].ColumnName = "Pet name";

            tableData.Columns.Add("Gender", typeof(string));
            tableData.Columns[2].ColumnName = "Gender";

            tableData.Columns.Add("DOB", typeof(string));
            tableData.Columns[3].ColumnName = "DOB";

            tableData.Columns.Add("Photo", typeof(string));
            tableData.Columns[4].ColumnName = "Pet photo";

            tableData.Columns.Add("ActivityLevel", typeof(int));
            tableData.Columns[5].ColumnName = "Activity level";

            tableData.Columns.Add("BCS", typeof(int));
            tableData.Columns[6].ColumnName = "BCS";

            tableData.Columns.Add("Spayed", typeof(bool));
            tableData.Columns[7].ColumnName = "Spayed?";

            tableData.Columns.Add("ActivityGoal", typeof(int));
            tableData.Columns[8].ColumnName = "Activity goal (min)";

            tableData.Columns.Add("CalorieGoal", typeof(int));
            tableData.Columns[9].ColumnName = "Calorie goal(kcal)";

            tableData.Columns.Add("WeightGoal", typeof(float));
            tableData.Columns[10].ColumnName = "Weight goal (kgs)";

            tableData.Columns.Add("UserId", typeof(string));
            tableData.Columns[11].ColumnName = "User ID";

            tableData.Columns.Add("PetTypeId", typeof(int));
            tableData.Columns[12].ColumnName = "Pet type ID";

            tableData.Columns[0].ReadOnly = true;
            tableData.Columns[1].ReadOnly = true;
            tableData.Columns[2].ReadOnly = true;
            tableData.Columns[3].ReadOnly = true;
            tableData.Columns[4].ReadOnly = true;
            tableData.Columns[5].ReadOnly = true;
            tableData.Columns[6].ReadOnly = true;
            tableData.Columns[7].ReadOnly = true;
            tableData.Columns[8].ReadOnly = true;
            tableData.Columns[9].ReadOnly = true;
            tableData.Columns[10].ReadOnly = true;
            tableData.Columns[11].ReadOnly = true;
            tableData.Columns[12].ReadOnly = true;

            foreach (var entry in entries)
            {
                tableData.Rows.Add(entry.PetId, entry.PetName, entry.Gender,
                    entry.DOB.ToString(), entry.Photo, entry.ActivityLevel, entry.BodyCondtionScore,
                    entry.Spayed, entry.TargetActivity, entry.TargetCalories, entry.TargetWeight,
                    entry.UserId, entry.PetTypeId);
            }
            return tableData;
        }

        private void SizeGrid()
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            DataGrid.ScrollBars = ScrollBars.None;
            var totalHeight = DataGrid.Rows.GetRowsHeight(states) + DataGrid.ColumnHeadersHeight;
            var totalWidth = DataGrid.Columns.GetColumnsWidth(states) + DataGrid.RowHeadersWidth;
            DataGrid.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void PopulateUserCollection()
        {
            IEnumerable<string> userEmails = Provider.GetAllUSerEmail();
            foreach (var name in userEmails)
            {
                UserCollection.Add(name);
            }
        }

        private void PopulateTypeCollection()
        {
            IEnumerable<string> types = Provider.GetAllTypeDesc();
            foreach (var type in types)
            {
                TypeCollection.Add(type);
            }
        }

        private void DataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedPetId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            NameTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            GenderComboBox.SelectedItem = DataGrid.Rows[e.RowIndex].Cells[2].ToString();
            DOBTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[3].ToString();
            photoPath = DataGrid.Rows[e.RowIndex].Cells[4].ToString();
            ActivityLevelComboBox.SelectedValue = DataGrid.Rows[e.RowIndex].Cells[5].ToString();
            BCSComboBox.SelectedItem = DataGrid.Rows[e.RowIndex].Cells[6].ToString();
            SpayedComboBox.SelectedValue = DataGrid.Rows[e.RowIndex].Cells[7];

            UserTextBox.Text = Provider.GetUserEmail(DataGrid.Rows[e.RowIndex].Cells[11].Value.ToString());
            userId = Provider.GetUserId(UserTextBox.Text);

            TypeTextBox.Text = Provider.GetTypeDesc(Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[12].Value.ToString()));
            typeId = Provider.GetTypeId(TypeTextBox.Text);

            ActivityGoalTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[8].ToString();
            WeightGoalTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[9].ToString();
            CalorieGoalTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[10].ToString();

            DeleteButton.Enabled = true;
            UpdateButton.Enabled = true;
            WeightTextBox.Enabled = false;

            ActivityGoalTextBox.Enabled = true;
            WeightGoalTextBox.Enabled = true;
            CalorieGoalTextBox.Enabled = true;
        }

        private void ResetDataGrid()
        {
            DataGrid.DataSource = GetGridData(CurrentPage);
            selectedPetId = 0;
            NameTextBox.Text = "";
            DOBTextBox.Text = "";
            photoPath = "None";
            UserTextBox.Text = "";
            userId = "None";
            TypeTextBox.Text = "";
            ActivityGoalTextBox.Text = "";
            WeightGoalTextBox.Text = "";
            CalorieGoalTextBox.Text = "";
            typeId = 0;

            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            WeightTextBox.Enabled = true;

            ActivityGoalTextBox.Enabled = false;
            WeightGoalTextBox.Enabled = false;
            CalorieGoalTextBox.Enabled = false;
        }

        private bool ValidateInput()
        {
            if (typeId == 0)
            {
                return false;
            }

            if (String.IsNullOrEmpty(NameTextBox.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(DOBTextBox.Text))
            {
                return false;
            }

            try
            {
                Convert.ToDateTime(DOBTextBox.Text);
            }
            catch (FormatException)
            {
                return false;
            }

            if (userId == "None")
            {
                return false;
            }

            if (typeId == 0)
            {
                return false;
            }

            if (ActivityGoalTextBox.Enabled)
            {
                if (String.IsNullOrEmpty(ActivityGoalTextBox.Text))
                {
                    return false;
                }

                try
                {
                    Convert.ToInt32(ActivityGoalTextBox.Text);
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            if (WeightGoalTextBox.Enabled)
            {
                if (String.IsNullOrEmpty(WeightGoalTextBox.Text))
                {
                    return false;
                }

                try
                {
                    Convert.ToDouble(WeightGoalTextBox.Text);
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            if (CalorieGoalTextBox.Enabled)
            {
                if (String.IsNullOrEmpty(CalorieGoalTextBox.Text))
                {
                    return false;
                }

                try
                {
                    Convert.ToInt32(CalorieGoalTextBox.Text);
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            if (WeightTextBox.Enabled)
            {
                if (String.IsNullOrEmpty(WeightTextBox.Text))
                {
                    return false;
                }

                try
                {
                    Convert.ToDouble(WeightTextBox.Text);
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            return true;
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            userId = Provider.GetUserId(UserTextBox.Text);
            typeId = Provider.GetTypeId(TypeTextBox.Text);

            if (ValidateInput())
            {
                var weight = (float)Convert.ToDouble(WeightTextBox.Text);
                var created = await Provider.CreatePet(NameTextBox.Text, GenderComboBox.SelectedItem.ToString(), DOBTextBox.Text,
                photoPath, Convert.ToInt32(ActivityLevelComboBox.SelectedValue.ToString()),
                Convert.ToInt32(BCSComboBox.SelectedValue.ToString()), SpayedComboBox.SelectedItem.ToString(),
                userId, typeId, weight);
                if (!created)
                {
                    MessageBox.Show(DB_ERROR);
                }
                else
                {
                    MessageBox.Show(CREATE_SUCCESS);
                }
                ResetDataGrid();
                TotalPages = Provider.GetTotalPages();
                SizeGrid();
                SetPagingButtons();
            }
            else
            {
                MessageBox.Show(INVALID_INPUT);
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            userId = Provider.GetUserId(UserTextBox.Text);
            typeId = Provider.GetTypeId(TypeTextBox.Text);

            if (ValidateInput())
            {
                var updated = await Provider.UpdatePet(selectedPetId, NameTextBox.Text, GenderComboBox.SelectedItem.ToString(), DOBTextBox.Text,
                    photoPath, Convert.ToInt32(ActivityLevelComboBox.SelectedValue.ToString()),
                    Convert.ToInt32(BCSComboBox.SelectedValue.ToString()), SpayedComboBox.SelectedItem.ToString(),
                    userId, typeId, Convert.ToInt32(ActivityGoalTextBox.Text), Convert.ToDouble(WeightGoalTextBox.Text),
                    Convert.ToInt32(CalorieGoalTextBox.Text));

                if (!updated)
                {
                    MessageBox.Show(DB_ERROR);
                }
                else
                {
                    MessageBox.Show(UPDATE_SUCCESS);
                }
                ResetDataGrid();
            }
            else
            {
                MessageBox.Show(INVALID_INPUT);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var deleted = await Provider.DeletePet(selectedPetId);
                if (!deleted)
                {
                    MessageBox.Show(DB_ERROR);
                }
                else
                {
                    MessageBox.Show(DELETE_SUCCESS);
                }
                ResetDataGrid();
                TotalPages = Provider.GetTotalPages();
                SizeGrid();
                SetPagingButtons();
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                DataGrid.DataSource = GetGridData(CurrentPage);
                SizeGrid();
            }
            SetPagingButtons();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                this.CurrentPage += 1;
                DataGrid.DataSource = GetGridData(CurrentPage);
                SizeGrid();
            }
            SetPagingButtons();
        }

        private void PhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                photoPath = dialog.FileName;
            }

        }
    }
}
