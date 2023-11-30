using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Adminstrator_Application.Model;

namespace Adminstrator_Application.UI
{

    public partial class addOperation : Form
    {
        public string targetColor;
        public int typeId;
        public int operationId;
        public Color selectedColorFormat;
        public string selectedColor;
        Admin_App_DataAccess.DataAccess dataAccess = new Admin_App_DataAccess.DataAccess();
        List<Model.Operation> operations = new List<Model.Operation>();

        public void setTypeId(int typeId)
        {
            this.typeId = typeId;
        }
        public addOperation()
        {
            InitializeComponent();
            operations.Clear();
            operations = dataAccess.GetOperations(typeId);
            operationLookUpEdit.Properties.DataSource = operations;
            operationLookUpEdit.Properties.DisplayMember = "value";
            operationLookUpEdit.Properties.ValueMember = "id";
            operationLookUpEdit.Properties.Columns.Clear();
            operationLookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("value"));




        }

        private void operationLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            object Id = operationLookUpEdit.EditValue;
            operationId = (int)Id;

        }

        private void btnCloseAddOperation_Click(object sender, EventArgs e)
        {

            DataContanier.Instance.SharedData = operationId;
            DataContanier.Instance.SharedData1 = checkEdit1.Checked;
            DataContanier.Instance.sharedData2 = selectedColor;
            DataContanier.Instance.sharedData3 = isFinal.Checked;

            this.Close();

        }
        private void btnOperationColorPick_EditValueChanged(object sender, EventArgs e)
        {
            selectedColorFormat = btnOperationColorPick.Color;
            lblSelectedColor.BackColor = selectedColorFormat;
            selectedColor = $"{selectedColorFormat.R},{selectedColorFormat.G},{selectedColorFormat.B}";
            targetColor= GetColorName(selectedColorFormat.R, selectedColorFormat.G, selectedColorFormat.B);
           
            
        }

        private void btnOperationSave_Click(object sender, EventArgs e)
        {
            dataAccess.SaveOperation(typeId, operationId, checkEdit1.Checked, targetColor, isFinal.Checked);
        }
        static string GetColorName(int red, int green, int blue)
        {
            Color targetColor = Color.FromArgb(red, green, blue);

            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                Color knownColorValue = Color.FromKnownColor(knownColor);

                if (knownColorValue.ToArgb() == targetColor.ToArgb())
                {
                    return knownColor.ToString();
                }
            }

            string closestColor = FindClosestColor(targetColor);
            return closestColor;
        }
        static string FindClosestColor(Color targetColor)
        {
            string closestColor = string.Empty;
            int minDiff = int.MaxValue;

            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                Color knownColorValue = Color.FromKnownColor(knownColor);
                int diff = Math.Abs(targetColor.R - knownColorValue.R) +
                           Math.Abs(targetColor.G - knownColorValue.G) +
                           Math.Abs(targetColor.B - knownColorValue.B);

                if (diff < minDiff)
                {
                    minDiff = diff;
                    closestColor = knownColor.ToString();
                }
            }

            return closestColor;
        }
    }
}
