using CurrencyProject;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMVCWeapon.ViewModels
{
    public class RepoViewModel
    {
        ICurrencyRepo repo;
        public List<SelectListItem> LocalizationSelectList;

        public RepoViewModel(ICurrencyRepo _repo) 
        {
            this.repo = _repo;
            LocalizationSelectList = new List<SelectListItem>()
            {
                new SelectListItem("US", "0"),
                new SelectListItem("MX", "1")
            };
        }

        public double TotalValue
        {
            get { return repo.TotalValue(); }
        }

        public void MakeChange(Double Amount)
        {
            repo = repo.MakeChange(Amount);
        }

        public List<ICurrency> Coins
        {
            get { return repo.Coins; }
        }

        public List<ICurrency> BankNotes
        { 
            get { return repo.BankNotes; }
        }
    }
}
