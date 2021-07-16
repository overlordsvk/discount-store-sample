using DiscountStoreReact.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cart.UnitTests
{
    [TestFixture]
    public class CartServiceTest
    {
        private CartService _cartService;

        [SetUp]
        public void Setup()
        {
            _cartService = new CartService();
        }

        [Test]
        public void GetList_EmptyCart_ReturnsEmptyList()
        {
            var list = _cartService.GetList();

            Assert.IsNotNull(list);
            Assert.IsInstanceOf(typeof(List<Item>), list);
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void GetList_EmptyCartAfterAddAndRemove_ReturnsEmptyList()
        {
            var item = new Item("Vase", 1.2m);
            _cartService.Add(item);
            _cartService.Remove(item.Id);

            var list = _cartService.GetList();

            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void GetTotal_EmptyCart_ReturnsZero()
        {
            var price = _cartService.GetTotal();

            Assert.AreEqual(0, price);
        }

        [Test]
        public void GetList_CartWithOneItem_ReturnsListItem()
        {
            var item = new Item("Vase", 1.2m);
            _cartService.Add(item);

            var list = _cartService.GetList();

            Assert.AreEqual(1, list.Count);
            Assert.Contains(item, list);
        }

        [Test]
        public void GetList_CartWithMultipleItems_ItemCount()
        {
            var item = new Item("Vase", 1.2m);
            _cartService.Add(item);
            _cartService.Add(item);
            _cartService.Add(item);

            var list = _cartService.GetList();

            Assert.AreEqual(3, list.Find(x => x.Id == item.Id).Count);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void GetList_CartWithMultipleItemsAndRemoval_ItemCount()
        {
            var item = new Item("Vase", 1.2m);
            _cartService.Add(item);
            _cartService.Add(item);
            _cartService.Remove(item.Id);
            _cartService.Add(item);
            _cartService.Add(item);

            var list = _cartService.GetList();

            Assert.AreEqual(3, list.Find(x => x.Id == item.Id).Count);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void GetTotal_CartWithoutDiscounts_Price()
        {
            var item = new Item("Vase", 1.2m);
            _cartService.Add(item);
            _cartService.Add(item);
            _cartService.Add(item);

            var price = _cartService.GetTotal();

            Assert.AreEqual(item.Price * 3, price);
        }

        [Test]
        public void GetTotal_CartWithDiscounts_Price()
        {
            var mug = new Item("Big mug", 1, new Discount("2 for 1.5€", 0.25m, 2));
            _cartService.Add(mug);
            _cartService.Add(mug);

            var price = _cartService.GetTotal();
            var expected = mug.Price * 2 * (1 - mug.Discount.DiscountPercentage);
            Assert.AreEqual(expected, price);
        }

        [Test]
        public void GetTotal_CartWithMixedDiscounts_Price()
        {
            var vase = new Item("Vase", 1.2m);
            var mug = new Item("Big mug", 1, new Discount("2 for 1.5€", 0.25m, 2));
            _cartService.Add(vase);
            _cartService.Add(mug);
            _cartService.Add(mug);
            _cartService.Add(vase);
            _cartService.Add(mug);

            var price = _cartService.GetTotal();
            var expected = (vase.Price * 2) + (mug.Price * 2 * (1 - mug.Discount.DiscountPercentage)) + mug.Price;
            Assert.AreEqual(expected, price);
        }
    }
}
