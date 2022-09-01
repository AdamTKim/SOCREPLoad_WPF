/////////////////////////////////////////////////////////////////////////////////////////
//Author: Adam Kim
//Created On: 4/19/2022
//Last Modified On: 8/16/2022
//Copyright: USAF // JT4 LLC
//Description: Main window of the SOCREPLoad application
/////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCREPLoad_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Global variables
		/// </summary>
		DataTable socrepDT = new DataTable();
		string unprocessedFileDirectory = "C:\\Users\\sys.showtime\\AppData\\Local\\Temp\\DWRCC Downloads";
		string socrepFileDirectory = Convert.ToString(Directory.CreateDirectory(Directory.GetParent(Convert.ToString(Directory.GetParent(Assembly.GetExecutingAssembly().Location))) + "\\_SOCREP Exports"));
		string socrepTemplateFileName = Convert.ToString(Directory.GetParent(Assembly.GetExecutingAssembly().Location)) + "\\assets\\SOCREPTemplate.xlsx";

		public MainWindow()
		{
			InitializeComponent();
			CreateTable();
		}

		/// <summary>
		/// Function to check if inputed value is a integer or not. If not do not accept value
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any text composition event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void CheckIfInt(object sender, TextCompositionEventArgs e)
		{
			try
			{
				Regex tempRegex = new Regex("[^0-9]+");
				e.Handled = tempRegex.IsMatch(e.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'CheckIfInt' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to create the socrepDT datatable
		/// </summary>
		/// <returns>None (Void)</returns>
		private void CreateTable()
		{
			try
			{
				// Name table and add columns
				socrepDT.TableName = "Aircraft_SOCREPLoadTable";
				socrepDT.Columns.Add("Submitted", typeof(bool));
				socrepDT.Columns.Add("Selected", typeof(bool));
				socrepDT.Columns.Add("LowActSelect", typeof(bool));
				socrepDT.Columns.Add("Slot", typeof(int));
				socrepDT.Columns.Add("Pilotname", typeof(string));
				socrepDT.Columns.Add("Callsign", typeof(string));
				socrepDT.Columns.Add("ACType", typeof(string));
				socrepDT.Columns.Add("Tailno", typeof(string));
				socrepDT.Columns.Add("PSID", typeof(string));
				socrepDT.Columns.Add("IFF", typeof(int));
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'CreateTable' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function that returns the respective empty fields
		/// </summary>
		/// <returns>String of the empty fields when attempting to submit a record</returns>
		private string EmptyFields()
		{
			try
			{
				// Create temp string to return.
				string tempString = String.Empty;

				// Check for empty fields
				if (String.IsNullOrEmpty(sortieMissionIDJulian_input.Text) || String.IsNullOrEmpty(sortieMissionIDTime_input.Text) || sortieMissionIDTime_input.Text.Length < 4)
				{
					tempString = tempString + " [Sortie Mission ID]";
				}
				if (String.IsNullOrEmpty(sortieDate_input.Text))
				{
					tempString = tempString + " [Sortie Date]";
				}
				if (String.IsNullOrEmpty(sortieStartTime_input.Text) || sortieStartTime_input.Text.Length < 4 || int.Parse(sortieStartTime_input.Text) > 2359)
				{
					tempString = tempString + " [Range Start Time]";
				}
				if (String.IsNullOrEmpty(sortieEndTime_input.Text) || sortieEndTime_input.Text.Length < 4 || int.Parse(sortieEndTime_input.Text) > 2359)
				{
					tempString = tempString + " [Range End Time]";
				}
				if (String.IsNullOrEmpty(sortieProject_input.Text))
				{
					tempString = tempString + " [Project Number]";
				}
				if (String.IsNullOrEmpty(sortieNumCD_input.Text))
				{
					tempString = tempString + " [Number of CDs]";
				}
				if (String.IsNullOrEmpty(RecordedStations()))
				{
					tempString = tempString + " [Recorded Stations]";
				}

				return tempString;
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'EmptyFields' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
				return String.Empty;
			}
		}

		/// <summary>
		/// Function to export the SOCREP into the templated SOCREP Excel template
		/// </summary>
		/// <returns>None (Void)</returns>
		private void ExportSOCREP()
		{
			try
			{
				// Check if file is already open
				if (!IsFileOpen(socrepFileDirectory + "\\" + sortieMissionIDJulian_input.Text + "-" + sortieMissionIDTime_input.Text + DateTime.Now.ToString(" EXyy-MM-dd.HHmmss") + ".xlsx"))
				{
					// General variables
					bool tempFlag = true;
					int tempCount = 0;

					// Variables for Excel applications, workbooks, and worksheets
					Excel.Application excelApp = new Excel.Application();
					Excel.Workbook excelSOCREPWorkBook = excelApp.Workbooks.Open(socrepTemplateFileName);
					Excel.Worksheet excelSOCREPWorkSheet = excelSOCREPWorkBook.Worksheets["SOCREP"];

					foreach (DataRow socrepRow in socrepDT.Rows)
					{
						// If socrepRow is selected for export
						if ((bool)socrepRow["Selected"])
						{
							// If header information hasn't been assigned yet
							if (tempFlag)
							{
								// Trip flag
								tempFlag = false;

								// Assign header fields
								excelSOCREPWorkSheet.Cells[2, 2] = sortieMissionIDJulian_input.Text + "-" + sortieMissionIDTime_input.Text.Replace(" ", String.Empty).ToUpper();
								excelSOCREPWorkSheet.Cells[2, 10] = sortieDate_input.Text;
								excelSOCREPWorkSheet.Cells[4, 3] = sortieStartTime_input.Text + "-" + sortieEndTime_input.Text;
								excelSOCREPWorkSheet.Cells[4, 5] = sortieProject_input.Text.Replace(" ", String.Empty).ToUpper();
								excelSOCREPWorkSheet.Cells[4, 7] = Convert.ToInt32(sortieNumCD_input.Text.Replace(" ", String.Empty)) + 1; // Add one CD for CS
								excelSOCREPWorkSheet.Cells[4, 9] = RecordedStations();

								// Assign aircraft counts
								excelSOCREPWorkSheet.Cells[6, 9] = "HAA: " + rowCountHAA_label.Content;
								excelSOCREPWorkSheet.Cells[6, 10] = "LAA: " + rowCountLAA_label.Content;
							}

							// Check if Pilotname is Null to avoid blank cells
							if (!String.IsNullOrEmpty((string)socrepRow["Pilotname"]))
							{
								excelSOCREPWorkSheet.Cells[8 + tempCount, 3] = Convert.ToString(socrepRow["Pilotname"]).ToUpper();
							}

							// Check if Callsign is Null to avoid blank cells
							if (!String.IsNullOrEmpty((string)socrepRow["Callsign"]))
							{
								excelSOCREPWorkSheet.Cells[8 + tempCount, 4] = Convert.ToString(socrepRow["Callsign"]).ToUpper();
							}

							// Fill in Pod Serial Number with "LOW" if LAA
							if ((bool)socrepRow["LowActSelect"])
							{
								excelSOCREPWorkSheet.Cells[8 + tempCount, 8] = "LOW";
							}

							// If ACType cell contains "MALD" then fill in Pod Serial with "MALD"
							if (((string)socrepRow["ACType"]).ToUpper().Contains("MALD"))
							{
								excelSOCREPWorkSheet.Cells[8 + tempCount, 8] = "MALD";
							}

							// Check if Tailno is Null to avoid blank cells
							if (!String.IsNullOrEmpty((string)socrepRow["Tailno"]))
							{
								excelSOCREPWorkSheet.Cells[8 + tempCount, 6] = Convert.ToString(socrepRow["Tailno"]).ToUpper();

								// If Tailno cell contains "BT" then fill in status with "BT"
								if (((string)socrepRow["Tailno"]).ToUpper().Contains("BT"))
								{
									excelSOCREPWorkSheet.Cells[8 + tempCount, 10] = "BT";
								}
								// If Tailno cell contains "NT" then fill in status with "NT"
								else if (((string)socrepRow["Tailno"]).ToUpper().Contains("NT"))
								{
									excelSOCREPWorkSheet.Cells[8 + tempCount, 10] = "NT";
								}
								// If Tailno cell contains "CNX" then fill in status with "CNX"
								else if (((string)socrepRow["Tailno"]).ToUpper().Contains("CNX"))
								{
									excelSOCREPWorkSheet.Cells[8 + tempCount, 10] = "CNX";
								}
							}

							// Loop through additional rows and assign to repective cells
							excelSOCREPWorkSheet.Cells[8 + tempCount, 2] = Convert.ToString(socrepRow["Slot"]);
							excelSOCREPWorkSheet.Cells[8 + tempCount, 5] = Convert.ToString(socrepRow["ACType"]).ToUpper();
							excelSOCREPWorkSheet.Cells[8 + tempCount, 7] = Convert.ToString(socrepRow["IFF"]);
							excelSOCREPWorkSheet.Cells[8 + tempCount, 9] = Convert.ToString(socrepRow["PSID"]).ToUpper();

							// Set socrepRow height and borders for table
							excelSOCREPWorkSheet.Rows[8 + tempCount].RowHeight = 20;
							excelSOCREPWorkSheet.get_Range("B" + Convert.ToString((8 + tempCount)), "J" + Convert.ToString((8 + tempCount))).Cells.Borders.Weight = Excel.XlBorderWeight.xlThin;

							// Alternate background color for each socrepRow for ease of reading
							if (tempCount % 2 != 0)
							{
								excelSOCREPWorkSheet.get_Range("B" + Convert.ToString((8 + tempCount)), "J" + Convert.ToString((8 + tempCount))).Interior.Color = System.Drawing.Color.LightGray;
							}

							tempCount = tempCount + 1;
							socrepRow["Submitted"] = true;
						}
					}
					try
					{
						// Save workbook
						excelSOCREPWorkBook.SaveAs(socrepFileDirectory + "\\" + sortieMissionIDJulian_input.Text + "-" + sortieMissionIDTime_input.Text + DateTime.Now.ToString(" EXyy-MM-dd.HHmmss") + ".xlsx",
							Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive);

						// Print Worksheet. Have to include hack to not display running Excel Application triggered by Dialog.Show()
						double tempHeight = excelApp.Height;
						double tempWidth = excelApp.Width;
						excelApp.Height = 0;
						excelApp.Width = 0;

						if (excelApp.Dialogs[Excel.XlBuiltInDialog.xlDialogPrint].Show())
						{
							excelApp.Visible = false;
							excelApp.Height = tempHeight;
							excelApp.Width = tempWidth;

							SortieClearFields();
							UnselectAll();

							// Prompt success if successful save and print
							MessageBox.Show(Application.Current.MainWindow, "Export Complete!", "SUCCESS");
						}
						else
						{
							MessageBox.Show(Application.Current.MainWindow, "Print Canceled! File saved in " + socrepFileDirectory + ".", "ERROR");
						}
					}
					catch (Exception)
					{
						// Prompt with error message
						MessageBox.Show(Application.Current.MainWindow, "Export Failed!", "ERROR");
					}

					// Close out of Excel and release Excel objects form memory
					excelSOCREPWorkBook.Close(false);
					excelApp.Quit();
					Marshal.ReleaseComObject(excelSOCREPWorkSheet);
					Marshal.ReleaseComObject(excelSOCREPWorkBook);
					Marshal.ReleaseComObject(excelApp);
				}
			}
			catch (COMException comEX)
			{
				MessageBox.Show(Application.Current.MainWindow, "Please ensure that Mircosoft Office Excel is installed on this machine.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, comEX.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'ExportSOCREP' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to generate the Mission ID julian date and populate the sortieMissionIDJulian_input field
		/// </summary>
		/// <returns>None (Void)</returns>
		private void GenerateJulianDate()
		{
			try
			{
				// Define variables to use for generation
				int tempDay = DateTime.Parse(sortieDate_input.Text).DayOfYear;
				string tempString = String.Empty;

				// Check if less than 10 or 100 to add leading zero(s)
				if (tempDay < 10)
				{
					tempString = "00" + tempDay.ToString();
				}
				else if (tempDay < 100)
				{
					tempString = "0" + tempDay.ToString();
				}
				else
				{
					tempString = tempDay.ToString();
				}

				// Assign to textbox
				sortieMissionIDJulian_input.Text = "M" + DateTime.Parse(sortieDate_input.Text).ToString("yy").Substring(1) + tempString;
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'GenerateJulianDate' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to check if a file is already open by another process
		/// </summary>
		/// <param name="fileName">String of the file name to check</param>
		/// <returns>Boolean if file is open or not</returns>
		private bool IsFileOpen(string fileName)
		{
			try
			{
				// Check if file exists
				if (File.Exists(fileName))
				{
					// Attempt to open file in filestream
					using (FileStream tempStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
					{
						// If opened then close stream and return false
						tempStream.Close();
						return false;
					}
				}

				// If file does not exist then return false
				return false;
			}
			catch (Exception)
			{
				// If exception is caught then file is open in another process
				MessageBox.Show(Application.Current.MainWindow, "The file you are attempting to overwrite is open in another process, please close it before continuing.", "ERROR");
				return true;
			}
		}

		/// <summary>
		/// Function to select all LAA checkboxes on file load
		/// </summary>
		/// <returns>None (Void)</returns>
		private void LowActAutoCheck()
		{
			try
			{
				foreach (DataRow socrepRow in socrepDT.Rows)
				{
					if(String.IsNullOrEmpty((string)socrepRow["Tailno"]) || ((string)socrepRow["Tailno"]).ToUpper().Contains("LOW") || ((string)socrepRow["Tailno"]) == "0")
					{
						socrepRow["LowActSelect"] = true;
					}
				}

				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'LowActAutoCheck' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function update the socrepRow counts when the lowActSelect_input Checkbox is checked
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void LowActSelect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'LowActSelect_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to select all aircraft if lowActSelectAll_input CheckBox is checked
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void LowActSelectAll_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (DataRow socrepRow in socrepDT.Rows)
				{
					socrepRow["LowActSelect"] = lowActSelectAll_input.IsChecked;
				}

				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'LowActSelectAll_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to open a file and bind the respective info to the proper datatables/datagrids
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void OpenFile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Define new CommonOpenFileDialog
				CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
				commonOpenFileDialog.Title = "Select File to Import:";
				commonOpenFileDialog.InitialDirectory = unprocessedFileDirectory;
				commonOpenFileDialog.IsFolderPicker = false;

				if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
				{
					// Clear datatable and read opened file into respective datatable
					socrepDT.Clear();

					// Variables for Excel application, workbook, and worksheet
					Excel.Application excelApp = new Excel.Application();
					Excel.Workbook excelSOCREPWorkBook = excelApp.Workbooks.Open(commonOpenFileDialog.FileName);
					Excel.Worksheet excelSOCREPWorkSheet = excelSOCREPWorkBook.Worksheets["Sheet"];

					// Starting from the second line
					for (int i = 2; i < excelSOCREPWorkSheet.Rows.Count - 1; i++)
					{
						// If cell is empty then break out of loop
						if (excelSOCREPWorkSheet.Cells[i, 1].Value == null)
						{
							break;
						}
						else
						{
							// Save values to temp variables and add as a socrepRow to the datatable
							int tempSlot = int.Parse(Convert.ToString(excelSOCREPWorkSheet.Cells[i, 1].Value));
							string tempPilotname = Convert.ToString(excelSOCREPWorkSheet.Cells[i, 2].Value);
							string tempCallsign = Convert.ToString(excelSOCREPWorkSheet.Cells[i, 3].Value);
							string tempACType = Convert.ToString(excelSOCREPWorkSheet.Cells[i, 4].Value);
							string tempTailno = Convert.ToString(excelSOCREPWorkSheet.Cells[i, 5].Value);
							string tempPSID = Convert.ToString(excelSOCREPWorkSheet.Cells[i, 6].Value);
							int tempIFF = int.Parse(Convert.ToString(excelSOCREPWorkSheet.Cells[i, 7].Value));
							socrepDT.Rows.Add(new Object[] {false, false, false, tempSlot, tempPilotname.Trim(), tempCallsign.Trim(), tempACType, tempTailno.Trim(), tempPSID, tempIFF});
						}       
					}

					// Bind datatable to datagrid
					socrepDG.ItemsSource = socrepDT.DefaultView;

					// Close out of Excel and release Excel objects form memory
					excelSOCREPWorkBook.Close(false);
					excelApp.Quit();
					Marshal.ReleaseComObject(excelSOCREPWorkSheet);
					Marshal.ReleaseComObject(excelSOCREPWorkBook);
					Marshal.ReleaseComObject(excelApp);

					// Automatically check LAA checkboxes
					LowActAutoCheck();
				}
				else
				{
					MessageBox.Show(Application.Current.MainWindow, "Could not open file.", "ERROR");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'OpenFile_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function that returns the respective empty fields
		/// </summary>
		/// <returns>String of the empty fields when attempting to submit a record</returns>
		private string RecordedStations()
		{
			try
			{
				// Create temp string to return
				string tempStation = String.Empty;
				string tempDash = String.Empty;

				// Check to see which radiobutton is selected
				if ((bool)sortieDash1_input.IsChecked)
				{
					tempDash = "(-1)";
				}
				else if ((bool)sortieDash2_input.IsChecked)
				{
					tempDash = "(-2)";
				}
				else
				{
					tempDash = "(-3)";
				}

				// Check to see which checkboxes are checked
				if ((bool)sortieStationM_input.IsChecked)
				{
					tempStation = "M,";
				}
				if ((bool)sortieStation2_input.IsChecked)
				{
					tempStation = tempStation + "2,";
				}
				if ((bool)sortieStation3_input.IsChecked)
				{
					tempStation = tempStation + "3,";
				}
				if ((bool)sortieStation4_input.IsChecked)
				{
					tempStation = tempStation + "4,";
				}
				if ((bool)sortieStation5_input.IsChecked)
				{
					tempStation = tempStation + "5,";
				}
				if ((bool)sortieStation6_input.IsChecked)
				{
					tempStation = tempStation + "6,";
				}
				if ((bool)sortieStation7_input.IsChecked)
				{
					tempStation = tempStation + "7,";
				}
				if ((bool)sortieStation8_input.IsChecked)
				{
					tempStation = tempStation + "8,";
				}
				if ((bool)sortieStation9_input.IsChecked)
				{
					tempStation = tempStation + "9,";
				}
				if ((bool)sortieStation10_input.IsChecked)
				{
					tempStation = tempStation + "10,";
				}

				// If string is empty then return an empty string (to avoid tempStation.Length - 1 returning a negative number)
				if (String.IsNullOrEmpty(tempStation))
				{
					return String.Empty;
				}

				// Replace last comma with a colon and add mission header dash
				return "CS," + tempStation.Remove(tempStation.Length - 1) + ":" + tempDash;
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'RecordedStations' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
				return String.Empty;
			}
		}

		/// <summary>
		/// Function update the socrepRow counts when the select_input Checkbox is checked
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void Select_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'Select_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to select all aircraft if selectAll_input CheckBox is checked
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SelectAll_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (DataRow socrepRow in socrepDT.Rows)
				{
					socrepRow["Selected"] = selectAll_input.IsChecked;
				}

				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SelectAll_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to remove the focus from a cell to allow for functional drag selection
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SOCREPDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			try
			{
				DataGrid? datagrid = sender as DataGrid;
				datagrid.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SOCREPDataGrid_CurrentCellChanged' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to allow for multi socrepRow selection in the datagrid
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SOCREPDataGridContextSelect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (DataRowView socrepRow in socrepDG.SelectedItems)
				{
					socrepRow[1] = true;
				}

				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SOCREPDataGridContextSelect_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to allow for multi socrepRow selection in the datagrid
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SOCREPDataGridContextUnselect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (DataRowView socrepRow in socrepDG.SelectedItems)
				{
					socrepRow[1] = false;
				}

				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SOCREPDataGridContextUnselect_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function for the socrepExport_button to call the ExportSOCREP function
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SOCREPExport_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string tempFields = EmptyFields();

				// Check if datatable is empty
				if (socrepDT.Rows.Count == 0)
				{
					MessageBox.Show(Application.Current.MainWindow, "No aircraft to export.", "ERROR");
				}
				// If no aircraft are selected then throw error
				else if (UpdateRowCount() == 0)
				{
					MessageBox.Show(Application.Current.MainWindow, "There are no selected aircraft to export.", "ERROR");
				}
				// Check if all necessary fields have been filled in
				else if (!String.IsNullOrEmpty(tempFields))
				{
					MessageBox.Show(Application.Current.MainWindow, "Please fill out or modify the following fields:" + tempFields, "ERROR");
				}
				else
				{
					ExportSOCREP();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SOCREPExport_Click' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to clear all needed fields after submitting a sortie
		/// </summary>
		/// <returns>None (Void)</returns>
		private void SortieClearFields()
		{
			try
			{
				// Empty all fields
				sortieMissionIDTime_input.Text = String.Empty;
				sortieStartTime_input.Text = String.Empty;
				sortieEndTime_input.Text = String.Empty;
				sortieProject_input.Text = String.Empty;
				sortieNumCD_input.Text = String.Empty;
				sortieStationM_input.IsChecked = false;
				sortieStation2_input.IsChecked = false;
				sortieStation3_input.IsChecked = false;
				sortieStation4_input.IsChecked = false;
				sortieStation5_input.IsChecked = false;
				sortieStation6_input.IsChecked = false;
				sortieStation7_input.IsChecked = false;
				sortieStation8_input.IsChecked = false;
				sortieStation9_input.IsChecked = false;
				sortieStation10_input.IsChecked = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SortieClearFields' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to set the text in sortieMissionIDJulian_input when the sortieDate_input textbox is loaded
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any routed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SortieDate_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				GenerateJulianDate();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SortieDate_Loaded' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to set the text in sortieMissionIDJulian_input when the selection in sortieDate_input is changed
		/// </summary>
		/// <param name="sender">Object that sent the action</param>
		/// <param name="e">Any selection changed event args sent by sender</param>
		/// <returns>None (Void)</returns>
		private void SortieDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				GenerateJulianDate();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'SortieDate_SelectedDateChanged' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to unselect all entries after an export
		/// </summary>
		/// <returns>None (Void)</returns>
		private void UnselectAll()
		{
			try
			{
				foreach (DataRow socrepRow in socrepDT.Rows)
				{
					socrepRow["Selected"] = false;
				}

				selectAll_input.IsChecked = false;
				UpdateRowCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'UnselectAll' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
			}
		}

		/// <summary>
		/// Function to update the socrepRow count in the status bar
		/// </summary>
		/// <returns>None (Void)</returns>
		private int UpdateRowCount()
		{
			try
			{
				// Set up temp variables
				int tempLow = 0;
				int tempHigh = 0;

				foreach (DataRow socrepRow in socrepDT.Rows)
				{
					// Check to make sure socrepRow is selected
					if ((bool)socrepRow["Selected"] && !((string)socrepRow["ACType"]).ToUpper().Contains("MALD"))
					{
						// Check to make sure socrepRow isn't marked to be deleted and check if LAA
						if (!socrepRow.RowState.Equals(DataRowState.Deleted) && (bool)socrepRow["LowActSelect"])
						{
							tempLow = tempLow + 1;
						}
						else
						{
							tempHigh = tempHigh + 1;
						}
					}
				}

				// Set socrepRow labels and return socrepRow count
				rowCountLAA_label.Content = tempLow;
				rowCountHAA_label.Content = tempHigh;
				rowCount_label.Content = tempHigh + tempLow;
				return (int)rowCount_label.Content;
			}
			catch (Exception ex)
			{
				MessageBox.Show(Application.Current.MainWindow, "There was a failure in the 'UpdateRowCount' function. Restart the application and try again or contact your system administrator if the problem persists.", "ERROR");
				MessageBox.Show(Application.Current.MainWindow, ex.ToString());
				return 0;
			}
		}
	}
}