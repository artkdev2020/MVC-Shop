using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace OnlineShop.Helpers
{
    public static class IndexCarouselHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html,
            IEnumerable<OnlineShop.Models.Product> products,
            IEnumerable<OnlineShop.Models.ProductImage> productImage)
        {
            //            < div class="owl-card owl-card_size mr">
            //    <div class="owl-card__icon scale">
            //        <img />
            //    </div>
            //    <div class="owl-card__body">
            //        <div class="owl-card__title"></div>
            //        <div class="owl-card__row">
            //            <div class="owl-card__price"></div>
            //            <div class="owl-card__sale"></div>
            //            <div class="owl-card__favorites-logo">
            //                <a><img src = "~/img/icons/heart.svg" /></ a >
            //            </ div >
            //        </ div >
            //    </ div >
            //</ div >


            string result = "";
            foreach (var item in products)
            {
                result += "<div class=\"owl-card owl-card_size mr\"" +
                    "<div class=\"owl-card__icon scale\">" +
                    "<img src=\"~/img/index/bottom_carousel/45d4292e760fc0a5b69da14a9dfd05d2.jpg\"/>" +
                    "</div>" +
                    "<div class=\"owl-card__body\">" +
                    $"<div class=\"owl-card__title\">{item.Name}</div>" +
                    "<div class=\"owl-card__row\">" +
                    $"<div class=\"owl-card__price\">{item.Price}</div>" +
                    $"<div class=\"owl-card__sale\">{getDiscount(item.Discount, item.Price)}</div>" +
                    "<div class=\"owl-card__favorites - logo\">" +
                    "<a><img src = \"~/img/icons/heart.svg\"/></a>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>";
            }
            return new HtmlString(result);
        }

        private static decimal getDiscount(double disc, decimal price)
        {
            if (disc > 0)
            {
                return price - (decimal)(disc / 100);
            }
            return price;
        }
    }
}
