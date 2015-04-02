using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DistantVacantGovUz
{
    public partial class frmLocalDocument : Form
    {
        private string documentName;
        private string documentFileName = "";
        private bool isDirty;

        private List<CVacancyItem> initialVacancyList;
        
        public frmLocalDocument()
        {
            InitializeComponent();
        }

        private void UpdateVacancyList()
        {
            lstVacancies.Items.Clear();

            bool c = true;

            for (int i = 0; i < initialVacancyList.Count; i++ )
            {
                ListViewItem li = lstVacancies.Items.Add("");
                li.SubItems.Add(initialVacancyList[i].seqNum);
                li.SubItems.Add((initialVacancyList[i].i_portal_vacancy_id == 0) ? "" : initialVacancyList[i].portal_vacancy_id);
                li.SubItems.Add(initialVacancyList[i].description_ru);
                li.SubItems.Add(initialVacancyList[i].description_uz);
                li.SubItems.Add((initialVacancyList[i].i_category_id == 0) ? "" : initialVacancyList[i].category);
                li.SubItems.Add(initialVacancyList[i].salary);
                li.SubItems.Add((initialVacancyList[i].i_employment_id == 0) ? "" : initialVacancyList[i].employment);
                li.SubItems.Add((initialVacancyList[i].i_gender_id == 0) ? "" : initialVacancyList[i].gender);
                li.SubItems.Add((initialVacancyList[i].i_experience_id == 0) ? "" : initialVacancyList[i].experience);
                li.SubItems.Add((initialVacancyList[i].i_education_id == 0) ? "" : initialVacancyList[i].education);
                li.SubItems.Add(initialVacancyList[i].expire_date);
                li.SubItems.Add(initialVacancyList[i].department_ru);
                li.SubItems.Add(initialVacancyList[i].specialization_ru);
                li.SubItems.Add(initialVacancyList[i].requirements_ru);
                li.SubItems.Add(initialVacancyList[i].information_ru);
                li.SubItems.Add(initialVacancyList[i].department_uz);
                li.SubItems.Add(initialVacancyList[i].specialization_uz);
                li.SubItems.Add(initialVacancyList[i].requirements_uz);
                li.SubItems.Add(initialVacancyList[i].information_uz);

                c = !c;

                if (initialVacancyList[i].IsValid())
                    li.BackColor = (c) ? Color.White : Color.AliceBlue;
                else
                    li.BackColor = Color.LightCoral;
            }

            foreach (ColumnHeader clmn in lstVacancies.Columns)
            {
                clmn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        public void SetDocument(string documentName)
        {
            isDirty = false;
            this.documentName = documentName;
            this.Text = this.documentName + " - " + "Local Vacancies";

            initialVacancyList = new List<CVacancyItem>();

            UpdateVacancyList();
        }

        public void SetDocument(string documentFileName, List<CVacancyItem> vacancyList)
        {
            isDirty = false;
            this.documentFileName = documentFileName;
            this.documentName = Path.GetFileName(documentFileName);

            this.initialVacancyList = vacancyList;

            this.Text = this.documentName + " - " + "Local Vacancies";

            UpdateVacancyList();
        }

        private void SaveDocument()
        {
            if (documentFileName != "")
            {
                CVacancyFileType.SaveFile(documentFileName, initialVacancyList);
            }
            else
            {
                SaveDocumentAs();
            }
        }

        private void SaveDocumentAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файл Вакансий (*.vacx)|*.vacx" + "|" + "Файл Вакансий (Старая версия, *.vac)|*.vac";

            if (documentFileName == "")
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + documentName;
            else
                sfd.InitialDirectory = documentFileName;

            sfd.ShowDialog();
        }

        private void lstVacancies_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            stsSelectedItems.Text = "Selected: " + lstVacancies.CheckedItems.Count;

            toolBtnDeleteChecked.Enabled = (lstVacancies.CheckedItems.Count > 0) ? true : false;
            toolBtnUncheckAll.Enabled = (lstVacancies.CheckedItems.Count > 0) ? true : false;
            toolBtnCheckAll.Enabled = (lstVacancies.CheckedItems.Count != lstVacancies.Items.Count) ? true : false;
        }

        private void toolBtnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = true;
            }
        }

        private void toolBtnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = false;
            }
        }

        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }
    }
}
