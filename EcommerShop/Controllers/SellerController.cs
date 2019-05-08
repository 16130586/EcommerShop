using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerShop.Models.ModelViews.Seller;
using EcommerShop.Models.ModelBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace EcommerShop.Controllers
{
    public class SellerController : Controller
    {
        private readonly ECommerceStoreContext _dbContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public SellerController(ECommerceStoreContext context,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender)
        {
            _dbContext = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public object DependencyResolver { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IndexModelView inputModal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new IdentityUser { UserName = inputModal.Email, Email = inputModal.Email };
            var result = await _userManager.CreateAsync(user, inputModal.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code = code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(inputModal.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                await _signInManager.SignInAsync(user, isPersistent: false);

                Shop shop = new Shop
                {
                    Name = inputModal.ShopName,
                    TradingCode = inputModal.TradingCode,
                    Address = inputModal.Address,
                    UserId = user.Id

                };
                await _dbContext.AddAsync(shop);
                await _dbContext.SaveChangesAsync();

               

            }
            if(!result.Succeeded)
                ModelState.AddModelError("EmailExisted", "Your email is in use!");
            return View(inputModal);
        }
    }
}