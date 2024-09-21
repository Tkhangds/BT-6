using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using Animal_Management.Model;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Animal_Management.Data_Layer
{
	internal class AnimalRepo
	{
		private string connectionString;
		
		public AnimalRepo()
		{
			connectionString = ConfigurationManager.ConnectionStrings["AnimalManagementDbConnectionString"].ConnectionString;
		}

		public List<AnimalModel> GetAnimals() {
			List<AnimalModel> animalModelList = new List<AnimalModel>();

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string query = "SELECT * FROM ANIMAL";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						AnimalModel animal = new AnimalModel()
						{	
							id = (int)reader["ID"],
							name = reader["NAME"].ToString(),
							quantity = (int)reader["QUANTITY"],
							maximumMilkGiven = (int)reader["MAXIMUM_MILK_GIVEN"],
							speak = reader["SPEAK"].ToString()
						};

						animalModelList.Add(animal);
					}
				}
			}

			return animalModelList;
		}

		public void UpdateQuantity(string name,int quantity)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string query = "UPDATE ANIMAL SET QUANTITY = @Quantity where NAME = @Name";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@Name", name);
					cmd.Parameters.AddWithValue("@Quantity", quantity);
					cmd.ExecuteNonQuery();
				}
			}

		}
	}
}
