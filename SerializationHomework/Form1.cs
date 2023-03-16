using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;  //Binary serialization
using System.Runtime.Serialization.Formatters.Soap;  //SOAP serialization
using System.Xml.Serialization;                        //XML serialization
using System.Text.Json;                                //JSON serialization
using System.Windows.Forms;
using System.Linq.Expressions;

namespace SerializationHomework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\empBinary.dat", FileMode.Create, FileAccess.Write);
                Empolyee emp = new Empolyee();
                emp.Id = Convert.ToInt32(txtEmpolyeeId.Text);
                emp.Name = txtEmpolyeeName.Text;
                emp.Location = txtLocation.Text;
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, emp);
                MessageBox.Show("Data Saved");
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {

            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\empBinary.dat", FileMode.Open, FileAccess.Read);
                Empolyee emp = new Empolyee();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                emp = (Empolyee)binaryFormatter.Deserialize(fs);
                txtEmpolyeeId.Text = emp.Id.ToString();
                txtEmpolyeeName.Text = emp.Name;
                txtLocation.Text = emp.Location;
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {

            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\empxml.xml", FileMode.Create, FileAccess.Write);
                Empolyee emp = new Empolyee();
                emp.Id = Convert.ToInt32(txtEmpolyeeId.Text);
                emp.Name = txtEmpolyeeName.Text;
                emp.Location = txtLocation.Text;
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Empolyee));
                xmlserializer.Serialize(fs, emp);
                MessageBox.Show("Data Saved");
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\empxml.xml", FileMode.Open, FileAccess.Read);
                Empolyee emp = new Empolyee();
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Empolyee));
                emp = (Empolyee)xmlserializer.Deserialize(fs);
                txtEmpolyeeId.Text = emp.Id.ToString();
                txtEmpolyeeName.Text = emp.Name;
                txtLocation.Text = emp.Location;
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\empSoap.soap", FileMode.Create, FileAccess.Write);
                Empolyee emp = new Empolyee();
                emp.Id = Convert.ToInt32(txtEmpolyeeId.Text);
                emp.Name = txtEmpolyeeName.Text;
                emp.Location = txtLocation.Text;
                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, emp);
                MessageBox.Show("Data Saved");
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\empSoap.soap", FileMode.Open, FileAccess.Read);
                Empolyee emp = new Empolyee();
                SoapFormatter soapFormatter = new SoapFormatter();
                emp = (Empolyee)soapFormatter.Deserialize(fs);
                txtEmpolyeeId.Text = emp.Id.ToString();
                txtEmpolyeeName.Text = emp.Name;
                txtLocation.Text = emp.Location;
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\DotNet20DecBatch\deptJson.json", FileMode.Create, FileAccess.Write);
                Empolyee emp = new Empolyee();
                emp.Id = Convert.ToInt32(txtEmpolyeeId.Text);
                emp.Name = txtEmpolyeeName.Text;
                emp.Location = txtLocation.Text;

                JsonSerializer.Serialize<Empolyee>(fs, emp);
                MessageBox.Show("Data Saved");
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {

            try
            {
                FileStream fs = new FileStream(@"D:\DotNet20DecBatch\deptJson.json", FileMode.Open, FileAccess.Read);
                Empolyee emp = new Empolyee();

                emp = JsonSerializer.Deserialize<Empolyee>(fs);
                txtEmpolyeeId.Text = emp.Id.ToString();
                txtEmpolyeeName.Text = emp.Name;
                txtLocation.Text = emp.Location;
                fs.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
