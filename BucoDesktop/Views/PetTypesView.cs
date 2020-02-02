using Buco.Data;
using BucoDesktop.Providers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Buco.Models;

namespace BucoDesktop.Views
{
    public partial class PetTypesView : Form
    {
        private readonly PetTypesProvider Provider;
        private int CurrentPage = 1;
        private int TotalPages;
        protected int selectedTypeId = 0;

        private readonly string DB_ERROR = "An error has occured with the database! Please try again...";
        private readonly string CREATE_SUCCESS = "New pet type has successfully been created.";
        private readonly string INVALID_INPUT = "Invalid input! Description must not be empty!";

        private readonly string UPDATE_SUCCESS = "Pet type has successfully been updated.";
        private readonly string INVALID_UPDATE = "Please select record you want to update!";

        private readonly string DELETE_SUCCESS = "Pet type has successfully been deleted!";

        public PetTypesView(ApplicationDbContext dataContext)
        {
            Provider = new PetTypesProvider(dataContext);
            InitializeComponent();
            Icon = new Icon("icon.ico");
            TotalPages = Provider.GetTotalPages();
            SetPagingButtons();
            DataGrid.DataSource = GetGridData(CurrentPage);
            DataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
            SizeGrid();
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
            var types = Provider.PopulateGrid(page).ToList();
            DataTable tableData = new DataTable();
            tableData.Columns.Add("ID", typeof(int));
            tableData.Columns[0].ColumnName = "Pet type ID";
            tableData.Columns.Add("Desc", typeof(string));
            tableData.Columns[1].ColumnName = "Description";
            tableData.Columns[0].ReadOnly = true;
            tableData.Columns[1].ReadOnly = true;

            foreach (var type in types)
            {
                tableData.Rows.Add(type.PetTypeId, type.PetTypeDesc);
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

        private void DataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedTypeId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            DescTextBox.Text = DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            DeleteButton.Enabled = true;
            UpdateButton.Enabled = true;
        }

        private void ResetDataGrid()
        {
            DataGrid.DataSource = GetGridData(CurrentPage);
            DescTextBox.Text = "";
            selectedTypeId = 0;
            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DescTextBox.Text))
            {
                var typeToCreate = new PetType
                {
                    PetTypeDesc = DescTextBox.Text
                };

                var created = await Provider.CreatePetType(typeToCreate);
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
            if (!String.IsNullOrEmpty(DescTextBox.Text))
            {
                var updated = await Provider.UpdatePetType(selectedTypeId, DescTextBox.Text);
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
                MessageBox.Show(INVALID_UPDATE);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var deleted = await Provider.DeletePetType(selectedTypeId);
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
                CurrentPage++;
                DataGrid.DataSource = GetGridData(CurrentPage);
                SizeGrid();
            }
            SetPagingButtons();
        }
    }
}
