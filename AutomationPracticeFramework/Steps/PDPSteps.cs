using AutomationPracticeFramework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Pages
{
    [Binding]
    public class PDPSteps : Base
    {
        HomePage hp = new HomePage(Driver);
        Utilities ut = new Utilities(Driver);

        private readonly ProductData productData;

        public PDPSteps(ProductData productData)
        {
            this.productData = productData;
        }

        [Given(@"user open '(.*)' section")]
        public void GivenUserOpenSection(string category)
        {
            hp.ReturnCategoryList(category)[1].Click();
        }
        
        [Given(@"opens first product from the list")]
        public void GivenOpensFirstProductFromTheList()
        {
            PLPPage plp = new PLPPage(Driver);
            ut.ClickOnElement(plp.firstProduct);
        }
        
        [Given(@"increases quantity to '(.*)'")]
        public void GivenIncreasesQuantityTo(string qty)
        {
            By iframe = By.ClassName("fancybox-iframe");
            Driver.SwitchTo().Frame(Driver.FindElement(iframe));
            PDPPage pdp = new PDPPage(Driver);
            ut.ClearInputField(pdp.quantity);
            ut.EnterTextInElement(pdp.quantity, qty);
            productData.ProductName = ut.ReturnTextFromElement(pdp.productName);
        }
        
        [When(@"user clicks on add to cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            PDPPage pdp = new PDPPage(Driver);
            ut.ClickOnElement(pdp.addToCard);
        }
        
        [When(@"user proceeds to checkout")]
        public void WhenUserProceedsToCheckout()
        {
            CartPage cp = new CartPage(Driver);
            ut.ClickOnElement(cp.proceedToCheckout);
        }
        
        [Then(@"cart is opened and product is added to cart")]
        public void ThenCartIsOpenedAndProductIsAddedToCart()
        {
            CheckoutPage cp = new CheckoutPage(Driver);
            Assert.That(ut.ReturnTextFromElement(cp.checkoutProduct), Is.EqualTo(productData.ProductName), "Product is not added to cart");
        }
    }
}
