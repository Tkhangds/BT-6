using Animal_Management.Bussiness_Layer;
using Animal_Management.Data_Layer;
using Animal_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal_Management
{
	public partial class Animal : Form
	{
		private AnimalService animalService = new AnimalService();

		List<AnimalModel> animalModels = new List<AnimalModel>();

		public Animal()
		{
			InitializeComponent();
		}

		public int sumOfMilk(int quantity, int maximumMilk)
		{
			Random random = new Random();
			int sum = 0;

			for (int i = 0; i < quantity; i++)
			{
				int randomNumber = random.Next(0, maximumMilk + 1);
				sum += randomNumber;
			}

			return sum;
		}

		public int sumOfCub(int quantity)
		{
			Random random = new Random();
			int sum = 0;

			for (int i = 0; i < quantity; i++)
			{
				int randomNumber = random.Next(0, 2 + 1);
				sum += randomNumber;
			}

			return sum;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Save();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			textBox1.Text = string.Empty;

			string a = "";
			string result = "";
			for (int i = 0; i < animalModels.Count; i++)
			{
				a = animalModels[i].speak + " ";
				result = result + string.Concat(Enumerable.Repeat(a, animalModels[i].quantity));
			}

			textBox1.Text = result;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			animalService.UpdateAnimalQuantity("BO", (int)slBo.Value);
			animalService.UpdateAnimalQuantity("CUU", (int)slCuu.Value);
			animalService.UpdateAnimalQuantity("DE", (int)slDe.Value);

			animalModels = animalService.GetAnimalModels();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			animalService.UpdateAnimalQuantity("BO", 0);
			animalService.UpdateAnimalQuantity("CUU", 0);
			animalService.UpdateAnimalQuantity("DE", 0);

			slBo.Value = 0;
			slCuu.Value = 0;
			slDe.Value = 0;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			numericUpDown1.Value = numericUpDown1.Value + sumOfMilk(animalModels[0].quantity, animalModels[0].maximumMilkGiven) + sumOfMilk(animalModels[1].quantity, animalModels[1].maximumMilkGiven) + sumOfMilk(animalModels[2].quantity, animalModels[2].maximumMilkGiven);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int num = animalModels.Where(x => x.name == "BO").First().quantity;
			animalService.UpdateAnimalQuantity("BO",num + sumOfCub(num));
			
			num = animalModels.Where(x => x.name == "DE").First().quantity;
			animalService.UpdateAnimalQuantity("DE", num + sumOfCub(num));

			num = animalModels.Where(x => x.name == "CUU").First().quantity;
			animalService.UpdateAnimalQuantity("CUU", num + sumOfCub(num));

			Save();
		}

		private void Save()
		{
			animalModels = animalService.GetAnimalModels();

			slBo.Value = animalModels.Where(obj => obj.name == "BO").First().quantity;
			slDe.Value = animalModels.Where(obj => obj.name == "DE").First().quantity;
			slCuu.Value = animalModels.Where(obj => obj.name == "CUU").First().quantity;
		}
	}
}
