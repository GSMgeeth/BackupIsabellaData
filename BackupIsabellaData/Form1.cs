﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using _Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace BackupIsabellaData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Workbook|*.xlsx";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string name = openFileDialog1.SafeFileName;

                if (name.Contains(".xlsx"))
                {
                    _Application excel = new _Excel.Application();
                    Workbook wb;
                    Worksheet ws;

                    string path = "C:/Users/Geeth Sandaru/Downloads/" + name;

                    wb = excel.Workbooks.Open(path);
                    ws = wb.Worksheets[3];

                    //string deptTmp = ws.Cells[2, 1].Value2;

                    int deptNo = 2;

                    string text = ws.Cells[2, 1].Value2.ToString();

                    DataTextBox.Text = text + "\n";

                    string year = "", month = "", day = "", date = "";

                    int x = 7;
                    int y = 6;

                    while (x < 483)
                    {
                        if (ws.Cells[x, 1].Value2 != null)
                        {
                            string tmp = ws.Cells[x, 1].Value2.ToString();

                            if (!tmp.Equals(date))
                            {
                                date = tmp;

                                year = date.Substring(0, 4);
                                month = date.Substring(5, 2);
                                day = date.Substring(8, 2);
                                
                                double bagNo = ws.Cells[x, 2].Value2;
                                double totalQty = ws.Cells[x, 4].Value2;

                                DataTextBox.AppendText(year + "/" + month + "/" + day + " - " + bagNo + " - " + totalQty + "\n");

                                while (y < 1610)
                                {
                                    if (ws.Cells[x, y].Value2 != null)
                                    {
                                        double qty = ws.Cells[x, y].Value2;
                                        string size = ws.Cells[4, y].Value2.ToString();
                                        string color = ws.Cells[3, y].Value2.ToString();

                                        string article = "";
                                        int tmpY = y;

                                        do
                                        {
                                            try
                                            {
                                                article = ws.Cells[2, tmpY].Value2.ToString();
                                            }
                                            catch (Exception)
                                            {
                                                article = "exc";
                                                tmpY--;
                                            }

                                        } while (article.Equals("exc"));
                                        
                                        DataTextBox.AppendText("    " + size + " - " + color + " - " + article + " -- " + qty + "\n");
                                        //DataTextBox.AppendText("    " + size + " - " + color + " -- " + qty + "\n");
                                    }
                                    
                                    y++;
                                }

                                y = 6;
                            }
                            else
                            {
                                double bagNo = ws.Cells[x, 2].Value2;
                                double totalQty = ws.Cells[x, 4].Value2;

                                DataTextBox.AppendText("same" + " - " + bagNo + " - " + totalQty + "\n");

                                while (y < 1610)
                                {
                                    if (ws.Cells[x, y].Value2 != null)
                                    {
                                        double qty = ws.Cells[x, y].Value2;
                                        string size = ws.Cells[4, y].Value2.ToString();
                                        string color = ws.Cells[3, y].Value2.ToString();

                                        string article = "";
                                        int tmpY = y;

                                        do
                                        {
                                            try
                                            {
                                                article = ws.Cells[2, tmpY].Value2.ToString();
                                            }
                                            catch (Exception)
                                            {
                                                article = "exc";
                                                tmpY--;
                                            }

                                        } while (article.Equals("exc"));

                                        DataTextBox.AppendText("    " + size + " - " + color + " - " + article + " -- " + qty + "\n");
                                        //DataTextBox.AppendText("    " + size + " - " + color + " -- " + qty + "\n");
                                    }

                                    y++;
                                }

                                y = 6;
                            }
                        }

                        x++;
                    }

                    //MySqlDataReader readerDept = DBConnection.getData("select * from department where deptName='" + deptTmp + "'");
                    /*
                    if (/*readerDept.HasRows true)
                    {
                        string date = ws.Cells[7, 1].Value2.ToString();
                        double totalQty = ws.Cells[7, 4].Value2;
                        double dayBagNo = ws.Cells[7, 2].Value2;

                        string day = date.Substring(1, date.IndexOf('/') - 1);
                        string tmpMonth = date.Substring(date.IndexOf('/') + 1);
                        string month = tmpMonth.Substring(0, tmpMonth.IndexOf('/'));
                        string year = tmpMonth.Substring((tmpMonth.IndexOf('/') + 1), 4);

                        DateTime d = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                        int q = (int)totalQty;
                        int bNo = (int)dayBagNo;
                        Department dept = new Department((int)deptNo);

                        Bag bag = new Bag(d, q, dept, bNo);

                        if (/*Database.isBagExists(bag) false)
                        {
                            MessageBox.Show("Bag already exists!", "File reader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataTextBox.Text = "Bag deptNo : " + deptNo + "\nBag sent date : " + date + "\nQuantity : " + totalQty + "\nBagNo : " + dayBagNo + "\n";
                            DataTextBox.AppendText("\nyear : " + year + "  " + d.Year);
                            DataTextBox.AppendText("\nmonth : " + month + "  " + d.Month);
                            DataTextBox.AppendText("\nday : " + day + "  " + d.Day + "\n\n");

                            for (int i = 0; i < (int)totalQty; i++)
                            {
                                string color = ws.Cells[(i + 5), 1].Value2;
                                string size = ws.Cells[(i + 5), 2].Value2;
                                string article = ws.Cells[(i + 5), 3].Value2;

                                string tmp = "\nItem " + (i + 1) + " : " + color + " " + size + " " + article;

                                DataTextBox.AppendText(tmp);

                                bag.addItem(i, color, size, article);
                            }

                            try
                            {
                                MySqlDataReader reader = DBConnection.getData("select * from department");

                                while (reader.Read())
                                {
                                    int dNo = reader.GetInt32("deptNo");
                                    string deptName = reader.GetString("deptName");

                                    string tmp2 = "\nDept : " + dNo + " " + deptName;

                                    DataTextBox.AppendText(tmp2);
                                }

                                reader.Close();

                                Database.saveBag(bag);
                            }
                            catch (Exception exc)
                            {
                                DataTextBox.AppendText("\n" + exc.Message);
                                DataTextBox.AppendText("\n\n" + exc.StackTrace);
                            }
                            finally
                            {
                                wb.Close();
                                excel.Quit();

                                Marshal.ReleaseComObject(wb);
                                Marshal.ReleaseComObject(excel);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Department name in the Excel file!", "File reader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something wrong with the excel file!\n" + exception.StackTrace, "File reader", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
