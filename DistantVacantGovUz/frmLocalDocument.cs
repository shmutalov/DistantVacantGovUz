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
        private string documentFileNameWithOutExtension = "";

        private bool bIsDirty = false;

        private bool isDirty
        {
            get
            {
                return bIsDirty;
            }

            set
            {
                bIsDirty = value;

                this.Text = ((bIsDirty)?"*":"") + this.documentName + " - " + "Local Vacancies";
            }
        }

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
                initialVacancyList[i].seqNum = (i + 1).ToString();

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
            this.documentFileNameWithOutExtension = documentFileName.Substring(0, documentFileName.Length - 4);

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

        private void ReportPrintVersion(CVacancyReports.REPORT_TYPE reportType, string language)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = documentFileNameWithOutExtension + "_" + language;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.OverwritePrompt = true;
            sfd.Title = "Сохранить версию для печати как...";

            switch (reportType)
            {
                case CVacancyReports.REPORT_TYPE.PDF:
                    sfd.Filter = "Документ PDF (*.pdf) | *.pdf";
                    break;
                case CVacancyReports.REPORT_TYPE.XLS:
                    sfd.Filter = "Документ XLS (*.xls) | *.xls";
                    break;
                default:
                    return;
            }


            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                byte[] bytes;

                using (frmRptPrintVersionSettings fRptSettings = new frmRptPrintVersionSettings())
                {
                    Dictionary<String, Object> parameters = new Dictionary<String, Object>();
                    
                    // language specific default header
                    switch (language)
                    {
                        case "ru":
                            fRptSettings.headerText = "Вакантные должности инженерно-технических работников и рабочих по " + "АО \"Алмалыкский ГМК\"" + " для размещения в Едином портале интерактивных государственных услуг на " + DateTime.Now.ToString("dd.MM.yyyy") + " г." + "\n";
                            break;
                        case "uz":
                            fRptSettings.headerText = "Yagona interaktiv davlat xizmatlari portalida joylashtirish uchun " + "\n" + "AJ \"Olmaliq KMK\"" + " bo'yicha " + DateTime.Now.ToString("dd.MM.yyyy") + " y. muhandis-texnik ishchilar va ishchilarning bo'sh ish o'rinlari" + "\n";
                            break;
                        case "en":
                        default:
                            fRptSettings.headerText = "Vacancies for publishing on Portal of JS \"Almalyk MMC\"" + " from " + DateTime.Now.ToString("dd.MM.yyyy") + " y." + "\n";
                            break;
                    }

                    if (fRptSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // report parameters
                        parameters.Add("whom", fRptSettings.whomText);
                        parameters.Add("header", fRptSettings.headerText);
                        parameters.Add("footer", fRptSettings.footerText);
                        parameters.Add("visas", fRptSettings.visas);
                    }

                    //bytes = CVacancyReports.GenerateReport(CVacancyReports.REPORT_TYPE.PDF, "PRINT_VERSION", language, parameters, initialVacancyList);
                    bytes = CVacancyReports.GenerateReport(reportType, "PRINT_VERSION", language, parameters, initialVacancyList);
                }

                if (bytes != null)
                {
                    if (CVacancyUtil.SaveBytesToFile(sfd.FileName, bytes))
                    {
                        DialogResult dr = System.Windows.Forms.DialogResult.No;

                        switch (reportType)
                        {
                            case CVacancyReports.REPORT_TYPE.PDF:
                                dr = MessageBox.Show("Версия для печати подготовлена. Открыть?", "Версия для печати (PDF)", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                break;
                            case CVacancyReports.REPORT_TYPE.XLS:
                                dr = MessageBox.Show("Версия для печати подготовлена. Открыть?", "Версия для печати (XLS)", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                break;
                        }

                        switch (dr)
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                string p = '"' + sfd.FileName + '"';
                                try
                                {
                                    System.Diagnostics.Process.Start(p);
                                }
                                catch (Exception ex)
                                {
                                }
                                break;
                            case System.Windows.Forms.DialogResult.No:
                                break;
                        }
                    }
                }
            }
        }

        private void toolBtnReportPdfPrintVersionRu_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.PDF, "ru");
        }

        private void toolBtnReportPdfPrintVersionUz_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.PDF, "uz");
        }

        private void lstVacancies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedItems.Count == 1)
                toolBtnEditSelected.Enabled = true;
            else
                toolBtnEditSelected.Enabled = false;
        }

        private void toolBtnDeleteChecked_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete selected rows?", "Deleting rows...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                List<CVacancyItem> itemsToDelete = new List<CVacancyItem>();

                foreach (int checkedIdx in lstVacancies.CheckedIndices)
                {
                    itemsToDelete.Add(initialVacancyList[checkedIdx]);
                }

                foreach (CVacancyItem v in itemsToDelete)
                {
                    try
                    {
                        initialVacancyList.Remove(v);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                isDirty = true;

                UpdateVacancyList();
            }

            if (lstVacancies.Items.Count == 0)
            {
                toolBtnCheckAll.Enabled = false;
                toolBtnUncheckAll.Enabled = false;
                toolBtnDeleteChecked.Enabled = false;
                toolBtnEditSelected.Enabled = false;
            }
        }

        private void toolBtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void toolBtnImportFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckPathExists = true;
            ofd.Title = "Выберите документ для импорта...";
            ofd.CheckFileExists = true;
            ofd.Filter = "Файл Вакансий (*.vac, *.vacx) | *.vac;*.vacx";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<CVacancyItem> importedVacancies = CVacancyFileType.OpenFile(ofd.FileName);

                if (importedVacancies != null && importedVacancies.Count > 0)
                {
                    foreach (CVacancyItem imp_v in importedVacancies)
                    {
                        initialVacancyList.Add(imp_v);
                    }

                    isDirty = true;

                    UpdateVacancyList();
                }
            }
        }

        private void toolBtnReportXlsPrintVersionRu_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.XLS, "ru");
        }

        private void toolBtnReportXlsPrintVersionUz_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.XLS, "uz");
        }

        private void lstVacancies_DoubleClick(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
            {
                int selectedIdx = lstVacancies.SelectedIndices[0];

                lstVacancies.Items[selectedIdx].Checked = !lstVacancies.Items[selectedIdx].Checked;

                // open vacancy edit form
            }
        }
    }
}
