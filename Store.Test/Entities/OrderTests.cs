using System;
using Store.Domain.Entities;

namespace Store.Test.Entities;

[TestClass]
public class OrderTests
{
    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_Generate8DigitsNumber()
    {
        Customer customer = new("Brewerton Santos","mail@mail.com");
        Discount discount = new(10, DateTime.Now.AddDays(10));
        Order order = new(customer, 10, discount);
        Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_WaitingPayment()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_WaitingDelivery()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_Canceled()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrderWithoutProduct_DontAdd()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrderWithAmountEqualsOrMinorZero_DontAdd()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_TotalEquals50()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsExpiredDiscount_OrderValueEquals60()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsInvalidRequest_OrderValueEquals60()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsDiscount10_OrderValueEquals50()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsDeliveryFee10_OrderValueEquals60()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsOrderWithoutClient_Invalid()
    {
        Assert.Fail();
    }
}