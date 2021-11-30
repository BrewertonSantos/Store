﻿using System;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Test.Entities;

[TestClass]
public class OrderTests
{
    private readonly Customer _customer = new("Brewerton Santos","mail@mail.com");
    private readonly Product _product = new Product("Mochila", 10, true);
    private readonly Discount _discount = new(10, DateTime.Now.AddDays(10));
    
    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_Generate8DigitsNumber()
    {
        Order order = new(_customer, 10, _discount);
        Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_WaitingPayment()
    {
        Order order = new(_customer, 10, _discount);
        Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValidNewOrder_WaitingDelivery()
    {
        Order order = new(_customer, 10, _discount);
        order.AddItem(_product, 2);
        
        order.Pay(20);
        
        Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
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