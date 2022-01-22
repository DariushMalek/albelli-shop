﻿using Albelli.Shop.Model.Entities;
using Albelli.Shop.Model.Requests;
using Albelli.Shop.Model.Response;

namespace Albelli.Shop.Model.Mapper;

public  class OrderMapper
{
    public IEnumerable<Order> Convert(IEnumerable<RequestOrder> orderResponseModel)
    {
        return orderResponseModel.Select(Convert);
    }

    public Order Convert(RequestOrder orderRequestModel)
    {
        var orderModel = new Order
        {
            OrderId = orderRequestModel.OrderId,
            CustomerId = orderRequestModel.CustomerId,
            RequiredBinWidthInMillimeters = orderRequestModel.RequiredBinWidthInMillimeters,
            Lines = orderRequestModel.Lines.Select(n => new OrderLine()
                {
                    ProductId = n.ProductId,
                    Quantity = n.Quantity
                }
            ).ToList()
        };
        return orderModel;
    }

    public IEnumerable<ResponseOrder> Convert(IEnumerable<Order> orderResponseModel)
    {
        return orderResponseModel.Select(Convert);
    }

    public ResponseOrder Convert(Order orderModel)
    {
        var orderResponseModel = new ResponseOrder
        {
            OrderId = orderModel.OrderId,
            CustomerId = orderModel.CustomerId,
            RequiredBinWidthInMillimeters = orderModel.RequiredBinWidthInMillimeters,
            Lines = orderModel.Lines.Select(n => new ResponseOrderLine()
                {
                    ProductId = n.ProductId,
                    Quantity = n.Quantity
                }
            ).ToList()
        };
        return orderResponseModel;
    }
}