using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_10_1_Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
				textBox1.Text = "";
				string path = @"C:\tempForms";
				Directory.CreateDirectory(path + @"\k1");
				textBox1.Text += "Папка k1 создана\r\n";

				Directory.CreateDirectory(path + @"\k2");
				textBox1.Text += "Папка k2 создана\r\n";

				File.Create(path + @"\k1\t1.txt").Close();
				textBox1.Text += "Файл t1 был создан\r\n";
				string text1 = "Моисеев Дмтрий Алексеевич, 2004 года рождения, место жительства г. Кольчугино\n";
				File.WriteAllText(path + @"\k1\t1.txt", text1);

				File.Create(path + @"\k1\t2.txt").Close();
				textBox1.Text = "Файл t2 был создан\r\n";
				string text2 = "Моисеева Ольга Владимировна, 1984 года рождения, место жительства г. Кольчугино\n";
				File.WriteAllText(path + @"\k1\t2.txt", text2);

				File.Create(path + @"\k2\t3.txt").Close();
				textBox1.Text += "Файл t3 был создан\r\n";

				File.WriteAllText(path + @"\k2\t3.txt", File.ReadAllText(path + @"\k1\t1.txt"));
				File.AppendAllText(path + @"\k2\t3.txt", File.ReadAllText(path + @"\k1\t2.txt"));

				FileInfo file1 = new FileInfo(path + @"\k1\t1.txt");
				FileInfo file2 = new FileInfo(path + @"\k1\t2.txt");
				FileInfo file3 = new FileInfo(path + @"\k2\t3.txt");

				textBox1.Text += "\r\nРазвернутая информация о файлах\r\n";
				textBox1.Text += String.Format("Первый файл\r\nИмя файла: {0}, Размер файла: {1}, Время создания файла: {2}\r\n\r\n", file1.Name, file1.Length, file1.CreationTime);
				textBox1.Text += String.Format("Второй файл\r\nИмя файла: {0}, Размер файла: {1}, Время создания файла: {2}\r\n\r\n", file2.Name, file2.Length, file2.CreationTime);
				textBox1.Text += String.Format("третий файл\r\nИмя файла: {0}, Размер файла: {1}, Время создания файла: {2}\r\n\r\n", file3.Name, file3.Length, file3.CreationTime);

				file2.MoveTo(path + @"\k2\t2.txt");
				textBox1.Text += "Файл t2 был перемещен в папку k2\r\n";
				file1.CopyTo(path + @"\k2\t1.txt");
				textBox1.Text += "Файл t1 был копирован в папку k2\r\n";

				Directory.Move(path + @"\k2", path + @"\ALL");
				textBox1.Text += "Папка k2 была переименованна в ALL\r\n";

				File.Delete(path + @"\k1\t1.txt");
				Directory.Delete(path + @"\k1");
				textBox1.Text += "Файл t1 папка и k1 были успешно удалены\r\n";

				DirectoryInfo directoryAll = new DirectoryInfo(path + @"\ALL");
				FileInfo[] filesInfo = directoryAll.GetFiles();

				foreach (FileInfo file in filesInfo)
				{
					textBox1.Text += String.Format("\r\nИмя файла: {0}\r\nРазмер файла: {1}\r\nВремя создания файла: {2}\r\n", file.Name, file.Length, file.CreationTime);
				}
			catch
			{
				textBox1.Text = "Что-то пошло не так...";
			}
		}
	}
}
