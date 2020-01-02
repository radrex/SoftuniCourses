namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Services;
    using Web.Models.Pet;
    using Services.Models.Pet;

    public class PetsController : Controller
    {
        //---------------- Fields -----------------
        private readonly IPetService pets;

        //------------- Constructors --------------
        public PetsController(IPetService pets)
        {
            this.pets = pets;
        }

        //--------------- Methods -----------------
        public IActionResult All(int page = 1)
        {
            var pets = this.pets.All(page);
            int totalPets = this.pets.Total();

            AllPetsViewModel model = new AllPetsViewModel
            {
                Pets = pets,
                Total = totalPets,
                CurrentPage = page,
            };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var pet = this.pets.Details(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public IActionResult ConfirmDelete(int id)
        {
            bool deleted = this.pets.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
        //public IEnumerable<PetListingServiceModel> All() => this.pets.All();

        //public IEnumerable<PetListingResponseModel> All()
        //{
        //    return new List<PetListingResponseModel>
        //    {
        //        new PetListingResponseModel
        //        {
        //            Id = 5,
        //            Name = "Ivan",
        //            Breed = "Kokoshka",
        //            Price = 10,
        //        },

        //        new PetListingResponseModel
        //        {
        //            Id = 5,
        //            Name = "Pesho",
        //            Breed = "Kokoshka",
        //            Price = 15b,
        //        },
        //    };
        //}
    }
}
