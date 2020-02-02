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
    public partial class WeightEntiesView : Form
    {
        private readonly WeightEntriesProvider Provider;
        private int CurrentPage = 1;
        private int TotalPages;
        protected int selectedEntryId = 0;
        protected int petId = 0;

        AutoCompleteStringCollection PetCollection = new AutoCompleteStringCollection();

        private readonly string DB_ERROR = "An error has occured with the database! Please try again...";
        private readonly string CREATE_SUCCESS = "New weight entry has successfully been created.";
        private readonly string INVALID_INPUT = "Invalid input! Weight must be a number, weight must not be empty!";

        private readonly string UPDATE_SUCCESS = "Weight entry has successfully been updated.";

        private readonly string DELETE_SUCCESS = "Weight entry has successfully been deleted!";

        public WeightEntiesView(ApplicationDbContext dataContext)
        {
            Provider = new WeightEntriesProvider(dataContext);
            InitializeComponent();
            Icon = new Icon("icon.ico");
            TotalPages = Provider.GetTotalPages();
            SetPagingButtons();
            DataGrid.DataSource = GetGridData(CurrentPage);
            DataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
            SizeGrid();

            PetTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            PetTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            PetTextBox.AutoCompleteCustomSource = PetCollection;

            PopulatePetCollection();
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
            tableData.Columns[0].ColumnName = "Weight entry ID";
            tableData.Columns.Add("Time", typeof(string));
            tableData.Columns[1].ColumnName = "Weight entry time";
            tableData.Columns.Add("Weight", typeof(float));
            tableData.Columns[2].ColumnName = "Mesured weight";
            tableData.Columns.Add("Pet ID", typeof(int));
            tableData.Columns[3].ColumnName = "Pet ID";

            tableData.Columns[0].ReadOnly = true;
            tableData.Columns[1].ReadOnly = true;
            tableData.Columns[2].ReadOnly = true;
            tableData.Columns[3].ReadOnly = true;

            foreach (var entry in entries)
            {
                tableData.Rows.Add(entry.WeightEntryId, entry.WeightTime, entry.MesuredWeight, entry.PetId);
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

        private void PopulatePetCollection()
        {
            IEnumerable<PetSelectList> petList = Provider.GetPetSelectList();
            foreach (var pet in petList)
            {
                PetCollection.Add(pet.PetName);
            }
        }

        private void DataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedEntryId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            WeightTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            PetTextBox.Text = Provider.GetPetName(Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[3].Value.ToString()));
            petId = Provider.GetPet(PetTextBox.Text);
            DeleteButton.Enabled = true;
            UpdateButton.Enabled = true;
        }

        private void ResetDataGrid()
        {
            DataGrid.DataSource = GetGridData(CurrentPage);
            PetTextBox.Text = "";
            WeightTextBox.Text = "";
            selectedEntryId = 0;
            petId = 0;
            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
        }

        private void PetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PetTextBox.TextLength > 2)
            {
                var petCollection = Provider.GetPetNames(PetTextBox.Text);
                foreach (var name in petCollection)
                {
                    PetCollection.Add(name);
                }
                PetTextBox.AutoCompleteCustomSource = PetCollection;
            }
        }

        private bool ValidateInput()
        {
            if (petId == 0)
            {
                return false;
            }

            if (String.IsNullOrEmpty(WeightTextBox.Text))
            {
                return false;
            }

            try
            {
                Convert.ToDouble(WeightTextBox.Text);
            }catch (FormatException)
            {
                return false;
            }

            return true;
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            petId = Provider.GetPet(PetTextBox.Text);

            if (ValidateInput())
            {
                var created = await Provider.CreateWeightEntry(Convert.ToDouble(WeightTextBox.Text), petId);
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
            petId = Provider.GetPet(PetTextBox.Text);

            if (ValidateInput())
            {
                var updated = await Provider.UpdateWeightEntry(selectedEntryId, Convert.ToDouble(WeightTextBox.Text), petId);
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
                var deleted = await Provider.DeleteWeightEntry(selectedEntryId);
                if (!deleted)
                {
                    MessageBox.Show(DB_ERROR);
                }
                else
                {
                    MessageBox.Show(DELETE_SUCCESS);
                }
                DataGrid.DataSource = GetGridData(CurrentPage);
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
    }
}
