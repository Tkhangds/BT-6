using Animal_Management.Data_Layer;
using Animal_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Management.Bussiness_Layer
{
	internal class AnimalService
	{
		AnimalRepo animalRepo = new AnimalRepo();

		public List<AnimalModel> GetAnimalModels() { 
			return animalRepo.GetAnimals();
		}

		public void UpdateAnimalQuantity(string name, int quantity)
		{
			animalRepo.UpdateQuantity(name, quantity);		
		}

	}
}
