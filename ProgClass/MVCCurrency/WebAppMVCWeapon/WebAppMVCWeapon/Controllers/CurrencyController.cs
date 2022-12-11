using Currency.Mexico;
using Currency.US;
using CurrencyProject;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCWeapon.ViewModels;

namespace WebAppMVCWeapon.Controllers
{
    public class CurrencyController : Controller
    {
        ICurrencyRepo repo { get; set; }
        RepoViewModel vm { get; set; }

        public CurrencyController() 
        {
            
        }

        //ISSUE
        public ActionResult Index(int Locale)
        {
            switch (Locale)
            {
                case 0:
                    repo = new USCurrencyRepo();
                    repo.AddCoin(new Quarter());
                    repo.AddCoin(new Quarter());
                    
                    //MakeChangeForMoney(Locale); 

                    break;
                case 1:
                    repo = new MXCurrencyRepo();
                    repo.AddCoin(new FiveCentCoin());
                    repo.AddBankNote(new OneHundredPesosBankNote());
                    
                    //MakeChangeForMoney(Locale);
                    
                    break;
            }
           
            vm = new RepoViewModel(repo);

            return View(vm);
        }

        //ISSUE: Pressing the bottom gets stuck in load, even though it goes through
        public ActionResult MakeChangeForMoney(int Locale, double Amount)
        {
           

            switch (Locale)
            {
                case 0:
                    repo = new USCurrencyRepo();

                    //repo.AddCoin(new Quarter());
                    //repo.AddCoin(new Quarter());
                   
                    repo.MakeChange(Amount);

                    break;
                case 1:
                    repo = new MXCurrencyRepo();
                    //repo.AddCoin(new FiveCentCoin());
                    //repo.AddBankNote(new OneHundredPesosBankNote());
                    
                    repo.MakeChange(Amount);
                    
                    
                    break;
            }

            vm = new RepoViewModel(repo);

            return View(vm);
        }
    }
}
