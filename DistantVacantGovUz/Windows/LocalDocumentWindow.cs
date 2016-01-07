using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;
using DistantVacantGovUz.Services;
using DistantVacantGovUz.Utils;

namespace DistantVacantGovUz.Windows
{
    public partial class LocalDocumentWindow : Form
    {
        private string _documentName;
        private string _documentFileName = string.Empty;
        private string _documentFileNameWithOutExtension = string.Empty;

        private bool _isNewDocument;
        private bool _bIsDirty;

        public string GetDocumentFileName()
        {
            return _documentFileName;
        }

        private bool IsDirty
        {
            get
            {
                return _bIsDirty;
            }

            set
            {
                _bIsDirty = value;

                Text = string.Format("{0}{1} - {2}"
                    , ((_bIsDirty) ? "*" : "")
                    , _documentName, 
                    language.strings.frmLocalDocumentCaption);
            }
        }

        private List<VacancyItem> _workingVacancyList;
        private List<VacancyItem> _oldVacancyList;

        public LocalDocumentWindow()
        {
            InitializeComponent();

            _oldVacancyList = new List<VacancyItem>();
        }

        private void UpdateVacancyList()
        {
            lstVacancies.Items.Clear();

            var c = true;

            for (var i = 0; i < _workingVacancyList.Count; i++)
            {
                _workingVacancyList[i].SequenceNumber = (i + 1).ToString();

                var li = lstVacancies.Items.Add("");
                li.SubItems.Add(_workingVacancyList[i].SequenceNumber);
                li.SubItems.Add((_workingVacancyList[i].PortalVacancyId == 0) ? "" : _workingVacancyList[i].PortalVacancyIdString);
                li.SubItems.Add(_workingVacancyList[i].DescriptionRu);
                li.SubItems.Add(_workingVacancyList[i].DescriptionUz);
                li.SubItems.Add((_workingVacancyList[i].CategoryId == -1) ? "" : _workingVacancyList[i].CategoryString);
                li.SubItems.Add(_workingVacancyList[i].Salary);
                li.SubItems.Add((_workingVacancyList[i].EmploymentId == -1) ? "" : _workingVacancyList[i].EmploymentString);
                li.SubItems.Add((_workingVacancyList[i].GenderId == -1) ? "" : _workingVacancyList[i].GenderString);
                li.SubItems.Add((_workingVacancyList[i].ExperienceId == -1) ? "" : _workingVacancyList[i].ExperienceString);
                li.SubItems.Add((_workingVacancyList[i].EducationId == -1) ? "" : _workingVacancyList[i].EducationString);
                li.SubItems.Add(_workingVacancyList[i].ExpireDate);
                li.SubItems.Add(_workingVacancyList[i].DepartmentRu);
                li.SubItems.Add(_workingVacancyList[i].SpecializationRu);
                li.SubItems.Add(_workingVacancyList[i].RequirementsRu);
                li.SubItems.Add(_workingVacancyList[i].InformationRu);
                li.SubItems.Add(_workingVacancyList[i].DepartmentUz);
                li.SubItems.Add(_workingVacancyList[i].SpecializationUz);
                li.SubItems.Add(_workingVacancyList[i].RequirementsUz);
                li.SubItems.Add(_workingVacancyList[i].InformationUz);

                c = !c;

                if (_workingVacancyList[i].IsValid())
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
            IsDirty = false;
            _isNewDocument = true;

            _documentName = documentName;
            _documentFileName = documentName;
            _documentFileNameWithOutExtension = documentName;

            _workingVacancyList = new List<VacancyItem>();

            Text = string.Format("{0} - {1}", 
                _documentName, 
                language.strings.frmLocalDocumentCaption);

            UpdateVacancyList();
        }

        public void SetDocument(string documentFileName, List<VacancyItem> vacancyList)
        {
            IsDirty = false;
            _isNewDocument = false;

            _documentFileName = documentFileName;
            _documentName = Path.GetFileName(documentFileName);
            _documentFileNameWithOutExtension = Path.GetFileNameWithoutExtension(documentFileName);

            _workingVacancyList = vacancyList;

            Text = string.Format("{0} - {1}", 
                _documentName, 
                language.strings.frmLocalDocumentCaption);

            UpdateVacancyList();
        }

        // Сохранение документа (по-умолчанию версия файла = 3)
        private void SaveDocument()
        {
            if (!_isNewDocument)
            {
                if (!VacancyFileUtil.SaveFile(_documentFileName, _workingVacancyList))
                {
                    MessageBox.Show(language.strings.MsgLocVacSaveError
                            , language.strings.MsgLocalVacSaveCaption
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    IsDirty = false;
                    _isNewDocument = false;
                }
            }
            else
            {
                SaveDocumentAs();
            }
        }

        // Сохранение документа как...
        private void SaveDocumentAs()
        {
            var sfd = new SaveFileDialog
            {
                Filter = language.strings.localDocSaveAsFilter
            };

            if (_documentFileName == "")
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + _documentName;
            else
                sfd.InitialDirectory = Path.GetDirectoryName(_documentFileName);

            sfd.FileName = _documentFileNameWithOutExtension;

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var version = (sfd.FilterIndex == 1) 
                ? VacancyFileVersion.Version3 
                : VacancyFileVersion.Version2;

            if (!VacancyFileUtil.SaveFileAs(sfd.FileName, _workingVacancyList, version))
            {
                MessageBox.Show(language.strings.MsgLocVacSaveError
                    , language.strings.MsgLocalVacSaveCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _documentFileName = sfd.FileName;
                _documentName = Path.GetFileName(_documentFileName);
                _documentFileNameWithOutExtension = Path.GetFileNameWithoutExtension(_documentFileName);

                IsDirty = false;
                _isNewDocument = false;
            }
        }

        private void lstVacancies_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            stsSelectedItems.Text = language.strings.localDocSelectedItems + lstVacancies.CheckedItems.Count;

            toolBtnDeleteChecked.Enabled = (lstVacancies.CheckedItems.Count > 0);
            toolBtnUncheckAll.Enabled = (lstVacancies.CheckedItems.Count > 0);
            toolBtnCheckAll.Enabled = (lstVacancies.CheckedItems.Count != lstVacancies.Items.Count);
        }

        private void toolBtnCheckAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = true;
            }
        }

        private void toolBtnUncheckAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = false;
            }
        }

        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void ReportPrintVersion(ReportType reportType, string language)
        {
            var sfd = new SaveFileDialog
            {
                FileName = _documentFileNameWithOutExtension + "_" + language,
                CheckPathExists = true,
                AddExtension = true,
                OverwritePrompt = true,
                Title = "Сохранить версию для печати как..."
            };

            switch (reportType)
            {
                case ReportType.Pdf:
                    sfd.Filter = "Документ PDF (*.pdf) | *.pdf";
                    break;
                case ReportType.Xls:
                    sfd.Filter = "Документ XLS (*.xls) | *.xls";
                    break;
                default:
                    return;
            }


            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            byte[] bytes;

            using (var fRptSettings = new ReportPrintVersionSettingsWindow())
            {
                var parameters = new Dictionary<string, object>();
                    
                // language specific default header
                switch (language)
                {
                    case "ru":
                        fRptSettings.HeaderText = "Вакантные должности инженерно-технических работников и рабочих по " 
                            + "АО \"Алмалыкский ГМК\"" + " для размещения в Едином портале интерактивных государственных услуг на " 
                            + DateTime.Now.ToString("dd.MM.yyyy") 
                            + " г." 
                            + "\n";
                        break;
                    case "uz":
                        fRptSettings.HeaderText = "Yagona interaktiv davlat xizmatlari portalida joylashtirish uchun " 
                            + "\n" 
                            + "AJ \"Olmaliq KMK\""
                            + " bo'yicha " 
                            + DateTime.Now.ToString("dd.MM.yyyy") 
                            + " y. muhandis-texnik ishchilar va ishchilarning bo'sh ish o'rinlari" 
                            + "\n";
                        break;
                    default:
                        fRptSettings.HeaderText = "Vacancies for publishing on Portal of JS \"Almalyk MMC\"" 
                            + " from " 
                            + DateTime.Now.ToString("dd.MM.yyyy") 
                            + " y." 
                            + "\n";
                        break;
                }

                if (fRptSettings.ShowDialog() == DialogResult.OK)
                {
                    // report parameters
                    parameters.Add("whom", fRptSettings.WhomText);
                    parameters.Add("header", fRptSettings.HeaderText);
                    parameters.Add("footer", fRptSettings.FooterText);
                    parameters.Add("visas", fRptSettings.Visas);
                }
                else
                    return;

                bytes = ReportService.GenerateReport(reportType, "PRINT_VERSION", language, parameters, _workingVacancyList);
            }

            if (bytes == null)
                return;

            if (!VacancyUtil.SaveBytesToFile(sfd.FileName, bytes))
                return;

            var dr = DialogResult.No;

            switch (reportType)
            {
                case ReportType.Pdf:
                    dr = MessageBox.Show("Версия для печати подготовлена. Открыть?", 
                        "Версия для печати (PDF)", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Information, 
                        MessageBoxDefaultButton.Button2);
                    break;
                case ReportType.Xls:
                    dr = MessageBox.Show("Версия для печати подготовлена. Открыть?", 
                        "Версия для печати (XLS)", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Information, 
                        MessageBoxDefaultButton.Button2);
                    break;
            }

            switch (dr)
            {
                case DialogResult.Yes:
                    var p = string.Format("{0}{1}{0}", '"', sfd.FileName);

                    try
                    {
                        System.Diagnostics.Process.Start(p);
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void toolBtnReportPdfPrintVersionRu_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(ReportType.Pdf, "ru");
        }

        private void toolBtnReportPdfPrintVersionUz_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(ReportType.Pdf, "uz");
        }

        private void lstVacancies_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolBtnEditSelected.Enabled = lstVacancies.SelectedItems.Count == 1;
        }

        private void toolBtnDeleteChecked_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(language.strings.MsgLocalDocDeletingRows
                    , language.strings.MsgLocalDocDeletingRowsCaption
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // сохраним текущий список
                VacancyUtil.CopyVacancyItemList(_workingVacancyList, _oldVacancyList);
                toolBtnUndo.Enabled = true;
                toolBtnUndo.Enabled = false;

                var itemsToDelete = (from int checkedIdx in lstVacancies.CheckedIndices
                                     select _workingVacancyList[checkedIdx])
                                     .ToList();

                foreach (var v in itemsToDelete)
                {
                    try
                    {
                        _workingVacancyList.Remove(v);
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                }

                IsDirty = true;

                UpdateVacancyList();
            }

            if (lstVacancies.Items.Count != 0)
                return;

            toolBtnCheckAll.Enabled = false;
            toolBtnUncheckAll.Enabled = false;
            toolBtnDeleteChecked.Enabled = false;
            toolBtnEditSelected.Enabled = false;
        }

        private void toolBtnAdd_Click(object sender, EventArgs e)
        {
            var tempList = new List<VacancyItem>();
            VacancyUtil.CopyVacancyItemList(_workingVacancyList, tempList);

            var beforeAddVacancyCount = _workingVacancyList.Count;

            var addVacancyWindow = new AddLocalVacancyWindow
            {
                Vacs = _workingVacancyList
            };

            addVacancyWindow.ShowDialog();

            if (beforeAddVacancyCount - _workingVacancyList.Count == 0)
                return;

            _oldVacancyList = tempList;
            toolBtnUndo.Enabled = true;
            toolBtnUndo.Enabled = false;

            IsDirty = true;

            UpdateVacancyList();

            lstVacancies.Items[lstVacancies.Items.Count - 1].Selected = true;
        }

        private void toolBtnImportFromFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                CheckPathExists = true,
                Title = language.strings.openVacancyDocImportTitle,
                CheckFileExists = true,
                Filter = language.strings.openVacancyDocumentFilter
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var importedVacancies = VacancyFileUtil.OpenFile(ofd.FileName);

            if (importedVacancies != null && importedVacancies.Count > 0)
            {
                // сохраним текущий список
                VacancyUtil.CopyVacancyItemList(_workingVacancyList, _oldVacancyList);
                toolBtnUndo.Enabled = true;
                toolBtnUndo.Enabled = false;

                foreach (var impV in importedVacancies)
                {
                    _workingVacancyList.Add(impV);
                }

                IsDirty = true;

                UpdateVacancyList();
            }
        }

        private void toolBtnReportXlsPrintVersionRu_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(ReportType.Xls, "ru");
        }

        private void toolBtnReportXlsPrintVersionUz_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(ReportType.Xls, "uz");
        }

        private void lstVacancies_DoubleClick(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
            {
                var tempList = new List<VacancyItem>();
                VacancyUtil.CopyVacancyItemList(_workingVacancyList, tempList);

                var selectedIdx = lstVacancies.SelectedIndices[0];

                lstVacancies.Items[selectedIdx].Checked = !lstVacancies.Items[selectedIdx].Checked;

                var editVacancyWindow = new EditLocalVacancyWindow
                {
                    Vac = _workingVacancyList[selectedIdx]
                };

                if (editVacancyWindow.ShowDialog() != DialogResult.OK)
                    return;

                _oldVacancyList = tempList;
                toolBtnUndo.Enabled = true;

                IsDirty = true;
                UpdateVacancyList();

                lstVacancies.Items[selectedIdx].Selected = true;
            }
        }

        private void toolBtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveDocumentAs();
        }

        private void toolBtnEditSelected_Click(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
            {
                var tempList = new List<VacancyItem>();
                VacancyUtil.CopyVacancyItemList(_workingVacancyList, tempList);

                var fEdit = new EditLocalVacancyWindow();
                var selectedIdx = lstVacancies.SelectedIndices[0];
                fEdit.Vac = _workingVacancyList[selectedIdx];

                if (fEdit.ShowDialog() == DialogResult.OK)
                {
                    _oldVacancyList = tempList;
                    toolBtnUndo.Enabled = true;
                    toolBtnUndo.Enabled = false;

                    IsDirty = true;
                    UpdateVacancyList();

                    lstVacancies.Items[selectedIdx].Selected = true;
                }
            }
        }

        private void toolBtnUndo_Click(object sender, EventArgs e)
        {
            VacancyUtil.Swap(ref _workingVacancyList, ref _oldVacancyList);

            toolBtnUndo.Enabled = false;
            toolBtnRedo.Enabled = true;

            UpdateVacancyList();
        }

        private void toolBtnRedo_Click(object sender, EventArgs e)
        {
            VacancyUtil.Swap(ref _workingVacancyList, ref _oldVacancyList);

            toolBtnUndo.Enabled = true;
            toolBtnRedo.Enabled = false;

            //UpdateVacancyList();
        }

        private void lstVacancies_BeforeRowReorder(object sender, EventArgs e)
        {
            VacancyUtil.CopyVacancyItemList(_workingVacancyList, _oldVacancyList);

            toolBtnUndo.Enabled = true;
            toolBtnRedo.Enabled = false;
            IsDirty = true;
        }

        private void RebuildWorkingVacancyList()
        {
            for (var i = 0; i < _workingVacancyList.Count; i++)
            {
                //workingVacancyList[i].seqNum = lstVacancies.Items[i].SubItems[1].Text;

                _workingVacancyList[int.Parse(lstVacancies.Items[i].SubItems[1].Text) - 1].SequenceNumber = (i + 1).ToString();
            }

            VacancyUtil.SortBySeqNum(_workingVacancyList);

            UpdateVacancyList();
        }

        private void lstVacancies_AfterRowReorder(object sender, EventArgs e)
        {
            RebuildWorkingVacancyList();
        }

        private void frmLocalDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDirty)
            {
                if (MessageBox.Show(language.strings.frmLocalDocSaveBeforeExit
                    , language.strings.frmLocalDocExitingCaption
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveDocument();
                }
            }
        }
    }
}
