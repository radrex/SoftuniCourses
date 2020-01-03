namespace PetStore.Web.Models.Pet
{
    using Services.Models.Pet;
    using System;
    using System.Collections.Generic;

    public class AllPetsViewModel
    {
        public IEnumerable<PetListingServiceModel> Pets { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public int PreviousPage => this.CurrentPage - 1;
        public int NextPage => this.CurrentPage + 1;
        public bool PreviousDisabled => this.CurrentPage == 1;
        public bool NextDisabled
        {
            get
            {
                double maxPage = Math.Ceiling(((double)this.Total) / 25);
                return maxPage == this.CurrentPage;
            }
        }
    }
}
